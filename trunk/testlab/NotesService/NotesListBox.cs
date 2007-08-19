using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace NotesService {
	/// <summary>
	/// Summary description for NotesListBox.
	/// </summary>
	public class NotesListBox : System.Windows.Forms.ListBox {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Font titleFont_ = null;
		private Font descriptionFont_ = null;
		private StringFormat ellipsisFormat_ = null;
		
		public NotesListBox() : base() {
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			titleFont_ = new Font("Tahoma", 8.0f, FontStyle.Bold);
			descriptionFont_ = new Font("Tahoma", 8.0f);
			
			ellipsisFormat_ = new StringFormat();
			ellipsisFormat_.Trimming = StringTrimming.EllipsisCharacter;
			
			InsertDebugData();
		}
		
		private void InsertDebugData() {
			DataSet data = new DataSet("notes");
			DataTable note = data.Tables.Add("note");
			note.Columns.Add("title");
			note.Columns.Add("description");
			
			for (int i = 0; i < 10; i ++) {
				DataRow row = note.NewRow();
				row["title"] = "This is the " + (i+1) + ". title ";
				row["description"] = "If your application creates multiple run times, the application may need to know which run time a context is associated with. In this case, call JS_GetRuntime, and pass the context as an argument. JS_GetRuntime returns a pointer to the appropriate run time if there is one:";
				note.Rows.Add(row);
			}
			
			this.DataSource = data;
			this.DisplayMember = "note.title";
		}
		
		protected override void OnDrawItem(DrawItemEventArgs e) {

			//			base.OnDrawItem(e);
			if (e.Index < 0) {
				return;
			}
			
			DataSet data = (DataSet)this.DataSource;
			if (data == null) {
				return;
			}
			
			DataRow note = null;
			try {
				note = data.Tables["note"].Rows[e.Index];
			}
			catch (IndexOutOfRangeException ex) {
				Console.Out.WriteLine(ex);
				return;
			}
			
			bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			
			Graphics g = e.Graphics;
			Bitmap localBitmap = new Bitmap(e.Bounds.Width, e.Bounds.Height);
			Graphics bitmapGraphics = Graphics.FromImage(localBitmap);
			bitmapGraphics.Clear(BackColor);

			Rectangle bounds = new Rectangle(0, 0, e.Bounds.Width, e.Bounds.Height);
			
			if (selected) {
				bitmapGraphics.FillRectangle(
					SystemBrushes.Info,
					bounds
					);

				bitmapGraphics.FillRectangle(
					SystemBrushes.Highlight,
					0,
					0,
					8,
					bounds.Height
					);

				bitmapGraphics.DrawLine(
					SystemPens.Highlight, 
					bounds.Width - 8,
					2,
					bounds.Width - 4,
					2
					);

				bitmapGraphics.DrawLine(
					SystemPens.Highlight, 
					bounds.Width - 4,
					2,
					bounds.Width - 4,
					6
					);

				bitmapGraphics.DrawLine(
					SystemPens.Highlight, 
					bounds.Width - 4,
					bounds.Height - 8,
					bounds.Width - 4,
					bounds.Height - 4
					);

				bitmapGraphics.DrawLine(
					SystemPens.Highlight, 
					bounds.Width - 8,
					bounds.Height - 4,
					bounds.Width - 4,
					bounds.Height - 4
					);
			}
			
			Brush b = selected ? SystemBrushes.WindowText : SystemBrushes.InactiveCaption;

			Rectangle clip;
			
			clip = new Rectangle(
				12,
				4,
				bounds.Width - 12 - 4,
				4 + titleFont_.Height
				);
			bitmapGraphics.DrawString(
				!note.IsNull("title") ? (string)note["title"] : "",
				titleFont_,
				b,
				clip,
				ellipsisFormat_
				);

			clip = new Rectangle(
				12,
				4 + titleFont_.Height + 2,
				bounds.Width - 12 - 4,
				descriptionFont_.Height * 2
				);
			bitmapGraphics.DrawString(
				!note.IsNull("description") ? (string)note["description"] : "",
				descriptionFont_,
				b,
				clip,
				ellipsisFormat_
				);

			// push our bitmap forward to the screen
			g.DrawImage(localBitmap, e.Bounds.Left, e.Bounds.Top);

			bitmapGraphics.Dispose();
			localBitmap.Dispose();
			g.Dispose();
			
		}
		
		protected override void OnMeasureItem(MeasureItemEventArgs e) {
			e.ItemHeight = 4 + titleFont_.Height + 2 + descriptionFont_.Height * 2 + 4;
		}
		
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			// 
			// NotesListBox
			// 
			this.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.IntegralHeight = false;
			this.Size = new System.Drawing.Size(150, 216);

		}
		#endregion
	}
}
