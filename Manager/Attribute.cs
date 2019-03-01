using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager {
    [Serializable]
	class Attribute {
		public string Name { get; set; } // Nombre del atributo
		public int Type { get; set; } // Caracter o Entero o Flotante
		public int Size { get; set; } // Si es entero, son 4 bytes, si es cadena es que elija el usuario
		public int Key { get; set; } //  El tipo de llave que tiene

		public Attribute() {
			Name = "";
			Type = 0;
		}
	}
}
