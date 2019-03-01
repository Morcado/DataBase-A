using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager {
	class DataBase {
		public string Name { get; set; }
		public string Path { get; set; }
		public List<Table> Tables { get; set; }

		public DataBase() {
			Name = Path = "";
			Tables = new List<Table>();
		}

		public void AddTable(Table table) {
			Tables.Add(table);
		}

		public void RemoveTable(string text) {
			Table table = Tables.Find(x => x.Name == text);
			Tables.Remove(table);
		}
	}
}
