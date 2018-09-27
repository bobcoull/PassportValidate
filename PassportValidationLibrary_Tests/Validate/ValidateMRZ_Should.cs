using System.Data.SqlTypes;
using NUnit.Framework;
using PassportValidationLibrary;

namespace PassportValidationLibrary_Tests
{
    [TestFixture]
    public class ValidateMRZ_Should
    {
        private IValidate validate = new Validate();

        [Test]
        public void Return_All_True_If_Valid_Check_Digits_And_Valid_Data()
        {
            // assign
            string mrz = "9991263238GBR9102033M2302281<<<<<<<<<<<<<<02";
            string passportNumber = "999126323";
            string nationality = "GBR";
            string dateOfBirth = "910203";
            string gender = "M";
            string dateOfExpiry = "230228";
            string personalNumber = "<<<<<<<<<<<<<<";

            // act
            var result = validate.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);

            // assert
            Assert.AreEqual(true, result.IsPersonalNumberCheckDigitValid);
            Assert.AreEqual(true, result.IsPersonalNumberCrossCheckValid);
            Assert.AreEqual(true, result.IsDateOfBirthCheckDigitValid);
            Assert.AreEqual(true, result.IsDateOfBirthCrossCheckValid);
            Assert.AreEqual(true, result.IsDateOfExpiryCheckDigitValid);
            Assert.AreEqual(true, result.IsDateOfExpiryCrossCheckValid);
            Assert.AreEqual(true, result.IsFinalCheckDigitValid);
            Assert.AreEqual(true, result.IsGenderCrossCheckValid);
            Assert.AreEqual(true, result.IsNationalitCrossCheckValid);
            Assert.AreEqual(true, result.IsPassportNumberCheckDigitValid);
            Assert.AreEqual(true, result.IsPassportNumberCrossCheckValid);
        }

        [Test]
        public void Return_All_False_If_Check_Digits_And_Data_Are_Invalid()
        {
            // assign
            string mrz = "9991263239GBX9102049M2302299<<<<<<<<<<<<<<13";
            string passportNumber = "99912632D";
            string nationality = "GBR";
            string dateOfBirth = "910203";
            string gender = "F";
            string dateOfExpiry = "230228";
            string personalNumber = "<<<<<<<356<<<<";

            // act
            var result = validate.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);

