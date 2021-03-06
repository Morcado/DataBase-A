﻿namespace Manager {
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
            this.attributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySelectedEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnNewTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnRenameTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddAttrib = new System.Windows.Forms.Button();
            this.btnDeleteAttrib = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnModifyAttrib = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.btnModifyEntry = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tablesToolStripMenuItem,
            this.attributesToolStripMenuItem,
            this.registersToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
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
            // attributesToolStripMenuItem
            // 
            this.attributesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAttributeToolStripMenuItem,
            this.modifyAttributeToolStripMenuItem,
            this.deleteAttributeToolStripMenuItem});
            this.attributesToolStripMenuItem.Name = "attributesToolStripMenuItem";
            this.attributesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.attributesToolStripMenuItem.Text = "Attributes";
            // 
            // addAttributeToolStripMenuItem
            // 
            this.addAttributeToolStripMenuItem.Enabled = false;
            this.addAttributeToolStripMenuItem.Name = "addAttributeToolStripMenuItem";
            this.addAttributeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addAttributeToolStripMenuItem.Text = "Add Attribute";
            // 
            // modifyAttributeToolStripMenuItem
            // 
            this.modifyAttributeToolStripMenuItem.Enabled = false;
            this.modifyAttributeToolStripMenuItem.Name = "modifyAttributeToolStripMenuItem";
            this.modifyAttributeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.modifyAttributeToolStripMenuItem.Text = "Modify Attribute";
            // 
            // deleteAttributeToolStripMenuItem
            // 
            this.deleteAttributeToolStripMenuItem.Enabled = false;
            this.deleteAttributeToolStripMenuItem.Name = "deleteAttributeToolStripMenuItem";
            this.deleteAttributeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.deleteAttributeToolStripMenuItem.Text = "Delete Attribute";
            // 
            // registersToolStripMenuItem
            // 
            this.registersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEntryToolStripMenuItem,
            this.deleteEntryToolStripMenuItem,
            this.modifySelectedEntryToolStripMenuItem});
            this.registersToolStripMenuItem.Name = "registersToolStripMenuItem";
            this.registersToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.registersToolStripMenuItem.Text = "Registers";
            // 
            // addNewEntryToolStripMenuItem
            // 
            this.addNewEntryToolStripMenuItem.Enabled = false;
            this.addNewEntryToolStripMenuItem.Name = "addNewEntryToolStripMenuItem";
            this.addNewEntryToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.addNewEntryToolStripMenuItem.Text = "Add new entry";
            // 
            // deleteEntryToolStripMenuItem
            // 
            this.deleteEntryToolStripMenuItem.Enabled = false;
            this.deleteEntryToolStripMenuItem.Name = "deleteEntryToolStripMenuItem";
            this.deleteEntryToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.deleteEntryToolStripMenuItem.Text = "Delete entry";
            // 
            // modifySelectedEntryToolStripMenuItem
            // 
            this.modifySelectedEntryToolStripMenuItem.Enabled = false;
            this.modifySelectedEntryToolStripMenuItem.Name = "modifySelectedEntryToolStripMenuItem";
            this.modifySelectedEntryToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.modifySelectedEntryToolStripMenuItem.Text = "Modify selected entry";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 51);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(133, 356);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.treeView1.Leave += new System.EventHandler(this.TreeView1_Leave);
            // 
            // btnNewTable
            // 
            this.btnNewTable.Enabled = false;
            this.btnNewTable.Location = new System.Drawing.Point(13, 29);
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
            this.btnDeleteTable.Location = new System.Drawing.Point(13, 58);
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
            this.btnRenameTable.Location = new System.Drawing.Point(13, 88);
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
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "List of tables";
            this.label1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(280, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(664, 296);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_RowHeaderMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 8;
            // 
            // btnAddAttrib
            // 
            this.btnAddAttrib.Enabled = false;
            this.btnAddAttrib.Location = new System.Drawing.Point(13, 29);
            this.btnAddAttrib.Name = "btnAddAttrib";
            this.btnAddAttrib.Size = new System.Drawing.Size(96, 23);
            this.btnAddAttrib.TabIndex = 9;
            this.btnAddAttrib.Text = "New attribute";
            this.btnAddAttrib.UseVisualStyleBackColor = true;
            this.btnAddAttrib.Click += new System.EventHandler(this.BtnAddAttrib_Click);
            // 
            // btnDeleteAttrib
            // 
            this.btnDeleteAttrib.Enabled = false;
            this.btnDeleteAttrib.Location = new System.Drawing.Point(13, 87);
            this.btnDeleteAttrib.Name = "btnDeleteAttrib";
            this.btnDeleteAttrib.Size = new System.Drawing.Size(96, 23);
            this.btnDeleteAttrib.TabIndex = 9;
            this.btnDeleteAttrib.Text = "Delete attribute";
            this.btnDeleteAttrib.UseVisualStyleBackColor = true;
            this.btnDeleteAttrib.Click += new System.EventHandler(this.BtnDeleteAttrib_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(277, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tables";
            // 
            // btnModifyAttrib
            // 
            this.btnModifyAttrib.Enabled = false;
            this.btnModifyAttrib.Location = new System.Drawing.Point(13, 58);
            this.btnModifyAttrib.Name = "btnModifyAttrib";
            this.btnModifyAttrib.Size = new System.Drawing.Size(96, 23);
            this.btnModifyAttrib.TabIndex = 9;
            this.btnModifyAttrib.Text = "Modify attribute";
            this.btnModifyAttrib.UseVisualStyleBackColor = true;
            this.btnModifyAttrib.Click += new System.EventHandler(this.BtnModifyAttrib_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(956, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddEntry.Enabled = false;
            this.btnAddEntry.Location = new System.Drawing.Point(279, 355);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(92, 23);
            this.btnAddEntry.TabIndex = 14;
            this.btnAddEntry.Text = "Add register";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.BtnAddRegister_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRenameTable);
            this.groupBox1.Controls.Add(this.btnNewTable);
            this.groupBox1.Controls.Add(this.btnDeleteTable);
            this.groupBox1.Location = new System.Drawing.Point(151, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 132);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnModifyAttrib);
            this.groupBox2.Controls.Add(this.btnDeleteAttrib);
            this.groupBox2.Controls.Add(this.btnAddAttrib);
            this.groupBox2.Location = new System.Drawing.Point(151, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 129);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteEntry.Enabled = false;
            this.btnDeleteEntry.Location = new System.Drawing.Point(377, 355);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(92, 23);
            this.btnDeleteEntry.TabIndex = 17;
            this.btnDeleteEntry.Text = "Delete register";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.BtnDeleteRegister_Click);
            // 
            // btnModifyEntry
            // 
            this.btnModifyEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModifyEntry.Enabled = false;
            this.btnModifyEntry.Location = new System.Drawing.Point(475, 355);
            this.btnModifyEntry.Name = "btnModifyEntry";
            this.btnModifyEntry.Size = new System.Drawing.Size(92, 23);
            this.btnModifyEntry.TabIndex = 18;
            this.btnModifyEntry.Text = "Modify register";
            this.btnModifyEntry.UseVisualStyleBackColor = true;
            this.btnModifyEntry.Click += new System.EventHandler(this.BtnModifyRegister_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Query";
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuery.Enabled = false;
            this.textBoxQuery.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuery.Location = new System.Drawing.Point(280, 385);
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(538, 21);
            this.textBoxQuery.TabIndex = 20;
            this.textBoxQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxQuery_KeyDown);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Enabled = false;
            this.btnExecute.Location = new System.Drawing.Point(824, 384);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(57, 23);
            this.btnExecute.TabIndex = 21;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(887, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 443);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.textBoxQuery);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnModifyEntry);
            this.Controls.Add(this.btnDeleteEntry);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(972, 482);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Base Management System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnModifyAttrib;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem attributesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addAttributeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modifyAttributeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteAttributeToolStripMenuItem;
		private System.Windows.Forms.Button btnAddEntry;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnDeleteEntry;
		private System.Windows.Forms.Button btnModifyEntry;
		private System.Windows.Forms.ToolStripMenuItem registersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addNewEntryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteEntryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modifySelectedEntryToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Button button1;
    }
}

