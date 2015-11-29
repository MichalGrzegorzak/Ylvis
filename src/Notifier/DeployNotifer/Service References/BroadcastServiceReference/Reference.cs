﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeployNotifer.BroadcastServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EventDataType", Namespace="http://schemas.datacontract.org/2004/07/WcfBroadcastService")]
    [System.SerializableAttribute()]
    public partial class EventDataType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClientNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EventMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MinutesField;
        
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
        public string ClientName {
            get {
                return this.ClientNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientNameField, value) != true)) {
                    this.ClientNameField = value;
                    this.RaisePropertyChanged("ClientName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EventMessage {
            get {
                return this.EventMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.EventMessageField, value) != true)) {
                    this.EventMessageField = value;
                    this.RaisePropertyChanged("EventMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Minutes {
            get {
                return this.MinutesField;
            }
            set {
                if ((this.MinutesField.Equals(value) != true)) {
                    this.MinutesField = value;
                    this.RaisePropertyChanged("Minutes");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BroadcastServiceReference.IBroadcastService", CallbackContract=typeof(DeployNotifer.BroadcastServiceReference.IBroadcastServiceCallback))]
    public interface IBroadcastService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBroadcastService/RegisterClient")]
        void RegisterClient(string clientName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBroadcastService/RegisterClient")]
        System.Threading.Tasks.Task RegisterClientAsync(string clientName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBroadcastService/NotifyServer")]
        void NotifyServer(DeployNotifer.BroadcastServiceReference.EventDataType eventData);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBroadcastService/NotifyServer")]
        System.Threading.Tasks.Task NotifyServerAsync(DeployNotifer.BroadcastServiceReference.EventDataType eventData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBroadcastServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IBroadcastService/BroadcastToClient")]
        void BroadcastToClient(DeployNotifer.BroadcastServiceReference.EventDataType eventData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBroadcastServiceChannel : DeployNotifer.BroadcastServiceReference.IBroadcastService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BroadcastServiceClient : System.ServiceModel.DuplexClientBase<DeployNotifer.BroadcastServiceReference.IBroadcastService>, DeployNotifer.BroadcastServiceReference.IBroadcastService {
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void RegisterClient(string clientName) {
            base.Channel.RegisterClient(clientName);
        }
        
        public System.Threading.Tasks.Task RegisterClientAsync(string clientName) {
            return base.Channel.RegisterClientAsync(clientName);
        }
        
        public void NotifyServer(DeployNotifer.BroadcastServiceReference.EventDataType eventData) {
            base.Channel.NotifyServer(eventData);
        }
        
        public System.Threading.Tasks.Task NotifyServerAsync(DeployNotifer.BroadcastServiceReference.EventDataType eventData) {
            return base.Channel.NotifyServerAsync(eventData);
        }
    }
}
