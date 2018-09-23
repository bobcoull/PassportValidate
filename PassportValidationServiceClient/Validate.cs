using PassportValidationServiceClient.PassportValidationService;

namespace PassportValidationServiceClient
{
    public interface IValidate
    {
        ValidateMRZ_Result ValidateMRZ(string mrz,
            string passportNumber,
            string nationality,
            string dateOfBirth,
            string gender,
            string dateOfExpiry);
    }

    public class Validate : IValidate
    {
        public ValidateMRZ_Result ValidateMRZ(string mrz,
            string passportNumber,
            string nationality,
            string dateOfBirth,
            string gender,
            string dateOfExpiry)
        {
            var validateClient = new PassportValidationService.ValidateClient();

            return validateClient.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry);
        }
    }
}
