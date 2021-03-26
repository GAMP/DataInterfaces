namespace ServerService
{
    /// <summary>
    /// Web api error codes.
    /// </summary>
    public enum WebApiErrorCode
    {
        Unknown,
        InvalidProperty,
        NonUniqueEntityValue,
        EntityNotFound,
        EntityInUse,
        EntityAlreadyReferenced,
        EntityNotReferenced
    }
}