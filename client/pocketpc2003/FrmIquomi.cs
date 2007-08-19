#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

using Commanigy.Iquomi.Client.SmartDevice.ServiceRef;

using Commanigy.Iquomi.Api;
using Commanigy.Iquomi.Services;

#endregion

namespace Commanigy.Iquomi.Client.SmartDevice {
	/// <summary>
	/// Summary description for FrmIquomi.
	/// </summary>
	public class FrmIquomi : System.Windows.Forms.Form {
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView lvServices;

		private string email = "peter@theill.com";
		private string password = "g5zTb4oNXBR1VWyUqhNdcQ==";
		private System.Windows.Forms.MainMenu mnmApp;
        private System.Windows.Forms.MenuItem miTools;
        private System.Windows.Forms.MenuItem miSignIn;
		private System.Windows.Forms.MenuItem miSignOut;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.ContextMenu ctmServices;
		private System.Windows.Forms.MenuItem menuItem6;

		/// <summary>
		/// Property Email (string)
		/// </summary>
		public string Email {
			get {
				return this.email;
			}
			set {
				this.email = value;
			}
		}

		/// <summary>
		/// Property Password (string)
		/// </summary>
		public string Password {
			get {
				return this.password;
			}
			set {
				this.password = value;
			}
		}

		private AdminRef.IquomiWSAdmin adminWebService;

		public FrmIquomi() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			adminWebService = new AdminRef.IquomiWSAdmin();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.mnmApp = new System.Windows.Forms.MainMenu();
			this.miTools = new System.Windows.Forms.MenuItem();
			this.miSignIn = new System.Windows.Forms.MenuItem();
			this.miSignOut = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.lvServices = new System.Windows.Forms.ListView();
			this.ctmServices = new System.Windows.Forms.ContextMenu();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// mnmApp
			// 
			this.mnmApp.MenuItems.Add(this.miTools);
			// 
			// miTools
			// 
			this.miTools.MenuItems.Add(this.miSignIn);
			this.miTools.MenuItems.Add(this.miSignOut);
			this.miTools.MenuItems.Add(this.menuItem4);
			this.miTools.MenuItems.Add(this.menuItem5);
			this.miTools.Text = "Tools";
			// 
			// miSignIn
			// 
			this.miSignIn.Text = "Sign In...";
			this.miSignIn.Click += new System.EventHandler(this.miSignIn_Click);
			// 
			// miSignOut
			// 
			this.miSignOut.Text = "Sign Out";
			// 
			// menuItem4
			// 
			this.menuItem4.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Text = "Preferences...";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 20);
			this.label1.Text = "Services";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(152, 240);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 20);
			this.button1.TabIndex = 1;
			this.button1.Text = "Load";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lvServices
			// 
			this.lvServices.ContextMenu = this.ctmServices;
			this.lvServices.FullRowSelect = true;
			this.lvServices.Location = new System.Drawing.Point(8, 32);
			this.lvServices.Name = "lvServices";
			this.lvServices.Size = new System.Drawing.Size(216, 200);
			this.lvServices.TabIndex = 0;
			this.lvServices.View = System.Windows.Forms.View.List;
			this.lvServices.ItemActivate += new System.EventHandler(this.lvServices_ItemActivate);
			// 
			// ctmServices
			// 
			this.ctmServices.MenuItems.Add(this.menuItem6);
			this.ctmServices.Popup += new System.EventHandler(this.ctmServices_Popup);
			// 
			// menuItem6
			// 
			this.menuItem6.Text = "Refresh";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// FrmIquomi
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.lvServices);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Menu = this.mnmApp;
			this.Name = "FrmIquomi";
			this.Text = "Iquomi";
			this.ResumeLayout(false);

        }
		#endregion
		
		private void button1_Click(object sender, System.EventArgs e) {
//			adminWebService.AuthenticationTypeValue = new AdminRef.AuthenticationType();
//			adminWebService.AuthenticationTypeValue.Iqid = this.Email;
//			adminWebService.AuthenticationTypeValue.Password = this.Password;
			
			adminWebService.BeginGetSubscriptionServices(new AsyncCallback(OnSubscriptionServices), adminWebService);
		}
		
		private void OnSubscriptionServices(IAsyncResult result) {
			AdminRef.IquomiWSAdmin aws = (AdminRef.IquomiWSAdmin)result.AsyncState;
			AdminRef.Service[] services = adminWebService.EndGetSubscriptionServices(result);
			if (services != null) {
				BuildServicesMenu(services);
			} else {
				lvServices.Items.Add(new ListViewItem("none found"));
			}
		}
		
		private void BuildServicesMenu(AdminRef.Service[] services) {
			foreach (AdminRef.Service s in services) {
				ListViewItem lvi = new ListViewItem(s.Name);
				lvServices.Items.Add(lvi);
			}
		}
		
		private void lvServices_ItemActivate(object sender, System.EventArgs e) {
			// execute service
			ListView lv = (ListView)sender;
			string serviceName = lv.Items[lv.SelectedIndices[0]].Text;
			MessageBox.Show("You clicked on " + serviceName);
		}
		
		private Service GetService(string serviceName) {
			Service myService = new Service();
//			myService.AuthenticationTypeValue = new AuthenticationType();
//			myService.AuthenticationTypeValue.Iqid = "petertheill";
//			myService.AuthenticationTypeValue.Password = "g5zTb4oNXBR1VWyUqhNdcQ==";
//			myService.RequestTypeValue = new RequestType();
//			myService.RequestTypeValue.Service = serviceName;
//			myService.RequestTypeValue.OwnerIqid = "petertheill";
			return myService;
		}
		
		private void menuItem6_Click(object sender, System.EventArgs e) {
			Service myService = GetService("iqServices");

			QueryRequestType req = new QueryRequestType();
			XpQueryType query = new XpQueryType();
			query.Select = "/m:iqServices/m:service";
			req.XpQuery = new XpQueryType[] { query };
			
			QueryResponseType res = myService.Query(req);
			if (res != null && res.XpQueryResponse != null && res.XpQueryResponse[0].Status == ResponseStatus.Success) {
				if (res.XpQueryResponse[0].Any.Length == 0) {
					return;
				}
				
//				serviceType[] services = (serviceType[])ServiceUtils.GetObject(
//					typeof(serviceType), 
//					res.XpQueryResponse[0].Any
//					);
//				foreach (serviceType s in services) {
//					ListViewItem lvi = new ListViewItem(s.name);
//					lvServices.Items.Add(lvi);
//				}
			}
		}

		private void ctmServices_Popup(object sender, System.EventArgs e) {
		
		}

        private void miSignIn_Click(System.Object sender, System.EventArgs e)
        {
        
        }
	}
}