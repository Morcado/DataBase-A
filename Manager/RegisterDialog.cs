﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager {
	public partial class RegisterDialog : Form {
		public Table Table { get; set; }
		public RegisterDialog(Table table) {
			InitializeComponent();
			panel1.AutoScroll = false;
			panel1.HorizontalScroll.Enabled = false;
			panel1.HorizontalScroll.Visible = false;
			panel1.HorizontalScroll.Maximum = 0;
			panel1.AutoScroll = true;

			Table = table;
			int xPos = 20, yPos = 10;

			//for (int i = 0; i < 20; i++) {
			foreach (Attribute attribute in table.Attributes) {

				Label label = new Label();
				label.Text = attribute.Name;
				label.Width = label.Text.Length * 10;
				label.Location = new Point(xPos, yPos + 5);
				panel1.Controls.Add(label);


				if (attribute.Type == "Int" || attribute.Type == "Float") {
					NumericUpDown nBox = new NumericUpDown();
					nBox.Location = new Point(xPos + 70, yPos);
					nBox.Width = 100;
					nBox.Name = attribute.Name;
					panel1.Controls.Add(nBox);
				}
				else {

					TextBox tBox = new TextBox();
					tBox.Width = 100;
					tBox.MaxLength = attribute.Size;
					tBox.Location = new Point(xPos + 70, yPos);
					tBox.Name = attribute.Name;
					panel1.Controls.Add(tBox);

				}

				yPos += 26;
				//switch (attribute.Type) {
				//	case "Int":
				//		break;
				//	case "String":
				//		break;
				//	case "Float":
				//		break;
				//	default:
				//		break;
				//}
			}

		}

		private void button1_Click(object sender, EventArgs e) {

			for (int i = 0; i < Table.Attributes.Count; i++) {
				Control ctrl = panel1.Controls[Table.Attributes[i].Name];
				switch (Table.Attributes[i].Type) {
					case "Int":
						NumericUpDown nCtrl = (NumericUpDown)ctrl;
						Table.List[i].Add(Convert.ToInt32(nCtrl.Value));
						break;
					case "Float":
						NumericUpDown fCtrl = (NumericUpDown)ctrl;
						Table.List[i].Add(Convert.ToDouble(fCtrl.Value));
						break;
					case "String":
						TextBox tBox = (TextBox)ctrl;
						Table.List[i].Add(tBox.Text);
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