            // assert
            Assert.AreEqual(false, result.IsPersonalNumberCheckDigitValid);
            Assert.AreEqual(false, result.IsPersonalNumberCrossCheckValid);
            Assert.AreEqual(false, result.IsDateOfBirthCheckDigitValid);
            Assert.AreEqual(false, result.IsDateOfBirthCrossCheckValid);
            Assert.AreEqual(false, result.IsDateOfExpiryCheckDigitValid);
            Assert.AreEqual(false, result.IsDateOfExpiryCrossCheckValid);
            Assert.AreEqual(false, result.IsFinalCheckDigitValid);
            Assert.AreEqual(false, result.IsGenderCrossCheckValid);
            Assert.AreEqual(false, result.IsNationalitCrossCheckValid);
            Assert.AreEqual(false, result.IsPassportNumberCheckDigitValid);
            Assert.AreEqual(false, result.IsPassportNumberCrossCheckValid);
        }

        [Test]
        public void Return_Failed_Check_Digit_If_Valid_MRZ_PassportNo_But_Invalid_Input_PassportNo()
        {
            // assign
            string mrz = "9991263238GBR9102033M2302281<<<<<<<<<<<<<<02";
            string passportNumber = "888126323";
            string nationality = "GBR";
            string dateOfBirth = "910203";
            string gender = "M";
            string dateOfExpiry = "230228";
            string personalNumber = "<<<<<<<<<<<<<<";

            // act
            var result = validate.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);

            // assert
            Assert.AreEqual(true, result.IsPersonalNumberCheckDigitValid);
            Assert.AreEqual(true, result.IsPersonalNumberCrossCheckValid);
            Assert.AreEqual(true, result.IsDateOfBirthCheckDigitValid);
            Assert.AreEqual(true, result.IsDateOfBirthCrossCheckValid);
            Assert.AreEqual(true, result.IsDateOfExpiryCheckDigitValid);
            Assert.AreEqual(true, result.IsDateOfExpiryCrossCheckValid);
            Assert.AreEqual(true, result.IsFinalCheckDigitValid);
            Assert.AreEqual(true, result.IsGenderCrossCheckValid);
            Assert.AreEqual(true, result.IsNationalitCrossCheckValid);
            Assert.AreEqual(false, result.IsPassportNumberCheckDigitValid);
            Assert.AreEqual(false, result.IsPassportNumberCrossCheckValid);
        }

        [Test]
        public void Return_Failed_Check_Digit_If_Valid_MRZ_DateOfBirth_But_Invalid_Input_DateOfBirth()
        {
            // assign
            string mrz = "9991263238GBR9102033M2302281<<<<<<<<<<<<<<02";
            string passportNumber = "999126323";
            string nationality = "GBR";
            string dateOfBirth = "910230";
            string gender = "M";
            string dateOfExpiry = "230228";
            string personalNumber = "<<<<<<<<<<<<<<";

            // act
            var result = validate.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);

            // assert
            Assert.AreEqual(true, result.IsPersonalNumberCheckDigitValid);
            Assert.AreEqual(true, result.IsPersonalNumberCrossCheckValid);
            Assert.AreEqual(false, result.IsDateOfBirthCheckDigitValid);
            Assert.AreEqual(false, result.IsDateOfBirthCrossCheckValid);
            Assert.AreEqual(true, result.IsDateOfExpiryCheckDigitValid);
            Assert.AreEqual(true, result.IsDateOfExpiryCrossCheckValid);
            Assert.AreEqual(true, result.IsFinalCheckDigitValid);
            Assert.AreEqual(true, result.IsGenderCrossCheckValid);
            Assert.AreEqual(true, result.IsNationalitCrossCheckValid);
            Assert.AreEqual(true, result.IsPassportNumberCheckDigitValid);
            Assert.AreEqual(true, result.IsPassportNumberCrossCheckValid);
        }


        [Test]
        public void Return_Failed_Check_Digit_If_Valid_MRZ_DateOfExpiry_But_Invalid_Input_DateOfExpiry()
        {
            // assign
            string mrz = "9991263238GBR9102033M2302281<<<<<<<<<<<<<<02";
            string passportNumber = "999126323";
            string nationality = "GBR";
            string dateOfBirth = "910203";
            string gender = "M";
            string dateOfExpiry = "210228";
            string personalNumber = "<<<<<<<<<<<<<<";

            // act
            var result = validate.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);

            // assert
            Assert.AreEqual(true, result.IsPersonalNumberCheckDigitValid);
            Assert.AreEqual(true, result.IsPersonalNumberCrossCheckValid);
            Assert.AreEqual(true, result.IsDateOfBirthCheckDigitValid);
            Assert.AreEqual(true, result.IsDateOfBirthCrossCheckValid);
            Assert.AreEqual(false, result.IsDateOfExpiryCheckDigitValid);
            Assert.AreEqual(false, result.IsDateOfExpiryCrossCheckValid);
            Assert.AreEqual(true, result.IsFinalCheckDigitValid);
            Assert.AreEqual(true, result.IsGenderCrossCheckValid);
            Assert.AreEqual(true, result.IsNationalitCrossCheckValid);
            Assert.AreEqual(true, result.IsPassportNumberCheckDigitValid);
            Assert.AreEqual(true, result.IsPassportNumberCrossCheckValid);
        }


        [Test]
        public void Return_Failed_Check_Digit_If_Valid_MRZ_PersonalNo_But_Invalid_Input_PersonalNo()
        {
            // assign
            string mrz = "9991263238GBR9102033M2302281<<<<<<<<<<<<<<02";
            string passportNumber = "999126323";
            string nationality = "GBR";
            string dateOfBirth = "910203";
            string gender = "M";
            string dateOfExpiry = "230228";
            string personalNumber = "1234567<<<<<<<";

            // act
            var result = validate.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);

            // assert
            Assert.AreEqual(false, result.IsPersonalNumberCheckDigitValid);
            Assert.AreEqual(false, result.IsPersonalNumberCrossCheckValid);
            Assert.AreEqual(true, result.IsDateOfBirthCheckDigitValid);
            Assert.AreEqual(true, result.IsDateOfBirthCrossCheckValid);
            Assert.AreEqual(true, result.IsDateOfExpiryCheckDigitValid);
            Assert.AreEqual(true, result.IsDateOfExpiryCrossCheckValid);
            Assert.AreEqual(true, result.IsFinalCheckDigitValid);
            Assert.AreEqual(true, result.IsGenderCrossCheckValid);
            Assert.AreEqual(true, result.IsNationalitCrossCheckValid);
            Assert.AreEqual(true, result.IsPassportNumberCheckDigitValid);
            Assert.AreEqual(true, result.IsPassportNumberCrossCheckValid);
        }

        // TODO: add more tests for specific failures
    }
}
