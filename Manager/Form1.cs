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

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			FolderBrowserDialog op = new FolderBrowserDialog();
			op.Description = "Open Database";

			treeView1.Nodes.Clear();
			dbPath = "";

			if (op.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(op.SelectedPath)) {
				string[] files = Directory.GetFiles(op.SelectedPath);
				dbPath = op.SelectedPath;

				foreach (string file in files) {
					treeView1.Nodes.Add(file.Remove(file.Length - 4).Replace(op.SelectedPath + "\\", ""));
				}
				dbName = label1.Text = op.SelectedPath.Split('\\').Last().ToString();
				treeView1.Enabled = true;
				button1.Enabled = true;
				button2.Enabled = true;
			}

		}

		private void CreateTable(string text) {
			try {
				// Crea el archivo del diccionario de datos
				BinaryWriter bw = new BinaryWriter(new FileStream(dbPath + "\\" + text + ".bin", FileMode.Create));
				bw.Close();
			}
			catch (IOException ex) {
				Console.WriteLine(ex.Message + "\n Cannot create file.");
				return;
			}
			treeView1.Nodes.Add(text);
		}

		private void DeleteTable(string text) {
			if (File.Exists(dbPath + "\\" + text + ".bin")) {
				File.Delete(dbPath + "\\" + text + ".bin");
			}
			treeView1.Nodes.Remove(treeView1.SelectedNode);
		}

		private void RenameTable(string oldName, string newName) {
			if (File.Exists(dbPath + "\\" + oldName + ".bin")) {
				File.Move(dbPath + "\\" + oldName + ".bin", dbPath + "\\" + newName + ".bin");
			}
			treeView1.SelectedNode.Text = newName;
		}

		private void button1_Click(object sender, EventArgs e) {
			NewTable nt = new NewTable("Create table", "");
			if (nt.ShowDialog() == DialogResult.OK) {
				CreateTable(nt.TableName);
				
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			DeleteTable(treeView1.SelectedNode.Text);
			button2.Enabled = false;
			treeView1.SelectedNode = null;
		}

		private void button3_Click(object sender, EventArgs e) {
			NewTable nt = new NewTable("Create table", treeView1.SelectedNode.Text);
			if (nt.ShowDialog() == DialogResult.OK) {
				RenameTable(treeView1.SelectedNode.Text, nt.TableName);
				//Modify
			}
		}


		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
			if (treeView1.SelectedNode != null) {
				button2.Enabled = true;
			}
			else {
				button2.Enabled = false;
			}
		}

		private void renameDBToolStripMenuItem_Click(object sender, EventArgs e) {
			NewTable nt = new NewTable("Change DB name", dbName);
			if (nt.ShowDialog() == DialogResult.OK) {
				if (Directory.Exists(dbPath) {
					Directory.Move(currentDB + "\\" + oldName + ".bin", currentDB + "\\" + newName + ".bin");
				}
				label1.Text = nt.TableName;
			}
		}
	}
}
