using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Datos.IManager;
using TFI_Agro_intelligent_DG.Negocio.Modelo;
using System.Security.Claims;
using System.IO;
using System.Text;

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
        private readonly ISeguridadManager _managerSeguridad;

        public CarritoController(ILogger<CarritoController> logger, ICarritoManager manager, ISeguridadManager managerSeguridad)
        {
            _logger = logger;
            _manager = manager;
            _managerSeguridad = managerSeguridad;
        }


        [HttpPost]
        public int AgregarCarrito(GenerarCarritoRequest param)
        //public async Task<int> AgregarCarrito(ServicioDataTableDTO data, string usuario)
        {
            //var usuarioID = 1;
            //int user = Convert.ToInt32(usuarioID);




            try
            {

                var carritoID = _manager.AgregarCarrito(param.usuario);
                if (carritoID != null)
                {
                    foreach (var item in param.data.data)
                    {
                        var carritoDetalleID = _manager.AgregarCarritoDetalle(Convert.ToInt32(item[0]), Convert.ToInt32(item[2]), carritoID);
                    }
                }
                else
                {
                    return -1;
                }
                
                _managerSeguridad.GrabarEvento(param.usuario, "Se genero la compra #" + carritoID.ToString());
                return carritoID;
            }
            catch (Exception ex)
            {
                return -1;
            }

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
            else
            {
                return new ServicioDataTableDTO();
            }
        }

        [HttpGet("files/{id}")]
        public async Task<ActionResult> DownloadFile(string id)
        {
            string archivo = _manager.GetPedidoPDF(Convert.ToInt32(id));

            /*
            var filePath = $"{id}.txt"; // Here, you should validate the request and the existance of the file.
            System.IO.File.WriteAllText(filePath, "COLO");
            */
            var bytes = await System.IO.File.ReadAllBytesAsync(archivo);

            return File(bytes, "application/octet-stream", Path.GetFileName(archivo));
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
