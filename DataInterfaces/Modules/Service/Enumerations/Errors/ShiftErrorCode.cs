using Localization;

namespace ServerService
{
    /// <summary>
    /// Shift error codes.
    /// </summary>
    public enum ShiftErrorCode
    {
        /// <summary>
        /// No active shift.
        /// </summary>
        [Localized("SHIFT_ERROR_NO_ACTIVE_SHIFT")]
        NoActiveShift = 0,
        /// <summary>
        /// Another shift.
        /// </summary>
        [Localized("SHIFT_ERROR_ANOTHER_ACTIVE")]
        AnotherShift = 1,
        /// <summary>
        /// Already active.
        /// </summary>
        [Localized("SHIFT_ERROR_ALREADY_ACTIVE")]
        AlreadyActive = 2,
        /// <summary>
        /// No register.
        /// </summary>
        [Localized("SHIFT_ERROR_NO_REGISTER")]
        NoRgister = 3,
        /// <summary>
        /// Invalid shift id.
        /// </summary>
        [Localized("SHIFT_ERROR_INVALID_ID")]
        InvalidShiftId = 4,
        /// <summary>
        /// Already ended.
        /// </summary>
        [Localized("SHIFT_ERROR_ALREADY_ENDED")]
        AlreadyEnded = 5,
        /// <summary>
        /// Shift disabled.
        /// </summary>
        [Localized("SHIFT_ERROR_DISABLED")]
        ShiftDisabled = 6,
        /// <summary>
        /// No operator.
        /// </summary>
        [Localized("SHIFT_ERROR_NO_OPERATOR")]
        NoOperator = 7,
        /// <summary>
        /// Shift ending.
        /// </summary>
        [Localized("SHIFT_ERROR_ENDING")]
        ShiftEnding = 8,
        /// <summary>
        /// Shift not ending.
        /// </summary>
        [Localized("SHIFT_ERROR_NOT_ENDING")]
        ShiftNotEnding = 9,
        /// <summary>
        /// Deleted register.
        /// </summary>
        [Localized("SHIFT_ERROR_DELETED_REGISTER")]
        DeletedRegister = 10,
    }
}
