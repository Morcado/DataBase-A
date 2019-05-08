using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager {
    [Serializable]
    public class Table {
        public List<Attribute> Attributes { get; set; }
        public string Name { get; set; }
        public bool HasPK { get; set; }
        public bool PKIsUsed { get; set; }
        public Attribute PK { get; set; }

        public Table(string newName) {
            Name = newName;
            Attributes = new List<Attribute>();
        }

        public void AddAttribute(Attribute attr) {
            Attributes.Add(attr);

            if (attr.Key == 1) {
                HasPK = true;
                PK = attr;
            }

            switch (attr.Type) {
                case "Int":
                    attr.Register = new List<int>();

                    if (Attributes.Count > 0) {
                        for (int i = 0; i < Attributes[0].Register.Count; i++) {
                            attr.Register.Add(0);
                        }
                    }
                    break;
                case "String":
                    attr.Register = new List<string>();

                    if (Attributes.Count > 0) {
                        for (int i = 0; i < Attributes[0].Register.Count; i++) {
                            attr.Register.Add("");
                        }
                    }
                    break;
                case "Float":
                    attr.Register = new List<float>();

                    if (Attributes.Count > 0) {
                        for (int i = 0; i < Attributes[0].Register.Count; i++) {
                            attr.Register.Add(0f);
                        }
                    }
                    break;
                default:
                    break;
            };
        }

        public void RemoveAttribute(Attribute at) {
            var att = Attributes.SingleOrDefault(x => x.Name == at.Name);
            if (att != null) {
                Attributes.Remove(att);

            }

            if (at.Key == 1) {
                HasPK = false;
                PK = null;
            }
        }

        public void ModifyAttribute(Attribute oldAttr, Attribute newAttr) {
            //int index = Attributes.IndexOf(oldAttr);
            //Attributes[index] = newAttr;

            RemoveAttribute(oldAttr);
            AddAttribute(newAttr);


        }

        public void AddRegister(List<object> newEntry) {
            //modificar le tipo en la lista, causa excepcion


            for (int i = 0; i < Attributes.Count; i++) {
                Attributes[i].Register.Add(newEntry[i]);
            }
        }

        public void DeleteRegister(int index) {
            for (int i = 0; i < Attributes.Count; i++) {
                Attributes[i].Register.RemoveAt(index);
            }
        }

        internal List<object> GetRegisterAt(int rowIndex) {
            List<object> register = new List<object>();
            for (int i = 0; i < Attributes.Count; i++) {
                register.Add(Attributes[i].Register[rowIndex]);
            }

            return register;
        }

        /* Busca un atributo por el nombre, regresa el objdeto atributo*/
        internal Attribute FindAttribute(string name) {
            foreach (var attribute in Attributes) {
                if (attribute.Name == name) {
                    return attribute;
                }
            }
            return null;
        }

        public bool HasRegisters() {
            if (Attributes.Count > 0) {
                if (Attributes[0].Register != null && Attributes[0].Register.Count > 0) {
                    return true;
                }
            }
            return false;
        }

        internal Attribute GetPKAttribute() {
            foreach (var attribute in Attributes) {
                if (attribute.Key == 1) {
                    return attribute;
                }
            }
            return null;
        }

        internal bool HasFK() {
            foreach (Attribute attribute in Attributes) {
                if (attribute.Key == 2) {
                    return true;
                }
            }
            return false;
        }

        public List<object> GetRegisterAsList(int index) {
            List<object> reg = new List<object>();
            foreach (var attrib in Attributes) {
                reg.Add(attrib.Register[index]);
            }
            return reg;
        }
    }
}
