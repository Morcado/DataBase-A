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
		public List<IList> Entries;
		

		public Table(string newName) {
			Name = newName;
			Attributes = new List<Attribute>();
			Entries = new List<IList>();

		}

		internal void AddAttribute(Attribute attr) {
			Attributes.Add(attr);

			if (attr.Key == 1) {
				HasPK = true;
			}

			switch (attr.Type) {
				case "Int":
					List<int> ints = new List<int>();
					Entries.Add(ints);
					break;
				case "String":
					List<string> strings = new List<string>();
					Entries.Add(strings);
					break;
				case "Float":
					List<float> floats = new List<float>();
					Entries.Add(floats);
					break;
				default:
					break;
			};
		}

		public void RemoveAttribute(Attribute at) {
			Attributes.Remove(at);

			if (at.Key == 1) {
				HasPK = false;
			}
			Entries.Clear();

			foreach (Attribute attribute in Attributes) {
				switch (attribute.Type) {
					case "Int":
						List<int> ints = new List<int>();
						Entries.Add(ints);
						break;
					case "String":
						List<string> strings = new List<string>();
						Entries.Add(strings);
						break;
					case "Float":
						List<float> floats = new List<float>();
						Entries.Add(floats);
						break;
					default:
						break;
				};
			}
		}

		public void ModifyAttribute(Attribute oldAttr, Attribute newAttr) {
			int index = Attributes.IndexOf(oldAttr);
			Attributes[index] = newAttr;

			//modificar atributo en la lista

		}

		public void AddEntry(List<object> newEntry) {
			//modificar le tipo en la lista, causa excepcion
			for (int i = 0; i < Entries.Count; i++) {
				Entries[i].Add(newEntry[i]);
			}
		}

		public void DeleteEntry(int index) {
			for (int i = 0; i < Entries.Count; i++) {
				Entries[i].RemoveAt(index);
			}
		}
	}
}
