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
        public List<IList> Registers;
        

        public Table(string newName) {
            Name = newName;
            Attributes = new List<Attribute>();
            Registers = new List<IList>();
        }

        public void AddAttribute(Attribute attr) {
            Attributes.Add(attr);

            if (attr.Key == 1) {
                HasPK = true;
            }

            switch (attr.Type) {
                case "Int":
                  

                    List<int> ints = new List<int>();
                    if (Registers.Count > 0) {
                        for (int i = 0; i < Registers[0].Count; i++) {
                            ints.Add(0);
                        }
                    }
                    Registers.Add(ints);
                    break;
                case "String":
                    List<string> strings = new List<string>();
                    if (Registers.Count > 0) {
                        for (int i = 0; i < Registers[0].Count; i++) {
                            strings.Add("");
                        }
                    }
                    Registers.Add(strings);
                    break;
                case "Float":
                    List<float> floats = new List<float>();
                    if (Registers.Count > 0) {
                        for (int i = 0; i < Registers[0].Count; i++) {
                            floats.Add(0f);
                        }
                    }
                    Registers.Add(floats);
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
            }
            Registers.Clear();

            foreach (Attribute attribute in Attributes) {
                switch (attribute.Type) {
                    case "Int":
                        List<int> ints = new List<int>();
                        Registers.Add(ints);
                        break;
                    case "String":
                        List<string> strings = new List<string>();
                        Registers.Add(strings);
                        break;
                    case "Float":
                        List<float> floats = new List<float>();
                        Registers.Add(floats);
                        break;
                    default:
                        break;
                };
            }
        }

        public void ModifyAttribute(Attribute oldAttr, Attribute newAttr) {
            //int index = Attributes.IndexOf(oldAttr);
            //Attributes[index] = newAttr;

            RemoveAttribute(oldAttr);
            AddAttribute(newAttr);

            //modificar atributo en la lista

        }

        public void AddRegister(List<object> newEntry) {
            //modificar le tipo en la lista, causa excepcion
            for (int i = 0; i < Registers.Count; i++) {
                Registers[i].Add(newEntry[i]);
            }
        }

        public void DeleteRegister(int index) {
            for (int i = 0; i < Registers.Count; i++) {
                Registers[i].RemoveAt(index);
            }
        }

        internal List<object> GetRegisterAt(int rowIndex) {
            List<object> entry = new List<object>();
            for (int i = 0; i < Registers.Count; i++) {
                entry.Add(Registers[i][rowIndex]);
            }
            return entry;
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
            if (Registers != null && Registers.Count > 0) {
                if (Registers[0].Count > 0) {
                    return true;
                }
            }
            return false;
        }
    }
}
