using PassportValidationLibrary;

namespace PassportValidationService
{
    public class Validate : IValidate
    {
        private PassportValidationLibrary.IValidate validate;

        public Validate()
        {
            validate = new PassportValidationLibrary.Validate();            
        }

        public Validate(PassportValidationLibrary.IValidate validate)
        {
            this.validate = validate;
        }

        public ValidateMRZResult ValidateMRZ(string mrz, 
            string passportNumber, 
            string nationality, 
            string dateOfBirth, 
            string gender,
            string dateOfExpiry,
            string personalNumber)
        {
            return validate.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);
        }
    }
}
