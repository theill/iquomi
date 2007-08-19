#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Web.Services.Protocols;
using System.Text;

using log4net;

using Commanigy.Iquomi.Api;
//using Commanigy.Iquomi.Api.Services;
using Commanigy.Iquomi.Client.IqProfileRef;
//using Commanigy.Iquomi.Services.IqProfile;

#endregion

namespace Commanigy.Iquomi.Client {
	/// <summary>
	/// Summary description for FrmPreferences.
	/// </summary>
	public class FrmPreferences : System.Windows.Forms.Form {
		private static readonly ILog log = LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
			);

		private IqProfileType profile;
		private IqProfile iqProfileService;

		/// <summary>
		/// Property IqProfileService (Services.Service)
		/// </summary>
		public IqProfile IqProfileService {
			get {
				return this.iqProfileService;
			}
			set {
				this.iqProfileService = value;
			}
		}

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
		private TabControl tcPreferences;
		private TabPage tpGeneral;
		private CheckBox cbAutoSync;
		private Commanigy.Controls.LabelLine lblSynchronization;
		private PictureBox pbSync;
		private CheckBox cbAutoSignIn;
		private PictureBox pbSignIn;
		private CheckBox cbAutoStart;
		private Commanigy.Controls.LabelLine lblSignIn;
		private TabPage tpProfile;
		private Label label2;
		private Label label1;
		private Label label3;
		private TextBox tbxSurName;
		private TextBox tbxMiddleName;
		private TextBox tbxGivenName;
		private Commanigy.Controls.LabelLine llNameDetails;
		private Commanigy.Controls.SyncPictureBox pbxProfile;
		private Label lblFullName;
		private TextBox tbFullName;
		private Button btnFullName;
		private Label lblEmail;
		private TextBox tbEmail;
		private Button button3;
		private Button button1;
		private Button button2;
		private TabPage tpAlerts;
		private Label label5;
		private PictureBox pictureBox5;
		private Commanigy.Controls.LabelLine labelLine3;
		private TabPage tpConnection;
		private Commanigy.Controls.LabelLine labelLine2;
		private PictureBox pictureBox4;
		private Label label4;
		private TabPage tpPresence;
		private IContainer components;

