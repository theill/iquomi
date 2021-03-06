﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version:2.0.40607.16
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.40607.16.
// 
namespace Commanigy.Iquomi.Client.SmartDevice.ServiceRef {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://services.iquomi.com/2004/01/core")]
    public class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        public SoapAuthenticationType SoapAuthenticationTypeValue;
        
        public SoapRequestType SoapRequestTypeValue;
        
        /// <remarks/>
        public Service() {
            this.Url = "http://services.iquomi.com/Service.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapAuthenticationTypeValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapRequestTypeValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.iquomi.com/2004/01/core/Insert", RequestNamespace="http://services.iquomi.com/2004/01/core", ResponseNamespace="http://services.iquomi.com/2004/01/core", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("InsertResponse", Namespace="http://schemas.iquomi.com/2004/01/core")]
        public InsertResponseType Insert([System.Xml.Serialization.XmlElementAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")] InsertRequestType InsertRequest) {
            object[] results = this.Invoke("Insert", new object[] {
                        InsertRequest});
            return ((InsertResponseType)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginInsert(InsertRequestType InsertRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Insert", new object[] {
                        InsertRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public InsertResponseType EndInsert(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((InsertResponseType)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapAuthenticationTypeValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapRequestTypeValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.iquomi.com/2004/01/core/Delete", RequestNamespace="http://services.iquomi.com/2004/01/core", ResponseNamespace="http://services.iquomi.com/2004/01/core", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("DeleteResponse", Namespace="http://schemas.iquomi.com/2004/01/core")]
        public DeleteResponseType Delete([System.Xml.Serialization.XmlElementAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")] DeleteRequestType DeleteRequest) {
            object[] results = this.Invoke("Delete", new object[] {
                        DeleteRequest});
            return ((DeleteResponseType)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDelete(DeleteRequestType DeleteRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Delete", new object[] {
                        DeleteRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public DeleteResponseType EndDelete(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((DeleteResponseType)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapAuthenticationTypeValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapRequestTypeValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.iquomi.com/2004/01/core/Replace", RequestNamespace="http://services.iquomi.com/2004/01/core", ResponseNamespace="http://services.iquomi.com/2004/01/core", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("ReplaceResponse", Namespace="http://schemas.iquomi.com/2004/01/core")]
        public ReplaceResponseType Replace([System.Xml.Serialization.XmlElementAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")] ReplaceRequestType ReplaceRequest) {
            object[] results = this.Invoke("Replace", new object[] {
                        ReplaceRequest});
            return ((ReplaceResponseType)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginReplace(ReplaceRequestType ReplaceRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Replace", new object[] {
                        ReplaceRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public ReplaceResponseType EndReplace(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ReplaceResponseType)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapAuthenticationTypeValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapRequestTypeValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.iquomi.com/2004/01/core/Update", RequestNamespace="http://services.iquomi.com/2004/01/core", ResponseNamespace="http://services.iquomi.com/2004/01/core", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("UpdateResponse", Namespace="http://schemas.iquomi.com/2004/01/core")]
        public UpdateResponseType Update([System.Xml.Serialization.XmlArrayAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")] [System.Xml.Serialization.XmlArrayItemAttribute("UpdateBlock", IsNullable=false)] UpdateBlockType[] UpdateRequest) {
            object[] results = this.Invoke("Update", new object[] {
                        UpdateRequest});
            return ((UpdateResponseType)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdate(UpdateBlockType[] UpdateRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Update", new object[] {
                        UpdateRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public UpdateResponseType EndUpdate(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((UpdateResponseType)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapAuthenticationTypeValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapRequestTypeValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.iquomi.com/2004/01/core/Query", RequestNamespace="http://services.iquomi.com/2004/01/core", ResponseNamespace="http://services.iquomi.com/2004/01/core", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("QueryResponse", Namespace="http://schemas.iquomi.com/2004/01/core")]
        public QueryResponseType Query([System.Xml.Serialization.XmlElementAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")] QueryRequestType QueryRequest) {
            object[] results = this.Invoke("Query", new object[] {
                        QueryRequest});
            return ((QueryResponseType)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginQuery(QueryRequestType QueryRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Query", new object[] {
                        QueryRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public QueryResponseType EndQuery(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((QueryResponseType)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapAuthenticationTypeValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SoapRequestTypeValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.iquomi.com/2004/01/core/Listen", RequestNamespace="http://services.iquomi.com/2004/01/core", ResponseNamespace="http://services.iquomi.com/2004/01/core", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("ListenResponse", Namespace="http://schemas.iquomi.com/2004/01/core")]
        public ListenResponseType Listen([System.Xml.Serialization.XmlElementAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")] ListenRequestType ListenRequest) {
            object[] results = this.Invoke("Listen", new object[] {
                        ListenRequest});
            return ((ListenResponseType)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginListen(ListenRequestType ListenRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Listen", new object[] {
                        ListenRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public ListenResponseType EndListen(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ListenResponseType)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.iquomi.com/2004/01/core")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://services.iquomi.com/2004/01/core", IsNullable=false)]
    public class SoapAuthenticationType : System.Web.Services.Protocols.SoapHeader {
        
        /// <remarks/>
        public string Iqid;
        
        /// <remarks/>
        public string Password;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ListenResponseType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SelectedNodeCount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SelectedNodeCountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ResponseStatus Status;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public enum ResponseStatus {
        
        /// <remarks/>
        Success,
        
        /// <remarks/>
        Failure,
        
        /// <remarks/>
        Rollback,
        
        /// <remarks/>
        NotAttempted,
        
        /// <remarks/>
        AccessDenied,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ListenRequestTypeContext {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
        public string Uri;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ListenRequestType {
        
        /// <remarks/>
        public ListenRequestTypeContext Context;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
        public string To;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Select;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MinOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinOccursSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MaxOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxOccursSpecified;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class DeletedBlueType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ChangedBlueType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ChangeQueryResponseType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChangedBlue")]
        public ChangedBlueType[] ChangedBlue;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DeletedBlue")]
        public DeletedBlueType[] DeletedBlue;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string BaseChangeNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SelectedNodeCount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SelectedNodeCountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ResponseStatus Status;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class XpQueryResponseType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SelectedNodeCount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SelectedNodeCountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ResponseStatus Status;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class QueryResponseType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("XpQueryResponse")]
        public XpQueryResponseType[] XpQueryResponse;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChangeQueryResponse")]
        public ChangeQueryResponseType[] ChangeQueryResponse;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ChangeQueryType {
        
        /// <remarks/>
        public QueryOptionsType Options;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Select;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string BaseChangeNumber;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class QueryOptionsType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Sort")]
        public SortType[] Sort;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Range")]
        public RangeType[] Range;
        
        /// <remarks/>
        public ShapeType Shape;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class SortType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(SortTypeDirection.Ascending)]
        public SortTypeDirection Direction;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key;
        
        public SortType() {
            this.Direction = SortTypeDirection.Ascending;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public enum SortTypeDirection {
        
        /// <remarks/>
        Ascending,
        
        /// <remarks/>
        Descending,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class RangeType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string First;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Count;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ShapeType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Include")]
        public ShapeAtomType[] Include;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Exclude")]
        public ShapeAtomType[] Exclude;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ShapeTypeBase Base;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BaseSpecified;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ShapeAtomType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Select;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public enum ShapeTypeBase {
        
        /// <remarks/>
        T,
        
        /// <remarks/>
        Nil,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class XpQueryType {
        
        /// <remarks/>
        public QueryOptionsType Options;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Select;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MinOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinOccursSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MaxOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxOccursSpecified;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class QueryRequestType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("XpQuery")]
        public XpQueryType[] XpQuery;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChangeQuery")]
        public ChangeQueryType[] ChangeQuery;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class UpdateBlockStatusType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InsertResponse")]
        public InsertResponseType[] InsertResponse;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DeleteResponse")]
        public DeleteResponseType[] DeleteResponse;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReplaceResponse")]
        public ReplaceResponseType[] ReplaceResponse;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SelectedNodeCount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SelectedNodeCountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ResponseStatus Status;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class InsertResponseType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NewBlueId")]
        public NewBlueIdType[] NewBlueId;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string NewChangeNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SelectedNodeCount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SelectedNodeCountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ResponseStatus Status;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class NewBlueIdType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class DeleteResponseType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string NewChangeNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SelectedNodeCount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SelectedNodeCountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ResponseStatus Status;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ReplaceResponseType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NewBlueId")]
        public NewBlueIdType[] NewBlueId;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string NewChangeNumber;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SelectedNodeCount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SelectedNodeCountSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ResponseStatus Status;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class UpdateResponseType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UpdateBlockStatus")]
        public UpdateBlockStatusType[] UpdateBlockStatus;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string NewChangeNumber;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class UpdateBlockType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InsertRequest")]
        public InsertRequestType[] InsertRequest;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DeleteRequest")]
        public DeleteRequestType[] DeleteRequest;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReplaceRequest")]
        public ReplaceRequestType[] ReplaceRequest;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Select;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public UpdateBlockTypeOnError OnError;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class InsertRequestType {
        
        /// <remarks/>
        public InsertRequestOptionsType Options;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Attributes")]
        public RedAttributeType[] Attributes;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Select;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool UseClientIds;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UseClientIdsSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MinOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinOccursSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MaxOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxOccursSpecified;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class InsertRequestOptionsType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class RedAttributeType {
        
        /// <remarks/>
        public string Name;
        
        /// <remarks/>
        public string Value;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class DeleteRequestType {
        
        /// <remarks/>
        public DeleteRequestOptionsType Options;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Select;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MinOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinOccursSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MaxOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxOccursSpecified;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class DeleteRequestOptionsType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ReplaceRequestType {
        
        /// <remarks/>
        public ReplaceRequestOptionsType Options;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Attributes")]
        public RedAttributeType[] Attributes;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Select;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool UseClientIds;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UseClientIdsSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MinOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinOccursSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MaxOccurs;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxOccursSpecified;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class ReplaceRequestOptionsType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public enum UpdateBlockTypeOnError {
        
        /// <remarks/>
        RollbackBlockAndFail,
        
        /// <remarks/>
        RollbackBlockAndContinue,
        
        /// <remarks/>
        Ignore,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class RequestTypeKey {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Puid;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Instance;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Cluster;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public class RequestType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Key")]
        public RequestTypeKey[] Key;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Service;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public RequestTypeDocument Document;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public RequestTypeMethod Method;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public RequestTypeGenResponse GenResponse;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public enum RequestTypeDocument {
        
        /// <remarks/>
        Content,
        
        /// <remarks/>
        RoleList,
        
        /// <remarks/>
        Policy,
        
        /// <remarks/>
        System,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public enum RequestTypeMethod {
        
        /// <remarks/>
        Insert,
        
        /// <remarks/>
        Delete,
        
        /// <remarks/>
        Replace,
        
        /// <remarks/>
        Update,
        
        /// <remarks/>
        Query,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.iquomi.com/2004/01/core")]
    public enum RequestTypeGenResponse {
        
        /// <remarks/>
        Always,
        
        /// <remarks/>
        Never,
        
        /// <remarks/>
        FaultOnly,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.iquomi.com/2004/01/core")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://services.iquomi.com/2004/01/core", IsNullable=false)]
    public class SoapRequestType : System.Web.Services.Protocols.SoapHeader {
        
        /// <remarks/>
        public RequestType Value;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr;
    }
}
