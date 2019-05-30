using System.Windows.Forms;

namespace Manager {
    public partial class QueryData : Form {
        public QueryData(Table table, string text) {
            InitializeComponent();
            Text = text;
            // Agrega las columnas de los atributos al datagrid
            foreach (Attribute attribute in table.Attributes) {
                DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn {
                    Name = attribute.Name,
                    HeaderText = attribute.ParentTable.Name + "." + attribute.Name,
                    SortMode = DataGridViewColumnSortMode.Programmatic,
                    Width = 120
                };
                dataGridView1.Columns.Add(dgc);
            }

            if (table.HasRegisters()) {
                for (int k = 0; k < table.Attributes[0].Register.Count; k++) {
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < table.Attributes.Count; i++) {
                        dataGridView1[i, k].Value = table.Attributes[i].Register[k];
                    }
                }
            }
        }
    }
}
