using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager {
	public partial class NewTable : Form {
		public string TableName { get; set; }

		public NewTable(string title, string v) {
			InitializeComponent();
			Text = title;
			textBox1.Text = v;
		}

		private void button1_Click(object sender, EventArgs e) {
			if (textBox1.Text != "") {
				TableName = textBox1.Text;
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
