﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Datos.IManager;
using TFI_Agro_intelligent_DG.Seguridad.Modelo;

namespace TFI_Agro_Itelligent_DG.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly ILogger<SeguridadController> _logger;
        private readonly ISeguridadManager _manager;


        public SeguridadController(ILogger<SeguridadController> logger, ISeguridadManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<Bitacora>> Get()
        {
            var bitacoras = await _manager.GetEventos();
            return bitacoras;
        }

    }
}
