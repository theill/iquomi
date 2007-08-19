#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using outlook = Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

#endregion

namespace Commanigy.Iquomi.Services.IqProfile.Client.Windows.Outlook {
	/// <summary>
	/// <remarks>http://www.codeproject.com/dotnet/PropertyPages.asp</remarks>
	/// </summary>
	public partial class IquomiPropertyPage : UserControl, outlook.PropertyPage {
		private outlook.PropertyPageSite ppSite;

		private bool dirty;

		public IquomiPropertyPage() {
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
		}

		/// <summary>
		/// Fixes an issue with Outlook and "Pages.Add"
		/// </summary>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("The text displayed in the caption of the property page.")]
		[DispId(-518)]
		public override string Text {
			get {
				return base.Text;
			}
			set {
				base.Text = value;
			}
		}

		#region PropertyPage Members

		public void Apply() {

			//RegistryKey r = Registry.CurrentUser.OpenSubKey(@"Software\Commanigy\Iquomi\IqContacts", true);
			//if (r == null) {
			//    r = Registry.CurrentUser.CreateSubKey(@"Software\Commanigy\Iquomi\IqContacts");
			//}

			//if (r == null) {
			//    System.Windows.Forms.MessageBox.Show("It's not possible to write to your Registry so settings can't be persisted.");
			//    return;
			//}

			//r.SetValue("Iqid", tbIqid.Text, RegistryValueKind.String);
			//if (tbPassword.Text.Length > 0) {
			//    r.SetValue("Password", Hash(tbPassword.Text), RegistryValueKind.String);
			//}
			dirty = false;
		}

		public bool Dirty {
			get {
				return dirty;
			}
		}

		public void GetPageInfo(ref string HelpFile, ref int HelpContext) {

		}

		#endregion

		protected string Hash(string v) {
			MD5 md5 = MD5.Create();
			md5.Initialize();

			string hashed = Convert.ToBase64String(
				md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(v))
				);
			md5.Clear();
			return hashed;
		}

		private void IquomiPropertyPage_Load(object sender, EventArgs e) {
			Type myType = typeof(System.Object);
			string assembly = System.Text.RegularExpressions.Regex.Replace(myType.Assembly.CodeBase,
			  "mscorlib.dll", "System.Windows.Forms.dll");
			assembly = System.Text.RegularExpressions.Regex.Replace(assembly, "file:///", "");
			assembly = System.Reflection.AssemblyName.GetAssemblyName(assembly).FullName;
			Type unmanaged = Type.GetType(System.Reflection.Assembly.CreateQualifiedName(
			  assembly, "System.Windows.Forms.UnsafeNativeMethods"));
			Type oleObj = unmanaged.GetNestedType("IOleObject");
			System.Reflection.MethodInfo mi = oleObj.GetMethod("GetClientSite");
			object myppSite = mi.Invoke(this, null);
			this.ppSite = (outlook.PropertyPageSite)myppSite;
		}

	}
}