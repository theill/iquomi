using System;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using Extensibility;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IquomiAddIn.localhost;

namespace IquomiAddIn {
	
	#region Read me for Add-in installation and setup information.
	// When run, the Add-in wizard prepared the registry for the Add-in.
	// At a later time, if the Add-in becomes unavailable for reasons such as:
	//   1) You moved this project to a computer other than which is was originally created on.
	//   2) You chose 'Yes' when presented with a message asking if you wish to remove the Add-in.
	//   3) Registry corruption.
	// you will need to re-register the Add-in by building the MyAddin21Setup project 
	// by right clicking the project in the Solution Explorer, then choosing install.
	#endregion
	
	/// <summary>
	///   The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[GuidAttribute("FEFE31C1-88D0-459F-92A7-EC59F3BC5AC4"), ProgId("IquomiAddIn.Connect")]
	public class Connect : Object, Extensibility.IDTExtensibility2 {
		private object applicationObject;
		private object addInInstance;

		private Microsoft.Office.Interop.Outlook.Items NotesItems;

		/// <summary>
		///		Implements the constructor for the Add-in object.
		///		Place your initialization code within this method.
		/// </summary>
		public Connect() {
			;
		}

		/// <summary>
		///      Implements the OnConnection method of the IDTExtensibility2 interface.
		///      Receives notification that the Add-in is being loaded.
		/// </summary>
		/// <param term='application'>
		///      Root object of the host application.
		/// </param>
		/// <param term='connectMode'>
		///      Describes how the Add-in is being loaded.
		/// </param>
		/// <param term='addInInst'>
		///      Object representing this Add-in.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom) {
			applicationObject = application;
			addInInstance = addInInst;

			if (connectMode != Extensibility.ext_ConnectMode.ext_cm_Startup) {
				OnStartupComplete(ref custom);
			}
			
			Microsoft.Office.Interop.Outlook._Application x = (Microsoft.Office.Interop.Outlook._Application)application;
			Microsoft.Office.Interop.Outlook.MAPIFolder f = x.GetNamespace("MAPI").GetDefaultFolder(OlDefaultFolders.olFolderNotes);
			foreach (Microsoft.Office.Interop.Outlook.NoteItem it in f.Items) {
//				MessageBox.Show("Subject:"+it.Subject + "\nEntryId:" + it.EntryID);
			}
			
			NotesItems = f.Items;
			NotesItems.ItemAdd += new Microsoft.Office.Interop.Outlook.ItemsEvents_ItemAddEventHandler(this.ItemAdd);
			NotesItems.ItemChange += new Microsoft.Office.Interop.Outlook.ItemsEvents_ItemChangeEventHandler(this.ItemChange);
			NotesItems.ItemRemove += new Microsoft.Office.Interop.Outlook.ItemsEvents_ItemRemoveEventHandler(this.ItemRemove);
			
			Marshal.ReleaseComObject(f);
			Marshal.ReleaseComObject(x);
		}

