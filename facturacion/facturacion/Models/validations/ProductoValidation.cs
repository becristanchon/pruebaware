using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.MetadataServices;
using System.Web;

namespace facturacion.Models
{

    [MetadataType(typeof(MetaData))]
    public partial class ProductoValidation
    {
        [Required]
        public int  fk_id_categoria;

        [Required]
        public string nombre;

        [Required]
        public int numero_stock;

        [Required]
        public string v_precio;

    }
}