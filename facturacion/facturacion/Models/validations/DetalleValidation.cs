using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.MetadataServices;
using System.Web;

namespace facturacion.Models
{
    [MetadataType(typeof(MetaData))]
    public partial class DetalleValidation
    {
        [Required]
        public int fk_id_producto;

        [Required]
        public int fk_id_factura;

        [Required]
        public int cantidad;

    }
}