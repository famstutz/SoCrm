﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Provider.PersonPersistence {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PersonPersistence.IPersistenceServiceOf_Person")]
    public interface IPersistenceServiceOf_Person {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Person/Save", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Person/SaveResponse")]
        System.Guid Save(SoCrm.Services.Customers.Contracts.Person entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Person/Get", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Person/GetResponse")]
        SoCrm.Services.Customers.Contracts.Person Get(System.Guid objectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Person/GetAll", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Person/GetAllResponse")]
        System.Collections.Generic.List<SoCrm.Services.Customers.Contracts.Person> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Person/Remove", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Person/RemoveResponse")]
        void Remove(SoCrm.Services.Customers.Contracts.Person entity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPersistenceServiceOf_PersonChannel : SoCrm.Services.Customers.Provider.PersonPersistence.IPersistenceServiceOf_Person, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PersistenceServiceOf_PersonClient : System.ServiceModel.ClientBase<SoCrm.Services.Customers.Provider.PersonPersistence.IPersistenceServiceOf_Person>, SoCrm.Services.Customers.Provider.PersonPersistence.IPersistenceServiceOf_Person {
        
        public PersistenceServiceOf_PersonClient() {
        }
        
        public PersistenceServiceOf_PersonClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PersistenceServiceOf_PersonClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersistenceServiceOf_PersonClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersistenceServiceOf_PersonClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Guid Save(SoCrm.Services.Customers.Contracts.Person entity) {
            return base.Channel.Save(entity);
        }
        
        public SoCrm.Services.Customers.Contracts.Person Get(System.Guid objectId) {
            return base.Channel.Get(objectId);
        }
        
        public System.Collections.Generic.List<SoCrm.Services.Customers.Contracts.Person> GetAll() {
            return base.Channel.GetAll();
        }
        
        public void Remove(SoCrm.Services.Customers.Contracts.Person entity) {
            base.Channel.Remove(entity);
        }
    }
}
