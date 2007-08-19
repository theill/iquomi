using System;
using System.CodeDom;
using System.IO;
using System.Text;
using System.Web.Services.Configuration;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace Microsoft.Hs
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
    public class HsSoapExtensionAttribute : SoapExtensionAttribute
    {
        public HsSoapExtensionAttribute()
        {
        }
        public HsSoapExtensionAttribute(bool enabled)
        {
            m_enabled = enabled;
        }
        public override int Priority 
        {
            get
            { 
                return m_priority; 
            }
            set 
            {
                m_priority = value; 
            }
        }
        public bool Enabled 
        { 
            get 
            { 
                return m_enabled;
            }
            set
            {
                m_enabled = value; 
            }
        }
        public override Type ExtensionType 
        {
            get 
            { 
                return typeof(HsSoapExtension); 
            }
        }
        private int m_priority = 0;
        private bool m_enabled = true;
    }

    /// <summary>
    /// The Hs SoapExtension class responsible for intercepting and modifying the request and response soap 
    /// messages.
    /// </summary>
    public class HsSoapExtension : SoapExtension
    {
        public HsSoapExtension()
        {
        }

        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) 
        {
            HsSoapExtensionAttribute attr = attribute as HsSoapExtensionAttribute;
            if(attr != null) 
            {
                return attr.Enabled;
            }
            return true;
        }

        public override object GetInitializer(Type serviceType) 
        {
            return true;
        }

        public override void Initialize(object initializer) 
        {
            if(initializer is Boolean) 
            {
                m_enabled = (bool)initializer;
            }
        }
        
        public override Stream ChainStream(Stream stream) 
        {
            if(!m_enabled)
            {
                return base.ChainStream(stream);
            }
            m_oldStream = stream;
            m_newStream = new MemoryStream();
            return m_newStream;
        }
        
        /// <summary>
        /// This method is called at all stages of serialization / deserialization and provides
        /// the opportunity to modify the inbound / outbound message.
        /// </summary>
        public override void ProcessMessage(SoapMessage message) 
        {
            if(!m_enabled)
            {
                return;
            }
            switch(message.Stage) 
            {
                case SoapMessageStage.BeforeSerialize:
                {
                    break;
                }
                case SoapMessageStage.AfterSerialize:
                {
                    ProcessHsRequest(message);
                    break;
                }
                case SoapMessageStage.BeforeDeserialize:
                {
                    ProcessHsResponse(message);
                    break;
                }
                case SoapMessageStage.AfterDeserialize:
                {
                    break;
                }
            }
        }
      
        /// <summary>
        /// Used to intercept the HsRequest SOAP and modify it as needed.
        /// </summary>
        /// <remarks>
        ///	We need to determine if there is a more efficient way to parse this than
        ///	with a StringBuilder buffer.
		/// </remarks>
        private void ProcessHsRequest(SoapMessage message)
        {   
            //
            // set the new stream postion to the beginning
            //
            m_newStream.Position = 0;

            //
            // read the stream into a StringBuilder
            //
            TextReader reader = new StreamReader(m_newStream);
            TextWriter writer = new StreamWriter(m_oldStream);
            StringBuilder request = new StringBuilder();
            request.Append(reader.ReadToEnd());
            string requestString = request.ToString();

            //
            // find the location of the <request element
            //
            int requestPos = requestString.IndexOf(s_requestStartTag);

            //
            // determine the service name
            //
            int servicePos = requestString.IndexOf(s_serviceAttribute, requestPos) + s_serviceAttribute.Length;
            int servicePosEnd = requestString.IndexOf("\"", servicePos);
            string serviceName = requestString.Substring(servicePos, servicePosEnd - servicePos);
            
            //
            // get the 'action' being passed and store it in the m_action private member
            //
            int pathPos = requestString.IndexOf(s_pathStartTag);
            int actionPos = requestString.IndexOf(s_actionStartTag, pathPos);
            int actionPosEnd = requestString.IndexOf(s_actionCloseTag, actionPos) + s_actionCloseTag.Length;
            m_action = requestString.Substring(actionPos, actionPosEnd - actionPos);

            //
            // get the 'to' value being passed and store it in the m_to private member
            //
            int toPos = requestString.IndexOf(s_toStartTag, pathPos);
            int toPosEnd = requestString.IndexOf(s_toCloseTag, toPos) + s_toCloseTag.Length;
            m_to = requestString.Substring(toPos, toPosEnd - toPos);

            //
            // get the 'fwd' value being passed and store it in the m_forward private member
            //
            int fwdPos = requestString.IndexOf(s_fwdStartTag, pathPos);
            int fwdPosEnd = requestString.IndexOf(s_fwdCloseTag, fwdPos) + s_fwdCloseTag.Length;
            m_forward = requestString.Substring(fwdPos, fwdPosEnd - fwdPos);

            //
            // get the 'rev' value being passed and store it in the m_reverse private member
            //
            int revPos = requestString.IndexOf(s_revStartTag, pathPos);
            int revPosEnd = requestString.IndexOf(s_revCloseTag, revPos) + s_revCloseTag.Length;
            m_reverse = requestString.Substring(revPos, revPosEnd - revPos);

            
            //
            // get the postion of the request/@method attribute 
            //
            int methodAttPos = requestString.IndexOf(s_methodAttribute, servicePosEnd);
            int methodAttPosEnd = requestString.IndexOf("\"", methodAttPos);
            string methodAttribute = requestString.Substring(methodAttPos, s_methodAttribute.Length + (methodAttPosEnd - methodAttPos));

            //
            // determine the method being requestd
            //
            int bodyPos = requestString.IndexOf(s_soapBodyStartTag) + s_soapBodyStartTag.Length;
            int methodPos = requestString.IndexOf("<", bodyPos) + 1;
            int methodPosEnd = requestString.IndexOf("Request", methodPos);
            string methodName = requestString.Substring(methodPos, methodPosEnd - methodPos);

            //
            // see if a logfile was specified
            //
            int licensesPos = requestString.IndexOf(s_licensesStartTag);
            int logfileTagPos = requestString.IndexOf(s_logfileStartTag, licensesPos);
            if (logfileTagPos != -1)
            {
                int logfilePos = logfileTagPos + s_logfileStartTag.Length;
                int logfileEndPos = requestString.IndexOf(s_logfileEndTag, logfilePos);
                m_logfile = requestString.Substring(logfilePos, logfileEndPos - logfilePos);
                //
                // check to see if we're logging original messages
                //
                int flagPos = m_logfile.IndexOf(":logOriginalMessages");
                if(flagPos != -1)
                {
                    m_logOriginalMessages = true;
                    m_logfile = m_logfile.Substring(0, flagPos);
                }
                m_logfileTag = requestString.Substring(logfileTagPos, (logfileEndPos + s_logfileEndTag.Length) - logfileTagPos);
            }
            
            //
            // write the original request to the log file (this will only work if the logfile was initialized)
            //
            if(m_logOriginalMessages)
            {
                WriteToLogFile(request, "Original Request");
            }
            
            //
            // replace the method name with the one really being called (incase someone forgot to set this)
            // but start at the request tag and only replace up to the s:Body tag (for efficiency)
            //
            request.Replace(methodAttribute, "method=\"" + methodName + "\" ", requestPos, bodyPos - requestPos);
            
            //
            // insert a namespace declaration for the service
            //
            request.Replace(s_soapEnvelopeStartTag, "<soap:Envelope xmlns:m=\"http://schemas.microsoft.com/hs/2001/10/" + serviceName + "\"", 0, pathPos);

            //
            // remove the logfile tag if it was found
            //
            if(m_logfileTag != null)
            {
                request.Replace(m_logfileTag, "");
            }

            //
            // write the modified request to the log file
            //
            WriteToLogFile(request, "Modified Request");

            writer.Write(request.ToString());
            writer.Flush();
        }

        /// <summary>
        /// Used to intercept HsResponse SOAP and modify it as needed
        /// </summary>
		/// <remarks>
		///	We need to determine if there is a more efficient way to parse this than
		///	with a StringBuilder buffer.
		/// </remarks>
		private void ProcessHsResponse(SoapMessage message)
        {
            //
            // Write the response to the new stream
            //
            TextReader reader = new StreamReader(m_oldStream);
            TextWriter writer = new StreamWriter(m_newStream);
            StringBuilder response = new StringBuilder();
            response.Append(reader.ReadToEnd());
            
            //
            // write the original response to the log file
            //
            if(m_logOriginalMessages)
            {
                WriteToLogFile(response, "Original Response");
            }
            string responseString = response.ToString();
           
            //
            // find the location of the <path element
            //
            int pathPos = responseString.IndexOf(s_pathStartTag);

            //
            // get the action element
            //
            int actionPos = responseString.IndexOf(s_actionStartTag, pathPos);
            int actionPosEnd = responseString.IndexOf(s_actionCloseTag, actionPos) + s_actionCloseTag.Length;
            string action = responseString.Substring(actionPos, actionPosEnd - actionPos);
            
			//
			// get the rev element
			//
            int revPos = responseString.IndexOf(s_revStartTag, pathPos);
            int revPosEnd = responseString.IndexOf(s_revCloseTag, revPos) + s_revCloseTag.Length;
            string rev = responseString.Substring(revPos, revPosEnd - revPos);
            
			//
			// replace rev with the original one (so the client doesn't have to set this again.
			//
			response.Replace(rev, m_forward + m_reverse);
            
            //
            // replace the action (with the original one) and add the <to> header back
            //
            response.Replace(action, m_action + m_to);

            //
            // replace the logfile tag (if it was removed)
            //
            if(m_logfileTag != null)
            {
                response.Replace(s_licensesEndTag, m_logfileTag + s_licensesEndTag);
            }
            
            //
            // write the modified response to the log file
            //
            WriteToLogFile(response, "Modified Response");

            writer.Write(response.ToString());
            writer.Flush();
            m_newStream.Position = 0;
        }

        /// <summary>
        /// Writes the contents of a StringBuilder instance to a log file
        /// </summary>
        private void WriteToLogFile(StringBuilder sb, string title)
        {
            if(m_logfile != null)
            {
                FileStream fs = new FileStream(m_logfile, FileMode.Append, FileAccess.Write);
                StreamWriter w = new StreamWriter(fs);
                w.WriteLine("---------------------------------- " + title + " at " + DateTime.Now);
                w.Write(sb.ToString());
                w.WriteLine(" ");
                w.WriteLine(" ");
                w.Flush();
                fs.Close();
            }
        }
        //
        // private member variables
        //
        private bool m_enabled = true;
        private Stream m_oldStream;
        private Stream m_newStream;
        private string m_forward = "";
        private string m_reverse = "";
        private string m_action = "";
        private string m_to = "";

        //
        // this temporary variable demonstrates how we'll pass the security context to the soap extension
        //
        private string m_logfile = null; 
        private string m_logfileTag = null;
        private bool   m_logOriginalMessages = false;
        
        //
        // common search targets.  we declare them here statically to save on the GC
        //
        private static string s_actionStartTag = "<action";
        private static string s_actionCloseTag = "</action>";
        private static string s_toStartTag = "<to>";
        private static string s_toCloseTag = "</to>";
        private static string s_fwdStartTag = "<fwd>";
        private static string s_fwdCloseTag = "</fwd>";
        private static string s_revStartTag = "<rev>";
        private static string s_revCloseTag = "</rev>";
        private static string s_requestStartTag = "<request";
        private static string s_pathStartTag = "<path";
        private static string s_licensesStartTag = "<licenses";
        private static string s_licensesEndTag = "</licenses>";
        private static string s_soapBodyStartTag = "<soap:Body>";
        private static string s_soapEnvelopeStartTag = "<soap:Envelope";
        private static string s_serviceAttribute = "service=\"";
        private static string s_methodAttribute = "method=\"";

        //
        // these temporary variables demonstrate how we'll pass the security context to the soap extension
        //
        private static string s_logfileStartTag = "<temp:logfile xmlns:temp=\"http://temp\">";
        private static string s_logfileEndTag = "</temp:logfile>";
    }
    
    /// <summary>
    /// This class is called during proxy class generation when <hs:operation> is encountered in the service wsdl
    /// </summary>
    public class HsSoapExtensionImporter : SoapExtensionImporter 
    {
        public override void ImportMethod(CodeAttributeDeclarationCollection metadata) 
        {
            SoapProtocolImporter importer = ImportContext;
            HsSoapExtensionOperationBinding hcOperation = (HsSoapExtensionOperationBinding)importer.OperationBinding.Extensions.Find(typeof(HsSoapExtensionOperationBinding));
            
            if(hcOperation == null)
            {
                //no hc:operation element was found.  
                return;
            }

            CodeAttributeDeclaration attr = new CodeAttributeDeclaration(typeof(HsSoapExtensionAttribute).FullName);
            attr.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(true)));
            metadata.Add(attr);
        }
    }
    
    /// <summary>
    /// This class is invoked when the XmlSerializer is serializing the proxy class and it encounters
    /// the [Microsoft.Hs.HsSoapExtensionAttribute()] attribute on the method being called.  This is
    /// how HsSoapExtension is invoked
    /// </summary>
    public class HsSoapExtensionReflector : SoapExtensionReflector 
    {
        public override void ReflectMethod() 
        {
            ProtocolReflector reflector = ReflectionContext;
            HsSoapExtensionAttribute attr = (HsSoapExtensionAttribute)reflector.Method.GetCustomAttribute(typeof(HsSoapExtensionAttribute));
            if (attr != null) 
            {
                HsSoapExtensionOperationBinding hssec = new HsSoapExtensionOperationBinding();
                reflector.OperationBinding.Extensions.Add(hssec);
            }
        }
    }

    
    /// <summary>
    /// This class associates the <hs:operation> tag in the my*.wsdl with this soap extension
    /// </summary>
    [XmlFormatExtension("operation", HsSoapExtensionOperationBinding.Namespace, typeof(OperationBinding))]
    [XmlFormatExtensionPrefix("hc", HsSoapExtensionOperationBinding.Namespace)]
    public class HsSoapExtensionOperationBinding : ServiceDescriptionFormatExtension 
    {
        public const string Namespace = "http://schemas.microsoft.com/hs/2001/10/core";
    }
}
