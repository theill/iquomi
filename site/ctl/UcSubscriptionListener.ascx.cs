#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Schema;

using log4net;

using Commanigy.Iquomi.Data;
using Commanigy.Iquomi.Ui;

#endregion

namespace Commanigy.Iquomi.Web {
	/// <summary>
	/// 
	/// </summary>
	public partial class UcSubscriptionListener : System.Web.UI.UserControl {
		private static readonly ILog log = LogManager.GetLogger(
			MethodBase.GetCurrentMethod().DeclaringType
			);
		
		private DbSubscription subscription;
		private DbSubscriptionListener subscriptionListener;

		#region Properties
		/// <summary>
		/// Property Subscription (DbSubscription)
		/// </summary>
		public DbSubscription Subscription {
			get {
				return this.subscription;
			}
			set {
				this.subscription = value;
			}
		}

		/// <summary>
		/// Property SubscriptionListener (DbSubscriptionListener)
		/// </summary>
		public DbSubscriptionListener SubscriptionListener {
			get {
				return this.subscriptionListener;
			}
			set {
				this.subscriptionListener = value;
			}
		}

		/// <summary>
		/// Property Iqid (string)
		/// </summary>
		public string Iqid {
			get {
				return this.TbxIqid.Text;
			}
			set {
				this.TbxIqid.Text = value;
			}
		}

		/// <summary>
		/// Property Filter (string)
		/// </summary>
		public string Filter {
			get {
				return this.TbxFilter.Text;
			}
			set {
				this.TbxFilter.Text = value;
			}
		}

		/// <summary>
		/// Property ContextUri (string)
		/// </summary>
		public string ContextUri {
			get {
				return this.TbxContextUri.Text;
			}
			set {
				this.TbxContextUri.Text = value;
			}
		}

		/// <summary>
		/// Property Context (string)
		/// </summary>
		public string ContextData {
			get {
				return this.TbxContextData.Text;
			}
			set {
				this.TbxContextData.Text = value;
			}
		}

		public DateTime ActiveFrom {
			get {
				DateTime v;
				DateTime.TryParse(this.TbxActiveFrom.Text, out v);
				return v;
			}
			set {
				this.TbxActiveFrom.Text = value != DateTime.MinValue ? value.ToString("u") : "";
			}
		}

		public DateTime ActiveTo {
			get {
				DateTime v;
				DateTime.TryParse(this.TbxActiveTo.Text, out v);
				return v;
			}
			set {
				this.TbxActiveTo.Text = value != DateTime.MinValue ? value.ToString("u") : "";
			}
		}

		/// <summary>
		/// Property To (string)
		/// </summary>
		public string To {
			get {
				return this.TbxTo.Text;
			}
			set {
				this.TbxTo.Text = value;
			}
		}
		#endregion

		public void SyncTo(DbSubscriptionListener v) {
			// Lookup id for account using unique Iquomi Id
			DbAccount a = DbAccount.FindByIqid(Iqid);
			if (!Iqid.Equals(a.Iqid)) {
				throw new Exception("Account \"" + Iqid + "\" not found");
			}

			v.AccountId = a.Id;
			v.Filter = Filter;
			v.ContextUri = ContextUri;
			v.Context = ContextData;
			v.ActiveFrom = ActiveFrom;
			v.ActiveTo = ActiveTo;
			v.To = To;
		}

		public void SyncFrom(DbSubscriptionListener v) {
			// Lookup account based on id to get unique Iquomi Id
			DbAccount a = DbAccount.FindById(v.AccountId);

			Iqid = a.Iqid;
			Filter = v.Filter;
			ContextUri = v.ContextUri;
			ContextData = v.Context;
			ActiveFrom = v.ActiveFrom;
			ActiveTo = v.ActiveTo;
			To = v.To;
		}

		protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args) {
			DbAccount a = DbAccount.FindByIqid(args.Value);
			args.IsValid = (a != null && a.Id > 0);
		}

	}
}