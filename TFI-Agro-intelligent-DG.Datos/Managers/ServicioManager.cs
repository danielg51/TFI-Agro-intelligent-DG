using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TFI_Agro_intelligent_DG.Negocio.Modelo;
using TFI_Agro_intelligent_DG.Contexts;

namespace TFI_Ago_intelligent_DG.Datos.Managers
{
    public class ServicioManager : TFI_Agro_intelligent_DG.Datos.IManager.IServicioManager
    {
        ServicioContext _context;

        public ServicioManager(ServicioContext context)
        {
            _context = context;
        }

        public async Task<Servicio> AddServicio(Servicio servicio)
        {
            if(servicio != null)
            {
                _context.Servicios.Add(servicio);
                await _context.SaveChangesAsync();
                return servicio;
            }
            return null;
        }

        public async Task<Servicio> DeleteServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            _context.Entry(servicio).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return servicio;
        }

        public async Task<Servicio> GetServicioById(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            return servicio;
        }

        public async Task<IEnumerable<Servicio>> GetServicios()
        {
            var servicios =  await _context.Servicios.ToListAsync();
            return servicios;
        }

        public async Task<Servicio> UpdateServicio(Servicio servicio)
        {
            _context.Entry(servicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return servicio;
        }
    }
}
