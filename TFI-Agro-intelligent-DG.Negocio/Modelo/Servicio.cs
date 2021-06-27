using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_Agro_intelligent_DG.Negocio.Modelo
{
    public class Servicio
    {
        public Servicio()
        {
        }
        [Key]
        public int ServicioId { get; set; }
        public string Descripcion { get; set; }
        public Sensor? Sensor { get; set; }
        public int? SensorId { get; set; }
        public ICollection<PackServicio> PackServicios { get; set; }

    }
}
