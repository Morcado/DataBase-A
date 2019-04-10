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

        /* Desactiva o activa los botones de agregar, eliminar y modificar atributos */
        public void ToggleAttribButtons(bool add, bool delete, bool modify) {
            btnAddAttrib.Enabled = addAttributeToolStripMenuItem.Enabled = add;
            btnDeleteAttrib.Enabled = deleteAttributeToolStripMenuItem.Enabled = delete;
            btnModifyAttrib.Enabled = modifyAttributeToolStripMenuItem.Enabled = modify;
        }

        /* Activa o desactiva los botones de nuevo, eliminar y renombrar tabla */
        public void ToggleTableButtons(bool newT, bool delete, bool rename) {
            btnNewTable.Enabled = newTableToolStripMenuItem.Enabled = newT;
            btnDeleteTable.Enabled = deleteTableToolStripMenuItem.Enabled = delete;
            btnRenameTable.Enabled = renameTableToolStripMenuItem.Enabled = rename;
        }
        
        /* Activa o desactiva los botones de agregar, eliminar y modificar entradas */
        public void ToggleEntryButtons(bool add, bool delete, bool modify) {
            btnAddEntry.Enabled = addNewEntryToolStripMenuItem.Enabled = add;
            btnDeleteEntry.Enabled = deleteEntryToolStripMenuItem.Enabled = delete;
            btnModifyEntry.Enabled = modifySelectedEntryToolStripMenuItem.Enabled = modify;
        }

        /* Activa o desactiva los botones de abrir, cerrar o renombrar base de datos */
        public void ToggleDBButtons(bool enabled) {
            deleteDBToolStripMenuItem.Enabled = enabled;
            renameDBToolStripMenuItem.Enabled = enabled;
            closeDBToolStripMenuItem.Enabled = enabled;
        }

        #endregion

        #region File operations

        /* Guarda un archivo de una tabla en la dirección que es especificada. La tabla 
         * contiene los atributos y las entradas*/
        private void SaveTable(Table table) {
            Stream stream = null;
            try {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(dataBase.Path + "\\" + table.Name + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, table); // Serializa la tabla
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            finally {
                if (null != stream) {
                    stream.Close(); // Cierra el archivo
                }
            }
        }

        /* Carga una tabla en la base de datos. Almacena la tabla en una variable de tabla. */
        private Table LoadTable(string tableName) {
            Stream stream = null;
            try {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(dataBase.Path + "\\" + tableName + ".bin", FileMode.Open, FileAccess.Read, FileShare.None);
                Table table = (Table)formatter.Deserialize(stream); // Desrializa
                return table;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            finally {
                if (null != stream) {
                    stream.Close(); // Cierra el archivo
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

                // Activa algunos botones
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

                // Desactiva todos los botones
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
        base de datos. Se pide el nombre de la tabla. Se guarda en el archivo binario*/
        private void BtnNewTable_Click(object sender, EventArgs e) {
            // Dialogo de nombre
            NameDialog nt = new NameDialog("Create table", "");
            if (nt.ShowDialog() == DialogResult.OK) {
                Table t = new Table(nt.NewName);
                dataBase.AddTable(t);
                currentTable = t;
                treeView1.Nodes.Add(nt.NewName);// Agrega la tabla al treeview
                SaveTable(currentTable);
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
            groupBox2.Text = ""; //titulo del group box de atributos
            ToggleTableButtons(true, true, true);

            // Si hay atributos, se activa solamente el boton de agregar entrada
            if (currentTable.Attributes.Count > 0) {
                ToggleEntryButtons(true, false, false);
            }
            else {
                ToggleEntryButtons(false, false, false);
            }

            // Si la tabla no tiene entradas, solo activa el boton de agregar atributo
            // Si tiene entradas, desactiva todos
            ToggleAttribButtons(true, false, false);
            
            
            ShowTableInfo();
        }

        /* Cuando se deja el enfoque del treeview, desactiva los botones de eliminar y modificar tabla
         */
        private void TreeView1_Leave(object sender, EventArgs e) {
            if (treeView1.SelectedNode == null) {
                ToggleTableButtons(true, false, false);
            }
            else {
                ToggleTableButtons(true, true, true);
            }
        }

        /* Muestra la tabla completa en el datagrid, Si no tiene datos, la tabla se queda vacía. Se
         * llama cada vez que se hace una modificación a las entradas o los atributos */
        private void ShowTableInfo() {
            dataGridView1.Columns.Clear();

            // Agrega las columnas de los atributos al datagrid
            foreach (Attribute attribute in currentTable.Attributes) {
                DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn {
                    Name = attribute.Name,
                    HeaderText = attribute.Name,
                    SortMode = DataGridViewColumnSortMode.Programmatic
                };
                dataGridView1.Columns.Add(dgc);
            }

            // Agrefa las tuplas que contenga esa tabla, verificando que haya alguna
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
                nd.Attr.parentTable = currentTable;
                // Si es atributo primario, se agrega a la tabla
                if (nd.Attr.Key == 1) {
                    dataBase.PKKeys.Add(nd.Attr);
                }
            }
            ShowTableInfo();
            SaveTable(currentTable);
        }
        

        /* Elimina un atributo de la tabla actual, elimina las referencias a aquel atributo */
        private void BtnDeleteAttrib_Click(object sender, EventArgs e) {
            Attribute at = currentTable.Attributes.Find(x => x.Name == groupBox2.Text);

            currentTable.RemoveAttribute(at);

            for (int i = 0; i < dataBase.Tables.Count; i++) {
                for (int j = 0; j < dataBase.Tables[i].Attributes.Count; j++) {
                    if (dataBase.Tables[i].Attributes[j].Name == at.Name) {
                        dataBase.Tables[i].RemoveAttribute(at);
                        SaveTable(dataBase.Tables[i]);
                    }
                }
            }

            // Elimina el atributo de la lista de claves primarias, si es que es primario

            if (at.Key == 1) {
                dataBase.PKKeys.Remove(at);
            }
            // Llama al evento de actualizar las columnas paara verificar
            ToggleAttribButtons(true, false, false);
            groupBox2.Text = "";
            ShowTableInfo();
            SaveTable(currentTable);
        }

        /* Modifica un atributo mostrando los parámetros que ya tiene para modificar de una forma más fácil */
        private void BtnModifyAttrib_Click(object sender, EventArgs e) {
            Attribute at = currentTable.Attributes.Find(x => x.Name == groupBox2.Text);
            AttributeDialog atrDlg = new AttributeDialog("Modify attribute", dataBase.PKKeys, currentTable, at);

            // Buscar en las otras tablas si hay datos para no poder agregarlo
            //...
            //...

            if (atrDlg.ShowDialog() == DialogResult.OK) {
                currentTable.ModifyAttribute(at, atrDlg.Attr);
                for (int i = 0; i < dataBase.Tables.Count; i++) {
                    for (int j = 0; j < dataBase.Tables[i].Attributes.Count; j++) {
                        if (dataBase.Tables[i].Attributes[j].Name == at.Name) {
                            dataBase.Tables[i].ModifyAttribute(at, atrDlg.Attr);
                            SaveTable(dataBase.Tables[i]);
                        }
                    }
                }

                //foreach (var table in dataBase.Tables) {
                //    foreach (var attribute in table.Attributes) {
                //        if (attribute.Name == at.Name) {
                //            table.ModifyAttribute(at, atrDlg.Attr);

                //        }
                //    }
                //}
            }

            ShowTableInfo();
            SaveTable(currentTable);
        }

        /* Boton de agregar una tupla en la tabla seleccionada. Desacva los botones de agregar, 
         * modificar y eliminar atributos
         */
        private void BtnAddEntry_Click(object sender, EventArgs e) {
            RegisterDialog regDlg = new RegisterDialog(currentTable, null);

            if (regDlg.ShowDialog() == DialogResult.OK) {
                currentTable.AddEntry(regDlg.Entry);
                ShowTableInfo();
                SaveTable(currentTable);
                ToggleAttribButtons(true, false, false);
            }

        }

        /* Llamado cuando se selecciona una columna atributo del datagridview. Hace las verificaciones 
         * que corresponden para poder acrivar los botones de agregar, eliminar y modificar.*/
        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            groupBox2.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            Attribute at = currentTable.FindAttribute(groupBox2.Text);

            if (at.Key == 2) {
                if (!at.CheckTables()) {
                    ToggleAttribButtons(true, false, false);
                }     
            }
            else {
                if (currentTable.Entries[0].Count == 0) {
                    ToggleAttribButtons(true, true, true);
                }
                else {
                    ToggleAttribButtons(true, false, false);
                }
            }
            //bool isUsed = dataBase.CheckTables(at);


            // Si las entradas están vacías, entonces activa los botones de modificar agregar y eliminar

        }

        /* Se activa cuando se selecciona yuna fila en el datagridview. Se realizan las verificaciones para
         * activar los botones de agregar, eliminar y modificar entrada.*/
        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            // Si hay entradas y no es la última fila del  datagrid view (la ultima siempre esta vacia)
            if (currentTable.Entries[0].Count > 0 && e.RowIndex != dataGridView1.Rows.Count - 1) {
                ToggleEntryButtons(true, true, true);
            }
            else {
                ToggleEntryButtons(true, false, false);
            }
        }

        /* Boton de eliminar entrada. Se tiene que seleccionar previamente una fila del datagridview. 
         * Muestra un dialogo de confirmacion y elimina la fila en OK */
        private void BtnDeleteEntry_Click(object sender, EventArgs e) {

            if (MessageBox.Show("Are you sure you want to delete entry?", "Delete entry", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                // Obtiene el indice de la fila seleccionada, el cual es el mismo indice de
                // la base de datos
                int index = dataGridView1.CurrentCell.RowIndex;

                currentTable.DeleteEntry(index);
                ShowTableInfo();
                SaveTable(currentTable);

                // Si no quedan mas entradas, se desactiva el boton de eliminar y modificar
                if (currentTable.Entries[0].Count == 0) {
                    ToggleEntryButtons(true, false, false);
                }
            }
        }

        /* Boton de modificar. Se debe seleccionar previamente una fila en el datagridview, se obtienen los
         * datos de esa fila, y despues se realiza la operacion de eliminar y agregar en la tabla.*/
        private void BtnModifyEntry_Click(object sender, EventArgs e) {
            List<object> entry = currentTable.GetEntryAt(dataGridView1.CurrentCell.RowIndex);

            // Carga el diálogo con los valores del registro
            RegisterDialog regDlg = new RegisterDialog(currentTable, entry);

            if (regDlg.ShowDialog() == DialogResult.OK) {
                currentTable.DeleteEntry(dataGridView1.CurrentCell.RowIndex);
                currentTable.AddEntry(regDlg.Entry);
            }
            ShowTableInfo();
            SaveTable(currentTable);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
