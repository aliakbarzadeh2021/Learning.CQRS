//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Learning.CQRS.WriteApi {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class HostSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static HostSettings defaultInstance = ((HostSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new HostSettings())));
        
        public static HostSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("*")]
        public string Origins {
            get {
                return ((string)(this["Origins"]));
            }
            set {
                this["Origins"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("admin")]
        public string RabbitMQ_UserName {
            get {
                return ((string)(this["RabbitMQ_UserName"]));
            }
            set {
                this["RabbitMQ_UserName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.3.202")]
        public string RabbitMQ_ServerName {
            get {
                return ((string)(this["RabbitMQ_ServerName"]));
            }
            set {
                this["RabbitMQ_ServerName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("admin")]
        public string RabbitMQ_Password {
            get {
                return ((string)(this["RabbitMQ_Password"]));
            }
            set {
                this["RabbitMQ_Password"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:15788")]
        public string HostApiAddress {
            get {
                return ((string)(this["HostApiAddress"]));
            }
            set {
                this["HostApiAddress"] = value;
            }
        }
    }
}
