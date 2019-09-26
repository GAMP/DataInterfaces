using Localization;

namespace ServerService
{
    #region ShiftErrorCode
    public enum ShiftErrorCode
    {
        [Localized("SHIFT_ERROR_NO_ACTIVE_SHIFT")]
        NoActiveShift = 0,
        [Localized("SHIFT_ERROR_ANOTHER_ACTIVE")]
        AnotherShift = 1,
        [Localized("SHIFT_ERROR_ALREADY_ACTIVE")]
        AlreadyActive = 2,
        [Localized("SHIFT_ERROR_NO_REGISTER")]
        NoRgister = 3,
        [Localized("SHIFT_ERROR_INVALID_ID")]
        InvalidShiftId = 4,
        [Localized("SHIFT_ERROR_ALREADY_ENDED")]
        AlreadyEnded = 5,
        [Localized("SHIFT_ERROR_DISABLED")]
        ShiftDisabled = 6,
        [Localized("SHIFT_ERROR_NO_OPERATOR")]
        NoOperator = 7,
        [Localized("SHIFT_ERROR_ENDING")]
        ShiftEnding = 8,
        [Localized("SHIFT_ERROR_NOT_ENDING")]
        ShiftNotEnding = 9,
        [Localized("SHIFT_ERROR_DELETED_REGISTER")]
        DeletedRegister = 10,
    }
    #endregion
}
