//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace facturacion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class p_productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public p_productos()
        {
            this.p_detalle_factura = new HashSet<p_detalle_factura>();
        }
    
        public int pk_id_producto { get; set; }
        public string v_nombre { get; set; }
        public Nullable<int> fk_id_categoria { get; set; }
        public string v_precio { get; set; }
        public Nullable<int> numero_stock { get; set; }
    
        public virtual c_categoria_productos c_categoria_productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p_detalle_factura> p_detalle_factura { get; set; }
    }
}