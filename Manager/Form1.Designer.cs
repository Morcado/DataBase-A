namespace Manager {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renameDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renameTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.closeDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tablesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(368, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDBToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeDBToolStripMenuItem,
            this.toolStripSeparator1,
            this.renameDBToolStripMenuItem,
            this.deleteDBToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openToolStripMenuItem.Text = "Open DB";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// renameDBToolStripMenuItem
			// 
			this.renameDBToolStripMenuItem.Enabled = false;
			this.renameDBToolStripMenuItem.Name = "renameDBToolStripMenuItem";
			this.renameDBToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.renameDBToolStripMenuItem.Text = "Rename DB";
			this.renameDBToolStripMenuItem.Click += new System.EventHandler(this.renameDBToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// deleteDBToolStripMenuItem
			// 
			this.deleteDBToolStripMenuItem.Enabled = false;
			this.deleteDBToolStripMenuItem.Name = "deleteDBToolStripMenuItem";
			this.deleteDBToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.deleteDBToolStripMenuItem.Text = "Delete DB";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// tablesToolStripMenuItem
			// 
			this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTableToolStripMenuItem,
            this.deleteTableToolStripMenuItem,
            this.renameTableToolStripMenuItem});
			this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
			this.tablesToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.tablesToolStripMenuItem.Text = "Tables";
			// 
			// newTableToolStripMenuItem
			// 
			this.newTableToolStripMenuItem.Enabled = false;
			this.newTableToolStripMenuItem.Name = "newTableToolStripMenuItem";
			this.newTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.newTableToolStripMenuItem.Text = "New table";
			// 
			// deleteTableToolStripMenuItem
			// 
			this.deleteTableToolStripMenuItem.Enabled = false;
			this.deleteTableToolStripMenuItem.Name = "deleteTableToolStripMenuItem";
			this.deleteTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.deleteTableToolStripMenuItem.Text = "Delete table";
			// 
			// renameTableToolStripMenuItem
			// 
			this.renameTableToolStripMenuItem.Enabled = false;
			this.renameTableToolStripMenuItem.Name = "renameTableToolStripMenuItem";
			this.renameTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.renameTableToolStripMenuItem.Text = "Rename Table";
			// 
			// treeView1
			// 
			this.treeView1.Enabled = false;
			this.treeView1.Location = new System.Drawing.Point(30, 73);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(212, 265);
			this.treeView1.TabIndex = 1;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(249, 73);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "New Table";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(248, 102);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Delete table";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(249, 132);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(95, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "Rename Table";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "label1";
			this.label1.Visible = false;
			// 
			// closeDBToolStripMenuItem
			// 
			this.closeDBToolStripMenuItem.Enabled = false;
			this.closeDBToolStripMenuItem.Name = "closeDBToolStripMenuItem";
			this.closeDBToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.closeDBToolStripMenuItem.Text = "Close DB";
			this.closeDBToolStripMenuItem.Click += new System.EventHandler(this.closeDBToolStripMenuItem_Click);
			// 
			// newDBToolStripMenuItem
			// 
			this.newDBToolStripMenuItem.Name = "newDBToolStripMenuItem";
			this.newDBToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.newDBToolStripMenuItem.Text = "New DB";
			this.newDBToolStripMenuItem.Click += new System.EventHandler(this.newDBToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(368, 389);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Data Base Management System";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem renameDBToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem deleteDBToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newTableToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteTableToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem renameTableToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeDBToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newDBToolStripMenuItem;
	}
}

