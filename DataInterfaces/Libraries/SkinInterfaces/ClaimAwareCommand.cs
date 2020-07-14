using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Windows.Input;
#if NETFRAMEWORK
using System.IdentityModel.Services;
using System.Security.Permissions;
#endif

namespace SkinInterfaces
{
    /// <summary>
    /// Claim aware ICommand.
    /// </summary>
    public class ClaimAwareCommand<T1, T2> : SimpleCommand<T1, T2>
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="canExecuteMethod">Can execute method.</param>
        /// <param name="executeMethod">Execute method.</param>
        public ClaimAwareCommand(Func<T1, bool> canExecuteMethod, Action<T2> executeMethod)
           : base(canExecuteMethod, executeMethod)
        {
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if method access was previously authorized.
        /// </summary>
        private bool IsAuthorized { get; set; }

        /// <summary>
        /// Gets or sets if access check should reoccur.
        /// </summary>
        private bool IsAuthorizedChecked { get; set; }

        #endregion

        #region FUNCTIONS

        private bool IsMethodAuthorized(MethodInfo methodInfo)
        {
            bool isAuthorized = true;

#if NETFRAMEWORK
            var claimAttributes = (System.IdentityModel.Services.ClaimsPrincipalPermissionAttribute[])methodInfo.GetCustomAttributes(typeof(System.IdentityModel.Services.ClaimsPrincipalPermissionAttribute), true);

            if (claimAttributes.Count() == 0)
                return true;

            foreach (var claimRequest in claimAttributes)
            {
                if (Thread.CurrentPrincipal is ClaimsPrincipal currentPrincipal)
                {
                    isAuthorized = claimRequest.Action == System.Security.Permissions.SecurityAction.Demand ? currentPrincipal.HasClaim(claimRequest.Resource, claimRequest.Operation) : true;
                }

                if (!isAuthorized)
                    break;
            }
#else
            var claimAttributes = (ClaimsPrincipalPermissionAttribute[])methodInfo.GetCustomAttributes(typeof(ClaimsPrincipalPermissionAttribute), true);

            if (claimAttributes.Count() == 0)
                return true;

            foreach (var claimRequest in claimAttributes)
            {
                if (Thread.CurrentPrincipal is ClaimsPrincipal currentPrincipal)
                {
                    isAuthorized = currentPrincipal.HasClaim(claimRequest.Resource, claimRequest.Operation);
                }
                else
                {
                    isAuthorized = false;
                }


                if (!isAuthorized)
                    break;
            }
#endif
            return isAuthorized;
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Called on can execute.
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
        /// <returns>True or false.</returns>
        public override bool CanExecute(object parameter)
        {
            IsAuthorized = !IsAuthorizedChecked ? (this.executeMethod == null || this.executeMethod != null && this.IsMethodAuthorized(this.executeMethod.Method)) : this.IsAuthorized;

            return IsAuthorized && CanExecute((T1)parameter);
        }

        /// <summary>
        /// Raises <see cref="ICommand.CanExecuteChanged"/>.
        /// </summary>
        public override void RaiseCanExecuteChanged()
        {
            base.RaiseCanExecuteChanged();
            IsAuthorizedChecked = false;
        }

        #endregion
    }
}

