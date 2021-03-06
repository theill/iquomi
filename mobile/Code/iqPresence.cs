﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=1.1.4322.573.
// 
namespace Commanigy.Iquomi.Services {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/iqPresence")]
    [System.Xml.Serialization.XmlRootAttribute("iqPresence", Namespace="http://schemas.iquomi.com/2004/01/iqPresence", IsNullable=false)]
    public class iqPresenceType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("endpoint")]
        public endpointType[] endpoint;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("subscription")]
        public subscriptionType[] subscription;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string changeNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string instanceId;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/iqPresence")]
    public class endpointType {
        
        /// <remarks/>
        public string deviceUuid;
        
        /// <remarks/>
        public System.DateTime expiresAt;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool expiresAtSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("argot")]
        public argotType[] argot;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string changeNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="hexBinary")]
        public System.Byte[] creator;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/iqPresence")]
    public class argotType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
        public string argotURI;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string changeNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="hexBinary")]
        public System.Byte[] creator;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class subscriptionTypeContext {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
        public string uri;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class subscriptionTypeTrigger {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string select;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public subscriptionTypeTriggerMode mode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string baseChangeNumber;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public enum subscriptionTypeTriggerMode {
        
        /// <remarks/>
        includeData,
        
        /// <remarks/>
        excludeData,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class subscriptionType {
        
        /// <remarks/>
        public subscriptionTypeTrigger trigger;
        
        /// <remarks/>
        public System.DateTime expiresAt;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool expiresAtSpecified;
        
        /// <remarks/>
        public subscriptionTypeContext context;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
        public string to;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string changeNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="hexBinary")]
        public System.Byte[] creator;
    }
}
