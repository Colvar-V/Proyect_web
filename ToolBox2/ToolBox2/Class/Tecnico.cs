using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolBox2.Class
{
    public class Tecnico : Usuario
    {
        public string Cargo { get; set; }
        public string Usuario { get; set; }
        public string Contrasena{ get; set; } 
        public string Correo { get; set; }
        public string Proyecto { get; set; }
        public int IdProyecto { get; set; }
    }

    public class RespuestaSQL { 
        public string Aprobado { get; set; } 
    }

    public class TRespuestaSQL
    { 
        public string CODIGO { get; set; }
        public string RESULTADO { get; set; }

    }
}