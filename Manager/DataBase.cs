using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager {
    class DataBase {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<Table> Tables { get; set; }
        public List<Attribute> PKKeys { get; set; }
        //public List<Tuple<Attribute, Table>> PKKeys { get; set; }

        public DataBase() {
            Name = Path = "";
            Tables = new List<Table>();
            PKKeys = new List<Attribute>();
            //PKKeys = new List<Tuple<Attribute, Table>>();
        }

        public void AddTable(Table table) {
            Tables.Add(table);
        }

        public void RemoveTable(string text) {
            Table table = Tables.Find(x => x.Name == text);

            foreach (var attri in table.Attributes) {
                PKKeys.Remove(attri);
            }
            Tables.Remove(table);
        }

        public Table FindTable(string text) {
            return Tables.Find(x => x.Name == text);
        }


        internal bool HasAttribAsFK(Attribute at) {
            foreach (var table in Tables) {
                foreach (var attrib in table.Attributes) {
                    if (attrib.Name == at.Name && attrib.Key == 2) {
                        return true;
                    }
                }
            }
            return false;
        }

        /* Busca un registro en todas las tablas, del atributo seleccionado como llave primaria
         El registro se inserto como llave secundaria*/
        public bool RegisterExists(object register, Attribute pKAtribute) {
            //string sval;
            //int ival;
            //float fval;

            //switch (pKAtribute.Type) {
            //    case "Int":
            //        ival = (int)register; 
            //        break;
            //    case "Float":
            //        fval = (float)register;
            //        break;
            //    case "String":
            //        sval = (float)
            //        break;
            //    default:
            //        break;
            //}
            foreach (var table in Tables) {
                foreach (var attrib in table.Attributes) {
                    if (attrib.ParentTable.Name.Equals(pKAtribute.ParentTable.Name) && attrib.Key == 1) {
                        foreach (var reg in attrib.Register) {
                            if (register.Equals(reg)) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        //internal bool CheckTables(Attribute at) {
        //	foreach (var table in tables) {
        //		if (table.Attributes.Contains(at)) {
        //			return true;
        //		}
        //	}
        //	return false;
        //}
    }
}
