using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SkinInterfaces
{
    public static class DataGridExtensions
    {
        #region FUNCTIONS

        public static DataGridCell GetCell(this DataGrid source, int row, int column)
        {
            DataGridRow rowContainer = GetRow(source, row);

            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    rowContainer.ApplyTemplate();
                    presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                }

                if (presenter == null)
                    return null;

                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    source.ScrollIntoView(rowContainer, source.Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }

        public static DataGridRow GetRow(this DataGrid source, int index)
        {
            DataGridRow row = (DataGridRow)source.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                // may be virtualized, bring into view and try again
                source.ScrollIntoView(source.Items[index]);
                row = (DataGridRow)source.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        public static bool TryFocusSelected(this DataGrid source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var CURRENT_INDEX = source.SelectedIndex;

            //we have now selection
            if (CURRENT_INDEX < 0)
                return false;

            //focus row at current index
            FocusRow(source, CURRENT_INDEX);

            return true;
        }

        public static void FocusRow(this DataGrid source, int rowIndex)
        {
            FocusRow(source, rowIndex, 0);
        }

        public static void FocusRow(this DataGrid source, int rowIndex, int columnIndex)
        {
            if (source == null)
                throw new ArgumentException(nameof(source));

            if (source.Items.Count < rowIndex)
                throw new ArgumentException("Row index smaller than items count.", nameof(rowIndex));

            if (source.Columns.Count <= 0)
                throw new ArgumentException("Column index smaller than columns count.", nameof(columnIndex));

            var TARGET_DATAGRID = source;
            var CURRENT_CELL = TARGET_DATAGRID.GetCell(rowIndex, columnIndex);

            if (CURRENT_CELL != null)
            {
                if (CURRENT_CELL.Content is FrameworkElement CONTENT && CONTENT.Parent is DataGridCell GRID_CELL)
                    GRID_CELL.Focus();
            }
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        } 

        #endregion
    }
}
