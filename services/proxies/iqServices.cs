﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50215.44
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50215.44.
// 
namespace Commanigy.Iquomi.Services {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.iquomi.com/2004/01/iqServices")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.iquomi.com/2004/01/iqServices", IsNullable=false)]
    public partial class iqServices {
        
        private serviceType[] serviceField;
        
        private System.Xml.XmlElement[] anyField;
        
        private string changeNumberField;
        
        private string instanceIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("service")]
        public serviceType[] service {
            get {
                return this.serviceField;
            }
            set {
                this.serviceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://schemas.iquomi.com/2004/01/core", DataType="nonNegativeInteger")]
        public string ChangeNumber {
            get {
                return this.changeNumberField;
            }
            set {
                this.changeNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://schemas.iquomi.com/2004/01/core")]
        public string InstanceId {
            get {
                return this.instanceIdField;
            }
            set {
                this.instanceIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/iqServices")]
    public partial class serviceType {
        
        private CatType[] catField;
        
        private serviceTypeKey keyField;
        
        private string referField;
        
        private string toField;
        
        private string spnField;
        
        private string realmField;
        
        private System.Xml.XmlElement[] anyField;
        
        private string nameField;
        
        private string changeNumberField;
        
        private string idField;
        
        private byte[] creatorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("cat")]
        public CatType[] cat {
            get {
                return this.catField;
            }
            set {
                this.catField = value;
            }
        }
        
        /// <remarks/>
        public serviceTypeKey key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        public string refer {
            get {
                return this.referField;
            }
            set {
                this.referField = value;
            }
        }
        
        /// <remarks/>
        public string to {
            get {
                return this.toField;
            }
            set {
                this.toField = value;
            }
        }
        
        /// <remarks/>
        public string spn {
            get {
                return this.spnField;
            }
            set {
                this.spnField = value;
            }
        }
        
        /// <remarks/>
        public string realm {
            get {
                return this.realmField;
            }
            set {
                this.realmField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://schemas.iquomi.com/2004/01/core", DataType="nonNegativeInteger")]
        public string ChangeNumber {
            get {
                return this.changeNumberField;
            }
            set {
                this.changeNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://schemas.iquomi.com/2004/01/core")]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://schemas.iquomi.com/2004/01/core", DataType="hexBinary")]
        public byte[] Creator {
            get {
                return this.creatorField;
            }
            set {
                this.creatorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public partial class CatType {
        
        private string refField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="anyURI")]
        public string Ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.iquomi.com/2004/01/iqServices")]
    public partial class serviceTypeKey {
        
        private string puidField;
        
        private string instanceField;
        
        private string clusterField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string puid {
            get {
                return this.puidField;
            }
            set {
                this.puidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string instance {
            get {
                return this.instanceField;
            }
            set {
                this.instanceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string cluster {
            get {
                return this.clusterField;
            }
            set {
                this.clusterField = value;
            }
        }
    }
}