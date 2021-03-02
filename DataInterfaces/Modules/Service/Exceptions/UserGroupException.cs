using Gizmo.Shared.Exceptions;

namespace ServerService.Exceptions
{
    /// <summary>
    /// User group exception.
    /// </summary>
    public class UserGroupException : ErrorCodeExceptionBase<UserGroupErrorCode>
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public UserGroupException(UserGroupErrorCode errorCode) : base(errorCode)
        {
        }

        #endregion
    }
}
