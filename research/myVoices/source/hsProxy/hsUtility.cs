using System;

using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Net;

namespace hsProxy
{
	/// <summary>
	/// Summary description for hsUtility.
	/// </summary>
	public class hsUtility
	{
		public hsUtility()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string Serialize(object o)
		{
			string ret = "";
			try
			{
				Type t = o.GetType();
				XmlSerializer xs = new XmlSerializer(t);
				MemoryStream ms = new MemoryStream();
				xs.Serialize(ms, o);

				ASCIIEncoding ae = new ASCIIEncoding();
				ret = ae.GetString(ms.GetBuffer());			
			}
			catch(Exception ex)
			{
				ret = "Exception.Utility.Serialize" + ex.ToString();
			}
			return ret;
		}

		public static string MakeHttpRequest(string url)
		{
			string html = "";
			try 
			{
				WebRequest req = WebRequest.Create(url);
				req.Timeout = 5000; //timeout in 10 seconds
				WebResponse result = req.GetResponse();
				StreamReader sr = new StreamReader(result.GetResponseStream());

				string line = sr.ReadLine();
				while(line != null)
				{
					//line = HttpUtility.HtmlEncode(line);
					if(line.Length != 0)
					{
						html += line;
					}
					line = sr.ReadLine();
				}
				sr.Close();
				result.Close();
			}
			catch(Exception e)
			{
				string error = e.ToString();
				//do nothing
			}
			return html;
		}
	}
}
