using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_Agro_intelligent_DG.Seguridad.Modelo
{
    public class Patente:AbstractPatente
    {
        [Key]
        public int PatenteId { get; set; }
        

    }
}
