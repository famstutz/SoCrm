﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoCrm.Services.Contacts.Provider.ContactPersistence {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DomainObject", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Contracts")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Services.Contacts.Provider.ContactPersistence.User))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Services.Contacts.Provider.ContactPersistence.Person))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Services.Contacts.Provider.ContactPersistence.Address))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Services.Contacts.Provider.ContactPersistence.EMailAddress))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Services.Contacts.Provider.ContactPersistence.Company))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Services.Contacts.Provider.ContactPersistence.PhoneNumber))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SoCrm.Services.Contacts.Contracts.Contact))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Security.Contracts")]
    [System.SerializableAttribute()]
    public partial class User : SoCrm.Services.Contacts.Provider.ContactPersistence.DomainObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Services.Contacts.Provider.ContactPersistence.Role RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Services.Contacts.Provider.ContactPersistence.Role Role {
            get {
                return this.RoleField;
            }
            set {
                if ((this.RoleField.Equals(value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Customers.Contracts")]
    [System.SerializableAttribute()]
    public partial class Person : SoCrm.Services.Contacts.Provider.ContactPersistence.DomainObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Services.Contacts.Provider.ContactPersistence.Address AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Services.Contacts.Provider.ContactPersistence.EMailAddress[] EMailAddressesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Services.Contacts.Provider.ContactPersistence.Company EmployerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Services.Contacts.Provider.ContactPersistence.PhoneNumber[] PhoneNumbersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Services.Contacts.Provider.ContactPersistence.Address Address {
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
        public SoCrm.Services.Contacts.Provider.ContactPersistence.EMailAddress[] EMailAddresses {
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
        public SoCrm.Services.Contacts.Provider.ContactPersistence.Company Employer {
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
        public SoCrm.Services.Contacts.Provider.ContactPersistence.PhoneNumber[] PhoneNumbers {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Address", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Customers.Contracts")]
    [System.SerializableAttribute()]
    public partial class Address : SoCrm.Services.Contacts.Provider.ContactPersistence.DomainObject {
        
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
    public partial class EMailAddress : SoCrm.Services.Contacts.Provider.ContactPersistence.DomainObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Services.Contacts.Provider.ContactPersistence.ContactType ContactTypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
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
        public SoCrm.Services.Contacts.Provider.ContactPersistence.ContactType ContactType {
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Company", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Customers.Contracts")]
    [System.SerializableAttribute()]
    public partial class Company : SoCrm.Services.Contacts.Provider.ContactPersistence.DomainObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Services.Contacts.Provider.ContactPersistence.Address AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Services.Contacts.Provider.ContactPersistence.Person[] EmployeesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Services.Contacts.Provider.ContactPersistence.Address Address {
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
        public SoCrm.Services.Contacts.Provider.ContactPersistence.Person[] Employees {
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
    public partial class PhoneNumber : SoCrm.Services.Contacts.Provider.ContactPersistence.DomainObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SoCrm.Services.Contacts.Provider.ContactPersistence.ContactType ContactTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumberField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SoCrm.Services.Contacts.Provider.ContactPersistence.ContactType ContactType {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Role", Namespace="http://schemas.datacontract.org/2004/07/SoCrm.Services.Security.Contracts")]
    public enum Role : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        User = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Administrator = 1,
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ContactPersistence.IPersistenceServiceOf_Contact")]
    public interface IPersistenceServiceOf_Contact {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Contact/Save", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Contact/SaveResponse")]
        void Save(SoCrm.Services.Contacts.Contracts.Contact entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Contact/Save", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Contact/SaveResponse")]
        System.Threading.Tasks.Task SaveAsync(SoCrm.Services.Contacts.Contracts.Contact entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Contact/Get", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Contact/GetResponse")]
        SoCrm.Services.Contacts.Contracts.Contact Get(System.Guid objectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Contact/Get", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Contact/GetResponse")]
        System.Threading.Tasks.Task<SoCrm.Services.Contacts.Contracts.Contact> GetAsync(System.Guid objectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Contact/GetAll", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Contact/GetAllResponse")]
        SoCrm.Services.Contacts.Contracts.Contact[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Contact/GetAll", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Contact/GetAllResponse")]
        System.Threading.Tasks.Task<SoCrm.Services.Contacts.Contracts.Contact[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Contact/Remove", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Contact/RemoveResponse")]
        void Remove(SoCrm.Services.Contacts.Contracts.Contact entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Contact/Remove", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Contact/RemoveResponse")]
        System.Threading.Tasks.Task RemoveAsync(SoCrm.Services.Contacts.Contracts.Contact entity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPersistenceServiceOf_ContactChannel : SoCrm.Services.Contacts.Provider.ContactPersistence.IPersistenceServiceOf_Contact, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PersistenceServiceOf_ContactClient : System.ServiceModel.ClientBase<SoCrm.Services.Contacts.Provider.ContactPersistence.IPersistenceServiceOf_Contact>, SoCrm.Services.Contacts.Provider.ContactPersistence.IPersistenceServiceOf_Contact {
        
        public PersistenceServiceOf_ContactClient() {
        }
        
        public PersistenceServiceOf_ContactClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PersistenceServiceOf_ContactClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersistenceServiceOf_ContactClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersistenceServiceOf_ContactClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Save(SoCrm.Services.Contacts.Contracts.Contact entity) {
            base.Channel.Save(entity);
        }
        
        public System.Threading.Tasks.Task SaveAsync(SoCrm.Services.Contacts.Contracts.Contact entity) {
            return base.Channel.SaveAsync(entity);
        }
        
        public SoCrm.Services.Contacts.Contracts.Contact Get(System.Guid objectId) {
            return base.Channel.Get(objectId);
        }
        
        public System.Threading.Tasks.Task<SoCrm.Services.Contacts.Contracts.Contact> GetAsync(System.Guid objectId) {
            return base.Channel.GetAsync(objectId);
        }
        
        public SoCrm.Services.Contacts.Contracts.Contact[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<SoCrm.Services.Contacts.Contracts.Contact[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void Remove(SoCrm.Services.Contacts.Contracts.Contact entity) {
            base.Channel.Remove(entity);
        }
        
        public System.Threading.Tasks.Task RemoveAsync(SoCrm.Services.Contacts.Contracts.Contact entity) {
            return base.Channel.RemoveAsync(entity);
        }
    }
}
