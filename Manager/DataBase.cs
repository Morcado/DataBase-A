using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager {
	class DataBase {
		public string Name { get; set; }
		public string Path { get; set; }
		private List<Table> tables;
		public List<Attribute> PKKeys { get; set; }
		//public List<Tuple<Attribute, Table>> PKKeys { get; set; }

		public DataBase() {
			Name = Path = "";
			tables = new List<Table>();
			PKKeys = new List<Attribute>();
			//PKKeys = new List<Tuple<Attribute, Table>>();
		}

		public void AddTable(Table table) {
			tables.Add(table);
		}

		public void RemoveTable(string text) {
			Table table = tables.Find(x => x.Name == text);
			tables.Remove(table);
		}

		public Table FindTable(string text) {
			return tables.Find(x => x.Name == text);
		}
	}
}
