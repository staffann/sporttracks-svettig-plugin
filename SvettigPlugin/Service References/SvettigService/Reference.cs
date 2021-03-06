﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SvettigPlugin.SvettigService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Application", Namespace="http://schemas.datacontract.org/2004/07/SvettigWorkoutService")]
    public enum Application : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SVETTIG_IOS = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SVETTIG_ANDROID = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RUNNERUP = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SPORT_TRACKS_PLUGIN = 4,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Registration", Namespace="http://schemas.datacontract.org/2004/07/SvettigWorkoutService")]
    [System.SerializableAttribute()]
    public partial class Registration : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int applicationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string birthdateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cityField;
        
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int sexField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int application {
            get {
                return this.applicationField;
            }
            set {
                if ((this.applicationField.Equals(value) != true)) {
                    this.applicationField = value;
                    this.RaisePropertyChanged("application");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string birthdate {
            get {
                return this.birthdateField;
            }
            set {
                if ((object.ReferenceEquals(this.birthdateField, value) != true)) {
                    this.birthdateField = value;
                    this.RaisePropertyChanged("birthdate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string city {
            get {
                return this.cityField;
            }
            set {
                if ((object.ReferenceEquals(this.cityField, value) != true)) {
                    this.cityField = value;
                    this.RaisePropertyChanged("city");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int sex {
            get {
                return this.sexField;
            }
            set {
                if ((this.sexField.Equals(value) != true)) {
                    this.sexField = value;
                    this.RaisePropertyChanged("sex");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Workout", Namespace="http://schemas.datacontract.org/2004/07/SvettigWorkoutService")]
    [System.SerializableAttribute()]
    public partial class Workout : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string appVersionField;
        
        private int applicationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int avgPulseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int borgValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string commentField;
        
        private string createdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string deviceModelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float distanceInMetersField;
        
        private string emailField;
        
        private string encryptedPasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int equipmentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int[] friendsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string hiddenCommentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int maxPulseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string operatingSystemField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int routeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float timeInSecondsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SvettigPlugin.SvettigService.Tracksegment[] tracksegmentsField;
        
        private int workoutCategoryField;
        
        private int workoutSubcategoryField;
        
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
        public string appVersion {
            get {
                return this.appVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.appVersionField, value) != true)) {
                    this.appVersionField = value;
                    this.RaisePropertyChanged("appVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int application {
            get {
                return this.applicationField;
            }
            set {
                if ((this.applicationField.Equals(value) != true)) {
                    this.applicationField = value;
                    this.RaisePropertyChanged("application");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int avgPulse {
            get {
                return this.avgPulseField;
            }
            set {
                if ((this.avgPulseField.Equals(value) != true)) {
                    this.avgPulseField = value;
                    this.RaisePropertyChanged("avgPulse");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int borgValue {
            get {
                return this.borgValueField;
            }
            set {
                if ((this.borgValueField.Equals(value) != true)) {
                    this.borgValueField = value;
                    this.RaisePropertyChanged("borgValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string comment {
            get {
                return this.commentField;
            }
            set {
                if ((object.ReferenceEquals(this.commentField, value) != true)) {
                    this.commentField = value;
                    this.RaisePropertyChanged("comment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string created {
            get {
                return this.createdField;
            }
            set {
                if ((object.ReferenceEquals(this.createdField, value) != true)) {
                    this.createdField = value;
                    this.RaisePropertyChanged("created");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string deviceModel {
            get {
                return this.deviceModelField;
            }
            set {
                if ((object.ReferenceEquals(this.deviceModelField, value) != true)) {
                    this.deviceModelField = value;
                    this.RaisePropertyChanged("deviceModel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float distanceInMeters {
            get {
                return this.distanceInMetersField;
            }
            set {
                if ((this.distanceInMetersField.Equals(value) != true)) {
                    this.distanceInMetersField = value;
                    this.RaisePropertyChanged("distanceInMeters");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string encryptedPassword {
            get {
                return this.encryptedPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.encryptedPasswordField, value) != true)) {
                    this.encryptedPasswordField = value;
                    this.RaisePropertyChanged("encryptedPassword");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int equipmentId {
            get {
                return this.equipmentIdField;
            }
            set {
                if ((this.equipmentIdField.Equals(value) != true)) {
                    this.equipmentIdField = value;
                    this.RaisePropertyChanged("equipmentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] friends {
            get {
                return this.friendsField;
            }
            set {
                if ((object.ReferenceEquals(this.friendsField, value) != true)) {
                    this.friendsField = value;
                    this.RaisePropertyChanged("friends");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string hiddenComment {
            get {
                return this.hiddenCommentField;
            }
            set {
                if ((object.ReferenceEquals(this.hiddenCommentField, value) != true)) {
                    this.hiddenCommentField = value;
                    this.RaisePropertyChanged("hiddenComment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int maxPulse {
            get {
                return this.maxPulseField;
            }
            set {
                if ((this.maxPulseField.Equals(value) != true)) {
                    this.maxPulseField = value;
                    this.RaisePropertyChanged("maxPulse");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string operatingSystem {
            get {
                return this.operatingSystemField;
            }
            set {
                if ((object.ReferenceEquals(this.operatingSystemField, value) != true)) {
                    this.operatingSystemField = value;
                    this.RaisePropertyChanged("operatingSystem");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int routeId {
            get {
                return this.routeIdField;
            }
            set {
                if ((this.routeIdField.Equals(value) != true)) {
                    this.routeIdField = value;
                    this.RaisePropertyChanged("routeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float timeInSeconds {
            get {
                return this.timeInSecondsField;
            }
            set {
                if ((this.timeInSecondsField.Equals(value) != true)) {
                    this.timeInSecondsField = value;
                    this.RaisePropertyChanged("timeInSeconds");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SvettigPlugin.SvettigService.Tracksegment[] tracksegments {
            get {
                return this.tracksegmentsField;
            }
            set {
                if ((object.ReferenceEquals(this.tracksegmentsField, value) != true)) {
                    this.tracksegmentsField = value;
                    this.RaisePropertyChanged("tracksegments");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int workoutCategory {
            get {
                return this.workoutCategoryField;
            }
            set {
                if ((this.workoutCategoryField.Equals(value) != true)) {
                    this.workoutCategoryField = value;
                    this.RaisePropertyChanged("workoutCategory");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int workoutSubcategory {
            get {
                return this.workoutSubcategoryField;
            }
            set {
                if ((this.workoutSubcategoryField.Equals(value) != true)) {
                    this.workoutSubcategoryField = value;
                    this.RaisePropertyChanged("workoutSubcategory");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Tracksegment", Namespace="http://schemas.datacontract.org/2004/07/SvettigWorkoutService")]
    [System.SerializableAttribute()]
    public partial class Tracksegment : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string createdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float distanceInMetersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double pausedSecondsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SvettigPlugin.SvettigService.Trackpoint[] trackpointsField;
        
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
        public string created {
            get {
                return this.createdField;
            }
            set {
                if ((object.ReferenceEquals(this.createdField, value) != true)) {
                    this.createdField = value;
                    this.RaisePropertyChanged("created");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float distanceInMeters {
            get {
                return this.distanceInMetersField;
            }
            set {
                if ((this.distanceInMetersField.Equals(value) != true)) {
                    this.distanceInMetersField = value;
                    this.RaisePropertyChanged("distanceInMeters");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double pausedSeconds {
            get {
                return this.pausedSecondsField;
            }
            set {
                if ((this.pausedSecondsField.Equals(value) != true)) {
                    this.pausedSecondsField = value;
                    this.RaisePropertyChanged("pausedSeconds");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SvettigPlugin.SvettigService.Trackpoint[] trackpoints {
            get {
                return this.trackpointsField;
            }
            set {
                if ((object.ReferenceEquals(this.trackpointsField, value) != true)) {
                    this.trackpointsField = value;
                    this.RaisePropertyChanged("trackpoints");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Trackpoint", Namespace="http://schemas.datacontract.org/2004/07/SvettigWorkoutService")]
    [System.SerializableAttribute()]
    public partial class Trackpoint : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float altitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string createdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int heartrateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float latitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float longitudeField;
        
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
        public float altitude {
            get {
                return this.altitudeField;
            }
            set {
                if ((this.altitudeField.Equals(value) != true)) {
                    this.altitudeField = value;
                    this.RaisePropertyChanged("altitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string created {
            get {
                return this.createdField;
            }
            set {
                if ((object.ReferenceEquals(this.createdField, value) != true)) {
                    this.createdField = value;
                    this.RaisePropertyChanged("created");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int heartrate {
            get {
                return this.heartrateField;
            }
            set {
                if ((this.heartrateField.Equals(value) != true)) {
                    this.heartrateField = value;
                    this.RaisePropertyChanged("heartrate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float latitude {
            get {
                return this.latitudeField;
            }
            set {
                if ((this.latitudeField.Equals(value) != true)) {
                    this.latitudeField = value;
                    this.RaisePropertyChanged("latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float longitude {
            get {
                return this.longitudeField;
            }
            set {
                if ((this.longitudeField.Equals(value) != true)) {
                    this.longitudeField = value;
                    this.RaisePropertyChanged("longitude");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SvettigService.IWorkoutService")]
    public interface IWorkoutService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkoutService/Login", ReplyAction="http://tempuri.org/IWorkoutService/LoginResponse")]
        System.Collections.Generic.Dictionary<string, object> Login(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkoutService/GetMessage", ReplyAction="http://tempuri.org/IWorkoutService/GetMessageResponse")]
        System.Collections.Generic.Dictionary<string, object> GetMessage(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkoutService/GetRoutes", ReplyAction="http://tempuri.org/IWorkoutService/GetRoutesResponse")]
        System.Collections.Generic.Dictionary<string, object> GetRoutes(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkoutService/GetWorkoutCategories", ReplyAction="http://tempuri.org/IWorkoutService/GetWorkoutCategoriesResponse")]
        System.Collections.Generic.Dictionary<string, object> GetWorkoutCategories(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkoutService/GetEquipment", ReplyAction="http://tempuri.org/IWorkoutService/GetEquipmentResponse")]
        System.Collections.Generic.Dictionary<string, object> GetEquipment(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkoutService/GetFriends", ReplyAction="http://tempuri.org/IWorkoutService/GetFriendsResponse")]
        System.Collections.Generic.Dictionary<object, object> GetFriends(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkoutService/SyncUser", ReplyAction="http://tempuri.org/IWorkoutService/SyncUserResponse")]
        System.Collections.Generic.Dictionary<string, object> SyncUser(SvettigPlugin.SvettigService.Registration user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkoutService/SyncWorkout", ReplyAction="http://tempuri.org/IWorkoutService/SyncWorkoutResponse")]
        System.Collections.Generic.Dictionary<string, object> SyncWorkout(SvettigPlugin.SvettigService.Workout workout);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkoutService/RegisterManualWorkout", ReplyAction="http://tempuri.org/IWorkoutService/RegisterManualWorkoutResponse")]
        System.Collections.Generic.Dictionary<string, object> RegisterManualWorkout(SvettigPlugin.SvettigService.Workout fixedWorkout);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWorkoutServiceChannel : SvettigPlugin.SvettigService.IWorkoutService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WorkoutServiceClient : System.ServiceModel.ClientBase<SvettigPlugin.SvettigService.IWorkoutService>, SvettigPlugin.SvettigService.IWorkoutService {
        
        public WorkoutServiceClient() {
        }
        
        public WorkoutServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WorkoutServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkoutServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkoutServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.Dictionary<string, object> Login(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application) {
            return base.Channel.Login(email, encryptedPassword, application);
        }
        
        public System.Collections.Generic.Dictionary<string, object> GetMessage(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application) {
            return base.Channel.GetMessage(email, encryptedPassword, application);
        }
        
        public System.Collections.Generic.Dictionary<string, object> GetRoutes(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application) {
            return base.Channel.GetRoutes(email, encryptedPassword, application);
        }
        
        public System.Collections.Generic.Dictionary<string, object> GetWorkoutCategories(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application) {
            return base.Channel.GetWorkoutCategories(email, encryptedPassword, application);
        }
        
        public System.Collections.Generic.Dictionary<string, object> GetEquipment(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application) {
            return base.Channel.GetEquipment(email, encryptedPassword, application);
        }
        
        public System.Collections.Generic.Dictionary<object, object> GetFriends(string email, string encryptedPassword, SvettigPlugin.SvettigService.Application application) {
            return base.Channel.GetFriends(email, encryptedPassword, application);
        }
        
        public System.Collections.Generic.Dictionary<string, object> SyncUser(SvettigPlugin.SvettigService.Registration user) {
            return base.Channel.SyncUser(user);
        }
        
        public System.Collections.Generic.Dictionary<string, object> SyncWorkout(SvettigPlugin.SvettigService.Workout workout) {
            return base.Channel.SyncWorkout(workout);
        }
        
        public System.Collections.Generic.Dictionary<string, object> RegisterManualWorkout(SvettigPlugin.SvettigService.Workout fixedWorkout) {
            return base.Channel.RegisterManualWorkout(fixedWorkout);
        }
    }
}
