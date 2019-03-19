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


		public Table(string newName) {
			Name = newName;
			Attributes = new List<Attribute>();

			//Crear una lista de gneericos
			//Type reg = Attributes[0].GetType();
			//Type listType = typeof(List<>).MakeGenericType(new[] { reg });
			//IList list = (IList)Activator.CreateInstance(listType);




		}

		internal void AddAttribute(Attribute attr) {
			Attributes.Add(attr);
		}

		public void CreateList() {
			// Crear una lista de genericos ilist
			List<IList<IList>> list = new List<IList<IList>>();

			foreach (Attribute attribute in Attributes) {
				List<IList> ob = new List<IList>();
				list.Add(ob);
			}

			foreach (IList il in list) {
				//(string)il.Count();
			}

		}


	}
}
