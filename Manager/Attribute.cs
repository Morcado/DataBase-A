﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager {
    [Serializable]
    public class Attribute {
        public string Name { get; set; }				// Nombre del atributo
        public string Type { get; set; }				// Caracter o Entero o Flotante
        public int Size { get; set; }					// Si es entero, son 4 bytes, si es cadena es que elija el usuario
        public int Key { get; set; }                    // El tipo de llave que tiene
        public Table ParentTable { get; set; }			// La tabla a la que pertenece el atributo
        public IList Register;

        public Attribute() {
            Name = "";
            Type = "";
            Size = 0;
            Key = 0;
        }

        /* Crea una copia del atributo, pero solo con las caracterisicas */
        public Attribute(Attribute at) {
            Name = at.Name;
            Type = at.Type;
            Size = at.Size;
            Key = at.Key;
        }

    }
}
