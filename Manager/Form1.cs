using System;
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
		#region Utilities
		/* Desactiva o activa los botones */
		public void ToggleAttribButtons(bool add, bool delete, bool modify) {
			btnAddAttrib.Enabled = addAttributeToolStripMenuItem.Enabled = add;
			btnDeleteAttrib.Enabled = deleteAttributeToolStripMenuItem.Enabled = delete;
			btnModifyAttrib.Enabled = modifyAttributeToolStripMenuItem.Enabled = modify;
		}

		public void ToggleTableButtons(bool newT, bool delete, bool rename) {
			btnNewTable.Enabled = newTableToolStripMenuItem.Enabled = newT;
			btnDeleteTable.Enabled = deleteTableToolStripMenuItem.Enabled = delete;
			btnRenameTable.Enabled = renameTableToolStripMenuItem.Enabled = rename;
		}
		
		public void ToggleEntryButtons(bool add, bool delete, bool modify) {
			btnAddEntry.Enabled = addNewEntryToolStripMenuItem.Enabled = add;
			btnDeleteEntry.Enabled = deleteEntryToolStripMenuItem.Enabled = delete;
			btnModifyEntry.Enabled = modifySelectedEntryToolStripMenuItem.Enabled = modify;
		}

		public void ToggleDBButtons(bool enabled) {
			deleteDBToolStripMenuItem.Enabled = enabled;
			renameDBToolStripMenuItem.Enabled = enabled;
			closeDBToolStripMenuItem.Enabled = enabled;
		}

		#endregion

		#region File operations
		/*Guarda una base de datos con todos sus valores utilizando serialización en XML*/
		private void SaveTable() {
			Stream stream = null;
			try {
				IFormatter formatter = new BinaryFormatter();
				stream = new FileStream(dataBase.Path + "\\" + currentTable.Name + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
				formatter.Serialize(stream, currentTable);
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
				stream = new FileStream(dataBase.Path + "\\" + tableName + ".bin", FileMode.Open, FileAccess.Read, FileShare.None);
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
					ToggleTableButtons(true, false, false);
					ToggleDBButtons(true);
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
			dataBase = new DataBase {
				Path = ""
			};

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
							dataBase.PKKeys.Add(attribute);
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

				ToggleTableButtons(true, false, false);
				ToggleDBButtons(true);
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
			dataGridView1.Columns.Clear();

			ToggleTableButtons(false, false, false);
			ToggleAttribButtons(false, false, false);
			ToggleDBButtons(false);
			ToggleEntryButtons(false, false, false);
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

				ToggleTableButtons(false, false, false);
				ToggleAttribButtons(false, false, false);
				ToggleDBButtons(false);
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
				dataBase.AddTable(t);
				currentTable = t;
				treeView1.Nodes.Add(nt.NewName);// Agrega la tabla al treeview
				SaveTable();
				currentTable = null;
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
				ToggleTableButtons(true, false, false);
				ToggleAttribButtons(false, false, false);
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
				ToggleTableButtons(true, false, false);
				ToggleAttribButtons(false, false, false);

				treeView1.SelectedNode = null; // Se deselecciona de la tabla para desactivar los controles

			}
		}

		#endregion

		/*Al elegir un elemento del tree view. Si no hay un elemento elegido, los botones se desactivan para
		 evitar problemas. Al elegir un elemento se actvan los botones de modificar y eliminar*/
		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e) {
			currentTable = dataBase.FindTable(treeView1.SelectedNode.Text);
			// se guarda la dirección de la tabla elegida
			selectedTable = dataBase.Path + "\\" + treeView1.SelectedNode.Text;
			ToggleTableButtons(true, true, true);

			if (currentTable.Attributes.Count > 0) {
				ToggleEntryButtons(true, false, false);
			}
			else {
				ToggleEntryButtons(false, false, false);
			}

			// Si la tabla tiene entradas, entonces no activa los controles
			if (currentTable.Entries.Count > 0 && currentTable.Entries[0].Count > 0) {
				btnAddAttrib.Enabled = addAttributeToolStripMenuItem.Enabled =  false;
			}
			else {
				ToggleAttribButtons(true, false, false);
			}
			
			ShowTableInfo();
		}

		private void TreeView1_Leave(object sender, EventArgs e) {
			ToggleTableButtons(true, false, false);
		}

		/* Muestra la tabla completa en el datagrid */
		private void ShowTableInfo() {
			dataGridView1.Columns.Clear();
			//comboBox1.Items.Clear();
			foreach (Attribute attribute in currentTable.Attributes) {
				DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn {
					Name = attribute.Name,
					HeaderText = attribute.Name,
					SortMode = DataGridViewColumnSortMode.Programmatic
				};
				dataGridView1.Columns.Add(dgc);
				//comboBox1.Items.Add(dgc.Name);
			}

			if (currentTable.Entries != null && currentTable.Entries.Count > 0 && currentTable.Entries[0].Count > 0) {

				for (int k = 0; k < currentTable.Entries[0].Count; k++) { // Recorre las filas
					dataGridView1.Rows.Add();
					for (int i = 0; i < currentTable.Attributes.Count; i++) { // Recorre las coluumneas
						dataGridView1.Rows[k].Cells[i].Value = currentTable.Entries[i][k];
					}
				}
			}
		}


		/* Agrega un atributo a la tabla. Pueden ser las llaves primarias de los otros atriburtos*/
		private void BtnAddAttrib_Click(object sender, EventArgs e) {
			List<string> keys = new List<string>();
			AttributeDialog nd = new AttributeDialog("New attribute", dataBase.PKKeys, currentTable, null);
			if (nd.ShowDialog() == DialogResult.OK) {
				currentTable.AddAttribute(nd.Attr);
				//comboBox1.Items.Add(nd.Attr.Name);
				if (nd.Attr.Key == 1) {
					dataBase.PKKeys.Add(nd.Attr);
				}
			}
			ShowTableInfo();
			SaveTable();
		}
		

		/* Elimina un atributo de la tabla actual, elimina las referencias a aquel atributo */
		private void BtnDeleteAttrib_Click(object sender, EventArgs e) {
			Attribute at = currentTable.Attributes.Find(x => x.Name == groupBox2.Text);

			currentTable.RemoveAttribute(at);
			dataBase.PKKeys.Remove(at);

			DataGridView1_ColumnHeaderMouseClick(this, null);
			ShowTableInfo();
			SaveTable();
		}

		/* Modifica un atributo mostrando los parámetros que ya tiene para modificar de una forma más fácil */
		private void BtnModifyAttrib_Click(object sender, EventArgs e) {
			Attribute at = currentTable.Attributes.Find(x => x.Name == groupBox2.Text);
			AttributeDialog atrDlg = new AttributeDialog("Modify attribute", dataBase.PKKeys, currentTable, at);

			if (atrDlg.ShowDialog() == DialogResult.OK) {
				currentTable.ModifyAttribute(at, atrDlg.Attr);

			}
			ShowTableInfo();
			SaveTable();
		}

		/* Agrega una tupla en la tabla seleccionada. Desacva los botones de*/
		private void BtnAddEntry_Click(object sender, EventArgs e) {
			RegisterDialog regDlg = new RegisterDialog(currentTable);

			if (regDlg.ShowDialog() == DialogResult.OK) {
				currentTable.AddEntry(regDlg.Entry);
				ShowTableInfo();
				SaveTable();
				ToggleAttribButtons(false, false, false);
			}

		}

		private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
			if (e != null && e.ColumnIndex != -1) {
				groupBox2.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText;

				//Buscar en las otras tablas si no tienen atributos para poder modificar o eliminar
				if (currentTable.Entries[0].Count == 0) {
					ToggleAttribButtons(true, true, true);
				}
				else {
					ToggleAttribButtons(false, false, false);
				}
			}
			else {
				ToggleAttribButtons(false, false, false);
				groupBox2.Text = "nada";
			}
		}

		private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
			if (e.RowIndex != -1) {
				if (currentTable.Entries[0].Count > 0 && e.RowIndex != dataGridView1.Rows.Count - 1) {
					ToggleEntryButtons(true, true, true);
				}
				else {
					ToggleEntryButtons(true, false, false);
				}
			}
			else {
				ToggleEntryButtons(true, false, false);
			}
		}

		private void BtnDeleteEntry_Click(object sender, EventArgs e) {

			if (MessageBox.Show("Are you sure you want to delete the database?", "Delete database", MessageBoxButtons.OKCancel) == DialogResult.OK) {
				int index = dataGridView1.CurrentCell.RowIndex;

				currentTable.DeleteEntry(index);
				ShowTableInfo();
				SaveTable();

				if (currentTable.Entries[0].Count == 0) {
					btnDeleteEntry.Enabled = false;
				}
			}
		}

		private void BtnModifyEntry_Click(object sender, EventArgs e) {
			List<object> entry = currentTable.GetEntryAt(dataGridView1.CurrentCell.RowIndex);

			RegisterDialog regDlg = new RegisterDialog(currentTable);

			if (regDlg.ShowDialog() == DialogResult.OK) {

			}
		}
	}
}
