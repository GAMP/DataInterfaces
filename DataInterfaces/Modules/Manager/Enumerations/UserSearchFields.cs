namespace Manager
{
    /// <summary>
    /// Extended user search fields.
    /// </summary>
    public enum UserSearchFields
    {
        None = 0,
        [Localization.Localized("PHONE_NUMBER")]
        Phone = 1,
        [Localization.Localized("MOBILE_PHONE_NUMBER")]
        MobilePhone = 2,
        [Localization.Localized("FIRST_NAME")]
        FirstName = 4,
        [Localization.Localized("LAST_NAME")]
        LastName = 8,
        [Localization.Localized("EMAIL_ADDRESS")]
        Email = 16,
    } 
}
