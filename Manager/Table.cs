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
		public List<IList> List;
		

		public Table(string newName) {
			Name = newName;
			Attributes = new List<Attribute>();
			List = new List<IList>();

			//Crear una lista de gneericos
			//Type reg = Attributes[0].GetType();
			//Type listType = typeof(List<>).MakeGenericType(new[] { reg });
			//IList list = (IList)Activator.CreateInstance(listType);




		}

		internal void AddAttribute(Attribute attr) {
			Attributes.Add(attr);

			if (attr.Key == 1) {
				HasPK = true;
			}


			switch (attr.Type) {
				case "Int":
					List<int> ints = new List<int>();
					List.Add(ints);
					break;
				case "String":
					List<string> strings = new List<string>();
					List.Add(strings);
					break;
				case "Float":
					List<float> floats = new List<float>();
					List.Add(floats);
					break;
				default:
					break;
			};


		}


		private void RemoveAttribute(Attribute at) {
			Attributes.Remove(at);

			if (at.Key == 1) {
				HasPK = false;
			}

			List.Clear();

			foreach (Attribute attribute in Attributes) {
				switch (attribute.Type) {
					case "Int":
						List<int> ints = new List<int>();
						List.Add(ints);
						break;
					case "String":
						List<string> strings = new List<string>();
						List.Add(strings);
						break;
					case "Float":
						List<float> floats = new List<float>();
						List.Add(floats);
						break;
					default:
						break;
				};
			}
		}

		public void ModifyAttribute(Attribute oldAttr, Attribute newAttr) {
			int index = Attributes.IndexOf(oldAttr);
			Attributes[index] = newAttr;


		}
	}
}
