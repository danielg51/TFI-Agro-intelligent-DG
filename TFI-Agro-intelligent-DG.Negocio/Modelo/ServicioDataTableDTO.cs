using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_Agro_intelligent_DG.Negocio.Modelo
{
    public class ServicioDataTableDTO
    {
        public string[][] data { get; set; }
    }

    public class GenerarCarritoRequest
    {
        public ServicioDataTableDTO data { get; set; }
        public string usuario { get; set; }
    }

    public class AddUpdatePackRequest
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
    }



}
