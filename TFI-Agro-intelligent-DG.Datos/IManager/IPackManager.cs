using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Negocio.Modelo;

namespace TFI_Agro_intelligent_DG.Datos.IManager
{
    public interface IPackManager
{

    Task<IEnumerable<Pack>> GetPacks();

    Task<Pack> GetPackById(int id);

    Task<Pack> AddPack(Pack pack);

    Task<Pack> UpdatePack(Pack pack);

    Task<Pack> DeletePack(int id);

}
}
