using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportValidationServiceClient
{
    /// <summary>
    /// Returned result from ValidateMRZ method
    /// </summary>
    public class ValidateMRZClientResult
    {
        /// <summary>
        /// This identifies if the call to the web service is availabloe
        /// </summary>
        public bool IsServiceAvailable { get; set; }

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

