using System;
using System.Text;
using System.Text.RegularExpressions;

namespace PassportValidationLibrary
{
    public interface IValidate
    {
        /// <summary>
        /// Validate check digits and content in MRZ.
        /// The content is compared against the entered values
        /// </summary>
        /// <param name="mrz">The full 44 character MRZ</param>
        /// <param name="passportNumber">Passport Number (9 digits alpha, numeric, less than sign)</param>
        /// <param name="nationality">Nationality (ISO 3166-1 alpha-3 code with modifications)</param>
        /// <param name="dateOfBirth">Dte of Birth - YYMMDD</param>
        /// <param name="gender">M or F or less than sign</param>
        /// <param name="dateOfExpiry">Expiry Date - YYMMDD</param>
        /// <param name="personalNumber">personal number</param>
        /// <returns>ValidateMRZResult object</returns>
        ValidateMRZResult ValidateMRZ(string mrz, string passportNumber, string nationality, string dateOfBirth, string gender, string dateOfExpiry, string personalNumber);

        /// <summary>
        /// Method to  return the check digit of the input string
        /// The string needs to be validated before checking - TODO: possibly refactor this to reduce duplicate code
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="isNumericAllowed">digits 0-9 are allowed</param>
        /// <param name="isAlphaAllowed">Alphas A-Z and special less than character allowed</param>
        /// <returns></returns>
        int GetCheckDigit(string inputString, bool isNumericAllowed, bool isAlphaAllowed);
    }

