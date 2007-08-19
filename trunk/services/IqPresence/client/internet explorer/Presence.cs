#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

#endregion

namespace InternetExplorer {
	public partial class Presence : UserControl {
		public Presence() {
			InitializeComponent();
		}

		private void InitializeComponent() {
			System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Node3");
			System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Node4");
			System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32});
			System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Node5");
			System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Node6");
			System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Node7");
			System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35,
            treeNode36});
			System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Node8");
			System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Node9");
			System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
            treeNode38,
            treeNode39});
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView1.Location = new System.Drawing.Point(3, 3);
			this.treeView1.Name = "treeView1";
			treeNode31.Name = "Node3";
			treeNode31.Text = "Node3";
			treeNode32.Name = "Node4";
			treeNode32.Text = "Node4";
			treeNode33.Name = "Node0";
			treeNode33.Text = "Node0";
			treeNode34.Name = "Node5";
			treeNode34.Text = "Node5";
			treeNode35.Name = "Node6";
			treeNode35.Text = "Node6";
			treeNode36.Name = "Node7";
			treeNode36.Text = "Node7";
			treeNode37.Name = "Node1";
			treeNode37.Text = "Node1";
			treeNode38.Name = "Node8";
			treeNode38.Text = "Node8";
			treeNode39.Name = "Node9";
			treeNode39.Text = "Node9";
			treeNode40.Name = "Node2";
			treeNode40.Text = "Node2";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode33,
            treeNode37,
            treeNode40});
			this.treeView1.Size = new System.Drawing.Size(193, 314);
			this.treeView1.TabIndex = 1;
			// 
			// richTextBox1
			// 
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(202, 3);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(375, 314);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// Presence
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.treeView1);
			this.Name = "Presence";
			this.Size = new System.Drawing.Size(580, 320);
			this.ResumeLayout(false);

		}
	}
}
