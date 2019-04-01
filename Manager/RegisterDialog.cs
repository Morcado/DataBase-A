using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Manager {
	public partial class RegisterDialog : Form {
		public Table Table { get; set; }
		public List<object> Entry { get; set; }

		public RegisterDialog(Table table, List<object> entry) {
			InitializeComponent();
			panel1.AutoScroll = false;
			panel1.HorizontalScroll.Enabled = false;
			panel1.HorizontalScroll.Visible = false;
			panel1.HorizontalScroll.Maximum = 0;
			panel1.AutoScroll = true;

			Table = table;
			Entry = new List<object>();
			int xPos = 20, yPos = 10;

			//for (int i = 0; i < 20; i++) {
			foreach (Attribute attribute in table.Attributes) {

				Label label = new Label();
				label.Text = attribute.Name;
				label.Width = 50;
				label.Location = new Point(xPos, yPos + 5);
				panel1.Controls.Add(label);


				if (attribute.Type == "Int" || attribute.Type == "Float") {
					NumericUpDown nBox = new NumericUpDown();
					nBox.Location = new Point(xPos + 90, yPos);
					nBox.Width = 100;
					nBox.Name = attribute.Name;
					nBox.Maximum = 2147483647;
					panel1.Controls.Add(nBox);
				}
				else {

					TextBox tBox = new TextBox();
					tBox.Width = 100;
					tBox.MaxLength = attribute.Size;
					tBox.Location = new Point(xPos + 90, yPos);
					tBox.Name = attribute.Name;
					panel1.Controls.Add(tBox);

				}

				yPos += 26;

			}

		}

		private void button1_Click(object sender, EventArgs e) {
			for (int i = 0; i < Table.Attributes.Count; i++) {
				Control ctrl = panel1.Controls[Table.Attributes[i].Name];
				switch (Table.Attributes[i].Type) {
					case "Int":
						NumericUpDown nCtrl = (NumericUpDown)ctrl;
						Entry.Add(Convert.ToInt32(nCtrl.Value));
						break;
					case "Float":
						NumericUpDown fCtrl = (NumericUpDown)ctrl;
						Entry.Add((float)Convert.ToDouble(fCtrl.Value));
						break;
					case "String":
						TextBox tBox = (TextBox)ctrl;
						Entry.Add(tBox.Text);
						break;
					default:
						break;
				}
			}

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
