using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager {
	public partial class Form1 : Form {
		private string dbPath;
		private string dbName;

		public Form1() {
			InitializeComponent();
			dbName = dbPath = "";
		}

		private void newDBToolStripMenuItem_Click(object sender, EventArgs e) {
			FolderBrowserDialog op = new FolderBrowserDialog();
			op.Description = "New database";
			op.ShowNewFolderButton = false;

			treeView1.Nodes.Clear();
			dbPath = dbName = "";

			if (op.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(op.SelectedPath)) {
				NameDialog nt = new NameDialog("New database name", "");
				if (nt.ShowDialog() == DialogResult.OK && nt.NewName != "") {
					dbName = nt.NewName;
					dbPath = op.SelectedPath + "\\" + dbName;
					Directory.CreateDirectory(dbPath);
					label1.Text = dbName;
					label1.Visible = true;
					button1.Enabled = true;
					newTableToolStripMenuItem.Enabled = true;

					renameDBToolStripMenuItem.Enabled = true;
					deleteDBToolStripMenuItem.Enabled = true;
					closeDBToolStripMenuItem.Enabled = true;
				}
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			FolderBrowserDialog op = new FolderBrowserDialog();
			op.Description = "Open database";
			op.ShowNewFolderButton = false;

			treeView1.Nodes.Clear();
			dbPath = "";

			if (op.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(op.SelectedPath)) {
				string[] files = Directory.GetFiles(op.SelectedPath);
				dbPath = op.SelectedPath;

				foreach (string file in files) {
					treeView1.Nodes.Add(Path.GetFileNameWithoutExtension(file));
				}
				dbName = label1.Text = op.SelectedPath.Split('\\').Last().ToString();
				label1.Text = dbName;
				label1.Visible = true;
				treeView1.Enabled = true;
				button1.Enabled = true;
				newTableToolStripMenuItem.Enabled = true;

				renameDBToolStripMenuItem.Enabled = true;
				deleteDBToolStripMenuItem.Enabled = true;
				closeDBToolStripMenuItem.Enabled = true;

			}
		}

		private void button1_Click(object sender, EventArgs e) {
			NameDialog nt = new NameDialog("Create table", "");
			if (nt.ShowDialog() == DialogResult.OK) {
				try {
					// Crea el archivo del diccionario de datos
					BinaryWriter bw = new BinaryWriter(new FileStream(dbPath + "\\" + nt.NewName + ".bin", FileMode.Create));
					bw.Close();
				}
				catch (IOException ex) {
					Console.WriteLine(ex.Message + "\n Cannot create file.");
					return;
				}
				treeView1.Nodes.Add(nt.NewName);
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want delete table?", "Delete table", MessageBoxButtons.OKCancel) == DialogResult.OK) {
				if (File.Exists(dbPath + "\\" + treeView1.SelectedNode.Text + ".bin")) {
					File.Delete(dbPath + "\\" + treeView1.SelectedNode.Text + ".bin");
				}
				treeView1.Nodes.Remove(treeView1.SelectedNode);
				button2.Enabled = false;
				button3.Enabled = false;
				treeView1.SelectedNode = null;
			}
		}

		private void button3_Click(object sender, EventArgs e) {
			NameDialog nt = new NameDialog("Rename table", treeView1.SelectedNode.Text);
			if (nt.ShowDialog() == DialogResult.OK) {
				if (File.Exists(dbPath + "\\" + treeView1.SelectedNode.Text + ".bin")) {
					File.Move(dbPath + "\\" + treeView1.SelectedNode.Text + ".bin", dbPath + "\\" + nt.NewName + ".bin");
				}
				treeView1.SelectedNode.Text = nt.NewName;

				button2.Enabled = false;
				button3.Enabled = false;
				treeView1.SelectedNode = null;

			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
			if (treeView1.SelectedNode != null) {
				button2.Enabled = true;
				button3.Enabled = true;
			}
			else {
				button2.Enabled = false;
				button3.Enabled = false;
			}
		}

		private void renameDBToolStripMenuItem_Click(object sender, EventArgs e) {
			NameDialog nt = new NameDialog("Change DB name", dbName);
			if (nt.ShowDialog() == DialogResult.OK) {
				if (Directory.Exists(dbPath)) {
					Directory.Move(dbPath, dbPath.Replace("\\" + dbName, "") + "\\" + nt.NewName);
				}
				label1.Text = nt.NewName;
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK) {
				Close();
			}
		}

		private void closeDBToolStripMenuItem_Click(object sender, EventArgs e) {
			dbPath = dbName = "";
			label1.Visible = false;

			treeView1.Nodes.Clear();
			treeView1.Enabled = false;

			button1.Enabled = false;
			button2.Enabled = false;
			button3.Enabled = false;
			newTableToolStripMenuItem.Enabled = false;
			deleteTableToolStripMenuItem.Enabled = false;
			renameTableToolStripMenuItem.Enabled = false;

			renameDBToolStripMenuItem.Enabled = false;
			deleteDBToolStripMenuItem.Enabled = false;
			closeDBToolStripMenuItem.Enabled = false;
		}

	}
}
