using PassportValidationLibrary;

namespace PassportValidation_Tests
{
    using NUnit.Framework;
//    using PassportValidationLibrary;

    namespace PassportValidationLibrary_Testz
    {
        /// <summary>
        /// A number of tests to check the return check digit.
        /// The rules are as follows;
        /// each position is assigned a value;
        /// for the digits 0 to 9 this is the value of the digits,
        /// for the letters A to Z this is 10 to 35,
        /// for the filler (less than sign) this is 0.
        /// The value of each position is then multiplied by its weight;
        /// the weight of the first position is 7, of the second it is 3, and of the third it is 1, and after that the weights repeat 7, 3, 1, and so on.
        /// All values are added together and the remainder of the final value divided by 10 is the check digit.
        /// </summary>
        [TestFixture]
        public class GetCheckDigit_Should
        {
            private IValidate validate = new Validate();

            [Test]
            public void Return_Valid_CheckDigit_For_Numeric_Values()
            {
                // assign
                string inputString = "1234567890"; // total = 147, so 147/10 = 14 remainder 7

                // act
                var result = validate.GetCheckDigit(inputString, true, false);

                //assert
                Assert.AreEqual(7, result);
            }

            [Test]
            public void Return_MinusOne_CheckDigit_For_Numeric_Value_That_Has_Alphas()
            {
                // assign
                string inputString = "123AA<4567890";

                // act
                var result = validate.GetCheckDigit(inputString, true, false);

                //assert
                Assert.AreEqual(-1, result);
            }

            [Test]
            public void Return_Valid_CheckDigit_For_Less_Than_Filler_Values()
            {
                // assign
                string inputString = "<<<"; // total = 0, so 0/10 = 0 remainder 0

                // act
                var result = validate.GetCheckDigit(inputString, false, true);

                //assert
                Assert.AreEqual(0, result);
            }

            [Test]
            public void Return_Valid_CheckDigit_For_Character_Values()
            {
                // assign
                string inputString = "ARZ"; // total = 186, so 186/10 = 18 remainder 6

                // act
                var result = validate.GetCheckDigit(inputString, false, true);
          
                //assert
                Assert.AreEqual(6, result);
            }

            [Test]
            public void Return_MinusOne_Check_Digit_If_Invalid_Chracters_In_String()
            {
                // assign
                string inputString = "A*==-R#Z"; // total = 186, so 186/10 = 18 remainder 6

                // act
                var result = validate.GetCheckDigit(inputString, true, true);

                //assert
                Assert.AreEqual(-1, result);
            }

            [Test]
            public void Return_MinusOne_CheckDigit_For_Alpha_Value_That_Has_Numerics()
            {
                // assign
                string inputString = "123AA<4567890";

                // act
                var result = validate.GetCheckDigit(inputString, true, false);

                //assert
                Assert.AreEqual(-1, result);
            }
        }
    }
}
