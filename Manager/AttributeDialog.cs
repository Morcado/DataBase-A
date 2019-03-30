using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager {
	public partial class AttributeDialog : Form {
		public Attribute Attr { get; set; }
		private List<Attribute> keys;
		private Table table;
		private bool modificable = false;

		//ublic AttributeDialog(string title, List<Tuple<Attribute, Table>> keys, Table table, Attribute attr) {
		public AttributeDialog(string title, List<Attribute> keys, Table table, Attribute attr) {
			InitializeComponent();
			Name = title;
			this.keys = keys;
			this.table = table;

			foreach (var attribute in keys) {
				if (!table.Attributes.Contains(attribute)) {
					comboBox2.Items.Add(attribute.Name);
				}
			}

			if (table.HasPK) {
				radioButton1.Enabled = false;
			}

			if (attr != null) {
				modificable = true;
				comboBox2.Text = attr.Name;
				numericUpDown1.Value = attr.Size;
				comboBox1.Text = attr.Type;

				switch (attr.Key) {
					case 1:
						radioButton1.Checked = true;
						break;
					case 2:
						radioButton2.Checked = true;
						break;
					case 3:
						radioButton3.Checked = true;
						break;
					default:
						break;
				}

				if (table.HasPK && attr.Key != 1) {
					// Si el atributo tiene llavev primaria y no es esta
					radioButton1.Enabled = false;
				}
				else {

					radioButton1.Enabled = true;
				}
			}

		}

		private void button1_Click(object sender, EventArgs e) {

			if (comboBox2.Text != "" && numericUpDown1.Value != 0 && comboBox1.SelectedIndex != -1 &&
					(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)) {
				Attr = new Attribute {
					Name = comboBox2.Text,
					Size = Convert.ToInt32(numericUpDown1.Value),
					Type = comboBox1.Text,
					Key = radioButton1.Checked ? 1 : (radioButton2.Checked ? 2 : (radioButton3.Checked ? 3 : 0))
				};



				if (!table.Attributes.Any(att => att.Name == comboBox2.Text) || modificable) {
					DialogResult = DialogResult.OK;
					Close();
				}
				else {
					MessageBox.Show("Attribute name already exists");
				}
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
			int index = comboBox2.SelectedIndex;

			comboBox1.Enabled = false;
			radioButton1.Enabled = false;
			radioButton2.Checked = true;
			radioButton2.Enabled = false;
			radioButton3.Enabled = false;


			comboBox1.Text = keys[index].Type;
			numericUpDown1.Value = Convert.ToInt32(keys[index].Size);

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			switch (comboBox1.Text) {
				case "Int":
				case "Float":
					numericUpDown1.Enabled = false;
					numericUpDown1.Value = 4;
					break;
				case "String":
					numericUpDown1.Value = 30;
					numericUpDown1.Enabled = true;
					break;
				default:
					break;
			}

		}

		private void comboBox2_TextUpdate(object sender, EventArgs e) {
			if (!keys.Any(x => x.Name == comboBox2.Text)) {
				comboBox1.Enabled = true;
				radioButton1.Enabled = true;
				radioButton2.Checked = false;
				radioButton2.Enabled = true;
				radioButton3.Enabled = true;

			}
			else {
				comboBox1.Enabled = false;
				radioButton1.Enabled = false;
				radioButton2.Checked = true;
				radioButton2.Enabled = false;
				radioButton3.Enabled = false;

			}
		}
	}
}
