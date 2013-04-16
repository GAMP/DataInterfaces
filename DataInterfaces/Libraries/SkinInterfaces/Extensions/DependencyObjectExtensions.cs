using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;

namespace SkinInterfaces
{
    public static class DependencyObjectExtensions
    {
        public static T GetValue<T>(this DependencyObject obj, DependencyProperty dp)
        {
            return (T)obj.GetValue(dp);
        }

        public static DependencyObject GetLogicalParent(this DependencyObject obj)
        {
            return LogicalTreeHelper.GetParent(obj);
        }

        public static IEnumerable<DependencyObject> GetLogicalChildren(this DependencyObject obj)
        {
            return LogicalTreeHelper.GetChildren(obj).Cast<DependencyObject>();
        }

        public static DependencyObject GetVisualParent(this DependencyObject obj)
        {
            return VisualTreeHelper.GetParent(obj);
        }

        public static IEnumerable<DependencyObject> GetVisualChildren(this DependencyObject obj)
        {
            int count = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < count; i++)
            {
                yield return VisualTreeHelper.GetChild(obj, i);
            }
        }

        public static T FindAncestor<T>(this DependencyObject obj) where T : DependencyObject
        {
            var tmp = VisualTreeHelper.GetParent(obj);
            while (tmp != null && !(tmp is T))
            {
                tmp = VisualTreeHelper.GetParent(tmp);
            }
            return tmp as T;
        }

        public static DependencyObject FindAncestor(this DependencyObject obj, Type ancestorType)
        {
            var tmp = VisualTreeHelper.GetParent(obj);
            while (tmp != null && !ancestorType.IsAssignableFrom(tmp.GetType()))
            {
                tmp = VisualTreeHelper.GetParent(tmp);
            }
            return tmp;
        }

        public static IEnumerable<T> FindDescendants<T>(this DependencyObject obj) where T : DependencyObject
        {
            var queue = new Queue<DependencyObject>(obj.GetVisualChildren());
            while (queue.Count > 0)
            {
                var child = queue.Dequeue();
                if (child is T)
                    yield return (T)child;
                foreach (var c in child.GetVisualChildren())
                {
                    queue.Enqueue(c);
                }
            }
        }

        public static IEnumerable<DependencyObject> FindDescendants(this DependencyObject obj, Type descendantType)
        {
            var queue = new Queue<DependencyObject>(obj.GetVisualChildren());
            while (queue.Count > 0)
            {
                var child = queue.Dequeue();
                if (descendantType.IsAssignableFrom(child.GetType()))
                    yield return child;
                foreach (var c in child.GetVisualChildren())
                {
                    queue.Enqueue(c);
                }
            }
        }

        public static void AddPropertyChangedHandler(this DependencyObject obj, DependencyProperty property, EventHandler handler)
        {
            var desc = DependencyPropertyDescriptor.FromProperty(property, obj.GetType());
            desc.AddValueChanged(obj, handler);
        }

        public static void RemovePropertyChangedHandler(this DependencyObject obj, DependencyProperty property, EventHandler handler)
        {
            var desc = DependencyPropertyDescriptor.FromProperty(property, obj.GetType());
            desc.RemoveValueChanged(obj, handler);
        }
    }
}
