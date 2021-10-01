using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BDLocal2.Model
{
    public class Producto
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Cantidad { get; set; }
    }
}
