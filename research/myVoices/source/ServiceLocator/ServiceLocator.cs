using System;
using System.Xml;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Microsoft.Hs.ServiceLocator.myServices;


namespace Microsoft.Hs.ServiceLocator
{
	/// <summary>
	/// Summary description for ServiceLocator.
	/// </summary>
	public class ServiceLocator
	{
		/// <summary>
		/// ServiceLocator constructor
		/// </summary>
		/// <param name="myServicesUri">The uri to the myServices instance to query, ex: http://localhost/myServices </param>
		/// <param name="logfile">An optional file to log the request and responses to</param>
		/// <param name="logOriginalMessages">
		/// A boolean indicating if the original request and responses should be logged
		///	or just simply the request and response message after it is modified by HsSoapExtension	
		/// </param>
		/// <example>
		///	//This example will query myServices at the location http://localhost/myServices and will log the modifed 
		///	//request and responses to c:\logfile.txt
		/// ServiceLocator services = new ServiceLocator("http://localhost/myServices", "c:\\logfile.txt", false);
		/// 
		/// //This example will query myServices at the location http://someserver/myServices and will not log
		/// //the request and responses
		/// ServiceLocator services = new ServiceLocator("http://someserver/myServices", null, false);
		/// 
		/// </example>
        public ServiceLocator(string myServicesUri, string logfile, bool logOriginalMessages)
        {
            //
            // check that myServicesUri is not null
            //
            if(myServicesUri == null)
            {
                throw new ArgumentNullException();
            }
            m_myServicesUri = myServicesUri;
            if(myServicesUri.EndsWith("/"))
            {
                m_myServicesUri = myServicesUri.TrimEnd(new char[]{'/'});
            }
			    
			m_logfile = logfile;
			m_logOriginalMessages = logOriginalMessages;
        }
		

        /// <summary>
        /// Given a service type and a username, query myServices for it's location and initialize it.
        /// </summary>
        /// <param name="serviceType">The System.Type of the service proxy</param>
        /// <param name="userName">The name of the user to query myServices for</param>
        /// <returns>An initialize service proxy instance</returns>
        /// <example>
        /// myFavoriteWebSites myFav = 
        ///		(myFavoriteWebSites) services.GetService(typeof(myFavoriteWebSites), "samgeo");
        /// </example> 
        public SoapHttpClientProtocol GetService(Type serviceType, string userName)
        {
            return GetUserService(serviceType, User.GetPuid(userName));
        }

        /// <summary>
        /// Given a service type and a users puid, query myServices for it's location and initialize it.
        /// </summary>
        /// <param name="serviceType">The System.Type of the service proxy</param>
        /// <param name="userPuid">The puid of the user to query myServices for</param>
        /// <returns>An initialize service proxy instance</returns>
        /// <example>
        /// myFavoriteWebSites myFav = 
        ///		(myFavoriteWebSites) services.GetService(typeof(myFavoriteWebSites), 11226);
        /// </example> 
        public SoapHttpClientProtocol GetService(Type serviceType, int userPuid)
        {
            return GetUserService(serviceType, userPuid.ToString());
        }

        private SoapHttpClientProtocol GetUserService(Type serviceType, string userPuid)
        {
            //
            // check that serviceType and userPuid are not null
            //
            if(serviceType == null || userPuid == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                if(m_serviceLocator == null)
                {
                    //
                    // myServices hasn't been initialized
                    //
                    this.Initialize();
                }
				
                //
                // check to see if this is a proxy class type
                //
                if ("SoapHttpClientProtocol" != serviceType.BaseType.Name)
                {
                    throw new Exception("You must initialize a proxy class that inherits from SoapHttpClientProtocol");
                }

                //
                // check to see if the service exists in the ticket cache
                //
                Hashtable syncTicketCache = Hashtable.Synchronized(m_ticketCache);
                string hash = userPuid + ":" + serviceType.Name;
                if(syncTicketCache.ContainsKey(hash))
                {
                    ServiceDescription serviceDescription = (ServiceDescription)syncTicketCache[hash];
                    return InitializeService(serviceType, serviceDescription, userPuid);
                }
                
                //
                // we didn't have a ticket cached.  query the service locator and cache the ticket
                //
                ServiceDescription newServiceDescription = QueryServiceLocator(serviceType, userPuid);
                syncTicketCache.Add(hash, newServiceDescription);

                //
                // return the initialize service
                //
                return InitializeService(serviceType, newServiceDescription, userPuid);
            }
            catch(Exception ex)
            {
                throw new Exception("Error returning the requested service in ServiceLocator::GetService", ex);
            }
        }

