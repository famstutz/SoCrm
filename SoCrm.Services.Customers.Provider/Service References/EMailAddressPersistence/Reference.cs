﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoCrm.Services.Customers.Provider.EMailAddressPersistence {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EMailAddressPersistence.IPersistenceServiceOf_EMailAddress")]
    public interface IPersistenceServiceOf_EMailAddress {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_EMailAddress/Save", ReplyAction="http://tempuri.org/IPersistenceServiceOf_EMailAddress/SaveResponse")]
        System.Guid Save(SoCrm.Services.Customers.Contracts.EMailAddress entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_EMailAddress/Get", ReplyAction="http://tempuri.org/IPersistenceServiceOf_EMailAddress/GetResponse")]
        SoCrm.Services.Customers.Contracts.EMailAddress Get(System.Guid objectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_EMailAddress/GetAll", ReplyAction="http://tempuri.org/IPersistenceServiceOf_EMailAddress/GetAllResponse")]
        System.Collections.Generic.List<SoCrm.Services.Customers.Contracts.EMailAddress> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersistenceServiceOf_EMailAddress/Remove", ReplyAction="http://tempuri.org/IPersistenceServiceOf_EMailAddress/RemoveResponse")]
        void Remove(SoCrm.Services.Customers.Contracts.EMailAddress entity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPersistenceServiceOf_EMailAddressChannel : SoCrm.Services.Customers.Provider.EMailAddressPersistence.IPersistenceServiceOf_EMailAddress, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PersistenceServiceOf_EMailAddressClient : System.ServiceModel.ClientBase<SoCrm.Services.Customers.Provider.EMailAddressPersistence.IPersistenceServiceOf_EMailAddress>, SoCrm.Services.Customers.Provider.EMailAddressPersistence.IPersistenceServiceOf_EMailAddress {
        
        public PersistenceServiceOf_EMailAddressClient() {
        }
        
        public PersistenceServiceOf_EMailAddressClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PersistenceServiceOf_EMailAddressClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersistenceServiceOf_EMailAddressClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersistenceServiceOf_EMailAddressClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Guid Save(SoCrm.Services.Customers.Contracts.EMailAddress entity) {
            return base.Channel.Save(entity);
        }
        
        public SoCrm.Services.Customers.Contracts.EMailAddress Get(System.Guid objectId) {
            return base.Channel.Get(objectId);
        }
        
        public System.Collections.Generic.List<SoCrm.Services.Customers.Contracts.EMailAddress> GetAll() {
            return base.Channel.GetAll();
        }
        
        public void Remove(SoCrm.Services.Customers.Contracts.EMailAddress entity) {
            base.Channel.Remove(entity);
        }
    }
}
