namespace Manager
{
    /// <summary>
    /// Extended user search fields.
    /// </summary>
    public enum UserSearchFields
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Phone.
        /// </summary>
        [Localization.Localized("PHONE_NUMBER")]
        Phone = 1,
        /// <summary>
        /// Mobile phone.
        /// </summary>
        [Localization.Localized("MOBILE_PHONE_NUMBER")]
        MobilePhone = 2,
        /// <summary>
        /// First name.
        /// </summary>
        [Localization.Localized("FIRST_NAME")]
        FirstName = 4,
        /// <summary>
        /// Last name.
        /// </summary>
        [Localization.Localized("LAST_NAME")]
        LastName = 8,
        /// <summary>
        /// Email.
        /// </summary>
        [Localization.Localized("EMAIL_ADDRESS")]
        Email = 16,
    }
}
