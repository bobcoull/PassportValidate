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
        [StringLength(9), Required]
        public string PassportNumber { get; set; }

        [StringLength(3), Required]
        public string Nationality { get; set; }

        [StringLength(2), Required]
        public string DateOfBirthDD { get; set; }

        [StringLength(2), Required]
        public string DateOfBirthMM { get; set; }

        [StringLength(2), Required]
        public string DateOfBirthYY { get; set; }

        [StringLength(1), Required]
        [RegularExpression(@"^[MF]{1}$")]
        public string Gender { get; set; }

        [StringLength(2), Required]
        public string DateOfExpiryDD { get; set; }

        [StringLength(2), Required]
        public string DateOfExpiryMM { get; set; }

        [StringLength(2), Required]
        public string DateOfExpiryYY { get; set; }

        [StringLength(44), Required]
        public string MRZ { get; set; }
    }
}