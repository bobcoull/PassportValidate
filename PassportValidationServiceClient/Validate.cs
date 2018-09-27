using System;
using System.Xml.XPath;
using PassportValidationServiceClient.PassportValidationService;

namespace PassportValidationServiceClient
{
    public interface IValidate
    {
        ValidateMRZClientResult ValidateMRZ(string mrz,
            string passportNumber,
            string nationality,
            string dateOfBirth,
            string gender,
            string dateOfExpiry,
            string personalNumber);
    }

    public class Validate : IValidate
    {
        public ValidateMRZClientResult ValidateMRZ(string mrz,
            string passportNumber,
            string nationality,
            string dateOfBirth,
            string gender,
            string dateOfExpiry,
            string personalNumber)
        {
            try
            {
                var validateClient = new PassportValidationService.ValidateClient();

                var result = validateClient.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);

                ValidateMRZClientResult validateMRZClientResult = new ValidateMRZClientResult
                {
                    IsPassportNumberCheckDigitValid = result.IsPassportNumberCheckDigitValid,
                    IsDateOfBirthCheckDigitValid = result.IsDateOfBirthCheckDigitValid,
                    IsDateOfExpiryCheckDigitValid = result.IsDateOfExpiryCheckDigitValid,
                    IsPersonalNumberCheckDigitValid = result.IsPersonalNumberCheckDigitValid,
                    IsFinalCheckDigitValid = result.IsFinalCheckDigitValid,
                    IsGenderCrossCheckValid = result.IsGenderCrossCheckValid,
                    IsDateOfBirthCrossCheckValid = result.IsDateOfBirthCrossCheckValid,
                    IsDateOfExpiryCrossCheckValid = result.IsDateOfExpiryCrossCheckValid,
                    IsNationalitCrossCheckValid = result.IsNationalitCrossCheckValid,
                    IsPassportNumberCrossCheckValid = result.IsPassportNumberCrossCheckValid,
                    IsPersonalNumberCrossCheckValid = result.IsPersonalNumberCrossCheckValid
                };

                validateMRZClientResult.IsServiceAvailable = true;

                return validateMRZClientResult;

            }
            catch (Exception e)
            {
                // TODO: need to record this somewhere
                return new ValidateMRZClientResult(); // default values so all will fail
            }
        }
    }
}