		public FrmPreferences() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPreferences));
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.tcPreferences = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.cbAutoSync = new System.Windows.Forms.CheckBox();
			this.lblSynchronization = new Commanigy.Controls.LabelLine();
			this.pbSync = new System.Windows.Forms.PictureBox();
			this.cbAutoSignIn = new System.Windows.Forms.CheckBox();
			this.pbSignIn = new System.Windows.Forms.PictureBox();
			this.cbAutoStart = new System.Windows.Forms.CheckBox();
			this.lblSignIn = new Commanigy.Controls.LabelLine();
			this.tpProfile = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxSurName = new System.Windows.Forms.TextBox();
			this.tbxMiddleName = new System.Windows.Forms.TextBox();
			this.tbxGivenName = new System.Windows.Forms.TextBox();
			this.llNameDetails = new Commanigy.Controls.LabelLine();
			this.pbxProfile = new Commanigy.Controls.SyncPictureBox();
			this.lblFullName = new System.Windows.Forms.Label();
			this.tbFullName = new System.Windows.Forms.TextBox();
			this.btnFullName = new System.Windows.Forms.Button();
			this.lblEmail = new System.Windows.Forms.Label();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tpAlerts = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.labelLine3 = new Commanigy.Controls.LabelLine();
			this.tpConnection = new System.Windows.Forms.TabPage();
			this.labelLine2 = new Commanigy.Controls.LabelLine();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tpPresence = new System.Windows.Forms.TabPage();
			this.tcPreferences.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSync)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSignIn)).BeginInit();
			this.tpProfile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxProfile)).BeginInit();
			this.tpAlerts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
			this.tpConnection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Name = "btnOk";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnApply
			// 
			resources.ApplyResources(this.btnApply, "btnApply");
			this.btnApply.Name = "btnApply";
			// 
			// tcPreferences
			// 
			resources.ApplyResources(this.tcPreferences, "tcPreferences");
			this.tcPreferences.Controls.Add(this.tpGeneral);
			this.tcPreferences.Controls.Add(this.tpProfile);
			this.tcPreferences.Controls.Add(this.tpAlerts);
			this.tcPreferences.Controls.Add(this.tpConnection);
			this.tcPreferences.Controls.Add(this.tpPresence);
			this.tcPreferences.Name = "tcPreferences";
			this.tcPreferences.SelectedIndex = 0;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.cbAutoSync);
			this.tpGeneral.Controls.Add(this.lblSynchronization);
			this.tpGeneral.Controls.Add(this.pbSync);
			this.tpGeneral.Controls.Add(this.cbAutoSignIn);
			this.tpGeneral.Controls.Add(this.pbSignIn);
			this.tpGeneral.Controls.Add(this.cbAutoStart);
			this.tpGeneral.Controls.Add(this.lblSignIn);
			resources.ApplyResources(this.tpGeneral, "tpGeneral");
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// cbAutoSync
			// 
			this.cbAutoSync.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.cbAutoSync, "cbAutoSync");
			this.cbAutoSync.Name = "cbAutoSync";
			this.cbAutoSync.UseVisualStyleBackColor = false;
			// 
			// lblSynchronization
			// 
			resources.ApplyResources(this.lblSynchronization, "lblSynchronization");
			this.lblSynchronization.BackColor = System.Drawing.Color.Transparent;
			this.lblSynchronization.Name = "lblSynchronization";
			// 
			// pbSync
			// 
			this.pbSync.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.pbSync, "pbSync");
			this.pbSync.Name = "pbSync";
			this.pbSync.TabStop = false;
			// 
			// cbAutoSignIn
			// 
			this.cbAutoSignIn.BackColor = System.Drawing.Color.Transparent;
			this.cbAutoSignIn.Checked = true;
			this.cbAutoSignIn.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.cbAutoSignIn, "cbAutoSignIn");
			this.cbAutoSignIn.Name = "cbAutoSignIn";
			this.cbAutoSignIn.UseVisualStyleBackColor = false;
			// 
			// pbSignIn
			// 
			this.pbSignIn.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.pbSignIn, "pbSignIn");
			this.pbSignIn.Name = "pbSignIn";
			this.pbSignIn.TabStop = false;
			// 
			// cbAutoStart
			// 
			this.cbAutoStart.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.cbAutoStart, "cbAutoStart");
			this.cbAutoStart.Name = "cbAutoStart";
			this.cbAutoStart.UseVisualStyleBackColor = false;
			// 
			// lblSignIn
			// 
			resources.ApplyResources(this.lblSignIn, "lblSignIn");
			this.lblSignIn.BackColor = System.Drawing.Color.Transparent;
			this.lblSignIn.Name = "lblSignIn";
			// 
			// tpProfile
			// 
			resources.ApplyResources(this.tpProfile, "tpProfile");
			this.tpProfile.Controls.Add(this.label2);
			this.tpProfile.Controls.Add(this.label1);
			this.tpProfile.Controls.Add(this.label3);
			this.tpProfile.Controls.Add(this.tbxSurName);
			this.tpProfile.Controls.Add(this.tbxMiddleName);
			this.tpProfile.Controls.Add(this.tbxGivenName);
			this.tpProfile.Controls.Add(this.llNameDetails);
			this.tpProfile.Controls.Add(this.pbxProfile);
			this.tpProfile.Controls.Add(this.lblFullName);
			this.tpProfile.Controls.Add(this.tbFullName);
			this.tpProfile.Controls.Add(this.btnFullName);
			this.tpProfile.Controls.Add(this.lblEmail);
			this.tpProfile.Controls.Add(this.tbEmail);
			this.tpProfile.Controls.Add(this.button3);
			this.tpProfile.Controls.Add(this.button1);
			this.tpProfile.Controls.Add(this.button2);
			this.tpProfile.Name = "tpProfile";
			this.tpProfile.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// tbxSurName
			// 
			resources.ApplyResources(this.tbxSurName, "tbxSurName");
			this.tbxSurName.Name = "tbxSurName";
			// 
			// tbxMiddleName
			// 
			resources.ApplyResources(this.tbxMiddleName, "tbxMiddleName");
			this.tbxMiddleName.Name = "tbxMiddleName";
			// 
			// tbxGivenName
			// 
			resources.ApplyResources(this.tbxGivenName, "tbxGivenName");
			this.tbxGivenName.Name = "tbxGivenName";
			// 
			// llNameDetails
			// 
			resources.ApplyResources(this.llNameDetails, "llNameDetails");
			this.llNameDetails.BackColor = System.Drawing.Color.Transparent;
			this.llNameDetails.Name = "llNameDetails";
			// 
			// pbxProfile
			// 
			this.pbxProfile.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.pbxProfile, "pbxProfile");
			this.pbxProfile.Name = "pbxProfile";
			this.pbxProfile.Synchronizing = false;
			this.pbxProfile.TabStop = false;
			this.pbxProfile.Click += new System.EventHandler(this.pbxProfile_Click);
			// 
			// lblFullName
			// 
			this.lblFullName.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.lblFullName, "lblFullName");
			this.lblFullName.Name = "lblFullName";
			// 
			// tbFullName
			// 
			resources.ApplyResources(this.tbFullName, "tbFullName");
			this.tbFullName.Name = "tbFullName";
			// 
			// btnFullName
			// 
			resources.ApplyResources(this.btnFullName, "btnFullName");
			this.btnFullName.Name = "btnFullName";
			this.btnFullName.Click += new System.EventHandler(this.btnFullName_Click);
			// 
			// lblEmail
			// 
			this.lblEmail.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.lblEmail, "lblEmail");
			this.lblEmail.Name = "lblEmail";
			// 
			// tbEmail
			// 
			resources.ApplyResources(this.tbEmail, "tbEmail");
			this.tbEmail.Name = "tbEmail";
			// 
			// button3
			// 
			resources.ApplyResources(this.button3, "button3");
			this.button3.Name = "button3";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			resources.ApplyResources(this.button2, "button2");
			this.button2.Name = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tpAlerts
			// 
			this.tpAlerts.Controls.Add(this.label5);
			this.tpAlerts.Controls.Add(this.pictureBox5);
			this.tpAlerts.Controls.Add(this.labelLine3);
			resources.ApplyResources(this.tpAlerts, "tpAlerts");
			this.tpAlerts.Name = "tpAlerts";
			this.tpAlerts.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// pictureBox5
			// 
			this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.pictureBox5, "pictureBox5");
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.TabStop = false;
			// 
			// labelLine3
			// 
			resources.ApplyResources(this.labelLine3, "labelLine3");
			this.labelLine3.BackColor = System.Drawing.Color.Transparent;
			this.labelLine3.Name = "labelLine3";
			// 
			// tpConnection
			// 
			this.tpConnection.Controls.Add(this.labelLine2);
			this.tpConnection.Controls.Add(this.pictureBox4);
			this.tpConnection.Controls.Add(this.label4);
			resources.ApplyResources(this.tpConnection, "tpConnection");
			this.tpConnection.Name = "tpConnection";
			this.tpConnection.UseVisualStyleBackColor = true;
			// 
			// labelLine2
			// 
			resources.ApplyResources(this.labelLine2, "labelLine2");
			this.labelLine2.BackColor = System.Drawing.Color.Transparent;
			this.labelLine2.Name = "labelLine2";
			// 
			// pictureBox4
			// 
			this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.pictureBox4, "pictureBox4");
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.TabStop = false;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// tpPresence
			// 
			resources.ApplyResources(this.tpPresence, "tpPresence");
			this.tpPresence.Name = "tpPresence";
			this.tpPresence.UseVisualStyleBackColor = true;
			// 
			// FrmPreferences
			// 
			this.AcceptButton = this.btnOk;
			resources.ApplyResources(this, "$this");
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.tcPreferences);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnApply);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmPreferences";
			this.ShowInTaskbar = false;
			this.tcPreferences.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbSync)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSignIn)).EndInit();
			this.tpProfile.ResumeLayout(false);
			this.tpProfile.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxProfile)).EndInit();
			this.tpAlerts.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
			this.tpConnection.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e) {
			QueryProfile();
		}

		/// <summary>
		/// 
		/// </summary>
		private void QueryProfile() {
			pbxProfile.Synchronizing = true;

			QueryRequestType req = new QueryRequestType();
			XpQueryType qt = new XpQueryType();
			qt.Select = "/m:IqProfile";
			req.XpQuery = new XpQueryType[] { qt };
			iqProfileService.BeginQuery(req, new AsyncCallback(OnProfileQueryResponse), iqProfileService);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="result"></param>
		private void OnProfileQueryResponse(IAsyncResult result) {
			IqProfile iqProfile = (IqProfile)result.AsyncState;

			try {
				QueryResponseType res = iqProfile.EndQuery(result);

				pbxProfile.BeginInvoke((MethodInvoker)delegate() {
					pbxProfile.Synchronizing = false;
				});

				if (res != null && res.XpQueryResponse.Length == 1 && res.XpQueryResponse[0].Status == ResponseStatus.Success) {
					profile = (IqProfileType)ServiceUtils.GetObject(typeof(IqProfileType), res.XpQueryResponse[0].Any[0]);
					log.Debug("Profile ChangeNumber: " + profile.ChangeNumber);
					this.BeginInvoke(
						(MethodInvoker)delegate() { SetProfile(profile); }
						);
				}
			}
			catch (System.Web.Services.Protocols.SoapException se) {
				log.Error("Failed to query profile", se);
				MessageBox.Show(se.Message);
			}
		}

		private void SetProfile(IqProfileType profile) {
			this.tbxGivenName.Text = "";
			this.tbxMiddleName.Text = "";
			this.tbxSurName.Text = "";
			this.tbEmail.Text = "";

			if (profile == null) {
				return;
			}

			if (profile.Name != null && profile.Name.Length > 0) {
				this.tbxGivenName.Text = profile.Name[0].GivenName.Value;
				this.tbxMiddleName.Text = profile.Name[0].MiddleName.Value;
				this.tbxSurName.Text = profile.Name[0].SurName.Value;
			}

			if (profile.EmailAddress != null && profile.EmailAddress.Length > 0) {
				this.tbEmail.Text = profile.EmailAddress[0].Email;
			}
		}

		/// <summary>
		/// Creates a single string concatenating full name details such as 
		/// first-, middle- and surname and title.
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		private string MakeFullName(NameType v) {
			if (v == null) {
				return "";
			}

			StringBuilder sb = new StringBuilder();
			if (v.Title != null) {
				sb.Append(v.Title.Value + " ");
			}

			if (v.GivenName != null) {
				sb.Append(v.GivenName.Value + " ");
			}

			if (v.MiddleName != null) {
				sb.Append(v.MiddleName.Value + " ");
			}

			if (v.SurName != null) {
				sb.Append(v.SurName.Value + " ");
			}

			if (v.Suffix != null) {
				sb.Append(v.Suffix.Value + " ");
			}

			return sb.ToString().Trim();
		}

		private LocalizableString MyLocalizableString(string v) {
			LocalizableString s = new LocalizableString();
			s.lang = "en-US";
			s.Value = v;
			return s;
		}

		private void button2_Click(object sender, System.EventArgs e) {
			ReplaceRequestType req = new ReplaceRequestType();
			req.Select = "/m:IqProfile";
			req.MinOccurs = 1;
			req.MaxOccurs = 1;

			// update internal structure before updating remotely
			NameType name = null;
			if (profile.Name == null) {
				profile.Name = new NameType[1];
				name = new NameType();
			} else {
				name = profile.Name[0];
			}

			//name.Title = MyLocalizableString("x");
			name.GivenName = MyLocalizableString(tbxGivenName.Text);
			name.MiddleName = MyLocalizableString(tbxMiddleName.Text);
			name.SurName = MyLocalizableString(tbxSurName.Text);
			//name.Suffix = MyLocalizableString("x");

			profile.Name[0] = name;

			EmailAddressBlueType email = null;
			if (profile.EmailAddress == null) {
				profile.EmailAddress = new EmailAddressBlueType[1];
				email = new EmailAddressBlueType();
			} else {
				email = profile.EmailAddress[0];
			}

			email.Name = MyLocalizableString("Personal E-mail");
			email.Email = tbEmail.Text;

			profile.EmailAddress[0] = email;

			req.Any = new XmlElement[] { ServiceUtils.SetObject(
										profile,
										"IqProfile"
										) };

			iqProfileService.BeginReplace(req, new AsyncCallback(OnProfileReplaceResponse), iqProfileService);
		}

		private void OnProfileReplaceResponse(IAsyncResult result) {
			IqProfile iqProfile = (IqProfile)result.AsyncState;

			try {
				ReplaceResponseType res = iqProfile.EndReplace(result);

				if (res != null && res.Status == ResponseStatus.Success) {
					MessageBox.Show("Updated");
					profile.ChangeNumber = res.NewChangeNumber;
				} else {
					MessageBox.Show("Failed to update");
				}
			}
			catch (System.Web.Services.Protocols.SoapException se) {
				MessageBox.Show(se.Message);
			}
		}

		private void button3_Click(object sender, System.EventArgs e) {
			InsertRequestType req = new InsertRequestType();
			req.Select = "/m:IqProfile";
			req.MinOccurs = 1;
			req.MinOccursSpecified = true;
			profile.EmailAddress = new EmailAddressBlueType[1];
			profile.EmailAddress[0] = new EmailAddressBlueType();
			profile.EmailAddress[0].Email = "peter@theill.com";
			profile.EmailAddress[0].Name = new LocalizableString();
			profile.EmailAddress[0].Name.lang = "en-US";
			profile.EmailAddress[0].Name.Value = "Personal E-mail";
			//req.Any = new XmlElement[] { ServiceUtils.SetObject(typeof(emailAddressType), profile.emailAddress[0], "emailAddress") };
			req.Any = new XmlElement[] { ServiceUtils.SetObject(profile.EmailAddress[0], "EmailAddress") };
			InsertResponseType ires = iqProfileService.Insert(req);
			MessageBox.Show(ires.Status.ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFullName_Click(object sender, System.EventArgs e) {
			// open "Name" section of IqProfile
			FrmProfileName a = new FrmProfileName();
			a.ProfileName = profile.Name[0];
			if (a.ShowDialog() == DialogResult.OK) {
				profile.Name[0] = a.ProfileName;
				tbFullName.Text = a.ProfileName.GivenName.Value + " " + a.ProfileName.SurName.Value;
			}
		}

		private void pbxProfile_Click(object sender, System.EventArgs e) {

		}

		private void btnOk_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

	}
}