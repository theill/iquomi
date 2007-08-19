using System;
using Microsoft.Hs.ServiceLocator.myServices;

namespace Microsoft.Hs.ServiceLocator
{
	/// <summary>
	/// Summary description for ServiceDescription.
	/// </summary>
	internal class ServiceDescription
	{
		public ServiceDescription(System.Type type, serviceType serviceTicket)
		{
            m_type = type;
            m_serviceTicket = serviceTicket;
		}
        public System.Type Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
				m_name = m_type.ToString();
				m_name = m_name.Substring(m_name.LastIndexOf(".") + 1);
            }
        }
		public string Name
		{
			get
			{
				return m_name;
			}
		}
        public serviceType serviceTicket
        {
            get
            {
                return m_serviceTicket;
            }
            set
            {
                m_serviceTicket = value;
            }
        }
        private System.Type m_type;
        private string m_name;
        private serviceType m_serviceTicket;
	}
}
