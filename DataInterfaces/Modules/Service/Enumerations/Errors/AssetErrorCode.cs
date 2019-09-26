using Localization;

namespace ServerService
{
    #region AssetErrorCode
    public enum AssetErrorCode
    {
        [Localized("ASSET_ERROR_NOT_CHECKED_IN")]
        NotCheckedIn = 0,
        [Localized("ASSET_ERROR_ALREADY_CHECKED_IN")]
        AlreadyCheckedIn = 1,
        [Localized("ASSET_ERROR_DISABLED")]
        AssetDisabled = 2,
    }
    #endregion
}
