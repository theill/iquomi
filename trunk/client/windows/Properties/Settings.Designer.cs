﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.26
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Commanigy.Iquomi.Client.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:4081/webservices/IqPresence.asmx")]
        public string Commanigy_Iquomi_Client_Windows_IqPresenceRef_IqPresence {
            get {
                return ((string)(this["Commanigy_Iquomi_Client_Windows_IqPresenceRef_IqPresence"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:4081/webservices/IqPresence.asmx")]
        public string Commanigy_Iquomi_Client_Windows_IqServicesRef_IqPresence {
            get {
                return ((string)(this["Commanigy_Iquomi_Client_Windows_IqServicesRef_IqPresence"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:4081/webservices/IqProfile.asmx")]
        public string Commanigy_Iquomi_Client_Windows_IqProfileRef_IqProfile {
            get {
                return ((string)(this["Commanigy_Iquomi_Client_Windows_IqProfileRef_IqProfile"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("240, 530")]
        public global::System.Drawing.Size MainWindowSize {
            get {
                return ((global::System.Drawing.Size)(this["MainWindowSize"]));
            }
            set {
                this["MainWindowSize"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:4081/webservices/IqAlerts.asmx")]
        public string Commanigy_Iquomi_Client_Windows_IqServicesRef_IqAlerts {
            get {
                return ((string)(this["Commanigy_Iquomi_Client_Windows_IqServicesRef_IqAlerts"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:4081/webservices/IqContacts.asmx")]
        public string Commanigy_Iquomi_Client_Windows_IqServicesRef_IqContacts {
            get {
                return ((string)(this["Commanigy_Iquomi_Client_Windows_IqServicesRef_IqContacts"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:4081/webservices/IqCore.asmx")]
        public string Commanigy_Iquomi_Client_Windows_IqServicesRef_IqCore {
            get {
                return ((string)(this["Commanigy_Iquomi_Client_Windows_IqServicesRef_IqCore"]));
            }
        }
    }
}
