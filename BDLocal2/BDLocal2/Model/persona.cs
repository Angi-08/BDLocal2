using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BDLocal2.Model
{
    public class persona
    {
        [PrimaryKey,AutoIncrement]
        public int Identificacion { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto => $"{Nombres} {Apellidos}";
      
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

    }
}