		/// <summary>
		/// Used to delay initialize the myServices proxy
		/// </summary>
		private void Initialize()
		{
			try
			{
				//
				// initialize the myServices instance
				//
				m_serviceLocator = new myServices.myServices();
				m_serviceLocator.Url = m_myServicesUri;
				
				//
				// initialize the ticketCache
				//
				m_ticketCache = new Hashtable();

				//
				// create the identity header
				//
				identityType identity = new identityType();
				licenses license = new licenses();
				license.identity = identity;
                
				//
				// create the path header
				//
				pathType path = new pathType();
				path.action = s_requestAction;
				path.to = m_myServicesUri;
				path.id = Guid.NewGuid().ToString();
				viaChainTypeVia forward = new viaChainTypeVia();
				viaChainTypeVia reverse = new viaChainTypeVia();
				path.fwd = new viaChainTypeVia[]{forward};
				path.rev = new viaChainTypeVia[]{reverse};
                
				//
				// create the request type
				//
				requestType request = new requestType();
				request.MustUnderstand = true;
				request.service = "myServices";
				request.document = requestTypeDocument.content;
				request.method = "query";
				request.genResponse = requestTypeGenResponse.always;
				requestTypeKey key = new requestTypeKey();

				//
				// temporary data for now.  This will get real when auth is turned on
				//
				key.cluster = "1";
				key.instance = "1";
				request.key = new requestTypeKey[]{key};

                // 
                // set the location of the logfile (if a logfile was specified)
                //
                if(m_logfile != null)
                {
                    XmlDocument logFileDoc = new XmlDocument();
                    string element = "<temp:logfile xmlns:temp='http://temp'>" + m_logfile+ "</temp:logfile>";
                    if(m_logOriginalMessages)
                    {
                        element = "<temp:logfile xmlns:temp='http://temp'>" + m_logfile + ":logOriginalMessages</temp:logfile>";
                    }
                    logFileDoc.LoadXml(element);
                    license.Any = new XmlElement[]{logFileDoc.DocumentElement};
                }
                
				//
				// add the headers to the myServices instance
				//
				m_serviceLocator.request = request;
				m_serviceLocator.path = path;
				m_serviceLocator.licensesValue = license;
			}
			catch(Exception ex)
			{
				throw new Exception("Error initializing the ServiceLocator myServices proxy", ex);
			}
		}
        /// <summary>
        /// Queries the service locator for the location of the user's service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="userPuid">The puid of the user to query the service locator for</param>
        /// <returns></returns>
        private ServiceDescription QueryServiceLocator(Type serviceType, string userPuid)
        {
            try
            {
                //
                // set the puid for the user and set the query for myServices
                //
                m_serviceLocator.request.key[0].puid = userPuid;
                m_serviceLocator.licensesValue.identity.kerberos = Int32.Parse(userPuid);

                //
                // build a request and query myServices
                //
                queryRequestType queryRequest = new queryRequestType();
                xpQueryType xpQuery = new xpQueryType();
                xpQuery.select = "/m:myServices/m:service[@name='" + serviceType.Name + "']";
                queryRequest.xpQuery = new xpQueryType[]{xpQuery};
                
                //
                // query the service
                //
                queryResponseType response = m_serviceLocator.query(queryRequest);

                //
                // fill out the service description and return it
                //
                serviceType serviceTicket = (serviceType)response.xpQueryResponse[0].Items[0];
                ServiceDescription serviceDescription = new ServiceDescription(serviceType, serviceTicket);
                return serviceDescription;
            }
            catch(Exception ex)
            {
                throw new Exception("Error querying the myServices service for the requested service in ServiceLocator::QueryServiceLocator\nPlease make sure that myServices is correctly provisioned", ex);
            }
        }
        
