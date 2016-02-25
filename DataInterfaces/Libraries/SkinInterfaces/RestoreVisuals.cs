using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkinInterfaces
{
    #region RestoreVisuals
    /// <summary>
    /// Generic class to restore controls visual options.
    /// This class can be used to restore original values of the control after animation.
    /// </summary>
    public class RestoreVisuals
    {
        public double Width
        {
            get;
            set;
        }

        public double Height
        {
            get;
            set;
        }

        public double Opacity
        {
            get;
            set;
        }

        public Thickness Margin
        {
            get;
            set;
        }

        public double ActualHeight
        {
            get;
            set;
        }

        public double ActualWidth
        {
            get;
            set;
        }
    }
    #endregion
}
