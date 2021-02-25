using Gizmo.Shared.Exceptions;

namespace ServerService.Exceptions
{
    /// <summary>
    /// Product exception.
    /// </summary>
    public class ProductException : ErrorCodeExceptionBase<ProductErrorCode>
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public ProductException(ProductErrorCode errorCode) : base(errorCode)
        {
        }

        #endregion
    }
}
