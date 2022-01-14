using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolBox2.Class
{
    public class Coord : Usuario
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public string Proyecto { get; set; }
        public int IdProyecto { get; set; }
    }
    public class CRespuestaSQL 
    {
        public string CODIGO { get; set; }
        public string RESULTADO { get; set; }

    }
}