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


        public PackController(ILogger<PackController> logger,IPackManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpGet]
        public async Task<ServicioDataTableDTO> Get()
        {
            var packs = await _manager.GetPacks();
            return new ServicioDataTableDTO {
                data = packs.Select(i => new string[] { i.PackId.ToString(), "", i.Descripcion }).ToArray()
            };
        }

        //[HttpGet]
        //public async Task<List<Pack>> GetPacks(int idVenta)
        //{
        //    var result = new List<Pack>();

        //    result.Add(new Pack { PackId = 1, Descripcion = "" });

        //    return result;
            
        //}

    }

}
