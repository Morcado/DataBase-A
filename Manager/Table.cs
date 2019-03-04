using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager {
	[Serializable]
	class Table {
		public List<Attribute> Attributes { get; set; }
		public string Name { get; set; }

		public Table(string newName) {
			Name = newName;
			Attributes = new List<Attribute>();
		}

		internal void AddAttribute(Attribute attr) {
			Attributes.Add(attr);
		}
	}
}
