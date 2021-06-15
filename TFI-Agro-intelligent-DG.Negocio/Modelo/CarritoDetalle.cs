using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_Agro_intelligent_DG.Negocio.Modelo
{
    public class CarritoDetalle
    {
        public CarritoDetalle()
        {
        }
        [Key]
        public int CarritoDetalleId { get; set; }
        public Pack Pack { get; set; }
        public int Cantidad { get; set; }
        
    }
}