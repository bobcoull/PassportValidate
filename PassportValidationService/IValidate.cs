using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PassportValidationLibrary;

namespace PassportValidationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IValidate" in both code and config file together.
    [ServiceContract]
    public interface IValidate
    {
        [OperationContract]
        ValidateMRZResult ValidateMRZ(string mrz, 
            string passportNumber, 
            string nationality, 
            string dateOfBirth,
            string gender, 
            string dateOfExpiry);
    }

    // TODO: Add new method that receives an encrypted string containing parameters


}