    /// <summary>
    /// class to validate Passport MRZ 
    /// </summary>
    public class Validate : IValidate
    {
        /// <summary>
        /// Validate check digits and content in MRZ.
        /// The content is compared against the entered values
        /// </summary>
        /// <param name="mrz">The full 44 character MRZ</param>
        /// <param name="passportNumber">Passport Number (9 digits alpha, numeric, less than sign)</param>
        /// <param name="nationality">Nationality (ISO 3166-1 alpha-3 code with modifications)</param>
        /// <param name="dateOfBirth">Dte of Birth - YYMMDD</param>
        /// <param name="gender">M or F or less than sign</param>
        /// <param name="dateOfExpiry">Expiry Date - YYMMDD</param>
        /// <param name="personalNumber">Personal Number</param>
        /// <returns>ValidateMRZResult object</returns>
        public ValidateMRZResult ValidateMRZ(string mrz, string passportNumber, string nationality, string dateOfBirth, string gender, string dateOfExpiry, string personalNumber)
        {
            ValidateMRZResult result = new ValidateMRZResult
            {
                IsPassportNumberCheckDigitValid = false,
                IsDateOfBirthCheckDigitValid = false,
                IsDateOfExpiryCheckDigitValid = false,
                IsPersonalNumberCheckDigitValid = false,
                IsFinalCheckDigitValid = false,
                IsGenderCrossCheckValid = false,
                IsDateOfBirthCrossCheckValid = false,
                IsDateOfExpiryCrossCheckValid = false,
                IsNationalitCrossCheckValid = false,
                IsPassportNumberCrossCheckValid = false,
                IsPersonalNumberCrossCheckValid = false
            };

            // this will be set to false if any item specific check digits can not be checked, due to invalid characters
            bool isFinalCheckDigitOkToCheck = true;

            // Check length of string - if not 44, or null then this has to be a complete failure of all checks
            if (string.IsNullOrEmpty(mrz) || mrz.Length != 44)
            {
                return result;
            }

            // Split up 44 characters into sections for validatioin
            string mrzPassportNumber = mrz.Substring(0, 9);
            string mrzCheckDigitPassportNumber = mrz.Substring(9, 1); // Check digit for passport number 
            string mrzNationality = mrz.Substring(10, 3);
            string mrzDateOfBirth = mrz.Substring(13, 6); // date in format YYMMDD
            string mrzCheckDigitDateOfBirth = mrz.Substring(19, 1); // Check digit for date of birth
            string mrzGender = mrz.Substring(20, 1);
            string mrzDateOfExpiry = mrz.Substring(21, 6); // date in format YYMMDD
            string mrzCheckDigitDateOfExpiry = mrz.Substring(27, 1);  // check digit expiration date
            string mrzPersonalNumber = mrz.Substring(28, 14);
            string mrzCheckDigitPersonalNumber = mrz.Substring(42, 1); // check digit personal number
            string mrzCheckDigitOverDigits = mrz.Substring(43, 1); // Check digit over digits 1–10, 14–20, and 22–43

            //
            // TODO: Do we need to UPPERCASE the values, or leave as entered?
            //

            // Validate Passport Number
            // can only do this is an entered number is passed
            if (!string.IsNullOrEmpty(passportNumber))
            {
                result.IsPassportNumberCrossCheckValid = (mrzPassportNumber == passportNumber) ? true : false;
            }

            // Validate Passport Number check digit
            if (IsValidPattern(mrzPassportNumber, true, true) && IsValidPattern(passportNumber, true, true))
            {
                result.IsPassportNumberCheckDigitValid = IsCheckDigitValid(mrzPassportNumber, passportNumber, mrzCheckDigitPassportNumber, true, true);
            }
            else
            {
                isFinalCheckDigitOkToCheck = false;
            }

            // Validate nationality
            // TODO: Out of scope at the moment but could validate code againt the ISO 3166-1 list, including the allowed additional modifications
            // TODO: see https://en.wikipedia.org/wiki/Machine-readable_passport for more details on modifications.
            if (!string.IsNullOrEmpty(nationality))
            {
                result.IsNationalitCrossCheckValid = (mrzNationality == nationality) ? true : false;
            }

            // Validate Date Of Birth
            if (!string.IsNullOrEmpty(dateOfBirth))
            {
                result.IsDateOfBirthCrossCheckValid = (mrzDateOfBirth == dateOfBirth) ? true : false;
            }

            // Validate Date of Birth check digit
            if (IsValidPattern(mrzDateOfBirth, true, false) && IsValidPattern(dateOfBirth, true, false))
            {
                result.IsDateOfBirthCheckDigitValid = IsCheckDigitValid(mrzDateOfBirth, dateOfBirth, mrzCheckDigitDateOfBirth, true, false);
            }
            else
            {
                isFinalCheckDigitOkToCheck = false;
            }

            // Validate Gender
            if (!string.IsNullOrEmpty(gender))
            {
                result.IsGenderCrossCheckValid = (mrzGender == gender) ? true : false;
            }

            // Validate Passport Expiration
            if (!string.IsNullOrEmpty(dateOfExpiry))
            {
                result.IsDateOfExpiryCrossCheckValid = (mrzDateOfExpiry == dateOfExpiry) ? true : false;
            }


            // Validate Passport Expiration check digit
            if (IsValidPattern(mrzDateOfExpiry, true, false) && IsValidPattern(dateOfExpiry, true, false))
            {
                result.IsDateOfExpiryCheckDigitValid = IsCheckDigitValid(mrzDateOfExpiry, dateOfExpiry, mrzCheckDigitDateOfExpiry, true, false);
            }
            else
            {
                isFinalCheckDigitOkToCheck = false;
            }

            // Validate Personal Number
            // can only do this is an entered number is passed
            if (!string.IsNullOrEmpty(personalNumber))
            {
                result.IsPersonalNumberCrossCheckValid = (mrzPersonalNumber == personalNumber) ? true : false;
            }

            // Validate Personal Number check digit
            if (IsValidPattern(mrzPersonalNumber, true, true) && IsValidPattern(personalNumber, true, true))
            {
                result.IsPersonalNumberCheckDigitValid = IsCheckDigitValid(mrzPersonalNumber, personalNumber, mrzCheckDigitPersonalNumber, true, true);
            }
            else
            {
                isFinalCheckDigitOkToCheck = false;
            }

            // Validate Final Check Digit, only if the section check digits are valid
            // Check digit for digits 1–10 (Passpor Number), 14–20 (Date Of Birth), and 22–43 (Date Of Expiry + Personal Number)
            if (isFinalCheckDigitOkToCheck)
            {
                string finalMrzCheckDigitString = String.Concat(mrzPassportNumber,
                    mrzCheckDigitPassportNumber,
                    mrzDateOfBirth,
                    mrzCheckDigitDateOfBirth,
                    mrzDateOfExpiry,
                    mrzCheckDigitDateOfExpiry,
                    mrzPersonalNumber,
                    mrzCheckDigitPersonalNumber);

                string finalInputCheckDigitString = String.Concat(passportNumber,
                    mrzCheckDigitPassportNumber,
                    dateOfBirth,
                    mrzCheckDigitDateOfBirth,
                    dateOfExpiry,
                    mrzCheckDigitDateOfExpiry,
                    personalNumber,
                    mrzCheckDigitPersonalNumber);

                result.IsFinalCheckDigitValid = IsCheckDigitValid(finalMrzCheckDigitString, finalInputCheckDigitString, mrzCheckDigitOverDigits, true, true);
            }

            return result;
        }

