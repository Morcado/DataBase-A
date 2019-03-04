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
		public AttributeDialog(string title) {
			Name = title;
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
	}
}
