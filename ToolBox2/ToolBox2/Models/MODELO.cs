//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToolBox2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MODELO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MODELO()
        {
            this.EQUIPOS = new HashSet<EQUIPOS>();
            this.Pre_Error = new HashSet<Pre_Error>();
        }
    
        public int Id { get; set; }
        public string Modelo1 { get; set; }
        public int Id_Marca { get; set; }
        public string Componentes { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPOS> EQUIPOS { get; set; }
        public virtual MARCA MARCA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pre_Error> Pre_Error { get; set; }
    }
}
