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
        private Table currentTable;
        private bool modificable = false;

        //public AttributeDialog(string title, List<Tuple<Attribute, Table>> keys, Table table, Attribute attr) {
        public AttributeDialog(string title, List<Attribute> keys, Table currentTable, Attribute attr) {
            InitializeComponent();
            Name = title;
            this.keys = keys;
            this.currentTable = currentTable;
            Attr = attr;

            foreach (var attribute in keys) {
                if (!currentTable.Attributes.Contains(attribute)) {
                    comboBox2.Items.Add(attribute.ParentTable.Name + "------>" + attribute.Name);
                }
            }

            if (attr != null) {
                modificable = true;
                comboBox2.Text = attr.Name;
                numericUpDown1.Value = attr.Size;
                comboBox1.Text = attr.Type;

                if (currentTable.HasPK) {
                    if (attr.Key == 1) {
                        radioButton1.Checked = true;
                    }
                    else {
                        radioButton3.Checked = true;
                        radioButton1.Enabled = false;
                    }
                }
                else {
                    if (attr.Key == 1) {
                        radioButton1.Checked = true;
                    }
                    else {
                        radioButton3.Checked = true;
                    }
                }
            }
            else {
                if (currentTable.HasPK) {
                    radioButton1.Enabled = false;
                    radioButton3.Checked = true;
                }
            }

        }

        private void Button1_Click(object sender, EventArgs e) {
            string parent = "";
            if (comboBox2.SelectedIndex != -1) {
                parent = keys[comboBox2.SelectedIndex].ParentTable.Name;
            }

            if (comboBox2.Text != "" && numericUpDown1.Value != 0 && comboBox1.SelectedIndex != -1 &&
                    (radioButton1.Checked || radioButton3.Checked || (!radioButton1.Enabled && !radioButton3.Enabled))) {

                
                Attr = new Attribute();
                Attr.Name = comboBox2.Text.Replace(parent + "------>", "");
                Attr.Size = Convert.ToInt32(numericUpDown1.Value);
                Attr.Type = comboBox1.Text;
                

                if (radioButton1.Enabled) {
                    Attr.Key = 1;
                    Attr.ParentTable = currentTable;
                }
                else {
                    if (radioButton3.Enabled) {
                        Attr.Key = 3;
                        Attr.ParentTable = currentTable;
                    }
                    else {
                        Attr.Key = 2;
                    }
                }

                
                if (!currentTable.Attributes.Any(att => att.Name == comboBox2.Text.Replace(parent + "------>", "")) || modificable) {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else {
                    MessageBox.Show("Attribute name already exists");
                }
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            int index = comboBox2.SelectedIndex;
            Attr = keys[index];

            comboBox1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton3.Enabled = false;
            radioButton1.Checked = false;
            radioButton3.Checked = false;


            comboBox1.Text = keys[index].Type;
            numericUpDown1.Value = Convert.ToInt32(keys[index].Size);

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
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

        private void ComboBox2_TextUpdate(object sender, EventArgs e) {
            //if (!keys.Any(x => x.Name == comboBox2.Text)) {
            //	comboBox1.Enabled = true;
            //	radioButton1.Enabled = true;
            //	radioButton3.Enabled = true;

            //}
            //else {
            //	comboBox1.Enabled = false;
            //	radioButton1.Enabled = false;
            //	radioButton3.Enabled = false;

            //}
        }
    }
}
