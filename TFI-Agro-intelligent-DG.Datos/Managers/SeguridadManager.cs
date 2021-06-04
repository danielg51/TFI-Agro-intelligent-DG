using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Contexts;
using TFI_Agro_intelligent_DG.Datos.IManager;
using TFI_Agro_intelligent_DG.Seguridad.Modelo;

namespace TFI_Agro_intelligent_DG.Datos.Managers
{
    public class SeguridadManager : ISeguridadManager
    {
        SeguridadContext _context;

        public SeguridadManager(SeguridadContext context)
        {
            _context = context;
        }
        public async Task<Bitacora> GrabarEvento(string usuarioId, string detalle)
        {
            var bitacora = new Bitacora
            {
                UserId = usuarioId,
                Detalle = detalle,
                FechaHoraAcceso = DateTime.Now,
            };
            _context.Bitacoras.Add(bitacora);
            await _context.SaveChangesAsync();
            return bitacora;
        }
        public async Task<IEnumerable<Bitacora>> GetEventos()
        {
            var eventos = await _context.Bitacoras.ToListAsync();
            return eventos;
        }
    }
}
