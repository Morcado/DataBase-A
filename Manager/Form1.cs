﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using TSQL;
using TSQL.Statements;
using TSQL.Tokens;

namespace Manager {
    public partial class Form1 : Form {
        private string selectedTable = "";
        private DataBase dataBase;
        private Table currentTable;
        private Table queryTable;
        public Form1() {
            dataBase = null;
            InitializeComponent();
            currentTable = null;

            ToolStripStatusLabel statusPanel = new ToolStripStatusLabel();
            ToolStripStatusLabel datetimePanel = new ToolStripStatusLabel();

            // Set first panel properties and add to StatusBar  
            
            statusPanel.ToolTipText = "Location of database: ";
            statusPanel.Spring = true;
            statusPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            statusPanel.BorderStyle = Border3DStyle.Sunken;
            statusStrip1.Items.Add(statusPanel);

            // Set second panel properties and add to StatusBar  

            datetimePanel.ToolTipText = "DateTime: " + System.DateTime.Today.ToString();
            datetimePanel.RightToLeft = RightToLeft;
            datetimePanel.Text = System.DateTime.Today.ToLongDateString();
            datetimePanel.Spring = true;
            datetimePanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            datetimePanel.BorderStyle = Border3DStyle.Sunken;
            statusStrip1.Items.Add(datetimePanel);


        }
        #region Utilities

        /* Desactiva o activa los botones de agregar, eliminar y modificar atributos */
        public void ToggleAttribButtons(bool add, bool delete, bool modify) {
            btnAddAttrib.Enabled = addAttributeToolStripMenuItem.Enabled = add;
            btnDeleteAttrib.Enabled = deleteAttributeToolStripMenuItem.Enabled = delete;
            btnModifyAttrib.Enabled = modifyAttributeToolStripMenuItem.Enabled = modify;
        }

        /* Activa o desactiva los botones de nuevo, eliminar y renombrar tabla */
        public void ToggleTableButtons(bool newT, bool delete, bool rename, bool query) {
            btnNewTable.Enabled = newTableToolStripMenuItem.Enabled = newT;
            btnDeleteTable.Enabled = deleteTableToolStripMenuItem.Enabled = delete;
            btnRenameTable.Enabled = renameTableToolStripMenuItem.Enabled = rename;

            textBoxQuery.Enabled = btnExecute.Enabled = query;
        }
        
