using System;
using System.Collections.Generic;
using System.Text;

namespace TFI_Agro_intelligent_DG.Seguridad.Modelo
{
    public class FamiliaPatenteUsuario
    {
        public int FamiliaPatenteUsuarioId { get; set; }
        public int FamiliaId { get; set; }
        public Familia Familia { get; set; }
        public int PatenteId { get; set; }
        public Patente Patente { get; set; }
        public int UserId { get; set; }
    }
}