		public void ItemAdd(object item) {
			Microsoft.Office.Interop.Outlook.NoteItem x = (Microsoft.Office.Interop.Outlook.NoteItem)item;
			MessageBox.Show("New Item: " + x.Subject);

			try {
//				Iquomi.IquomiService ns = new Iquomi.IquomiService();
//				Iquomi.Item it = new Iquomi.Item();
//				it.StorePath = "//notes";
//				it.StoreObject = "<note><title>" + "Outlook(tm) Note" + "</title><description>" + x.Subject + "</description></note>";
//				it = ns.Create(it);

				localhost.Service myService = new IquomiAddIn.localhost.Service();
				myService.AuthenticationTypeValue = new AuthenticationType();
				myService.AuthenticationTypeValue.Iqid = "petertheill";
				myService.AuthenticationTypeValue.Password = "g5zTb4oNXBR1VWyUqhNdcQ==";
				myService.RequestTypeValue = new RequestType();
				myService.RequestTypeValue.OwnerIqid = "petertheill";
				myService.RequestTypeValue.Service = "OutlookNotes";
				
				localhost.InsertRequestType req = new IquomiAddIn.localhost.InsertRequestType();
				req.Select = "//notes";
				req.Any = "<note id=\"\"><title>" + "Outlook(tm) Note via ws" + "</title><description>" + x.Subject + "</description></note>";
				req.MinOccurs = new IquomiAddIn.localhost.MinOccursType();
				req.MinOccurs.Value = 1;
				req.UseClientIds = new IquomiAddIn.localhost.UseClientIdsType();
				req.UseClientIds.Value = false;
				MessageBox.Show("Inserting");
				localhost.InsertResponseType res = myService.Insert(req);
				MessageBox.Show("Inserting done!");
				if (res.Status == localhost.ResponseStatus.Success) {
					MessageBox.Show("Got back: " + res.NewIds[0].Id);
				} else {
					MessageBox.Show("Else was here!");
				}

			}
			catch (System.Exception e) {
				MessageBox.Show(e.Message);
				MessageBox.Show(e.StackTrace);
			}
		}

		public void ItemChange(object item) {
			Microsoft.Office.Interop.Outlook.NoteItem x = (Microsoft.Office.Interop.Outlook.NoteItem)item;
			MessageBox.Show("Update item: " + x.Subject);

//			Iquomi.IquomiService ns = new Iquomi.IquomiService();
//			Iquomi.Item it = new Iquomi.Item();
//			it.StorePath = "//notes/[@description='"+x.Subject+"']";
//			it.StoreObject = "<note><title>" + x.Subject.Substring(0, 20) + "</title><description>" + x.Subject + "</description></note>";
//			it = ns.Update(it);
		}

		public void ItemRemove() {
			MessageBox.Show("Remove item: ");

			localhost.Service myService = new IquomiAddIn.localhost.Service();
			myService.AuthenticationTypeValue = new AuthenticationType();
			myService.AuthenticationTypeValue.Iqid = "petertheill";
			myService.AuthenticationTypeValue.Password = "g5zTb4oNXBR1VWyUqhNdcQ==";
			myService.RequestTypeValue = new RequestType();
			myService.RequestTypeValue.OwnerIqid = "petertheill";
			myService.RequestTypeValue.Service = "OutlookNotes";
			
			localhost.DeleteRequestType req = new IquomiAddIn.localhost.DeleteRequestType();
			req.Select = "//notes/note[@id='first']";
			req.MinOccurs = new IquomiAddIn.localhost.MinOccursType();
			req.MinOccurs.Value = 1;
			req.MaxOccurs = new IquomiAddIn.localhost.MaxOccursType();
			req.MaxOccurs.Value = 1;
			MessageBox.Show("Deleting");
			localhost.DeleteResponseType res = myService.Delete(req);
			MessageBox.Show("Deleting done!");
			if (res.Status == localhost.ResponseStatus.Success) {
				MessageBox.Show("done - it's gone!");
			} else {
				MessageBox.Show("Else was here!");
			}
		}

		/// <summary>
		///     Implements the OnDisconnection method of the IDTExtensibility2 interface.
		///     Receives notification that the Add-in is being unloaded.
		/// </summary>
		/// <param term='disconnectMode'>
		///      Describes how the Add-in is being unloaded.
		/// </param>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom) {
			if (disconnectMode != Extensibility.ext_DisconnectMode.ext_dm_HostShutdown) {
				OnBeginShutdown(ref custom);

			}

			applicationObject = null;
		}

		/// <summary>
		///      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
		///      Receives notification that the collection of Add-ins has changed.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnAddInsUpdate(ref System.Array custom) {
			;
		}

		/// <summary>
		///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		///      Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref System.Array custom) {
			;
		}

		/// <summary>
		///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		///      Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref System.Array custom) {
			;
		}
	}
}