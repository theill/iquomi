using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NotesService {
	/// <summary>
	/// Summary description for NoteItem.
	/// </summary>
	public class NoteItem : System.Windows.Forms.ListViewItem {
		public object Data;
		
		public NoteItem(string[] args): base(args) {
			;
		}

	}
}
