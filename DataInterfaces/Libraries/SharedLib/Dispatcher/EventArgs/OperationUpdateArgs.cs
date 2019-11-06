namespace SharedLib.Dispatcher
{
    /// <summary>
    /// Operation update event args.
    /// </summary>
    public class OperationUpdateArgs : OperationEventArgsBase
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="param">Update parameter.</param>
        public OperationUpdateArgs(object param) : base(param)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="count">Count.</param>
        public OperationUpdateArgs(byte[] buffer, int offset, int count) : base(buffer, offset, count)
        { }

        #endregion
    }
}
