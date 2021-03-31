using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace facturacion.Models
{


    [MetadataType(typeof(Metadata))]
    public partial class p_persona  
    {

       
        sealed class Metadata
        {

            [Required]
            public string v_numero_documento;
            [Required]
            public string c_tipo_documento;
           
        }

    }
}