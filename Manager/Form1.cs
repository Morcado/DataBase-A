﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Manager {
	public partial class Form1 : Form {
		private string selectedTable = "";
		private DataBase dataBase;
		private Table currentTable;

		public Form1() {
			dataBase = null;
			InitializeComponent();
			currentTable = null;
		}
		#region File operations
		/*Guarda una base de datos con todos sus valores utilizando serialización en XML*/
		private void SaveTable(Table table) {
            Stream stream = null;
            try {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(dataBase.Path + "\\" + table.Name, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, table);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            finally {
                if (null != stream) {
                    stream.Close();
                }
            }
        }

		/* Carga una tabla en la base de datos*/
		private Table LoadTable(string tableName) {
			Stream stream = null;
			try {
				IFormatter formatter = new BinaryFormatter();
				stream = new FileStream(dataBase.Path + "\\" + tableName, FileMode.Open, FileAccess.Read, FileShare.None);
				Table table = (Table)formatter.Deserialize(stream);
				return table;
			}
			catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			finally {
				if (null != stream) {
					stream.Close();
				}
			}
			return null;
		}

		#endregion
		#region File menu operations

		/*Crea una nueva base de datos en la ubicación especificada, crea una nueva carpeta
		Inicializa los controles y establece la variable de db como nueva*/
		private void NewDBToolStripMenuItem_Click(object sender, EventArgs e) {
			FolderBrowserDialog op = new FolderBrowserDialog {
				Description = "New database",
				ShowNewFolderButton = false
			};
			
			dataBase = new DataBase(); //crea la base de datos que va a guardar

			treeView1.Nodes.Clear();
			if (op.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(op.SelectedPath)) {
				NameDialog nt = new NameDialog("New database name", "");
				if (nt.ShowDialog() == DialogResult.OK && nt.NewName != "") {
					dataBase.Name = nt.NewName;
					dataBase.Path = op.SelectedPath + "\\" + dataBase.Name;
					Directory.CreateDirectory(dataBase.Path);
					label1.Text = dataBase.Name;
					label1.Visible = true;
					btnNewTable.Enabled = true;
					newTableToolStripMenuItem.Enabled = true;

					renameDBToolStripMenuItem.Enabled = true;
					deleteDBToolStripMenuItem.Enabled = true;
					closeDBToolStripMenuItem.Enabled = true;
				}
			}
		}

		/*Abrir una nueva base de datos. Se selecciona la carpeta que contenga la base de datos y
		se cargan todas sus tablas y de los atributos.Se inicializan los controles..*/
		private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
			FolderBrowserDialog op = new FolderBrowserDialog { // Dialogo de abrir carpeta
				Description = "Open database",
				ShowNewFolderButton = false
			};

			treeView1.Nodes.Clear(); // Control de treeview para ver las tablas
			dataBase = new DataBase();
			dataBase.Path = "";

			if (op.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(op.SelectedPath)) {
				string[] files = Directory.GetFiles(op.SelectedPath); // Obtiene los archivos que se encuentran
				// en la carpeta
				dataBase.Path = op.SelectedPath; // Dirección de la base de datos actual

				// Muestra las tablas sin el nombre de la extensión
				foreach (string file in files) {
					treeView1.Nodes.Add(Path.GetFileNameWithoutExtension(file));
					Table t = LoadTable(Path.GetFileNameWithoutExtension(file));

					foreach (Attribute attribute in t.Attributes) {
						if (attribute.Key == 1) {
							dataBase.PKKeys.Add(attribute.Name);
						}
					}
					dataBase.AddTable(t);
					// Carga toda la información de los archivos de las tablas y almacena en dataBase
					//LoadFile(Path.GetFileName(file));
				}

				// Nomre de la base de datos
				dataBase.Name = label1.Text = op.SelectedPath.Split('\\').Last().ToString();

				// Actualizacion de los controles
				label1.Visible = true;
				treeView1.Enabled = true;
				btnNewTable.Enabled = true;
				newTableToolStripMenuItem.Enabled = true;

				renameDBToolStripMenuItem.Enabled = true;
				deleteDBToolStripMenuItem.Enabled = true;
				closeDBToolStripMenuItem.Enabled = true;

			}
		}

		/*Opción del menu que permite cambiar el nombre de la base de datos. Se muestra un dialogo de confirmación
		y un dialogo de nuevo nombre*/
		private void RenameDBToolStripMenuItem_Click(object sender, EventArgs e) {
			NameDialog nt = new NameDialog("Change DB name", dataBase.Name);
			if (nt.ShowDialog() == DialogResult.OK) {
				if (Directory.Exists(dataBase.Path)) { // Verifica que exite el directorio
													   // Se mueve la carpeta en la misma dirección con un nuevo nombre
					Directory.Move(dataBase.Path, dataBase.Path.Replace("\\" + dataBase.Name, "") + "\\" + nt.NewName);
				}
				label1.Text = nt.NewName;
			}
		}

		/* Cierra la base de datos actual. Desactiva los controles y limpia las variables. Se desactivan los controles */
		private void CloseDBToolStripMenuItem_Click(object sender, EventArgs e) {
			dataBase.Name = dataBase.Path = "";
			label1.Visible = false;

			treeView1.Nodes.Clear();
			treeView1.Enabled = false;

			btnNewTable.Enabled = newTableToolStripMenuItem.Enabled = false;
			btnDeleteTable.Enabled = deleteTableToolStripMenuItem.Enabled = false;
			btnRenameTable.Enabled = renameTableToolStripMenuItem.Enabled = false;

			btnAddAttrib.Enabled = false;
			btnDeleteAttrib.Enabled = false;
			btnModifyAttrib.Enabled = false;

			renameDBToolStripMenuItem.Enabled = false;
			deleteDBToolStripMenuItem.Enabled = false;
			closeDBToolStripMenuItem.Enabled = false;
		}

		/* Elimina la base de datos elegida. Se comporta de la misma manera que cerrar, pero las variables
		y los archivos se eliminan y se muestra una confirmación antes de eliminarla 
		Se desactivan los controles*/
		private void DeleteDBToolStripMenuItem_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want to delete the database?", "Delete database", MessageBoxButtons.OKCancel) == DialogResult.OK) {
				Directory.Delete(dataBase.Path, true);
				dataBase.Name = dataBase.Path = "";
				label1.Visible = false;

				treeView1.Nodes.Clear();
				treeView1.Enabled = false;

				btnNewTable.Enabled = newTableToolStripMenuItem.Enabled = false;
				btnDeleteTable.Enabled = deleteTableToolStripMenuItem.Enabled = false;
				btnRenameTable.Enabled = renameTableToolStripMenuItem.Enabled = false;

				btnAddAttrib.Enabled = false;
				btnDeleteAttrib.Enabled = false;
				btnModifyAttrib.Enabled = false;

				renameDBToolStripMenuItem.Enabled = false;
				deleteDBToolStripMenuItem.Enabled = false;
				closeDBToolStripMenuItem.Enabled = false;
			}
		}

		/* Menu para salir del programa. Cierra la aplicación*/
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK) {
				Close();
			}
		}

		#endregion
		#region Table menu operations

		/*Crea una nueva tabla en la base de datos actual. Se inicializa la variable de tabla y se guarda en la 
		base de datos.Se pide el nombre de la tabla*/
		private void BtnNewTable_Click(object sender, EventArgs e) {
			// Dialogo de nombre
			NameDialog nt = new NameDialog("Create table", "");
			if (nt.ShowDialog() == DialogResult.OK) {
				Table t = new Table(nt.NewName);

				SaveTable(t);
				dataBase.AddTable(t);
				treeView1.Nodes.Add(nt.NewName);// Agrega la tabla al treeview
			}
			
		}

		/*Elimina una tabla de la base de datos. Actualiza el tree view y elimina los datos de la tabla*/
		private void BtnDeleteTable_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want delete table?", "Delete table", MessageBoxButtons.OKCancel) == DialogResult.OK) {
				// Comprueba que la tabla exista antes de eliminarla.
				if (File.Exists(dataBase.Path + "\\" + treeView1.SelectedNode.Text + ".bin")) {
					// Elimina la tabla utilizando el nombre elegido en treeview
					dataBase.RemoveTable(treeView1.SelectedNode.Text);
					File.Delete(dataBase.Path + "\\" + treeView1.SelectedNode.Text + ".bin");
				}
				// Elimina del treeview
				treeView1.Nodes.Remove(treeView1.SelectedNode);

				// Actualizar los controles
				btnDeleteTable.Enabled = false;
				btnRenameTable.Enabled = false;
				btnAddAttrib.Enabled = false;
				btnDeleteAttrib.Enabled = false;
				btnModifyAttrib.Enabled = false;
				treeView1.SelectedNode = null;
			}
		}

		/*Cambia el nombre a una tabla. Se tiene que elegir del treeview para activar esta opción.
		 Se muestra un cuadro de dialogo con el nombre anterior y se modifica. Se modifica el nombre del archivo de la tabla*/
		private void BtnRenameTable_Click(object sender, EventArgs e) {
			NameDialog nt = new NameDialog("Rename table", treeView1.SelectedNode.Text);
			if (nt.ShowDialog() == DialogResult.OK) {
				// Comprueba que la tabla exista
				if (File.Exists(dataBase.Path + "\\" + treeView1.SelectedNode.Text + ".bin")) {
					// El metodo de mover cambia el nombre de la tabla, se tiene que dar la misma dirección
					Table table = dataBase.FindTable(treeView1.SelectedNode.Text);
					table.Name = nt.NewName;
					File.Move(dataBase.Path + "\\" + treeView1.SelectedNode.Text + ".bin", dataBase.Path + "\\" + nt.NewName + ".bin");
				}
				treeView1.SelectedNode.Text = nt.NewName;

				// Se actualizan los controles
				btnDeleteTable.Enabled = false;
				btnRenameTable.Enabled = false;
				btnAddAttrib.Enabled = false;
				btnDeleteAttrib.Enabled = false;
				btnModifyAttrib.Enabled = false;

				treeView1.SelectedNode = null; // Se deselecciona de la tabla para desactivar los controles
				
			}
		}

		#endregion

		/*Al elegir un elemento del tree view. Si no hay un elemento elegido, los botones se desactivan para
		 evitar problemas. Al elegir un elemento se actvan los botones de modificar y eliminar*/
		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e) {
			if (treeView1.SelectedNode != null) { 
				// Si se elige un elemento, se activan los controles y se guarda la dirección de la tabla elegida
				btnDeleteTable.Enabled = true;
				btnRenameTable.Enabled = true;

				btnAddAttrib.Enabled = true;
				//btnDeleteAttrib.Enabled = true;
				//btnModifyAttrib.Enabled = true;
				selectedTable = dataBase.Path + "\\" + treeView1.SelectedNode.Text;
				//Table = dataBase.FindTable(treeView1.SelectedNode.Text);
				//currentTable = LoadTable(treeView1.SelectedNode.Text);
				currentTable = dataBase.FindTable(treeView1.SelectedNode.Text);
				ShowTableInfo(currentTable);
			}
			else {
				// Si no se elige nada, se desactivan los controles y se limpia la tabla elegida
				btnDeleteTable.Enabled = false;
				btnRenameTable.Enabled = false;

				btnAddAttrib.Enabled = false;
				btnDeleteAttrib.Enabled = false;
				btnModifyAttrib.Enabled = false;
				selectedTable = "";
			}
		}

		/* Muestra la tabla completa en el datagrid */
		private void ShowTableInfo(Table table) {
			dataGridView1.Columns.Clear();
			foreach (Attribute attribute in table.Attributes) {
				DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn {
					Name = attribute.Name,
					HeaderText = attribute.Name
				};
				dataGridView1.Columns.Add(dgc);
			}
		}


		/* Agrega un atributo a la tabla. Pueden ser las llaves primarias de los otros atriburtos*/
		private void BtnAddAttrib_Click(object sender, EventArgs e) {
			List<string> keys = new List<string>();
			AttributeDialog nd = new AttributeDialog("New attribute", dataBase.PKKeys);
			if (nd.ShowDialog() == DialogResult.OK) {
				currentTable.AddAttribute(nd.Attr);
				comboBox1.Items.Add(nd.Attr.Name);
			}
			ShowTableInfo(currentTable);
		}



		private void BtnDeleteAttrib_Click(object sender, EventArgs e) {
			
		}

		private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
	
			btnDeleteAttrib.Enabled = true;	
		}
	}
}
