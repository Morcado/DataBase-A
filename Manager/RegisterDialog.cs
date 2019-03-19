using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager {
	public partial class RegisterDialog : Form {
		public RegisterDialog(Table table) {
			InitializeComponent();
			panel1.AutoScroll = false;
			panel1.HorizontalScroll.Enabled = false;
			panel1.HorizontalScroll.Visible = false;
			panel1.HorizontalScroll.Maximum = 0;
			panel1.AutoScroll = true;


			int xPos = 20, yPos = 10;

			//foreach (Attribute attribute in table.Attributes) {
			for (int i = 0; i < 20; i++) {

				Label label = new Label();
				label.Text = "3333" + i.ToString();
				label.Width = label.Text.Length * 10;
				label.Location = new Point(xPos, yPos + 5);
				panel1.Controls.Add(label);

				TextBox tBox = new TextBox();
				tBox.Location = new Point(xPos + 70, yPos);
				panel1.Controls.Add(tBox);


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
	}
}
