using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager {
	public partial class NameDialog : Form {
		public string NewName { get; set; }

		public NameDialog(string title, string textBoxText) {
			InitializeComponent();
			Text = title;
			textBox1.Text = textBoxText;
		}

		private void button1_Click(object sender, EventArgs e) {
			if (textBox1.Text != "") {
				NewName = textBox1.Text;
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
