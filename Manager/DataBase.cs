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
