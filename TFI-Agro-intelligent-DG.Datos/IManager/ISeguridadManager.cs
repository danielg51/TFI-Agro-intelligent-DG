using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Seguridad.Modelo;

namespace TFI_Agro_intelligent_DG.Datos.IManager
{
   public interface ISeguridadManager
    {

        Task<Bitacora> GrabarEvento(string usuarioId, string Detalle);
        
        Task<IEnumerable<Bitacora>> GetEventos();

       
    }
}
