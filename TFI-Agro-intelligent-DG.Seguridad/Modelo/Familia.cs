using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_Agro_intelligent_DG.Seguridad.Modelo
{
    public class Familia: AbstractPatente
    {
        public int FamiliaId { get; set; }

        public int? FamiliaPadreId { get; set; }

        public Familia FamiliaPadre { get; set; }
        public Familia()
        {
        }
    }
}
