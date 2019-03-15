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
		public AttributeDialog(string title, List<string> keys) {
			Name = title;
			comboBox2.Items.AddRange(keys.ToArray());
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			if (textBox1.Text != "" && numericUpDown1.Value != 0 && comboBox1.SelectedIndex != -1 &&
					(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)){
				Attr = new Attribute {
					Name = textBox1.Text,
					Size = Convert.ToInt32(numericUpDown1.Value),
					Type = comboBox1.Text,
					Key = radioButton1.Checked ? 1 : (radioButton2.Checked ? 2 : (radioButton3.Checked ? 3 : 0))
				};
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
			radioButton1.Enabled = false;
			radioButton2.Checked = true;
			radioButton2.Enabled = false;
			radioButton3.Enabled = false;
			numericUpDown1.Value = Convert.ToInt32();

		}
	}
}