        /// <summary>
        /// Creates and initializes a Hs service class using reflection
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceDescription"></param>
        /// <returns></returns>
        private SoapHttpClientProtocol InitializeService(Type serviceType, ServiceDescription serviceDescription, string userPuid)
        {
            try
            {
                //
                // get the module of the service type (we'll need this to get the headers)
                //
                Module serviceClassModule = serviceType.Module;
                string serviceNamespace = serviceType.Namespace;

                //
                // create a new instance of the type
                //
                ConstructorInfo serviceConstructor = serviceType.GetConstructor(new Type[0]);
                object newService = serviceConstructor.Invoke(new Object[0]);
                
                //
                // set the url of the new service
                //
                PropertyInfo urlProperty = serviceType.GetProperty("Url");
                urlProperty.SetValue(newService, serviceDescription.serviceTicket.to + "/" + serviceType.Name, null);
                
                //
                // find and create the identity header
                //
                Type identityType = serviceClassModule.GetType(serviceNamespace + ".identityType");
                ConstructorInfo identityTypeConstructor = identityType.GetConstructor(new Type[0]);
                object identity = identityTypeConstructor.Invoke(new Object[0]);
                
                //
                // set the kerb value on the identity header
                //
				//TODO: this will get initialized by the auth dll
                int kerbValue = Int32.Parse(userPuid); 
                FieldInfo kerberosField = identityType.GetField("kerberos");
                kerberosField.SetValue(identity, kerbValue);

                //
                // find and create the license header
                //
                Type licensesType = serviceClassModule.GetType(serviceNamespace + ".licenses");
                ConstructorInfo licensesTypeConstructor = licensesType.GetConstructor(new Type[0]);
                object licenses = licensesTypeConstructor.Invoke(new Object[0]);
                
                //
                //  set the identity on the license header
                //
                FieldInfo identityField = licensesType.GetField("identity");
                identityField.SetValue(licenses, identity);

                // 
                // set the location of the logfile (if a logfile was specified)
                //
                if(m_logfile != null)
                {
                    XmlDocument logFileDoc = new XmlDocument();
                    string element = "<temp:logfile xmlns:temp='http://temp'>" + m_logfile+ "</temp:logfile>";
                    if(m_logOriginalMessages)
                    {
                        element = "<temp:logfile xmlns:temp='http://temp'>" + m_logfile + ":logOriginalMessages</temp:logfile>";
                    }
                    logFileDoc.LoadXml(element);
                    
                    FieldInfo anyField = licensesType.GetField("Any");
                    anyField.SetValue(licenses, new XmlElement[]{logFileDoc.DocumentElement});
                }

                

                //
                // find and create the path header
                //
                Type pathType = serviceClassModule.GetType(serviceNamespace + ".pathType");
                ConstructorInfo pathTypeConstructor = pathType.GetConstructor(new Type[0]);
                object path = pathTypeConstructor.Invoke(new Object[0]);

                //
                // set the action, to and id fields
                //
                FieldInfo actionField = pathType.GetField("action");
                actionField.SetValue(path, s_requestAction);
                
                FieldInfo toField = pathType.GetField("to");
                toField.SetValue(path, serviceDescription.serviceTicket.to);
                
                FieldInfo idField = pathType.GetField("id");
                idField.SetValue(path, Guid.NewGuid().ToString());
                
                //
                // find and create two via instances
                //
                Type viaChainType = serviceClassModule.GetType(serviceNamespace + ".viaChainTypeVia");
                ConstructorInfo viaChainTypeConstructor = viaChainType.GetConstructor(new Type[0]);
                object forward = viaChainTypeConstructor.Invoke(new Object[0]);
                object reverse = viaChainTypeConstructor.Invoke(new Object[0]);

                //
                // create arrays for the forward and reverse array fields and set the fwd and rev fields
                //
                Array forwardArray = Array.CreateInstance(viaChainType, 1);
                Array reverseArray = Array.CreateInstance(viaChainType, 1);

                forwardArray.SetValue(forward, 0);
                reverseArray.SetValue(reverse, 0);

                FieldInfo fwdField = pathType.GetField("fwd");
                fwdField.SetValue(path, forwardArray);
                
                FieldInfo revField = pathType.GetField("rev");
                revField.SetValue(path, reverseArray);

                //
                // find and create the request type
                //
                Type requestType = serviceClassModule.GetType(serviceNamespace + ".requestType");
                ConstructorInfo requestTypeConstructor = requestType.GetConstructor(new Type[0]);
                object request = requestTypeConstructor.Invoke(new Object[0]);
                
                //
                // set the service and method fields
                //
                FieldInfo serviceField = requestType.GetField("service");
                serviceField.SetValue(request, serviceType.Name);
                
                FieldInfo methodField = requestType.GetField("method");
                methodField.SetValue(request, "query");

                //
                // set the genResponse and requestDocument fields
                //
                Type genResponseEnumType = serviceClassModule.GetType(serviceNamespace + ".requestTypeGenResponse");
                object genResponseEnum = Enum.Parse(genResponseEnumType, "always");
                FieldInfo genResponseField = requestType.GetField("genResponse");
                genResponseField.SetValue(request, genResponseEnum);

                Type requestDocumentEnumType = serviceClassModule.GetType(serviceNamespace + ".requestTypeDocument");
                object requestDocumentEnum = Enum.Parse(requestDocumentEnumType, "content");
                FieldInfo documentField = requestType.GetField("document");
                documentField.SetValue(request, requestDocumentEnum);
                

                //
                // find and create the key type and set the cluster, instance and puid fields
                //
                Type requestTypeKey = serviceClassModule.GetType(serviceNamespace + ".requestTypeKey");
                ConstructorInfo requestTypeKeyConstructor = requestTypeKey.GetConstructor(new Type[0]);
                object key = requestTypeKeyConstructor.Invoke(new Object[0]);
                
                FieldInfo clusterField = requestTypeKey.GetField("cluster");
                clusterField.SetValue(key, serviceDescription.serviceTicket.key.cluster);

                FieldInfo instanceField = requestTypeKey.GetField("instance");
                instanceField.SetValue(key, serviceDescription.serviceTicket.key.instance);

                FieldInfo puidField = requestTypeKey.GetField("puid");
                puidField.SetValue(key, serviceDescription.serviceTicket.key.puid);

                //
                // add the key to the request header
                //
                Array keyArray = Array.CreateInstance(requestTypeKey, 1);
                keyArray.SetValue(key, 0);

                FieldInfo keyField = requestType.GetField("key");
                keyField.SetValue(request, keyArray);

               
                //
                // add the headers we've initialized to the new class instance
                //
                FieldInfo requestField = serviceType.GetField("request");
                requestField.SetValue(newService, request);
                
                FieldInfo pathField = serviceType.GetField("path");
                pathField.SetValue(newService, path);

                FieldInfo licensesValueField = serviceType.GetField("licensesValue");
                licensesValueField.SetValue(newService, licenses);

                return (SoapHttpClientProtocol) newService;
            }
            catch(Exception ex)
            {
                throw new Exception("Error initializing the service proxy class in ServiceLocator::InitializeService", ex);
            }
        }

        //
        // static data
        //
        private static string s_requestAction = "http://schemas.microsoft.com/hs/2001/10/core#request";
		
        //
        // private member data
        //
        private myServices.myServices m_serviceLocator = null;
        private string m_myServicesUri;
        private string m_logfile;
        private bool m_logOriginalMessages;
        private Hashtable m_ticketCache = null;
	}
}

