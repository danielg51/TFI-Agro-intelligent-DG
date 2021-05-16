using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TFI_Agro_intelligent_DG.Negocio.Modelo
{
    public class PackServicio
    {
        [Key]
        public int PackServicioId { get; set; }
        public Pack Pack { get; set; }
        public int PackId { get; set; }
        public Servicio Servicio { get; set; }
        public int ServicioId { get; set; }
        public int Cantidad { get; set; }
    }
}
