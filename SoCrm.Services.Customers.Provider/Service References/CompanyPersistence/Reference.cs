﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Provider.CompanyPersistence {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CompanyPersistence.IPersistenceServiceOf_Company")]
    public interface IPersistenceServiceOf_Company {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Company/Save", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Company/SaveResponse")]
        System.Guid Save(SoCrm.Services.Customers.Contracts.Company entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Company/Get", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Company/GetResponse")]
        SoCrm.Services.Customers.Contracts.Company Get(System.Guid objectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Company/GetAll", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Company/GetAllResponse")]
        System.Collections.Generic.List<SoCrm.Services.Customers.Contracts.Company> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_Company/Remove", ReplyAction="http://tempuri.org/IPersistenceServiceOf_Company/RemoveResponse")]
        void Remove(SoCrm.Services.Customers.Contracts.Company entity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPersistenceServiceOf_CompanyChannel : SoCrm.Services.Customers.Provider.CompanyPersistence.IPersistenceServiceOf_Company, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PersistenceServiceOf_CompanyClient : System.ServiceModel.ClientBase<SoCrm.Services.Customers.Provider.CompanyPersistence.IPersistenceServiceOf_Company>, SoCrm.Services.Customers.Provider.CompanyPersistence.IPersistenceServiceOf_Company {
        
        public PersistenceServiceOf_CompanyClient() {
        }
        
        public PersistenceServiceOf_CompanyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PersistenceServiceOf_CompanyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersistenceServiceOf_CompanyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersistenceServiceOf_CompanyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Guid Save(SoCrm.Services.Customers.Contracts.Company entity) {
            return base.Channel.Save(entity);
        }
        
        public SoCrm.Services.Customers.Contracts.Company Get(System.Guid objectId) {
            return base.Channel.Get(objectId);
        }
        
        public System.Collections.Generic.List<SoCrm.Services.Customers.Contracts.Company> GetAll() {
            return base.Channel.GetAll();
        }
        
        public void Remove(SoCrm.Services.Customers.Contracts.Company entity) {
            base.Channel.Remove(entity);
        }
    }
}
