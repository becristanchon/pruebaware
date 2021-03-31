using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace facturacion.Models
{
    public partial class FacturaValidation
    {
        [Required]
        public string fk_id_cliente;

        [Required]
        public Nullable<System.DateTime> d_fecha_compra;






    }
}