using System.Windows;

namespace SkinInterfaces
{
    public class BindingProxy : Freezable
    { 
        #region DEPENDENCY PROPERTIES
        public static readonly DependencyProperty DataProperty =
           DependencyProperty.Register("Data", typeof(object),
                                        typeof(BindingProxy));
        #endregion

        #region PROPERTY
        /// <summary>
        /// Gets or sets data object.
        /// </summary>
        public object Data
        {
            get { return GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
        #endregion

        #region OVERRIDES

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion
    }
}
