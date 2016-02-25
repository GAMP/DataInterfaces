using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using CoreLib;

namespace SkinInterfaces
{
    public static class GridViewBehavior
    {
        #region Columns binding

        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static object GetColumnsSource(GridView obj)
        {
            return obj.GetValue(ColumnsSourceProperty);
        }
        
        public static void SetColumnsSource(GridView obj, object value)
        {
            obj.SetValue(ColumnsSourceProperty, value);
        }
        
        public static readonly DependencyProperty ColumnsSourceProperty =
            DependencyProperty.RegisterAttached(
                "ColumnsSource",
                typeof(object),
                typeof(GridViewBehavior),
                new UIPropertyMetadata(
                    null,
                    ColumnsSourceChanged));
        
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetHeaderTextMember(GridView obj)
        {
            return (string)obj.GetValue(HeaderTextMemberProperty);
        }
        
        public static void SetHeaderTextMember(GridView obj, string value)
        {
            obj.SetValue(HeaderTextMemberProperty, value);
        }
        
        public static readonly DependencyProperty HeaderTextMemberProperty =
            DependencyProperty.RegisterAttached("HeaderTextMember", typeof(string), typeof(GridViewBehavior), new UIPropertyMetadata(null));
        
        [AttachedPropertyBrowsableForType(typeof(GridView))]
        public static string GetDisplayMemberMember(GridView obj)
        {
            return (string)obj.GetValue(DisplayMemberMemberProperty);
        }
        
        public static void SetDisplayMemberMember(GridView obj, string value)
        {
            obj.SetValue(DisplayMemberMemberProperty, value);
        }
        
        public static readonly DependencyProperty DisplayMemberMemberProperty =
            DependencyProperty.RegisterAttached("DisplayMemberMember", typeof(string), typeof(GridViewBehavior), new UIPropertyMetadata(null));


        private static void ColumnsSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            GridView gridView = obj as GridView;
            if (gridView != null)
            {
                gridView.Columns.Clear();

                if (e.OldValue != null)
                {
                    ICollectionView view = CollectionViewSource.GetDefaultView(e.OldValue);
                    if (view != null)
                        RemoveHandlers(gridView, view);
                }

                if (e.NewValue != null)
                {
                    ICollectionView view = CollectionViewSource.GetDefaultView(e.NewValue);
                    if (view != null)
                    {
                        AddHandlers(gridView, view);
                        CreateColumns(gridView, view);
                    }
                }
            }
        }

        private static readonly IDictionary<ICollectionView, List<GridView>> _gridViewsByColumnsSource =
            new Dictionary<ICollectionView, List<GridView>>();

        private static void AddHandlers(GridView gridView, ICollectionView view)
        {
            _gridViewsByColumnsSource[view].Add(gridView);
            view.CollectionChanged += ColumnsSource_CollectionChanged;
        }

        private static void CreateColumns(GridView gridView, ICollectionView view)
        {
            foreach (var item in view)
            {
                GridViewColumn column = CreateColumn(gridView, item);
                gridView.Columns.Add(column);
            }
        }

        private static void RemoveHandlers(GridView gridView, ICollectionView view)
        {
            view.CollectionChanged -= ColumnsSource_CollectionChanged;
            _gridViewsByColumnsSource[view].Remove(gridView);
        }

