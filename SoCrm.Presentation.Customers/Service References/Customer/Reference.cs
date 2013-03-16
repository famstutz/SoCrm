﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoCrm.Presentation.Customers.Customer {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Customers.Contracts")]
    [System.SerializableAttribute()]
    public partial class Person : SoCrm.Presentation.Customers.Customer.DomainObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Presentation.Customers.Customer.Address AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Presentation.Customers.Customer.EMailAddress[] EMailAddressesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Presentation.Customers.Customer.Company EmployerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Presentation.Customers.Customer.PhoneNumber[] PhoneNumbersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Presentation.Customers.Customer.Address Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Presentation.Customers.Customer.EMailAddress[] EMailAddresses {
            get {
                return this.EMailAddressesField;
            }
            set {
                if ((object.ReferenceEquals(this.EMailAddressesField, value) != true)) {
                    this.EMailAddressesField = value;
                    this.RaisePropertyChanged("EMailAddresses");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Presentation.Customers.Customer.Company Employer {
            get {
                return this.EmployerField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployerField, value) != true)) {
                    this.EmployerField = value;
                    this.RaisePropertyChanged("Employer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Presentation.Customers.Customer.PhoneNumber[] PhoneNumbers {
            get {
                return this.PhoneNumbersField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneNumbersField, value) != true)) {
                    this.PhoneNumbersField = value;
                    this.RaisePropertyChanged("PhoneNumbers");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DomainObject", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Contracts")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Presentation.Customers.Customer.Address))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Presentation.Customers.Customer.EMailAddress))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Presentation.Customers.Customer.Company))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Presentation.Customers.Customer.PhoneNumber))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Presentation.Customers.Customer.Person))]
    public partial class DomainObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreationTimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastUpdateTimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid ObjectIdField;
        
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
        public System.DateTime CreationTimeStamp {
            get {
                return this.CreationTimeStampField;
            }
            set {
                if ((this.CreationTimeStampField.Equals(value) != true)) {
                    this.CreationTimeStampField = value;
                    this.RaisePropertyChanged("CreationTimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastUpdateTimeStamp {
            get {
                return this.LastUpdateTimeStampField;
            }
            set {
                if ((this.LastUpdateTimeStampField.Equals(value) != true)) {
                    this.LastUpdateTimeStampField = value;
                    this.RaisePropertyChanged("LastUpdateTimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid ObjectId {
            get {
                return this.ObjectIdField;
            }
            set {
                if ((this.ObjectIdField.Equals(value) != true)) {
                    this.ObjectIdField = value;
                    this.RaisePropertyChanged("ObjectId");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Address", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Customers.Contracts")]
    [System.SerializableAttribute()]
    public partial class Address : SoCrm.Presentation.Customers.Customer.DomainObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressLineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ZipCodeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AddressLine {
            get {
                return this.AddressLineField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressLineField, value) != true)) {
                    this.AddressLineField = value;
                    this.RaisePropertyChanged("AddressLine");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Country {
            get {
                return this.CountryField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryField, value) != true)) {
                    this.CountryField = value;
                    this.RaisePropertyChanged("Country");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ZipCode {
            get {
                return this.ZipCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ZipCodeField, value) != true)) {
                    this.ZipCodeField = value;
                    this.RaisePropertyChanged("ZipCode");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EMailAddress", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Customers.Contracts")]
    [System.SerializableAttribute()]
    public partial class EMailAddress : SoCrm.Presentation.Customers.Customer.DomainObject {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Company", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Customers.Contracts")]
    [System.SerializableAttribute()]
    public partial class Company : SoCrm.Presentation.Customers.Customer.DomainObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Presentation.Customers.Customer.Address AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Presentation.Customers.Customer.Person[] EmployeesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Presentation.Customers.Customer.Address Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Presentation.Customers.Customer.Person[] Employees {
            get {
                return this.EmployeesField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeesField, value) != true)) {
                    this.EmployeesField = value;
                    this.RaisePropertyChanged("Employees");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Website {
            get {
                return this.WebsiteField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteField, value) != true)) {
                    this.WebsiteField = value;
                    this.RaisePropertyChanged("Website");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PhoneNumber", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Customers.Contracts")]
    [System.SerializableAttribute()]
    public partial class PhoneNumber : SoCrm.Presentation.Customers.Customer.DomainObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Presentation.Customers.Customer.ContactType ContactTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumberField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Presentation.Customers.Customer.ContactType ContactType {
            get {
                return this.ContactTypeField;
            }
            set {
                if ((this.ContactTypeField.Equals(value) != true)) {
                    this.ContactTypeField = value;
                    this.RaisePropertyChanged("ContactType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Number {
            get {
                return this.NumberField;
            }
            set {
                if ((object.ReferenceEquals(this.NumberField, value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ContactType", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Customers.Contracts")]
    public enum ContactType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Private = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Company = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Customer.ICustomerService")]
    public interface ICustomerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllPersons", ReplyAction="http://tempuri.org/ICustomerService/GetAllPersonsResponse")]
        SoCrm.Presentation.Customers.Customer.Person[] GetAllPersons();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllPersons", ReplyAction="http://tempuri.org/ICustomerService/GetAllPersonsResponse")]
        System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Person[]> GetAllPersonsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllCompanies", ReplyAction="http://tempuri.org/ICustomerService/GetAllCompaniesResponse")]
        SoCrm.Presentation.Customers.Customer.Company[] GetAllCompanies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllCompanies", ReplyAction="http://tempuri.org/ICustomerService/GetAllCompaniesResponse")]
        System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Company[]> GetAllCompaniesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllAddresses", ReplyAction="http://tempuri.org/ICustomerService/GetAllAddressesResponse")]
        SoCrm.Presentation.Customers.Customer.Address[] GetAllAddresses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllAddresses", ReplyAction="http://tempuri.org/ICustomerService/GetAllAddressesResponse")]
        System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Address[]> GetAllAddressesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllEMailAddresses", ReplyAction="http://tempuri.org/ICustomerService/GetAllEMailAddressesResponse")]
        SoCrm.Presentation.Customers.Customer.EMailAddress[] GetAllEMailAddresses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllEMailAddresses", ReplyAction="http://tempuri.org/ICustomerService/GetAllEMailAddressesResponse")]
        System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.EMailAddress[]> GetAllEMailAddressesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllPhoneNumbers", ReplyAction="http://tempuri.org/ICustomerService/GetAllPhoneNumbersResponse")]
        SoCrm.Presentation.Customers.Customer.PhoneNumber[] GetAllPhoneNumbers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllPhoneNumbers", ReplyAction="http://tempuri.org/ICustomerService/GetAllPhoneNumbersResponse")]
        System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.PhoneNumber[]> GetAllPhoneNumbersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetPersonByObjectId", ReplyAction="http://tempuri.org/ICustomerService/GetPersonByObjectIdResponse")]
        SoCrm.Presentation.Customers.Customer.Person GetPersonByObjectId(System.Guid objectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetPersonByObjectId", ReplyAction="http://tempuri.org/ICustomerService/GetPersonByObjectIdResponse")]
        System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Person> GetPersonByObjectIdAsync(System.Guid objectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetPersonsByNameAndCompany", ReplyAction="http://tempuri.org/ICustomerService/GetPersonsByNameAndCompanyResponse")]
        SoCrm.Presentation.Customers.Customer.Person[] GetPersonsByNameAndCompany(string personName, string companyName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetPersonsByNameAndCompany", ReplyAction="http://tempuri.org/ICustomerService/GetPersonsByNameAndCompanyResponse")]
        System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Person[]> GetPersonsByNameAndCompanyAsync(string personName, string companyName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCompanyByObjectId", ReplyAction="http://tempuri.org/ICustomerService/GetCompanyByObjectIdResponse")]
        SoCrm.Presentation.Customers.Customer.Company GetCompanyByObjectId(System.Guid objectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCompanyByObjectId", ReplyAction="http://tempuri.org/ICustomerService/GetCompanyByObjectIdResponse")]
        System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Company> GetCompanyByObjectIdAsync(System.Guid objectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreateAddress", ReplyAction="http://tempuri.org/ICustomerService/CreateAddressResponse")]
        void CreateAddress(string addressLine, string zipCode, string city, string country);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreateAddress", ReplyAction="http://tempuri.org/ICustomerService/CreateAddressResponse")]
        System.Threading.Tasks.Task CreateAddressAsync(string addressLine, string zipCode, string city, string country);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreatePhoneNumber", ReplyAction="http://tempuri.org/ICustomerService/CreatePhoneNumberResponse")]
        void CreatePhoneNumber(string phoneNumber, SoCrm.Presentation.Customers.Customer.ContactType contactType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreatePhoneNumber", ReplyAction="http://tempuri.org/ICustomerService/CreatePhoneNumberResponse")]
        System.Threading.Tasks.Task CreatePhoneNumberAsync(string phoneNumber, SoCrm.Presentation.Customers.Customer.ContactType contactType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreateEmailAddress", ReplyAction="http://tempuri.org/ICustomerService/CreateEmailAddressResponse")]
        void CreateEmailAddress(string emailAddress, SoCrm.Presentation.Customers.Customer.ContactType contactType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreateEmailAddress", ReplyAction="http://tempuri.org/ICustomerService/CreateEmailAddressResponse")]
        System.Threading.Tasks.Task CreateEmailAddressAsync(string emailAddress, SoCrm.Presentation.Customers.Customer.ContactType contactType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreateCompany", ReplyAction="http://tempuri.org/ICustomerService/CreateCompanyResponse")]
        void CreateCompany(string name, SoCrm.Presentation.Customers.Customer.Address address, string website);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreateCompany", ReplyAction="http://tempuri.org/ICustomerService/CreateCompanyResponse")]
        System.Threading.Tasks.Task CreateCompanyAsync(string name, SoCrm.Presentation.Customers.Customer.Address address, string website);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreatePerson", ReplyAction="http://tempuri.org/ICustomerService/CreatePersonResponse")]
        void CreatePerson(string firstName, string lastName, SoCrm.Presentation.Customers.Customer.Company employer, SoCrm.Presentation.Customers.Customer.Address address, SoCrm.Presentation.Customers.Customer.PhoneNumber[] phoneNumbers, SoCrm.Presentation.Customers.Customer.EMailAddress[] emailAddresses);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/CreatePerson", ReplyAction="http://tempuri.org/ICustomerService/CreatePersonResponse")]
        System.Threading.Tasks.Task CreatePersonAsync(string firstName, string lastName, SoCrm.Presentation.Customers.Customer.Company employer, SoCrm.Presentation.Customers.Customer.Address address, SoCrm.Presentation.Customers.Customer.PhoneNumber[] phoneNumbers, SoCrm.Presentation.Customers.Customer.EMailAddress[] emailAddresses);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerServiceChannel : SoCrm.Presentation.Customers.Customer.ICustomerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerServiceClient : System.ServiceModel.ClientBase<SoCrm.Presentation.Customers.Customer.ICustomerService>, SoCrm.Presentation.Customers.Customer.ICustomerService {
        
        public CustomerServiceClient() {
        }
        
        public CustomerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SoCrm.Presentation.Customers.Customer.Person[] GetAllPersons() {
            return base.Channel.GetAllPersons();
        }
        
        public System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Person[]> GetAllPersonsAsync() {
            return base.Channel.GetAllPersonsAsync();
        }
        
        public SoCrm.Presentation.Customers.Customer.Company[] GetAllCompanies() {
            return base.Channel.GetAllCompanies();
        }
        
        public System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Company[]> GetAllCompaniesAsync() {
            return base.Channel.GetAllCompaniesAsync();
        }
        
        public SoCrm.Presentation.Customers.Customer.Address[] GetAllAddresses() {
            return base.Channel.GetAllAddresses();
        }
        
        public System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Address[]> GetAllAddressesAsync() {
            return base.Channel.GetAllAddressesAsync();
        }
        
        public SoCrm.Presentation.Customers.Customer.EMailAddress[] GetAllEMailAddresses() {
            return base.Channel.GetAllEMailAddresses();
        }
        
        public System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.EMailAddress[]> GetAllEMailAddressesAsync() {
            return base.Channel.GetAllEMailAddressesAsync();
        }
        
        public SoCrm.Presentation.Customers.Customer.PhoneNumber[] GetAllPhoneNumbers() {
            return base.Channel.GetAllPhoneNumbers();
        }
        
        public System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.PhoneNumber[]> GetAllPhoneNumbersAsync() {
            return base.Channel.GetAllPhoneNumbersAsync();
        }
        
        public SoCrm.Presentation.Customers.Customer.Person GetPersonByObjectId(System.Guid objectId) {
            return base.Channel.GetPersonByObjectId(objectId);
        }
        
        public System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Person> GetPersonByObjectIdAsync(System.Guid objectId) {
            return base.Channel.GetPersonByObjectIdAsync(objectId);
        }
        
        public SoCrm.Presentation.Customers.Customer.Person[] GetPersonsByNameAndCompany(string personName, string companyName) {
            return base.Channel.GetPersonsByNameAndCompany(personName, companyName);
        }
        
        public System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Person[]> GetPersonsByNameAndCompanyAsync(string personName, string companyName) {
            return base.Channel.GetPersonsByNameAndCompanyAsync(personName, companyName);
        }
        
        public SoCrm.Presentation.Customers.Customer.Company GetCompanyByObjectId(System.Guid objectId) {
            return base.Channel.GetCompanyByObjectId(objectId);
        }
        
        public System.Threading.Tasks.Task<SoCrm.Presentation.Customers.Customer.Company> GetCompanyByObjectIdAsync(System.Guid objectId) {
            return base.Channel.GetCompanyByObjectIdAsync(objectId);
        }
        
        public void CreateAddress(string addressLine, string zipCode, string city, string country) {
            base.Channel.CreateAddress(addressLine, zipCode, city, country);
        }
        
        public System.Threading.Tasks.Task CreateAddressAsync(string addressLine, string zipCode, string city, string country) {
            return base.Channel.CreateAddressAsync(addressLine, zipCode, city, country);
        }
        
        public void CreatePhoneNumber(string phoneNumber, SoCrm.Presentation.Customers.Customer.ContactType contactType) {
            base.Channel.CreatePhoneNumber(phoneNumber, contactType);
        }
        
        public System.Threading.Tasks.Task CreatePhoneNumberAsync(string phoneNumber, SoCrm.Presentation.Customers.Customer.ContactType contactType) {
            return base.Channel.CreatePhoneNumberAsync(phoneNumber, contactType);
        }
        
        public void CreateEmailAddress(string emailAddress, SoCrm.Presentation.Customers.Customer.ContactType contactType) {
            base.Channel.CreateEmailAddress(emailAddress, contactType);
        }
        
        public System.Threading.Tasks.Task CreateEmailAddressAsync(string emailAddress, SoCrm.Presentation.Customers.Customer.ContactType contactType) {
            return base.Channel.CreateEmailAddressAsync(emailAddress, contactType);
        }
        
        public void CreateCompany(string name, SoCrm.Presentation.Customers.Customer.Address address, string website) {
            base.Channel.CreateCompany(name, address, website);
        }
        
        public System.Threading.Tasks.Task CreateCompanyAsync(string name, SoCrm.Presentation.Customers.Customer.Address address, string website) {
            return base.Channel.CreateCompanyAsync(name, address, website);
        }
        
        public void CreatePerson(string firstName, string lastName, SoCrm.Presentation.Customers.Customer.Company employer, SoCrm.Presentation.Customers.Customer.Address address, SoCrm.Presentation.Customers.Customer.PhoneNumber[] phoneNumbers, SoCrm.Presentation.Customers.Customer.EMailAddress[] emailAddresses) {
            base.Channel.CreatePerson(firstName, lastName, employer, address, phoneNumbers, emailAddresses);
        }
        
        public System.Threading.Tasks.Task CreatePersonAsync(string firstName, string lastName, SoCrm.Presentation.Customers.Customer.Company employer, SoCrm.Presentation.Customers.Customer.Address address, SoCrm.Presentation.Customers.Customer.PhoneNumber[] phoneNumbers, SoCrm.Presentation.Customers.Customer.EMailAddress[] emailAddresses) {
            return base.Channel.CreatePersonAsync(firstName, lastName, employer, address, phoneNumbers, emailAddresses);
        }
    }
}
