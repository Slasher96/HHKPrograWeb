//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoPrograWebHHK
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Venta = new HashSet<Venta>();
        }
    
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool estaActivo { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    
        public virtual Cliente Cliente1 { get; set; }
        public virtual Cliente Cliente2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
