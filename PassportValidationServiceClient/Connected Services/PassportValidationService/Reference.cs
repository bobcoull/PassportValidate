﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PassportValidationServiceClient.PassportValidationService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ValidateMRZResult", Namespace="http://schemas.datacontract.org/2004/07/PassportValidationLibrary")]
    [System.SerializableAttribute()]
    public partial class ValidateMRZResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDateOfBirthCheckDigitValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDateOfBirthCrossCheckValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDateOfExpiryCheckDigitValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDateOfExpiryCrossCheckValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsFinalCheckDigitValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsGenderCrossCheckValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsNationalitCrossCheckValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsPassportNumberCheckDigitValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsPassportNumberCrossCheckValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsPersonalNumberCheckDigitValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsPersonalNumberCrossCheckValidField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDateOfBirthCheckDigitValid {
            get {
                return this.IsDateOfBirthCheckDigitValidField;
            }
            set {
                if ((this.IsDateOfBirthCheckDigitValidField.Equals(value) != true)) {
                    this.IsDateOfBirthCheckDigitValidField = value;
                    this.RaisePropertyChanged("IsDateOfBirthCheckDigitValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDateOfBirthCrossCheckValid {
            get {
                return this.IsDateOfBirthCrossCheckValidField;
            }
            set {
                if ((this.IsDateOfBirthCrossCheckValidField.Equals(value) != true)) {
                    this.IsDateOfBirthCrossCheckValidField = value;
                    this.RaisePropertyChanged("IsDateOfBirthCrossCheckValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDateOfExpiryCheckDigitValid {
            get {
                return this.IsDateOfExpiryCheckDigitValidField;
            }
            set {
                if ((this.IsDateOfExpiryCheckDigitValidField.Equals(value) != true)) {
                    this.IsDateOfExpiryCheckDigitValidField = value;
                    this.RaisePropertyChanged("IsDateOfExpiryCheckDigitValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDateOfExpiryCrossCheckValid {
            get {
                return this.IsDateOfExpiryCrossCheckValidField;
            }
            set {
                if ((this.IsDateOfExpiryCrossCheckValidField.Equals(value) != true)) {
                    this.IsDateOfExpiryCrossCheckValidField = value;
                    this.RaisePropertyChanged("IsDateOfExpiryCrossCheckValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsFinalCheckDigitValid {
            get {
                return this.IsFinalCheckDigitValidField;
            }
            set {
                if ((this.IsFinalCheckDigitValidField.Equals(value) != true)) {
                    this.IsFinalCheckDigitValidField = value;
                    this.RaisePropertyChanged("IsFinalCheckDigitValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsGenderCrossCheckValid {
            get {
                return this.IsGenderCrossCheckValidField;
            }
            set {
                if ((this.IsGenderCrossCheckValidField.Equals(value) != true)) {
                    this.IsGenderCrossCheckValidField = value;
                    this.RaisePropertyChanged("IsGenderCrossCheckValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsNationalitCrossCheckValid {
            get {
                return this.IsNationalitCrossCheckValidField;
            }
            set {
                if ((this.IsNationalitCrossCheckValidField.Equals(value) != true)) {
                    this.IsNationalitCrossCheckValidField = value;
                    this.RaisePropertyChanged("IsNationalitCrossCheckValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsPassportNumberCheckDigitValid {
            get {
                return this.IsPassportNumberCheckDigitValidField;
            }
            set {
                if ((this.IsPassportNumberCheckDigitValidField.Equals(value) != true)) {
                    this.IsPassportNumberCheckDigitValidField = value;
                    this.RaisePropertyChanged("IsPassportNumberCheckDigitValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsPassportNumberCrossCheckValid {
            get {
                return this.IsPassportNumberCrossCheckValidField;
            }
            set {
                if ((this.IsPassportNumberCrossCheckValidField.Equals(value) != true)) {
                    this.IsPassportNumberCrossCheckValidField = value;
                    this.RaisePropertyChanged("IsPassportNumberCrossCheckValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsPersonalNumberCheckDigitValid {
            get {
                return this.IsPersonalNumberCheckDigitValidField;
            }
            set {
                if ((this.IsPersonalNumberCheckDigitValidField.Equals(value) != true)) {
                    this.IsPersonalNumberCheckDigitValidField = value;
                    this.RaisePropertyChanged("IsPersonalNumberCheckDigitValid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsPersonalNumberCrossCheckValid {
            get {
                return this.IsPersonalNumberCrossCheckValidField;
            }
            set {
                if ((this.IsPersonalNumberCrossCheckValidField.Equals(value) != true)) {
                    this.IsPersonalNumberCrossCheckValidField = value;
                    this.RaisePropertyChanged("IsPersonalNumberCrossCheckValid");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PassportValidationService.IValidate")]
    public interface IValidate {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidate/ValidateMRZ", ReplyAction="http://tempuri.org/IValidate/ValidateMRZResponse")]
        PassportValidationServiceClient.PassportValidationService.ValidateMRZResult ValidateMRZ(string mrz, string passportNumber, string nationality, string dateOfBirth, string gender, string dateOfExpiry, string personalNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IValidate/ValidateMRZ", ReplyAction="http://tempuri.org/IValidate/ValidateMRZResponse")]
        System.Threading.Tasks.Task<PassportValidationServiceClient.PassportValidationService.ValidateMRZResult> ValidateMRZAsync(string mrz, string passportNumber, string nationality, string dateOfBirth, string gender, string dateOfExpiry, string personalNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IValidateChannel : PassportValidationServiceClient.PassportValidationService.IValidate, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ValidateClient : System.ServiceModel.ClientBase<PassportValidationServiceClient.PassportValidationService.IValidate>, PassportValidationServiceClient.PassportValidationService.IValidate {
        
        public ValidateClient() {
        }
        
        public ValidateClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ValidateClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ValidateClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ValidateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PassportValidationServiceClient.PassportValidationService.ValidateMRZResult ValidateMRZ(string mrz, string passportNumber, string nationality, string dateOfBirth, string gender, string dateOfExpiry, string personalNumber) {
            return base.Channel.ValidateMRZ(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);
        }
        
        public System.Threading.Tasks.Task<PassportValidationServiceClient.PassportValidationService.ValidateMRZResult> ValidateMRZAsync(string mrz, string passportNumber, string nationality, string dateOfBirth, string gender, string dateOfExpiry, string personalNumber) {
            return base.Channel.ValidateMRZAsync(mrz, passportNumber, nationality, dateOfBirth, gender, dateOfExpiry, personalNumber);
        }
    }
}
