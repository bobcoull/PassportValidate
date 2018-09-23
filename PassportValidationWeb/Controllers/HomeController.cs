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
                DateOfBirthDD = "03",
                DateOfBirthMM = "02",
                DateOfBirthYY = "91",
                Gender = "M",
                DateOfExpiryDD = "28",
                DateOfExpiryMM = "02",
                DateOfExpiryYY = "23"
            };

            return View(mrzDataCaptureModel);
        }

        [ValidateInput(false)] // because of the special less than character we need to prevent input validtion
        [HttpPost]
        public ActionResult Index(MRZDataCaptureModel mrzDataCaptureModel)
        {
            if (ModelState.IsValid)
            {
                string dateOfBirth = mrzDataCaptureModel.DateOfBirthYY + mrzDataCaptureModel.DateOfBirthMM + mrzDataCaptureModel.DateOfBirthDD;
                string dateOfExpiry = mrzDataCaptureModel.DateOfExpiryYY + mrzDataCaptureModel.DateOfExpiryMM + mrzDataCaptureModel.DateOfExpiryDD;

                var res = validate.ValidateMRZ(mrzDataCaptureModel.MRZ, mrzDataCaptureModel.PassportNumber,
                    mrzDataCaptureModel.Nationality, dateOfBirth, mrzDataCaptureModel.Gender, dateOfExpiry);

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

                return View("Results", validateMRZResultModel);
            }

            // Error occurred in data form
            // TODO Add validation error messages:

            // Becasue ValidateInput=false encode values before displaying
            mrzDataCaptureModel.PassportNumber = HttpUtility.HtmlEncode(mrzDataCaptureModel.PassportNumber);
            mrzDataCaptureModel.Nationality = HttpUtility.HtmlEncode(mrzDataCaptureModel.Nationality);
            mrzDataCaptureModel.DateOfBirthDD = HttpUtility.HtmlEncode(mrzDataCaptureModel.DateOfBirthDD);
            mrzDataCaptureModel.DateOfBirthMM= HttpUtility.HtmlEncode(mrzDataCaptureModel.DateOfBirthMM);
            mrzDataCaptureModel.DateOfBirthYY = HttpUtility.HtmlEncode(mrzDataCaptureModel.DateOfBirthYY);
            mrzDataCaptureModel.Gender = HttpUtility.HtmlEncode(mrzDataCaptureModel.Gender);
            mrzDataCaptureModel.DateOfExpiryDD = HttpUtility.HtmlEncode(mrzDataCaptureModel.DateOfExpiryDD);
            mrzDataCaptureModel.DateOfExpiryMM = HttpUtility.HtmlEncode(mrzDataCaptureModel.DateOfExpiryMM);
            mrzDataCaptureModel.DateOfExpiryYY = HttpUtility.HtmlEncode(mrzDataCaptureModel.DateOfExpiryYY);
            mrzDataCaptureModel.MRZ = HttpUtility.HtmlEncode(mrzDataCaptureModel.MRZ);
            
            return View(mrzDataCaptureModel);
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}