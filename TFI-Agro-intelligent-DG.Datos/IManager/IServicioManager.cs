using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Negocio.Modelo;

namespace TFI_Agro_intelligent_DG.Datos.IManager
{
    public interface IServicioManager
    {

        Task<IEnumerable<Servicio>> GetServicios();

        Task<Servicio> GetServicioById(int id);

        Task<Servicio> AddServicio(Servicio servicio);

        Task<Servicio> UpdateServicio(Servicio servicio);

        Task<Servicio> DeleteServicio(int id);

    }
}
