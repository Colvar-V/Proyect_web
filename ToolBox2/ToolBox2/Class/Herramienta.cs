using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToolBox2.Class
{
    public class Herramienta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Proyecto { get; set; }
        public string N_Archivo { get; set; }
    }
    public class Archivo
    {
        [Required]
        [DisplayName("Herramienta")]
        public HttpPostedFileBase Archivo1 { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int IdProyecto { get; set; }
        public string Link { get; set; }
    }
}