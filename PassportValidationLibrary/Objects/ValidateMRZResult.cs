
namespace PassportValidationLibrary
{
    /// <summary>
    /// Returned result from ValidateMRZ method
    /// </summary>
    public class ValidateMRZResult
    {
        public bool IsPassportNumberCheckDigitValid { get; set; }
        public bool IsDateOfBirthCheckDigitValid { get; set; }
        public bool IsDateOfExpiryCheckDigitValid { get; set; }
        public bool IsPersonalNumberCheckDigitValid { get; set; }
        public bool IsFinalCheckDigitValid { get; set; }
        public bool IsGenderCrossCheckValid { get; set; }
        public bool IsDateOfBirthCrossCheckValid { get; set; }
        public bool IsDateOfExpiryCrossCheckValid { get; set; }
        public bool IsNationalitCrossCheckValid { get; set; }
        public bool IsPassportNumberCrossCheckValid { get; set; }
        public bool IsPersonalNumberCrossCheckValid { get; set; }
    }
}
