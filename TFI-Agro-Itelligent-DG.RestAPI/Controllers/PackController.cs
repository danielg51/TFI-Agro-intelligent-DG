using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Datos.IManager;
using TFI_Agro_intelligent_DG.Negocio.Modelo;

namespace TFI_Agro_Itelligent_DG.RestAPI.Controllers
{
    [EnableCors("All")]
    [ApiController]
    [Route("[controller]")]
    public class PackController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Servicio Antihelada", "Servicio Riego", "Servicio anti-Plagas", "Servicio KING","Servicio Small", "Servicio Medium"
        };

        private readonly ILogger<PackController> _logger;
        private readonly IPackManager _manager;


        public PackController(ILogger<PackController> logger, IPackManager manager)
        {
            _logger = logger;
            _manager = manager;

        }

        [HttpGet]
        public async Task<ServicioDataTableDTO> Get()
        {
            var packs = await _manager.GetPacks();
            return new ServicioDataTableDTO
            {
                data = packs.Select(i => new string[] { i.PackId.ToString(), "", i.Descripcion, i.Precio.ToString() }).ToArray()
            };
        }


        [HttpGet("GetPack/")]
        public async Task<IEnumerable<Pack>> GetPack()
        {
            return await _manager.GetPacks();

        }

        [HttpGet("GetPack/{packId}")]
        public async Task<Pack> GetPack(int packId)
        {
            var pack = await _manager.GetPackById(packId);
            return pack;

        }

        [HttpPost("AddPack/{param}")]
        public async Task<int> AddPack(AddUpdatePackRequest param)
        {
            try
            {
                var pack = new Pack()
                {
                    Descripcion = param.descripcion,
                    Precio = param.precio
                };

                var packNew = await _manager.AddPack(pack);
                return packNew.PackId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        [HttpPost("UpdatePack/{param}")]
        public async Task<int> UpdatePack(AddUpdatePackRequest param)
        {
            try
            {
                var pack = await _manager.GetPackById(param.id);
                pack.Descripcion = param.descripcion;
                pack.Precio = param.precio;
                var packNew = await _manager.UpdatePack(pack);
                return packNew.PackId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        [HttpPost("DeletePack/{packId}")]
        public async Task<int> DeletePack(int packId)
        {
            try
            {
                var packNew = await _manager.DeletePack(packId);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        //public async Task<int> AgregarCarrito(ServicioDataTableDTO data, string usuario)
        //{

        //[HttpGet]
        //public async Task<List<Pack>> GetPacks(int idVenta)
        //{
        //    var result = new List<Pack>();

        //    result.Add(new Pack { PackId = 1, Descripcion = "" });

        //    return result;

        //}

    }

}
