using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Contexts;
using TFI_Agro_intelligent_DG.Negocio.Modelo;

namespace TFI_Agro_intelligent_DG.Datos.Managers
{
 public class PackManager : TFI_Agro_intelligent_DG.Datos.IManager.IPackManager
{
    ServicioContext _context;

    public PackManager(ServicioContext context)
    {
        _context = context;
    }

    public async Task<Pack> AddPack(Pack pack)
    {
        if (pack != null)
        {
            _context.Packs.Add(pack);
            await _context.SaveChangesAsync();
            return pack;
        }
        return null;
    }

    public async Task<Pack> DeletePack(int id)
    {
        var pack = await _context.Packs.FindAsync(id);
        _context.Entry(pack).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return pack;
    }

    public async Task<Pack> GetPackById(int id)
    {
        var pack = await _context.Packs.FindAsync(id);
        return pack;
    }

    public async Task<IEnumerable<Pack>> GetPacks()
    {
        var packs = await _context.Packs.ToListAsync();
        return packs;
    }

    public async Task<Pack> UpdatePack(Pack pack)
    {
        _context.Entry(pack).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return pack;
    }
}
}
