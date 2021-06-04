using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFI_Agro_intelligent_DG.Seguridad.Modelo
{
    public class Bitacora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BitacoraId { get; set; }
        public string UserId { get; set; }
        public DateTime FechaHoraAcceso { get; set; }
        public string Detalle { get; set; }
    }
}
