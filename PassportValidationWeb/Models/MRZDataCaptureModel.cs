using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;

namespace PassportValidationWeb.Models
{
    public class MRZDataCaptureModel
    {
        [StringLength(9, MinimumLength = 9), Required]
        [RegularExpression("([A-Z0-9<]+)", ErrorMessage = "Enter only alphabetic, numeric or less than sign")]
        public string PassportNumber { get; set; }

        [StringLength(3, MinimumLength = 3), Required]
        [RegularExpression("([A-Z]+)", ErrorMessage = "Enter only alphabetic characters")]
        public string Nationality { get; set; }

        [StringLength(10, MinimumLength = 8), Required]
        [RegularExpression(@"([0-9]{2})[\/-]?([0-9]{2})[\/-]?([0-9]{4})", ErrorMessage = "Enter date in format DD/MM/YYYY")]
        public string DateOfBirth { get; set; }

        [StringLength(1), Required]
        [RegularExpression(@"^[MF]{1}$", ErrorMessage = "Enter either M or F")]
        public string Gender { get; set; }

        public IEnumerable<SelectListItem> GenderItems { get; set; }

        [StringLength(10, MinimumLength = 8), Required]
        [RegularExpression(@"([0-9]{2})[\/-]?([0-9]{2})[\/-]?([0-9]{4})", ErrorMessage = "Enter date in format DD/MM/YYYY")]
        public string DateOfExpiry { get; set; }

        [StringLength(14, MinimumLength = 14), Required]
        [RegularExpression("([A-Z0-9<]+)", ErrorMessage = "Enter only alphabetic, numeric or less than sign")]
        public string PersonalNumber { get; set; }

        [StringLength(44, MinimumLength = 44), Required]
        [RegularExpression("([A-Z0-9<]+)", ErrorMessage = "Enter only alphabetic, numeric or less than sign")]
        public string MRZ { get; set; }
    }
}