        private static void ColumnsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ICollectionView view = (ICollectionView)sender;
            var gridViews = _gridViewsByColumnsSource[view];
            if (gridViews.IsNullOrEmpty())
                return;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var gridView in gridViews)
                    {
                        for (int i = 0; i < e.NewItems.Count; i++)
                        {
                            GridViewColumn column = CreateColumn(gridView, e.NewItems[i]);
                            gridView.Columns.Insert(e.NewStartingIndex + i, column);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    foreach (var gridView in gridViews)
                    {
                        List<GridViewColumn> columns = new List<GridViewColumn>();
                        for (int i = 0; i < e.OldItems.Count; i++)
                        {
                            GridViewColumn column = gridView.Columns[e.OldStartingIndex + i];
                            columns.Add(column);
                        }
                        for (int i = 0; i < e.NewItems.Count; i++)
                        {
                            GridViewColumn column = columns[i];
                            gridView.Columns.Insert(e.NewStartingIndex + i, column);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var gridView in gridViews)
                    {
                        for (int i = 0; i < e.OldItems.Count; i++)
                        {
                            gridView.Columns.RemoveAt(e.OldStartingIndex);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    foreach (var gridView in gridViews)
                    {
                        for (int i = 0; i < e.NewItems.Count; i++)
                        {
                            GridViewColumn column = CreateColumn(gridView, e.NewItems[i]);
                            gridView.Columns[e.NewStartingIndex + i] = column;
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (var gridView in gridViews)
                    {
                        gridView.Columns.Clear();
                        CreateColumns(gridView, sender as ICollectionView);
                    }
                    break;
                default:
                    break;
            }
        }

        private static GridViewColumn CreateColumn(GridView gridView, object columnSource)
        {
            GridViewColumn column = new GridViewColumn();
            string headerTextMember = GetHeaderTextMember(gridView);
            string displayMemberMember = GetDisplayMemberMember(gridView);
            if (!headerTextMember.IsNullOrEmpty())
            {
                column.Header = GetPropertyValue(columnSource, headerTextMember);
            }
            if (!displayMemberMember.IsNullOrEmpty())
            {
                string propertyName = GetPropertyValue(columnSource, displayMemberMember) as string;
                column.DisplayMemberBinding = new Binding(propertyName);
            }
            return column;
        }

        private static object GetPropertyValue(object obj, string propertyName)
        {
            if (obj != null)
            {
                PropertyInfo prop = obj.GetType().GetProperty(propertyName);
                if (prop != null)
                    return prop.GetValue(obj, null);
            }
            return null;
        }

        #endregion

        #region GridView auto sort

        #region Public attached properties
        
        [AttachedPropertyBrowsableForType(typeof(ListView))]
        public static ICommand GetSortCommand(ListView obj)
        {
            return (ICommand)obj.GetValue(SortCommandProperty);
        }
        
        public static void SetSortCommand(ListView obj, ICommand value)
        {
            obj.SetValue(SortCommandProperty, value);
        }
        
        public static readonly DependencyProperty SortCommandProperty =
            DependencyProperty.RegisterAttached(
                "SortCommand",
                typeof(ICommand),
                typeof(GridViewBehavior),
                new UIPropertyMetadata(
                    null,
                    OnSortCommandChanged
                )
            );

        private static void OnSortCommandChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ListView listView = o as ListView;
            if (listView == null)
                return;

            // Don't change click handler if AutoSort enabled
            if (GetAutoSort(listView))
                return;

            if (e.OldValue != null && e.NewValue == null)
            {
                listView.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ColumnHeader_Click));
            }
            if (e.OldValue == null && e.NewValue != null)
            {
                listView.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ColumnHeader_Click));
            }
        }
        
        [AttachedPropertyBrowsableForType(typeof(ListView))]
        public static bool GetAutoSort(ListView obj)
        {
            return (bool)obj.GetValue(AutoSortProperty);
        }
        
        public static void SetAutoSort(ListView obj, bool value)
        {
            obj.SetValue(AutoSortProperty, value);
        }
        
        public static readonly DependencyProperty AutoSortProperty =
            DependencyProperty.RegisterAttached(
                "AutoSort",
                typeof(bool),
                typeof(GridViewBehavior),
                new UIPropertyMetadata(
                    false,
                    OnAutoSortChanged
                )
            );

        private static void OnAutoSortChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ListView listView = o as ListView;
            if (listView == null)
                return;

            // Don't change click handler if a command is set
            if (GetSortCommand(listView) != null)
                return;

            bool oldValue = (bool)e.OldValue;
            bool newValue = (bool)e.NewValue;
            if (oldValue && !newValue)
            {
                listView.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ColumnHeader_Click));
            }
            if (!oldValue && newValue)
            {
                listView.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ColumnHeader_Click));
                listView.DoWhenLoaded(SetGlyphForInitialSort);
            }
        }

        private static void SetGlyphForInitialSort(ListView listView)
        {
            if (!GetAutoSort(listView) || !GetShowSortGlyph(listView))
                return;

            var view = CollectionViewSource.GetDefaultView(listView.Items);
            if (!view.SortDescriptions.Any())
                return;

            var headerRow = listView.FindDescendants<GridViewHeaderRowPresenter>().FirstOrDefault();
            if (headerRow == null)
                return;

            var sort = view.SortDescriptions.First();
            var headers = headerRow.FindDescendants<GridViewColumnHeader>();
            foreach (var header in headers)
            {
                if (header.Column == null)
                    continue;
                string sortPropertyName = GetSortPropertyName(header.Column);
                if (sortPropertyName != sort.PropertyName)
                    continue;

                AddSortGlyph(
                    header,
                    sort.Direction,
                    sort.Direction == ListSortDirection.Ascending ? GetSortGlyphAscending(listView) : GetSortGlyphDescending(listView));
                SetSortedColumnHeader(listView, header);
                break;
            }

        }
        
        [AttachedPropertyBrowsableForType(typeof(GridViewColumn))]
        public static string GetSortPropertyName(GridViewColumn obj)
        {
            return (string)obj.GetValue(SortPropertyNameProperty);
        }
        
        public static void SetSortPropertyName(GridViewColumn obj, string value)
        {
            obj.SetValue(SortPropertyNameProperty, value);
        }
        
        public static readonly DependencyProperty SortPropertyNameProperty =
            DependencyProperty.RegisterAttached(
                "SortPropertyName",
                typeof(string),
                typeof(GridViewBehavior),
                new UIPropertyMetadata(null)
            );
        
        [AttachedPropertyBrowsableForType(typeof(ListView))]
        public static bool GetShowSortGlyph(ListView obj)
        {
            return (bool)obj.GetValue(ShowSortGlyphProperty);
        }
        
        public static void SetShowSortGlyph(ListView obj, bool value)
        {
            obj.SetValue(ShowSortGlyphProperty, value);
        }
        
        public static readonly DependencyProperty ShowSortGlyphProperty =
            DependencyProperty.RegisterAttached("ShowSortGlyph", typeof(bool), typeof(GridViewBehavior), new UIPropertyMetadata(true));
        
        [AttachedPropertyBrowsableForType(typeof(ListView))]
        public static ImageSource GetSortGlyphAscending(ListView obj)
        {
            return (ImageSource)obj.GetValue(SortGlyphAscendingProperty);
        }
        
        public static void SetSortGlyphAscending(ListView obj, ImageSource value)
        {
            obj.SetValue(SortGlyphAscendingProperty, value);
        }
        
        public static readonly DependencyProperty SortGlyphAscendingProperty =
            DependencyProperty.RegisterAttached("SortGlyphAscending", typeof(ImageSource), typeof(GridViewBehavior), new UIPropertyMetadata(null));
        
        [AttachedPropertyBrowsableForType(typeof(ListView))]
        public static ImageSource GetSortGlyphDescending(ListView obj)
        {
            return (ImageSource)obj.GetValue(SortGlyphDescendingProperty);
        }
        
        public static void SetSortGlyphDescending(ListView obj, ImageSource value)
        {
            obj.SetValue(SortGlyphDescendingProperty, value);
        }
        
        public static readonly DependencyProperty SortGlyphDescendingProperty =
            DependencyProperty.RegisterAttached("SortGlyphDescending", typeof(ImageSource), typeof(GridViewBehavior), new UIPropertyMetadata(null));


        #endregion

        #region Private attached properties

        private static GridViewColumnHeader GetSortedColumnHeader(DependencyObject obj)
        {
            return (GridViewColumnHeader)obj.GetValue(_sortedColumnHeaderProperty);
        }

        private static void SetSortedColumnHeader(DependencyObject obj, GridViewColumnHeader value)
        {
            obj.SetValue(_sortedColumnHeaderProperty, value);
        }

        private static readonly DependencyProperty _sortedColumnHeaderProperty =
            DependencyProperty.RegisterAttached("SortedColumnHeader", typeof(GridViewColumnHeader), typeof(GridViewBehavior), new UIPropertyMetadata(null));

        #endregion

        #region Column header click event handler

        private static void ColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked != null && headerClicked.Column != null)
            {
                string propertyName = GetSortPropertyName(headerClicked.Column);
                if (!string.IsNullOrEmpty(propertyName))
                {
                    ListView listView = headerClicked.FindAncestor<ListView>();
                    if (listView != null)
                    {
                        ICommand command = GetSortCommand(listView);
                        if (command != null)
                        {
                            if (command.CanExecute(propertyName))
                            {
                                command.Execute(propertyName);
                            }
                        }
                        else if (GetAutoSort(listView))
                        {
                            ApplySort(listView.Items, propertyName, listView, headerClicked);
                        }
                    }
                }
            }
        }

        #endregion

        #region Helper methods

        private static void ApplySort(ICollectionView view, string propertyName, ListView listView, GridViewColumnHeader sortedColumnHeader)
        {
            ListSortDirection direction = ListSortDirection.Ascending;
            if (view.SortDescriptions.Count > 0)
            {
                SortDescription currentSort = view.SortDescriptions[0];
                if (currentSort.PropertyName == propertyName)
                {
                    if (currentSort.Direction == ListSortDirection.Ascending)
                        direction = ListSortDirection.Descending;
                    else
                        direction = ListSortDirection.Ascending;
                }
                view.SortDescriptions.Clear();

                GridViewColumnHeader currentSortedColumnHeader = GetSortedColumnHeader(listView);
                if (currentSortedColumnHeader != null)
                {
                    RemoveSortGlyph(currentSortedColumnHeader);
                }
            }
            if (!string.IsNullOrEmpty(propertyName))
            {
                view.SortDescriptions.Add(new SortDescription(propertyName, direction));
                if (GetShowSortGlyph(listView))
                    AddSortGlyph(
                        sortedColumnHeader,
                        direction,
                        direction == ListSortDirection.Ascending ? GetSortGlyphAscending(listView) : GetSortGlyphDescending(listView));
                SetSortedColumnHeader(listView, sortedColumnHeader);
            }
        }

        private static void AddSortGlyph(GridViewColumnHeader columnHeader, ListSortDirection direction, ImageSource sortGlyph)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(columnHeader);
            adornerLayer.Add(
                new SortGlyphAdorner(
                    columnHeader,
                    direction,
                    sortGlyph
                    ));
        }

        private static void RemoveSortGlyph(GridViewColumnHeader columnHeader)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(columnHeader);
            Adorner[] adorners = adornerLayer.GetAdorners(columnHeader);
            if (adorners != null)
            {
                foreach (Adorner adorner in adorners)
                {
                    if (adorner is SortGlyphAdorner)
                        adornerLayer.Remove(adorner);
                }
            }
        }

        #endregion

        #region SortGlyphAdorner nested class

        private class SortGlyphAdorner : Adorner
        {
            private readonly GridViewColumnHeader _columnHeader;
            private readonly ListSortDirection _direction;
            private readonly ImageSource _sortGlyph;

            public SortGlyphAdorner(GridViewColumnHeader columnHeader, ListSortDirection direction, ImageSource sortGlyph)
                : base(columnHeader)
            {
                _columnHeader = columnHeader;
                _direction = direction;
                _sortGlyph = sortGlyph;
            }

            private Geometry GetDefaultGlyph()
            {
                double x1 = _columnHeader.ActualWidth - 13;
                double x2 = x1 + 10;
                double x3 = x1 + 5;
                double y1 = _columnHeader.ActualHeight / 2 - 3;
                double y2 = y1 + 5;

                if (_direction == ListSortDirection.Ascending)
                {
                    double tmp = y1;
                    y1 = y2;
                    y2 = tmp;
                }

                PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();
                pathSegmentCollection.Add(new LineSegment(new Point(x2, y1), true));
                pathSegmentCollection.Add(new LineSegment(new Point(x3, y2), true));

                PathFigure pathFigure = new PathFigure(
                    new Point(x1, y1),
                    pathSegmentCollection,
                    true);

                PathFigureCollection pathFigureCollection = new PathFigureCollection();
                pathFigureCollection.Add(pathFigure);

                PathGeometry pathGeometry = new PathGeometry(pathFigureCollection);
                return pathGeometry;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (_sortGlyph != null)
                {
                    double x = _columnHeader.ActualWidth - 13;
                    double y = _columnHeader.ActualHeight / 2 - 5;
                    Rect rect = new Rect(x, y, 10, 10);
                    drawingContext.DrawImage(_sortGlyph, rect);
                }
                else
                {
                    drawingContext.DrawGeometry(Brushes.LightGray, new Pen(Brushes.Gray, 1.0), GetDefaultGlyph());
                }
            }
        }

        #endregion

        #endregion
    }
}
