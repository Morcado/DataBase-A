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
			this.newDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.renameDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renameTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.btnNewTable = new System.Windows.Forms.Button();
			this.btnDeleteTable = new System.Windows.Forms.Button();
			this.btnRenameTable = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAddAttrib = new System.Windows.Forms.Button();
			this.btnDeleteAttrib = new System.Windows.Forms.Button();
			this.treeView2 = new System.Windows.Forms.TreeView();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnModifyAttrib = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tablesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(864, 24);
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
			// newDBToolStripMenuItem
			// 
			this.newDBToolStripMenuItem.Name = "newDBToolStripMenuItem";
			this.newDBToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.newDBToolStripMenuItem.Text = "New DB";
			this.newDBToolStripMenuItem.Click += new System.EventHandler(this.NewDBToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.openToolStripMenuItem.Text = "Open DB";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// closeDBToolStripMenuItem
			// 
			this.closeDBToolStripMenuItem.Enabled = false;
			this.closeDBToolStripMenuItem.Name = "closeDBToolStripMenuItem";
			this.closeDBToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.closeDBToolStripMenuItem.Text = "Close DB";
			this.closeDBToolStripMenuItem.Click += new System.EventHandler(this.CloseDBToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
			// 
			// renameDBToolStripMenuItem
			// 
			this.renameDBToolStripMenuItem.Enabled = false;
			this.renameDBToolStripMenuItem.Name = "renameDBToolStripMenuItem";
			this.renameDBToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.renameDBToolStripMenuItem.Text = "Rename DB";
			this.renameDBToolStripMenuItem.Click += new System.EventHandler(this.RenameDBToolStripMenuItem_Click);
			// 
			// deleteDBToolStripMenuItem
			// 
			this.deleteDBToolStripMenuItem.Enabled = false;
			this.deleteDBToolStripMenuItem.Name = "deleteDBToolStripMenuItem";
			this.deleteDBToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.deleteDBToolStripMenuItem.Text = "Delete DB";
			this.deleteDBToolStripMenuItem.Click += new System.EventHandler(this.DeleteDBToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(132, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
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
			this.newTableToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.newTableToolStripMenuItem.Text = "New table";
			// 
			// deleteTableToolStripMenuItem
			// 
			this.deleteTableToolStripMenuItem.Enabled = false;
			this.deleteTableToolStripMenuItem.Name = "deleteTableToolStripMenuItem";
			this.deleteTableToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.deleteTableToolStripMenuItem.Text = "Delete table";
			// 
			// renameTableToolStripMenuItem
			// 
			this.renameTableToolStripMenuItem.Enabled = false;
			this.renameTableToolStripMenuItem.Name = "renameTableToolStripMenuItem";
			this.renameTableToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.renameTableToolStripMenuItem.Text = "Rename Table";
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(12, 73);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(212, 265);
			this.treeView1.TabIndex = 1;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
			// 
			// btnNewTable
			// 
			this.btnNewTable.Enabled = false;
			this.btnNewTable.Location = new System.Drawing.Point(230, 72);
			this.btnNewTable.Name = "btnNewTable";
			this.btnNewTable.Size = new System.Drawing.Size(96, 23);
			this.btnNewTable.TabIndex = 2;
			this.btnNewTable.Text = "New Table";
			this.btnNewTable.UseVisualStyleBackColor = true;
			this.btnNewTable.Click += new System.EventHandler(this.BtnNewTable_Click);
			// 
			// btnDeleteTable
			// 
			this.btnDeleteTable.Enabled = false;
			this.btnDeleteTable.Location = new System.Drawing.Point(230, 101);
			this.btnDeleteTable.Name = "btnDeleteTable";
			this.btnDeleteTable.Size = new System.Drawing.Size(96, 23);
			this.btnDeleteTable.TabIndex = 3;
			this.btnDeleteTable.Text = "Delete table";
			this.btnDeleteTable.UseVisualStyleBackColor = true;
			this.btnDeleteTable.Click += new System.EventHandler(this.BtnDeleteTable_Click);
			// 
			// btnRenameTable
			// 
			this.btnRenameTable.Enabled = false;
			this.btnRenameTable.Location = new System.Drawing.Point(230, 131);
			this.btnRenameTable.Name = "btnRenameTable";
			this.btnRenameTable.Size = new System.Drawing.Size(96, 23);
			this.btnRenameTable.TabIndex = 4;
			this.btnRenameTable.Text = "Rename Table";
			this.btnRenameTable.UseVisualStyleBackColor = true;
			this.btnRenameTable.Click += new System.EventHandler(this.BtnRenameTable_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tables";
			this.label1.Visible = false;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(550, 72);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(302, 266);
			this.dataGridView1.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(560, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 13);
			this.label2.TabIndex = 8;
			// 
			// btnAddAttrib
			// 
			this.btnAddAttrib.Enabled = false;
			this.btnAddAttrib.Location = new System.Drawing.Point(230, 181);
			this.btnAddAttrib.Name = "btnAddAttrib";
			this.btnAddAttrib.Size = new System.Drawing.Size(96, 23);
			this.btnAddAttrib.TabIndex = 9;
			this.btnAddAttrib.Text = "Add attribute";
			this.btnAddAttrib.UseVisualStyleBackColor = true;
			// 
			// btnDeleteAttrib
			// 
			this.btnDeleteAttrib.Enabled = false;
			this.btnDeleteAttrib.Location = new System.Drawing.Point(230, 210);
			this.btnDeleteAttrib.Name = "btnDeleteAttrib";
			this.btnDeleteAttrib.Size = new System.Drawing.Size(96, 23);
			this.btnDeleteAttrib.TabIndex = 9;
			this.btnDeleteAttrib.Text = "Delete attribute";
			this.btnDeleteAttrib.UseVisualStyleBackColor = true;
			// 
			// treeView2
			// 
			this.treeView2.Location = new System.Drawing.Point(332, 72);
			this.treeView2.Name = "treeView2";
			this.treeView2.Size = new System.Drawing.Size(212, 265);
			this.treeView2.TabIndex = 1;
			this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(329, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Attributes";
			this.label3.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(547, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Tables";
			this.label4.Visible = false;
			// 
			// btnModifyAttrib
			// 
			this.btnModifyAttrib.Enabled = false;
			this.btnModifyAttrib.Location = new System.Drawing.Point(230, 239);
			this.btnModifyAttrib.Name = "btnModifyAttrib";
			this.btnModifyAttrib.Size = new System.Drawing.Size(96, 23);
			this.btnModifyAttrib.TabIndex = 9;
			this.btnModifyAttrib.Text = "Modify attribute";
			this.btnModifyAttrib.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(392, 354);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 10;
			this.button7.Text = "button7";
			this.button7.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 388);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(864, 22);
			this.statusStrip1.TabIndex = 11;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(864, 410);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.btnModifyAttrib);
			this.Controls.Add(this.btnDeleteAttrib);
			this.Controls.Add(this.btnAddAttrib);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnRenameTable);
			this.Controls.Add(this.btnDeleteTable);
			this.Controls.Add(this.btnNewTable);
			this.Controls.Add(this.treeView2);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Data Base Management System";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button btnNewTable;
		private System.Windows.Forms.Button btnDeleteTable;
		private System.Windows.Forms.Button btnRenameTable;
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
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnAddAttrib;
		private System.Windows.Forms.Button btnDeleteAttrib;
		private System.Windows.Forms.TreeView treeView2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnModifyAttrib;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.StatusStrip statusStrip1;
	}
}