        /// <summary>
        /// Returns true if string mathes required pattern
        /// </summary>
        /// <param name="inputString">string to check</param>
        /// <param name="isNumericAllowed">are digits 0-9 allowed</param>
        /// <param name="isAlphaAllowed">are alphas A-Z + special less than characer allowed</param>
        /// <returns></returns>
        private bool IsValidPattern(string inputString, bool isNumericAllowed, bool isAlphaAllowed)
        {
            string numericPattern = string.Empty;
            string alphaPattern = string.Empty;

            if (isNumericAllowed)
            {
                numericPattern += "0-9";
            }

            if (isAlphaAllowed)
            {
                alphaPattern += "A-Z<"; // < is a special filler character
            }

            string regexPattern = string.Format(@"^[{0}{1}]+$", numericPattern, alphaPattern);
            var match = Regex.Match(inputString, regexPattern, RegexOptions.Compiled);
            return match.Success;
        }

        /// <summary>
        /// Return true if expected check digit is equal to actual check digit
        /// </summary>
        /// <param name="mrzExtractString">string extracted from mrz</param>
        /// <param name="inputString">the input string</param>
        /// <param name="expectedCheckDigitString">the check digit to test against in string format</param>
        /// <returns></returns>
        private bool IsCheckDigitValid(string mrzExtractString, string inputString, string expectedCheckDigitString, bool isNumericAllowed, bool isAlphaAllowed)
        {       
            int expectedCheckDigit;

            if (mrzExtractString == inputString)
            {
                int actualCheckDigit = GetCheckDigit(mrzExtractString, isNumericAllowed, isAlphaAllowed); // return -1 indicates a character error in string            

                if (actualCheckDigit != -1 && int.TryParse(expectedCheckDigitString, out expectedCheckDigit))
                {
                    return (expectedCheckDigit == actualCheckDigit) ? true : false;
                }
            }

            return false;
        }

        /// <summary>
        /// Method to  return the check digit of the input string
        /// The string needs to be validated before checking - TODO: possibly refactor this to reduce duplicate code
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="isNumericAllowed">digits 0-9 are allowed</param>
        /// <param name="isAlphaAllowed">Alphas A-Z and special less than character allowed</param>
        /// <returns></returns>
        public int GetCheckDigit(string inputString, bool isNumericAllowed, bool isAlphaAllowed)
        {
            int checkDigit = 0;

            // The check digit calculation is as follows:
            // each position is assigned a value;
            // for the digits 0 to 9 this is the value of the digits,
            // for the letters A to Z this is 10 to 35,
            // for the filler < this is 0.
            // The value of each position is then multiplied by its weight;
            // the weight of the first position is 7, of the second it is 3, and of the third it is 1, and after that the weights repeat 7, 3, 1, and so on.
            // All values are added together and the remainder of the final value divided by 10 is the check digit.

            int total = 0;
            int[] multipliers = {7, 3, 1}; // multiplier loops 7, 3, 1 repeating

            for (int i=0; i < inputString.Length; i++)
            {
                int multiplierIndex = i % 3;
                int inputCharValue = int.MinValue;

                if (int.TryParse(inputString.Substring(i, 1), out int inputIntValue) && isNumericAllowed)
                {
                    inputCharValue = int.Parse(inputString.Substring(i, 1));
                }
                else if (inputString.Substring(i, 1) == "<" && isAlphaAllowed)
                {
                    inputCharValue = 0;
                }
                else
                {
                    // A - Z = 65  - 90. Need  to convert to 10 - 35 for value to process
                    var asciiValue = Encoding.ASCII.GetBytes(inputString.Substring(i, 1));

                    if (asciiValue[0] >= 65 && asciiValue[0] <= 90 && isAlphaAllowed)
                    {
                        inputCharValue = asciiValue[0] - 55;
                    }
                    else
                    {
                        return -1; // string does not allow this charater
                    }
                }

                total += inputCharValue * multipliers[multiplierIndex];
            }

            checkDigit = total % 10;
            return checkDigit;
        }
    }
}