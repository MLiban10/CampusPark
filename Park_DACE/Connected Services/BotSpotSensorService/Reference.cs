﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Park_DACE.BotSpotSensorService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ParkingSpot", Namespace="http://schemas.datacontract.org/2004/07/BOT_SpotSensors")]
    [System.SerializableAttribute()]
    public partial class ParkingSpot : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateTimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IntBatteryStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StrIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StrLocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StrNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StrTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StrValueField;
        
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
        public System.DateTime DateTimeStamp {
            get {
                return this.DateTimeStampField;
            }
            set {
                if ((this.DateTimeStampField.Equals(value) != true)) {
                    this.DateTimeStampField = value;
                    this.RaisePropertyChanged("DateTimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IntBatteryStatus {
            get {
                return this.IntBatteryStatusField;
            }
            set {
                if ((this.IntBatteryStatusField.Equals(value) != true)) {
                    this.IntBatteryStatusField = value;
                    this.RaisePropertyChanged("IntBatteryStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StrId {
            get {
                return this.StrIdField;
            }
            set {
                if ((object.ReferenceEquals(this.StrIdField, value) != true)) {
                    this.StrIdField = value;
                    this.RaisePropertyChanged("StrId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StrLocation {
            get {
                return this.StrLocationField;
            }
            set {
                if ((object.ReferenceEquals(this.StrLocationField, value) != true)) {
                    this.StrLocationField = value;
                    this.RaisePropertyChanged("StrLocation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StrName {
            get {
                return this.StrNameField;
            }
            set {
                if ((object.ReferenceEquals(this.StrNameField, value) != true)) {
                    this.StrNameField = value;
                    this.RaisePropertyChanged("StrName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StrType {
            get {
                return this.StrTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.StrTypeField, value) != true)) {
                    this.StrTypeField = value;
                    this.RaisePropertyChanged("StrType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StrValue {
            get {
                return this.StrValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StrValueField, value) != true)) {
                    this.StrValueField = value;
                    this.RaisePropertyChanged("StrValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BotSpotSensorService.IServiceBOTSpotSensors")]
    public interface IServiceBOTSpotSensors {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceBOTSpotSensors/ParkingSpot", ReplyAction="http://tempuri.org/IServiceBOTSpotSensors/ParkingSpotResponse")]
        void ParkingSpot([System.ServiceModel.MessageParameterAttribute(Name="parkingSpot")] Park_DACE.BotSpotSensorService.ParkingSpot parkingSpot1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceBOTSpotSensors/ParkingSpot", ReplyAction="http://tempuri.org/IServiceBOTSpotSensors/ParkingSpotResponse")]
        System.Threading.Tasks.Task ParkingSpotAsync(Park_DACE.BotSpotSensorService.ParkingSpot parkingSpot);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceBOTSpotSensors/GetParkingSpotsXpath", ReplyAction="http://tempuri.org/IServiceBOTSpotSensors/GetParkingSpotsXpathResponse")]
        string GetParkingSpotsXpath();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceBOTSpotSensors/GetParkingSpotsXpath", ReplyAction="http://tempuri.org/IServiceBOTSpotSensors/GetParkingSpotsXpathResponse")]
        System.Threading.Tasks.Task<string> GetParkingSpotsXpathAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceBOTSpotSensorsChannel : Park_DACE.BotSpotSensorService.IServiceBOTSpotSensors, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceBOTSpotSensorsClient : System.ServiceModel.ClientBase<Park_DACE.BotSpotSensorService.IServiceBOTSpotSensors>, Park_DACE.BotSpotSensorService.IServiceBOTSpotSensors {
        
        public ServiceBOTSpotSensorsClient() {
        }
        
        public ServiceBOTSpotSensorsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceBOTSpotSensorsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceBOTSpotSensorsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceBOTSpotSensorsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ParkingSpot(Park_DACE.BotSpotSensorService.ParkingSpot parkingSpot1) {
            base.Channel.ParkingSpot(parkingSpot1);
        }
        
        public System.Threading.Tasks.Task ParkingSpotAsync(Park_DACE.BotSpotSensorService.ParkingSpot parkingSpot) {
            return base.Channel.ParkingSpotAsync(parkingSpot);
        }
        
        public string GetParkingSpotsXpath() {
            return base.Channel.GetParkingSpotsXpath();
        }
        
        public System.Threading.Tasks.Task<string> GetParkingSpotsXpathAsync() {
            return base.Channel.GetParkingSpotsXpathAsync();
        }
    }
}