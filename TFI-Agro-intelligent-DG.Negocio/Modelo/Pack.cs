using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFI_Agro_intelligent_DG.Negocio.Modelo
{
    [Table("Pack")]
    public class Pack
    {
        [Key]
        public int PackId { get; set; }

        public string Descripcion { get; set; }

        public ICollection<PackServicio> PackServicios { get; set; }

        public double Precio { get; set; }

    }
}
