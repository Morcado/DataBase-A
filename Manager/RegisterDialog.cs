using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Manager {
	public partial class RegisterDialog : Form {
		public Table Table { get; set; }
		public List<object> Register { get; set; }

		public RegisterDialog(Table table, List<object> register) {
			InitializeComponent();
			panel1.AutoScroll = false;
			panel1.HorizontalScroll.Enabled = false;
			panel1.HorizontalScroll.Visible = false;
			panel1.HorizontalScroll.Maximum = 0;
			panel1.AutoScroll = true;

			Table = table;
			Register = new List<object>();
			int xPos = 20, yPos = 10, i = 0;

			//for (int i = 0; i < 20; i++) {
			foreach (Attribute attribute in table.Attributes) {

				Label label = new Label {
					Text = attribute.Name,
					Width = 50,
					Location = new Point(xPos, yPos + 5)
				};
				panel1.Controls.Add(label);


				if (attribute.Type == "Int" || attribute.Type == "Float") {
					NumericUpDown nBox = new NumericUpDown {
						Location = new Point(xPos + 90, yPos),
						Width = 100,
						Name = attribute.Name,
						Maximum = 2147483647
					};
					if (register != null) {
						if (attribute.Type == "Int") {
							nBox.Value = Convert.ToInt32(register[i++]);
						}
						else {
							nBox.Value = Convert.ToDecimal(Convert.ToSingle(register[i++]));
						}
					}
					panel1.Controls.Add(nBox);

				}
				else {

					TextBox tBox = new TextBox {
						Width = 100,
						MaxLength = attribute.Size,
						Location = new Point(xPos + 90, yPos),
						Name = attribute.Name
					};
					panel1.Controls.Add(tBox);

					if (register != null) {
						tBox.Text = register[i].ToString();
					}
				}

				yPos += 26;

			}

		}

		private void Button1_Click(object sender, EventArgs e) {
			for (int i = 0; i < Table.Attributes.Count; i++) {
				Control ctrl = panel1.Controls[Table.Attributes[i].Name];
				switch (Table.Attributes[i].Type) {
					case "Int":
						NumericUpDown nCtrl = (NumericUpDown)ctrl;
						Register.Add(Convert.ToInt32(nCtrl.Value));
						break;
					case "Float":
						NumericUpDown fCtrl = (NumericUpDown)ctrl;
						Register.Add((float)Convert.ToDouble(fCtrl.Value));
						break;
					case "String":
						TextBox tBox = (TextBox)ctrl;
						Register.Add(tBox.Text);
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
