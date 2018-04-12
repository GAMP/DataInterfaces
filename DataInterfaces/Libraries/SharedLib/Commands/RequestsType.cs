namespace SharedLib.Commands
{
    #region RequestsType
    /// <summary>
    /// Request type.
    /// </summary>
    public enum RequestsType : byte
    {
        /// <summary>
        /// A new request command.
        /// </summary>
        Request = 0,
       
        /// <summary>
        /// Response command.
        /// </summary>
        Response = 1,

        /// <summary>
        /// Command state update.
        /// </summary>
        CommandStateUpdate = 2,

        /// <summary>
        /// Encryption negotiation.
        /// </summary>
        NEGEncryption = 3,

        /// <summary>
        /// Operation state update.
        /// </summary>
        OperationStateUpdate = 4,

        /// <summary>
        /// Compression negotiation.
        /// </summary>
        NEGCompression = 5,
        
        /// <summary>
        /// Protocol negotiation.
        /// </summary>
        NEGProtocol = 6,
        
        /// <summary>
        /// Authentication negotiation.
        /// </summary>
        NEGAuthenticate = 7,  
        
        /// <summary>
        /// Operation update.
        /// </summary>
        OperationUpdate = 8,
        
        /// <summary>
        /// Operation abort.
        /// </summary>
        OperationAbort = 16,
        
        /// <summary>
        /// This state should be set when the operation does not have any completion so the other side would remove it from the operation list.
        /// </summary>
        OperationRelease = 32,
    }
    #endregion
}
