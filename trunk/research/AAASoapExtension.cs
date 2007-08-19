using System;
using System.IO;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Xsl;
using Krak.AAA;
using Krak.Data;

namespace Krak.AAA
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class AAASoapExtension : SoapExtension
	{
		private const string __KrakSoapHeaderName = "KrakSoapHeader";
		private Stream outputStream;
		private Stream inputStream;
		//private Stream errorStream = null;
		private static string secsToTicketTimeout = null;
		private static int maxConcurrentUsers = -1;
		private static int currentUsers = 0;

		private bool continueProcessMessage = true;
		private string soapHeaderProduct = null;
		private object billingObject = null;
		private BillingType billingType;
		private ProductMethod _productMethod = null;
		private UsageLog _usageLog = null;
		private string soapFault = null;

		public AAASoapExtension() 
		{
			if (secsToTicketTimeout == null)
			{
				if ((System.Configuration.ConfigurationSettings.AppSettings.Get("TicketTimeout") != null) &&
					(System.Configuration.ConfigurationSettings.AppSettings.Get("TicketTimeout") != ""))
				{
					secsToTicketTimeout = System.Configuration.ConfigurationSettings.AppSettings.Get("TicketTimeout");
				}
				else
				{
					secsToTicketTimeout = "1800";
				}
			}

			if (maxConcurrentUsers == -1)
			{
				if ((System.Configuration.ConfigurationSettings.AppSettings.Get("TicketTimeout") != null) &&
					(System.Configuration.ConfigurationSettings.AppSettings.Get("TicketTimeout") != ""))
				{
					try
					{
						maxConcurrentUsers = int.Parse(System.Configuration.ConfigurationSettings.AppSettings.Get("MaxConcurrentUsers"));
					}
					// TODO : Errorhandling
					catch
					{
						maxConcurrentUsers = 100000;
					}
				}
				else
				{
					maxConcurrentUsers = 100000;
				}
			}
		}

		private static bool AddUserToCounter()
		{
			bool freeUserSlot = false;

			System.Threading.Monitor.Enter(currentUsers);
			try
			{
				if (currentUsers < maxConcurrentUsers)
				{
					currentUsers++;
					freeUserSlot = true;
				}
			}
			// TODO: Errorhandling
  		catch{}
			finally
			{
				System.Threading.Monitor.Exit(currentUsers);
			}

			return freeUserSlot;
		}

		private static void SubUserFromCounter()
		{
			System.Threading.Monitor.Enter(currentUsers);
			try
			{
				currentUsers--;
			}
			finally
			{
				System.Threading.Monitor.Exit(currentUsers);
			}
		}

		private void WriteAccessLog(SoapMessage message)
		{
			try
			{
				AccessLog accessLog = new AccessLog();
				accessLog.IPAddress = HttpContext.Current.Request.UserHostAddress.ToString();
				accessLog.URL = message.Url;

				AAADataAdapter aaaDataAdapter = new AAADataAdapter();
				aaaDataAdapter.InsertAccessLog(accessLog);
			}
			catch(Exception e)
			{
				continueProcessMessage = false;
				throwSoapException(e.Message);
			}

		}

		private bool AuthenticateRequest(SoapServerMessage message)
		{
			string soapHeaderTicket = null;
			System.Xml.XmlNode node = null;
			System.Collections.IEnumerator enumerator = null;

			try
			{
				// Loop through the collection of SoapHeaders
				foreach (SoapUnknownHeader header in message.Headers)
				{
					// Inspect the KrakSoapHeader
					if ((header.Element.Name == __KrakSoapHeaderName) && (header.Element.NamespaceURI == "http://webservice.krak.dk/"))
					{
						enumerator = header.Element.ChildNodes.GetEnumerator();
						while (enumerator.MoveNext())
						{
							node = (System.Xml.XmlNode)enumerator.Current;
							
							if (node.LocalName == "ticket")
								soapHeaderTicket = node.InnerText;

							if (node.LocalName == "product")
								soapHeaderProduct = node.InnerText;
						}
					}
				}

				if (soapHeaderTicket == null)
					throw new ApplicationException(Localization.GetLocalizedString("SoapHeaderMissing"));

				FormsAuthenticationTicket ticket = null;
				try
				{
					ticket = FormsAuthentication.Decrypt(soapHeaderTicket);
				}
				catch
				{
					throw new ApplicationException(Localization.GetLocalizedString("TicketInvalid"));
				}

				if (ticket ==null)
					throw new ApplicationException(Localization.GetLocalizedString("CookieInvalid"));

				string userData = ticket.UserData;
				
				//Set current thread's UI to the locale we've set in the UserData for the cookie.
				//NOTE: Until this point we can't actually throw any localized exceptions.
				if (userData!=null && userData!="")
					System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(userData);

				if (ticket.Expired)
					throw new ApplicationException(Localization.GetLocalizedString("TicketExpired"));

				if (!AddUserToCounter())
					throw new ApplicationException(Localization.GetLocalizedString("ToManyUsers"));

				//Set the current user
				AAADataAdapter aaaDataAdapter = new AAADataAdapter();
				AccountUser accountUser = aaaDataAdapter.GetAccountUserByUserName(ticket.Name);
				HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(ticket), new string[] {""});
				
				return true;
			}
			catch(ApplicationException ae)
			{
				continueProcessMessage = false;
				throwSoapException(ae.Message);
				return false;
			}
		}

		private bool PrepareBilling(ProductAccess productAccess)
		{
			bool billingOK = false;
			AAADataAdapter aaaDataAdapter = new AAADataAdapter();

			switch(productAccess.Product.BillingType)
			{
				case BillingType.Credit:
					Credit credit = aaaDataAdapter.GetCreditByProductAccessID(productAccess.ID);
					if (credit != null)
					{
						if (! credit.IsEmpty)
						{
							billingOK = true;
							billingObject = credit;
						}
					}

					if (! billingOK)
						throw new ApplicationException(Localization.GetLocalizedString("CreditExceed"));

					break;
				case BillingType.UsageLimit:
					UsageLimit usageLimit = aaaDataAdapter.GetUsageLimitByProductAccessID(productAccess.ID);
					if (usageLimit != null)
					{
						if (! usageLimit.OnLimit)
						{
							billingOK = true;
							billingObject = usageLimit;
						}
					}

					if (! billingOK)
						throw new ApplicationException(Localization.GetLocalizedString("UsageLimitExceed"));

					break;
				case BillingType.Subscription:
					Subscription subscription = aaaDataAdapter.GetSubscriptionByProductAccessID(productAccess.ID);
					if (subscription != null)
					{
						if (subscription.StartDate <= DateTime.Now && subscription.EndDate >= DateTime.Now)
						{
							billingOK = true;
							billingObject = subscription;
						}
					}

					if (! billingOK)
						throw new ApplicationException(Localization.GetLocalizedString("SubscriptionExpired"));

					break;

			}
			billingType = productAccess.Product.BillingType;

			return billingOK;
		}

		private bool AuthorizeRequest(SoapMessage message)
		{
			System.Diagnostics.Trace.WriteLine("Headers"+message.Headers.Count);
			long startTime = DateTime.Now.Ticks;
			bool authorized = false;
			bool billingOK = false;

			HttpContext httpContext = HttpContext.Current;
			AAADataAdapter aaaDataAdapter = new AAADataAdapter();

			string accountUserName = HttpContext.Current.User.Identity.Name;
			string methodName = message.MethodInfo.Name;
			string path = HttpContext.Current.Request.Path;
			string name = path.Substring(path.LastIndexOf('/')+1);

			//TODO: Remove this hack
			path = "/20030305" + path;

			AccountUser accountUser = aaaDataAdapter.GetAccountUserByUserName(accountUserName);
			try
			{
				foreach (ProductAccess productAccess in accountUser.Account.ProductAccesses)
				{
					if (productAccess.Product.ProductNumber.StartsWith(soapHeaderProduct))
					{
						if (productAccess.Active)
						{
							billingOK = PrepareBilling(productAccess);
							if (billingOK)
							{
								foreach (ProductMethod productMethod in productAccess.Product.ProductMethods)
								{
									if (productMethod.Method.Name == methodName)
									{
										UsageLog usageLog = new UsageLog();
										usageLog.IPAddress = httpContext.Request.UserHostAddress;
										usageLog.StartTime = startTime;
										usageLog.ProductAccessID = productAccess.ID;
										usageLog.ProductMethodID = productMethod.ID;
										_usageLog = usageLog;
										_productMethod = productMethod;
										authorized = true;
										break;
									}
								}
							}
						}
					}			
				}
			}
			catch(Exception ex)
			{
				continueProcessMessage = false;
				throwSoapException(ex.Message);
			}
			
			if (! authorized)
			{
				continueProcessMessage = false;
				throwSoapException(Localization.GetLocalizedString("AccessDinied"));
			}

			return authorized;
		}

		private void DoUsageLogging()
		{
			HttpContext httpContext = HttpContext.Current;
			try
			{
				if (_usageLog != null)
				{
					_usageLog.EndTime = DateTime.Now.Ticks;
					int recordCount;
					try
					{
						recordCount = (int)httpContext.Items["Krak.recordCount"];
					}
					catch
					{
						recordCount = 0;
					}

					_usageLog.OutputCount = recordCount;
					ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncUsageLogging), _usageLog);
				}
			}
			catch
			{
				continueProcessMessage = false;
			}
		}

		private void DoAccounting()
		{
			int recordCount;

			try
			{
				HttpContext httpContext = HttpContext.Current;

				switch (billingType)
				{
					case BillingType.Credit:
						Credit credit = (Credit)billingObject;
						try
						{
							recordCount = (int)httpContext.Items["Krak.RecordCount"];
						}
						// TODO : ErrorHandling
						catch
						{
							recordCount = 0;
						}
							
						credit.CreditLeft -= recordCount;
						if (credit.CreditLeft<0)
						{
							throw new ApplicationException(Localization.GetLocalizedString("CreditExceed"));
						}
							
						ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncCreditAccounting), credit);
						break;
					case BillingType.UsageLimit:
						UsageLimit usageLimit = (UsageLimit)billingObject;
						try
						{
							recordCount = (int)httpContext.Items["Krak.RecordCount"];
						}
							// TODO : ErrorHandling
						catch
						{
							recordCount = 0;
						}
							
						usageLimit.UsageCount += recordCount;
						if (usageLimit.UsageCount > usageLimit.Limit)
						{
							throw new ApplicationException(Localization.GetLocalizedString("CreditExceed"));
						}
							
						ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncUsageLimitAccounting), usageLimit);
						break;
					case BillingType.Subscription:
						break;
				}
			}
			catch(ApplicationException ae)
			{
				continueProcessMessage = false;
				throwSoapException(ae.Message);
			}
		}

		/// <summary>
		/// This method is called from the ThreadPool to do asynchronious logging.
		/// </summary>
		/// <param name="o">WSBillingLog object containing log information</param>
		private void AsyncUsageLogging(object o)
		{
			UsageLog usageLog = (UsageLog)o;
			AAADataAdapter aaaDataAdapter = new AAADataAdapter();

			TimeSpan ts1 = new TimeSpan(usageLog.StartTime);
			TimeSpan ts2 = new TimeSpan(usageLog.EndTime);
			TimeSpan duration = ts2-ts1;
			System.Diagnostics.Trace.WriteLine("Duration="+duration.ToString());

			try
			{
				usageLog.Duration = Convert.ToInt32(duration.TotalMilliseconds);
			}
			catch
			{
				usageLog.Duration = 0;
			}

			aaaDataAdapter.InsertUsageLog(usageLog);
		}

		/// <summary>
		/// This method is called from the ThreadPool to do asynchronious accounting.
		/// </summary>
		/// <param name="o">WSCredit object containing credit information</param>
		private void AsyncCreditAccounting(object o)
		{
			Credit credit = (Credit)o;
			AAADataAdapter aaaDataAdapter = new AAADataAdapter();

			aaaDataAdapter.UpdateCredit(credit);
		}

		/// <summary>
		/// This method is called from the ThreadPool to do asynchronious accounting.
		/// </summary>
		/// <param name="o">WSUsageLimit object containing credit information</param>
		private void AsyncUsageLimitAccounting(object o)
		{
			UsageLimit usageLimit = (UsageLimit)o;
			AAADataAdapter aaaDataAdapter = new AAADataAdapter();

			aaaDataAdapter.UpdateUsageLimit(usageLimit);
		}

		private void CopyStream(Stream from, Stream to)
		{
			StreamReader reader = new StreamReader(from);
			StreamWriter writer = new StreamWriter(to);
			writer.WriteLine(reader.ReadToEnd());
			writer.Flush();
		}

		private void ApplyXSLT(SoapMessage message)
		{
			try
			{
				if (_productMethod != null)
				{
					DataLevel dataLevel = _productMethod.DataLevel;

					if (dataLevel != null)
					{
						outputStream.Position = 0;
						XmlDocument xmlDoc = new XmlDocument();
						xmlDoc.Load(outputStream);
					
						XslTransform xslt = new XslTransform();
						try
						{
							xslt.Load(HttpContext.Current.Request.PhysicalApplicationPath+dataLevel.XSLTPath);
						}
						catch(Exception e)
						{
							System.Diagnostics.Trace.WriteLine(e.Message);
						}
					
						Stream styledOutputStream = new MemoryStream();
						xslt.Transform(xmlDoc, null, styledOutputStream, null);
						styledOutputStream.Position = 0;
						string xml = new StreamReader(styledOutputStream).ReadToEnd();
						Stream tmp = new MemoryStream();

						styledOutputStream.Position = 0;
						CopyStream(styledOutputStream, inputStream);
					}
					else
					{
						outputStream.Position = 0;
						CopyStream(outputStream, inputStream);
					}					
				}
			}
			catch(ApplicationException ae)
			{
				continueProcessMessage = false;
				throwSoapException(ae.Message);
			}
		}

		private void WriteInput(SoapMessage message)
		{
			try
			{
				CopyStream(inputStream, outputStream);
				outputStream.Position = 0;
			}
			catch(Exception e)
			{
				continueProcessMessage = false;
				throwSoapException(e.Message);
			}
		}

		public override void Initialize(object initializer) {}

		public override System.IO.Stream ChainStream(System.IO.Stream stream)
		{
			inputStream = stream;
			outputStream = new MemoryStream();
			return outputStream;
		}

		public override object GetInitializer(Type serviceType)
		{
			return null;
		}

		public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
		{
			return null;
		}

		public override void ProcessMessage(SoapMessage message)
		{
			System.Diagnostics.Trace.WriteLine("message="+message.Stage);
			if (message is SoapServerMessage)
			{
				switch (message.Stage)
				{
					case SoapMessageStage.BeforeDeserialize:
						WriteAccessLog(message);
						WriteInput(message);
						break;
					case SoapMessageStage.AfterDeserialize:
						AuthenticateRequest((SoapServerMessage)message);
						if (continueProcessMessage)
						{
							AuthorizeRequest(message);
						}
						break;
					case SoapMessageStage.BeforeSerialize:
						if (continueProcessMessage)
						{
							DoUsageLogging();
							DoAccounting();
						}
						break;
					case SoapMessageStage.AfterSerialize:
						if (soapFault != null)
						{
							HttpContext.Current.Response.Write(soapFault);
							HttpContext.Current.Response.ContentType="text/xml";
							HttpContext.Current.Response.Cache.SetNoStore();
							HttpContext.Current.Response.End(); //End current request
						}
						else
						{
							if (continueProcessMessage)
							{
								ApplyXSLT(message);
							}
							else
							{
								outputStream.Position = 0;
								CopyStream(outputStream, inputStream);
							}
						}
						SubUserFromCounter();
						break;
				}
			}
		}

		/// <summary>
		/// throwSoapException writes an appropriately formatted soap fault to the response stream.
		/// The .NET framework usually automatically converts exceptions into Soap Faults for us.
		/// Unfortunately, not when the the exception is thrown from an HttpModule, so we need to do 
		/// this.
		/// </summary>
		/// <param name="message"></param>
		void throwSoapException(string message)
		{
			soapFault = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><soap:Fault><faultCode>soap:Server</faultCode><faultstring>{0}</faultstring><detail></detail></soap:Fault></soap:Body></soap:Envelope>";
			soapFault = string.Format( soapFault, message);

			// Escape the execution of the WebService method
			throw new ApplicationException();
		}
	}
}
