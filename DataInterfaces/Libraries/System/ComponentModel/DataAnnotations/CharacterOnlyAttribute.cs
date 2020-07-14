using System.Linq;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Validation attribute ensuring that only characters contained in specified.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CharacterOnlyAttribute : ValidationAttribute
    {
        #region CONSTRUCTOR
        public CharacterOnlyAttribute()
        { }
        #endregion

        #region OVERRIDES

        public override bool IsValid(object value)
        {
            if (value is string stringValue)
            {
                if (stringValue.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
                    return false;
            }

            return true;
        }

        #endregion
    }
}
