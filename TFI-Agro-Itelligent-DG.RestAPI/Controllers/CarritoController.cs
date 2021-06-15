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
    public class CarritoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Servicio Antihelada", "Servicio Riego", "Servicio anti-Plagas", "Servicio KING","Servicio Small", "Servicio Medium"
        };

        private readonly ILogger<CarritoController> _logger;
        private readonly ICarritoManager _manager;


        public CarritoController(ILogger<CarritoController> logger, ICarritoManager manager)
        {
            _logger = logger;
            _manager = manager;
        }


        [HttpGet]
        public async Task<ServicioDataTableDTO> Get(int CarritoID)
        {
            var carrito = await _manager.GetCarrito(CarritoID);
            if (carrito != null)
            {
                return new ServicioDataTableDTO
                {
                    data = carrito.DetalleCompra.Select(i => new string[] { i.Pack.PackId.ToString(), i.Pack.Descripcion, i.Cantidad.ToString(), (i.Pack.Precio * i.Cantidad).ToString() }).ToArray()
                };
            }
            else {
                return new ServicioDataTableDTO();
            }
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
