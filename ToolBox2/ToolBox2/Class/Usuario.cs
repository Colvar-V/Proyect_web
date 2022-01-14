using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolBox2.Class
{
    public class Usuario
    {
        private int _Id;

        public int Id { get => _Id; set => _Id = value; }
        private string _Nombre;
        public string Nombre { get => _Nombre; set => _Nombre = value; }

        private Nullable<decimal> _Telefono;
        public decimal? Telefono { get => _Telefono; set => _Telefono = value; }

       
    }
}