        /* Activa o desactiva los botones de agregar, eliminar y modificar entradas */
        public void ToggleRegisterButtons(bool add, bool delete, bool modify) {
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
                    ToggleTableButtons(true, false, false, true);
                    ToggleDBButtons(true);
                    statusStrip1.Items[0].Text = dataBase.Path;
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
                    if (t == null) {
                        MessageBox.Show("Unable to open database. Check that is a database");
                    }

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
                ToggleTableButtons(true, false, false, true);
                ToggleDBButtons(true);
                statusStrip1.Items[0].Text = dataBase.Path;
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
                    dataBase.Path = dataBase.Path.Replace("\\" + dataBase.Name, "") + "\\" + nt.NewName;
                }
                label1.Text = nt.NewName;
                statusStrip1.Items[0].Text = dataBase.Path;
            }
        }

        /* Cierra la base de datos actual. Desactiva los controles y limpia las variables. Se desactivan los controles */
        private void CloseDBToolStripMenuItem_Click(object sender, EventArgs e) {
            dataBase.Name = dataBase.Path = "";
            label1.Visible = false;

            treeView1.Nodes.Clear();
            treeView1.Enabled = false;
            dataGridView1.Columns.Clear();

            ToggleTableButtons(false, false, false, false);
            ToggleAttribButtons(false, false, false);
            ToggleDBButtons(false);
            ToggleRegisterButtons(false, false, false);
            statusStrip1.Items[0].Text = "";
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
                currentTable = null;
                dataBase = null;

                // Desactiva todos los botones
                ToggleTableButtons(false, false, false, false);
                ToggleAttribButtons(false, false, false);
                ToggleDBButtons(false);
                dataGridView1.Columns.Clear();
                statusStrip1.Items[0].Text = "";
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
                ToggleTableButtons(true, false, false, true);
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
                ToggleTableButtons(true, false, false, true);
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
            label4.Text = currentTable.Name;
            ToggleTableButtons(true, true, true, true);

            if (currentTable.HasRegisters()) {
                ToggleAttribButtons(false, false, false);
            }
            else {
                ToggleAttribButtons(true, false, false);
            }

            // Si hay atributos, se activa solamente el boton de agregar entrada
            if (currentTable.Attributes.Count > 0) {
                ToggleRegisterButtons(true, false, false);
            }
            else {
                ToggleRegisterButtons(false, false, false);
            }

            // Busca si la PK de la tabla no es referencaida
            bool isUsed = false;
            if (currentTable.HasPK) {
                //Attribute pk = currentTable.GetPKAttribute();
                foreach (var table in dataBase.Tables) {
                    Attribute tab = table.FindAttribute(currentTable.PK.Name);
                    if (tab != null && tab.Key == 2) {
                        isUsed = true;
                        break;
                    }
                }
            }

            if (isUsed) {
                ToggleTableButtons(true, false, false, true);
            }
            else {
                ToggleTableButtons(true, true, true, true);
            }

            ShowTableInfo(currentTable, dataGridView1);
        }

        /* Cuando se deja el enfoque del treeview, desactiva los botones de eliminar y modificar tabla
         */
        private void TreeView1_Leave(object sender, EventArgs e) {
            if (treeView1.SelectedNode == null) {
                ToggleTableButtons(true, false, false, true);
            }
            else {
                ToggleTableButtons(true, true, true, true           );
            }
        }

        /* Muestra la tabla completa en el datagrid, Si no tiene datos, la tabla se queda vacía. Se
         * llama cada vez que se hace una modificación a las entradas o los atributos */
        private void ShowTableInfo(Table table, DataGridView data) {
            data.Columns.Clear();
            // Agrega las columnas de los atributos al datagrid
            foreach (Attribute attribute in table.Attributes) {
                DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn {
                    Name = attribute.Name,
                    HeaderText = attribute.Name,
                    SortMode = DataGridViewColumnSortMode.Programmatic
                };
                if (attribute.Key == 1) {
                    dgc.HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold|System.Drawing.FontStyle.Underline);
                }
                data.Columns.Add(dgc);
            }

            if (table.HasRegisters()) {
                for (int k = 0; k < table.Attributes[0].Register.Count; k++) {
                    data.Rows.Add();
                    for (int i = 0; i < table.Attributes.Count; i++) {
                        data[i, k].Value = table.Attributes[i].Register[k];
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
                // Si es atributo primario, se agrega a la tabla
                if (nd.Attr.Key == 1) {
                    dataBase.PKKeys.Add(nd.Attr);
                }
            }
            ShowTableInfo(currentTable, dataGridView1);
            SaveTable(currentTable);
            ToggleRegisterButtons(true, true, true);
        }
        

        /* Elimina un atributo de la tabla actual, elimina las referencias a aquel atributo */
        private void BtnDeleteAttrib_Click(object sender, EventArgs e) {
            Attribute at = currentTable.Attributes.Find(x => x.Name == groupBox2.Text);

            currentTable.RemoveAttribute(at);

            // Elimina el atributo de la lista de claves primarias, si es que es primario

            if (at.Key == 1) {
                dataBase.PKKeys.Remove(at);
            }
            // Llama al evento de actualizar las columnas paara verificar
            ToggleAttribButtons(true, false, false);
            groupBox2.Text = "";
            ShowTableInfo(currentTable, dataGridView1);
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
                currentTable.HasPK = false;
                dataBase.PKKeys.Remove(at);
                currentTable.ModifyAttribute(at, atrDlg.Attr);
                dataBase.PKKeys.Add(atrDlg.Attr);
            }

            ShowTableInfo(currentTable, dataGridView1);
            SaveTable(currentTable);
        }

        /* Boton de agregar una tupla en la tabla seleccionada. Desactiva los botones de agregar, 
         * modificar y eliminar atributos
         */
        private void BtnAddRegister_Click(object sender, EventArgs e) {
            ToggleAttribButtons(false, false, false);
            RegisterDialog regDlg = new RegisterDialog(currentTable, null);

            if (regDlg.ShowDialog() == DialogResult.OK) {
                if (!currentTable.PK.Register.Contains(regDlg.PKValue)) {
                    if (currentTable.HasFK()) {
                        bool insert = true;
                        int i = 0;
                        for (i = 0; i < regDlg.FKAtribute.Count; i++) { 
                            if (!dataBase.RegisterExists(regDlg.FKValue[i], regDlg.FKAtribute[i])) {
                                insert = false;
                                break;
                            }
                        }
                        if (insert) {
                            currentTable.AddRegister(regDlg.Register);
                            ShowTableInfo(currentTable, dataGridView1);
                            SaveTable(currentTable);
                            ToggleRegisterButtons(true, false, false);
                            ToggleAttribButtons(false, false, false);
                        }
                        else {
                            MessageBox.Show("Couldn't insert register. The " + regDlg.FKAtribute[i].Name + " with value \"" + regDlg.FKValue[i] +  "\" doesn't exists");
                        }
                                      
                    }
                    else {
                        currentTable.AddRegister(regDlg.Register);
                        ShowTableInfo(currentTable, dataGridView1);
                        SaveTable(currentTable);
                        ToggleRegisterButtons(true, false, false);
                        ToggleAttribButtons(false, false, false);
                    }
                }
                else {
                    MessageBox.Show("Couldn't add register. The " + currentTable.PK.Name + " with value \"" + regDlg.PKValue.ToString()  + "\" already exists");
                }
            }
        }

        /* Llamado cuando se selecciona una columna atributo del datagridview. Hace las verificaciones 
         * que corresponden para poder acrivar los botones de agregar, eliminar y modificar.*/
        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            groupBox2.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            Attribute at = currentTable.FindAttribute(groupBox2.Text);

            if (at.Key == 2) {
                if (currentTable.HasRegisters()) {
                    ToggleAttribButtons(false, true, false);
                }
                else {
                    ToggleAttribButtons(true, true, true);
                }  
            }
            else {
                if (dataBase.HasAttribAsFK(at)) {
                    ToggleAttribButtons(false, false, false);
                }
                else {
                    if (!currentTable.HasRegisters()) {
                        ToggleAttribButtons(true, true, true);
                    }
                    else {
                        ToggleAttribButtons(false, true, false);
                    }
                }
            }
            // Si las entradas están vacías, entonces activa los botones de modificar agregar y eliminar

        }

        /* Se activa cuando se selecciona yuna fila en el datagridview. Se realizan las verificaciones para
         * activar los botones de agregar, eliminar y modificar entrada.*/
        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            // Si hay entradas y no es la última fila del  datagrid view (la ultima siempre esta vacia)
            if (currentTable.HasRegisters() && e.RowIndex != dataGridView1.Rows.Count) {
                ToggleRegisterButtons(true, true, true);
            }
            else {
                ToggleRegisterButtons(true, false, false);
            }
        }

        public bool CheckTablesForRegistry(int index) {
            bool used = false;
            /* Busca en todas las tablas los atributos FK en las PK, si no encuentra ninguno se puede eliminar*/

            foreach (var table in dataBase.Tables) {
                if (table.Name == currentTable.Name) {
                    continue;
                }
                foreach (var attri in table.Attributes) {
                    if (attri.ParentTable.Name.Equals(currentTable.PK.ParentTable.Name)) {
                        foreach (var reg in attri.Register) {
                            if (reg.Equals(currentTable.PK.Register[index])) {
                                used = true;
                                break;
                            }
                        }
                    }
                }
            }
            return used;
        }

        /* Boton de eliminar entrada. Se tiene que seleccionar previamente una fila del datagridview. 
         * Muestra un dialogo de confirmacion y elimina la fila en OK */
        private void BtnDeleteRegister_Click(object sender, EventArgs e) {

            bool resp = CheckTablesForRegistry(dataGridView1.CurrentCell.RowIndex);
            if (!resp) {
                if (MessageBox.Show("Are you sure you want to delete register?", "Delete register", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    // Obtiene el indice de la fila seleccionada, el cual es el mismo indice de
                    // la base de datos
                    int index = dataGridView1.CurrentCell.RowIndex;

                    currentTable.DeleteRegister(index);
                    ShowTableInfo(currentTable, dataGridView1);
                    SaveTable(currentTable);

                    // Si no quedan mas entradas, se desactiva el boton de eliminar y modificar
                    if (!currentTable.HasRegisters()) {
                        ToggleRegisterButtons(true, false, false);
                        ToggleAttribButtons(true, false, false);
                    }
                }
            }
            else {
                MessageBox.Show("Cannot delete, registry is used in another table as PK");
            }

        }

        /* Boton de modificar. Se debe seleccionar previamente una fila en el datagridview, se obtienen los
         * datos de esa fila, y despues se realiza la operacion de eliminar y agregar en la tabla.*/
        private void BtnModifyRegister_Click(object sender, EventArgs e) {
            bool resp = CheckTablesForRegistry(dataGridView1.CurrentCell.RowIndex);
            if (!resp) {
                List<object> entry = currentTable.GetRegisterAt(dataGridView1.CurrentCell.RowIndex);

                // Carga el diálogo con los valores del registro
                RegisterDialog regDlg = new RegisterDialog(currentTable, entry);

                if (regDlg.ShowDialog() == DialogResult.OK) {
                    if (currentTable.HasFK()) {
                        bool correct = true;
                        int i;
                        for (i = 0; i < regDlg.FKAtribute.Count; i++) { 
                            if (!dataBase.RegisterExists(regDlg.FKValue[i], regDlg.FKAtribute[i])) {
                                correct = false;
                                break;
                            }
                        }
                        if (correct) {
                            currentTable.DeleteRegister(dataGridView1.CurrentCell.RowIndex);
                            currentTable.AddRegister(regDlg.Register);
                        }
                        else {
                            MessageBox.Show("Cannot modify, The " + regDlg.FKAtribute[i].Name + " with value " + regDlg.FKValue[i] + " doesn't exist");
                        }

                    }
                    else {
                        currentTable.DeleteRegister(dataGridView1.CurrentCell.RowIndex);
                        currentTable.AddRegister(regDlg.Register);
                    }
                }
                ShowTableInfo(currentTable, dataGridView1);
                SaveTable(currentTable);
            }
            else {
                MessageBox.Show("Cannot modify, registry is used in another table as PK");
            }
        }

        private void BtnExecute_Click(object sender, EventArgs e) {
            string res = ExecuteQuery();
            if (res == "") {
                QueryData queryData = new QueryData(queryTable, textBoxQuery.Text);
                queryData.Show();
            }
            else {
                MessageBox.Show(res);
            }
        }

        /* Ejecuta una sentencia en el manejador. Valida los datos de la secuencia escrita 
         * y regresa los errores que pueda tener. Se utiliza TSQL para haceer el arbol de la 
         * secuencia y poder verificar sus partes. 
         * Crea una nueba tabla con los valores obtenidos de la secuencia */
        private string ExecuteQuery() {
            // Si la secuenci está vacía
            if (textBoxQuery.Text == "") {
                return "Error: no query entered";
            }

            // Guarda la sentencia en un arbol TSQL, despues se separa en las partes de select y from
            var query = TSQLStatementReader.ParseStatements(@textBoxQuery.Text)[0] as TSQLSelectStatement;
            if (query != null) {
                // Guarda los tokens del select y del from.
                var select = query.Select.Tokens;
                var from = query.From.Tokens;
                
                Table t1 = dataBase.FindTable(from[1].Text); // Tabla del FROM
                Table t2 = null; //Tabla que puede ser usada en INNER JOIN
                Attribute innerAt1 = null;
                Attribute whereAttribute = null;
                Attribute innerAt2 = null;
                List<Attribute> innerAttributes = new List<Attribute>();
                string leftSide = "", resp = "";
                object rightSide = null;
                string oper = "";
                int min = 0, max = 0;
                queryTable = new Table("Query");

                // No se escribio bien la sentencia
                if (query.From == null) {
                    return "Error: Incorrect sintaxis";
                }
                // La tabla indicada no se encuentra
                if (t1 == null) {
                    return "Error: Table \"" + from[1].Text + "\" not found";
                }

                /* Si hay 13 tokens entonces es posible que haya una sentencia de inner join*/
                if (from.Count == 13) {

                    // Verifica que se haya escrito INNER JOIN .. ON
                    if (from[2].Type == TSQLTokenType.Keyword && from[3].Type == TSQLTokenType.Keyword && from[5].Type == TSQLTokenType.Keyword) {
                        // Busca la tabla con la que hace inner
                        t2 = dataBase.FindTable(from[4].Text);
                        if (t2 == null) {
                            return "Error: Table \"" + from[1].Text + "\" not found";
                        }
                        /* Intenta buscar los atributos de cada tabla, si no los encuentra los intenta 
                         buscar de la forma invertida, si no los ecuentra entonces no existen*/
                        innerAt1 = t1.FindAttribute(from[8].Text);
                        innerAt2 = t2.FindAttribute(from[12].Text);
                        if (innerAt1 == null || innerAt2 == null) {
                            innerAt1 = t2.FindAttribute(from[8].Text);
                            innerAt2 = t1.FindAttribute(from[12].Text);
                            if (innerAt1 == null || innerAt2 == null) {
                                if (innerAt1 == null) {
                                    return "Error: Attribute \"" + from[8].Text + "\" not found";
                                }
                                if (innerAt2 == null) {
                                    return "Error: Attribute \"" + from[12].Text + "\" not found";
                                }
                            }
                        }
                        // Hace inner join entre diferentes tipos de datos
                        if (innerAt1.Type != innerAt2.Type) {
                            return "Error: can not join on diferent types";
                        }
                        // Hace inner join entre dos diferentes llaves
                        if (!innerAt1.ParentTable.Name.Equals(innerAt2.ParentTable.Name)) {
                            return "Error: must compare between same keys";
                        }
                        // Busca las tablas que fue escrita en la parte de ON
                        if (dataBase.FindTable(from[6].Text) == null) {
                            return "Error: table not found";
                        }
                        if (dataBase.FindTable(from[10].Text) == null) {
                            return "Error: table not found";
                        }
                        // Verifica que no se haga inner join con *
                        if (select[1].Text == "*") {
                            return "Error: Can't make inner join with *";
                        }
                    }
                    else {
                        return "Error: Incorrect sintaxis";
                    }
                }
                else {
                    if (from.Count != 2) {
                        return "Error: Incorrect sintaxis";
                    }
                }

                /* Se realiza la sentencia select de la tabla especificada. 
                 Se agrega todos los atribuutos de la tabla a la nueva tabla, con constructor de copia */
                if (select[1].Type == TSQLTokenType.Operator) {
                    foreach (var attribu in t1.Attributes) {
                        Attribute att = new Attribute(attribu);
                        att.ParentTable = t1;

                        queryTable.AddAttribute(att);
                    }
                }
                else {
                    /*Agrega los atributos indicado en el orden, si uno no se encuentra se sale 
                     y marca error. Si la sentencia está escrita de la forma Tabla.Atributo, primero
                     busca la tabla*/
                    for (int i = 1; i < select.Count; i++) {
                        if (select[i].Type == TSQLTokenType.Identifier && dataBase.FindTable(select[i].Text) == null) {
                            Attribute at = t1.FindAttribute(select[i].Text);
                            if (at == null) {
                                // Si no la encontro en la primera tabla, la empieza a buscar en la segunda
                                if (t2 != null) {
                                    at = t2.FindAttribute(select[i].Text);
                                    if (at == null) {
                                        return "Error: Attribute \"" + select[i].Text + "\" not found";
                                    }
                                    else {
                                        // Agraga la tabla a las columnas y establece el padre como la tabla 2 o 1
                                        Attribute att = new Attribute(at);
                                        att.ParentTable = t2;
                                        queryTable.AddAttribute(att);
                                        innerAttributes.Add(at);
                                    }
                                }
                                else {
                                    return "Error: Attribute \"" + select[i].Text + "\" not found";
                                }
                            }
                            else {
                                // Agrega la columna y etablece como padre a la tabla
                                Attribute att = new Attribute(at);
                                att.ParentTable = t1;
                                queryTable.AddAttribute(att);
                                innerAttributes.Add(at);
                            }
                        }
                    }
                }

                /* Verifica que la oracion tenga un where, si lo tiene, generaliza la condicion y 
                 la separa en el lado izquierdo, derecho y operador*/
                if (query.Where != null) {
                    // Verifica que no se compare con una cadena ingresada
                    if (query.Where.Tokens[3].Type == TSQLTokenType.StringLiteral) {
                        return "Error: can't compare with string";
                    }

                    leftSide = query.Where.Tokens[1].Text;
                    rightSide = query.Where.Tokens[3].Text;
                    oper = query.Where.Tokens[2].Text;

                    // Intenta convertir a entero para saber que no es cadena
                    try {
                        int dumm = Convert.ToInt32(rightSide);
                    }
                    catch {
                        return "Error: string compared";
                    }

                    // Busca el atributo con el que se compara
                    Attribute at = t1.Attributes.Find(x => x.Name == leftSide);
                    if (leftSide == "" || rightSide == null || oper == "") {
                        return "Error: Incorrect query syntaxis on WHERE";
                    }

                    if (at == null) {
                        return "Error: Attribute " + leftSide + " not found";
                    }
                    // Verifica que el atributo con el que se compara no sea string
                    if (at.Type == "String") {
                        return "Error: can't do WHERE on string type";
                    }

                    // Busca el atributo del where.
                    for (int h = 0; h < t1.Attributes.Count; h++) {
                        if (t1.Attributes[h].Name == leftSide) {
                            whereAttribute = t1.Attributes[h];
                            //object tReg = t1.Attributes[h].Register[i];
                            //valid = VerifyWhere(t1.Attributes[h].Type, oper, rightSide, tReg);
                            break;
                        }
                    }
                    if (whereAttribute == null) {
                        return "Error: Attribute \"" + leftSide.ToString() + "\" not found";
                    }
                }

                /* Busca el maximo y minimo de registros de las dos tablas para realizar el inner join. Se
                hace un ciclo de min*max para agregar todas */
                min = t2 != null ? Math.Min(t1.PK.Register.Count, t2.PK.Register.Count) : t1.PK.Register.Count;
                max = t2 != null ? Math.Max(t1.PK.Register.Count, t2.PK.Register.Count) : t1.PK.Register.Count;

                /* Llena la tabla de la sentencia con los valores de los registros 
                 * de la otra tabla, por lo tanto no es inner join. si tiene where, checa la condicion*/
                if (t2 == null) {
                    for (int i = 0; i < min; i++) {
                        /* Crea un nuevo registro vacío, los datos se llenan en el orden en que
                          la tabla de la sentencia tiene los atributos */
                        List<object> nr = new List<object>();
                        int valid = 0;
                        if (query.Where != null) {
                            valid = CompareValues(whereAttribute.Type, oper, rightSide, whereAttribute.Register[i]);
                        }
                        /* Busca el atributo actual en todos los atributos de la tabla destino y la
                        tabla de la sentencia */
                        foreach (var attribute in innerAttributes) {
                            nr.Add(attribute.Register[i]);
                        }

                        if (query.Where != null) {
                            if (valid == 1) {
                                queryTable.AddRegister(nr);
                            }
                        }
                        else {
                            queryTable.AddRegister(nr);
                        }
                    }
                }
                // Si la sentencia tiene inner join, agrega los valores de las dos tablas
                else {
                    for (int h = 0; h < innerAt1.Register.Count; h++) {
                        for (int g = 0; g < innerAt2.Register.Count; g++) {
                            bool valid = false;
                            List<object> nr = new List<object>();
                            int resul = CompareValues(innerAt1.Type, "=", innerAt2.Register[g], innerAt1.Register[h]);
                            if (resul == 1) {
                                foreach (var attribute in innerAttributes) {
                                    if (attribute.ParentTable.Name.Equals(t1.Name)) {
                                        nr.Add(attribute.Register[h]);
                                    }
                                    else {
                                        nr.Add(attribute.Register[g]);
                                    }
                                }
                                if (query.Where != null) {
                                    if (valid) {
                                        queryTable.AddRegister(nr);
                                    }
                                }
                                else {
                                    queryTable.AddRegister(nr);
                                }
                            }
                            else {
                                if (resul == -1) {
                                    return "Error: can't compare with string";
                                }
                            }
                        }
                    }
                }
                return "";
            }
            else {
                return "Error: Incorrect query syntaxis";
            }
        }

        /* Verifica dos datos de tipo objeto, recibe dos objetos y los intenta 
        * convertir al tipo que se recibe. El comparador se encuentra en oper
        * y solo valida las opciones ==, <, >, <=, >=, != */
        private int CompareValues(string type, string oper, object a, object b) {
            /* Si es entero, o flotante los convierte a su tipo */
            if (type == "Int") {
                int n1, n2;
                try {
                    n1 = Convert.ToInt32(b);
                    n2 = Convert.ToInt32(a);
                }
                catch {
                    return -1;
                }
                switch (oper) {
                    case "=":
                        if (n1 == n2) {
                            return 1;
                        }
                        break;
                    case "<":
                        if (n1 > n2) {
                            return 1;
                        }
                        break;
                    case ">":
                        if (n1 > n2) {
                            return 1;
                        }
                        break;
                    case ">=":
                        if (n1 >= n2) {
                            return 1;
                        }
                        break;
                    case "<=":
                        if (n1 <= n2) {
                            return 1;
                        }
                        break;
                    case "!=":
                        if (n1 != n2) {
                            return 1;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (type == "Float") {
                float n1, n2;
                try {
                    n1 = Convert.ToSingle(b);
                    n2 = Convert.ToSingle(a);
                }
                catch {
                    return -1;
                }
                switch (oper) {
                    case "=":
                        if (n1 == n2) {
                            return 1;
                        }
                        break;
                    case "<":
                        if (n1 < n2) {
                            return 1;
                        }
                        break;
                    case ">":
                        
                        if (n1 > n2) {
                            return 1;
                        }
                        break;
                    case ">=":
                        if (n1 >= n2) {
                            return 1;
                        }
                        break;
                    case "<=":
                        if (n1 <= n2) {
                            return 1;
                        }
                        break;
                    case "!=":
                        if (n1 != n2) {
                            return 1;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (type == "String") {
                string s1 = Convert.ToString(b), s2 = Convert.ToString(a);
                switch (oper) {
                    case "=":
                        if (s1.Equals(s2)) {
                            return 1;
                        }
                        break;
                    default:
                        break;
                }
            }
            return 0;
        }

        /* Cuando se presiona la tecla ENTER en el textbox de la query*/
        private void TextBoxQuery_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                BtnExecute_Click(this, null);
            }
        }

        /* Boton para limpiar el cuadro de texto */
        private void Button1_Click(object sender, EventArgs e) {
            textBoxQuery.Clear();
         
        }

        /* Abre el diálogo de el Acerca de */
        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e) {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }


        private void ExportToolStripMenuItem_Click(object sender, EventArgs e) {
            var cvs = new StringBuilder();
        }
    }
}
