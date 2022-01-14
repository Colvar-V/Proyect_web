using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolBox2.Class
{
    public class Error
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Solucion { get; set; }
        public int IdModelo { get; set; }
        public string Modelo { get; set; }
    }
    public class ERespuesta {
        public string CODIGO { get; set; }
        public string RESULTADO { get; set; }
    }
}