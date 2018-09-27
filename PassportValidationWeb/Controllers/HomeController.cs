using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PassportValidationWeb.Models;
using PassportValidationServiceClient;

namespace PassportValidationWeb.Controllers
{
    public class HomeController : Controller
    {
        private IValidate validate;

        public HomeController()
        {
            validate = new PassportValidationServiceClient.Validate();
        }

        public HomeController(IValidate validate)
        {
            this.validate = validate;
        }

        [HttpGet]
        public ActionResult Index()
        {
            //MRZDataCaptureModel mrzDataCaptureModel = new MRZDataCaptureModel();

            // preload with test data for initial testing
            MRZDataCaptureModel mrzDataCaptureModel = new MRZDataCaptureModel
            {
                MRZ = "9991263238GBR9102033M2302281<<<<<<<<<<<<<<02",
                PassportNumber = "999126323",
                Nationality = "GBR",
                DateOfBirth = "03/02/1991",
                Gender = "M",
                DateOfExpiry = "28/02/2023",
                PersonalNumber = "<<<<<<<<<<<<<<"
            };

            mrzDataCaptureModel.GenderItems = GetGenders();

            return View(mrzDataCaptureModel);
        }

        [ValidateInput(false)] // because of the special less than character we need to prevent input validtion
        [HttpPost]
        public ActionResult Index(MRZDataCaptureModel mrzDataCaptureModel)
        {
            string dateOfBirthYYMMDD = string.Empty;
            string dateOfExpiryYYMMDD = string.Empty;

            // addition validation to standard model validation
            // validate dates are valid
            if (!IsDateValid(mrzDataCaptureModel.DateOfBirth, out dateOfBirthYYMMDD))
            {
                ModelState.AddModelError("DateOfBirth", "Error in date");
            }

            if (!IsDateValid(mrzDataCaptureModel.DateOfExpiry, out dateOfExpiryYYMMDD))
            {
                ModelState.AddModelError("DateOfExpiry", "Error in date");
            }

            if (ModelState.IsValid)
            {
                var res = validate.ValidateMRZ(mrzDataCaptureModel.MRZ, mrzDataCaptureModel.PassportNumber,
                    mrzDataCaptureModel.Nationality, dateOfBirthYYMMDD, mrzDataCaptureModel.Gender, dateOfExpiryYYMMDD, mrzDataCaptureModel.PersonalNumber);

                ValidateMRZResultModel validateMRZResultModel = new ValidateMRZResultModel();

                validateMRZResultModel.IsPersonalNumberCheckDigitValid = res.IsPersonalNumberCheckDigitValid;
                validateMRZResultModel.IsDateOfBirthCheckDigitValid = res.IsDateOfBirthCheckDigitValid;
                validateMRZResultModel.IsDateOfBirthCrossCheckValid = res.IsDateOfBirthCrossCheckValid;
                validateMRZResultModel.IsDateOfExpiryCheckDigitValid = res.IsDateOfExpiryCheckDigitValid;
                validateMRZResultModel.IsDateOfExpiryCrossCheckValid = res.IsDateOfExpiryCrossCheckValid;
                validateMRZResultModel.IsFinalCheckDigitValid = res.IsFinalCheckDigitValid;
                validateMRZResultModel.IsGenderCrossCheckValid = res.IsGenderCrossCheckValid;
                validateMRZResultModel.IsNationalitCrossCheckValid = res.IsNationalitCrossCheckValid;
                validateMRZResultModel.IsPassportNumberCheckDigitValid = res.IsPassportNumberCheckDigitValid;
                validateMRZResultModel.IsPassportNumberCrossCheckValid = res.IsPassportNumberCrossCheckValid;
                validateMRZResultModel.IsPersonalNumberCrossCheckValid = res.IsPersonalNumberCrossCheckValid;

                validateMRZResultModel.IsServiceAvailable = res.IsServiceAvailable;

                return View("Results", validateMRZResultModel);
            }

            // Error occurred in data form

            // Becasue ValidateInput=false encode values before displaying
            mrzDataCaptureModel.PassportNumber = HttpUtility.HtmlEncode(mrzDataCaptureModel.PassportNumber);
            mrzDataCaptureModel.Nationality = HttpUtility.HtmlEncode(mrzDataCaptureModel.Nationality);
            mrzDataCaptureModel.DateOfBirth = HttpUtility.HtmlEncode(mrzDataCaptureModel.DateOfBirth);
            mrzDataCaptureModel.Gender = mrzDataCaptureModel.Gender;
            mrzDataCaptureModel.GenderItems = GetGenders();
            mrzDataCaptureModel.DateOfExpiry = HttpUtility.HtmlEncode(mrzDataCaptureModel.DateOfExpiry);
            mrzDataCaptureModel.MRZ = HttpUtility.HtmlEncode(mrzDataCaptureModel.MRZ);
            
            return View(mrzDataCaptureModel);
        }

        public ActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// Validate if date is valid
        /// </summary>
        /// <param name="inputDate">date in format DDMMYYYY with option - or / separators</param>
        /// <param name="dateOfBirthYYMMDD">date in formt DDMMYY is validated</param>
        /// <returns>true if date is valid</returns>
        private bool IsDateValid(string inputDate, out string dateOfBirthYYMMDD)
        {
            bool isValid = false;
            dateOfBirthYYMMDD = null;

            if (inputDate != null)
            {
                var match = Regex.Match(inputDate, @"([0-9]{2})[\/-]?([0-9]{2})[\/-]?([0-9]{2})([0-9]{2})", RegexOptions.Compiled);
                if (match.Success)
                {
                    if (match.Groups.Count > 4)
                    {
                        dateOfBirthYYMMDD = string.Format("{0}{1}{2}", match.Groups[4].Value, match.Groups[2].Value, match.Groups[1].Value);

                        DateTime dateTime;

                        if (DateTime.TryParseExact(dateOfBirthYYMMDD, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                        {
                            return true;
                        }
                    }
                }
            }

            return isValid;
        }

        private List<SelectListItem> GetGenders()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Text = "", Value = ""},
                new SelectListItem{Text = "Male", Value = "M"},
                new SelectListItem{Text = "Female", Value = "F"},
            };
        }

    }
}