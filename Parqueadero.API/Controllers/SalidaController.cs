using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parqueadero.API.Common;
using Parqueadero.API.Models;
using Parqueadero.Repository.Repository;
using Parqueadero.Service.Contrat;
using Parqueadero.Service.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Parqueadero.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalidaController : Controller
    {
        private readonly ISalidaService _salidaService;
        private readonly IEntradaService _entradaService;
        private readonly IVehiculoService _vehiculoService;
        private readonly IMapper _mapper;
        private HelperController _helperController = new HelperController();

        public SalidaController(ISalidaService salidaService
            , IEntradaService entradaService
            , IVehiculoService vehiculoService
            , IMapper mapper)
        {
            _salidaService = salidaService;
            _entradaService = entradaService;
            _vehiculoService = vehiculoService;
            _mapper = mapper;
        }

        [HttpPost("CrearSalida")]
        public async Task<IActionResult> AddSalida(SalidaVM salidaVM)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.SelectMany(x => x.Value.Errors));

                var entradaResponse = _entradaService.GetEntityById(salidaVM.EntradaId).Result;

                if (entradaResponse == null)
                    return BadRequest($"No ha ingresado un vehiculo con número de entrada {salidaVM.EntradaId}");
                else
                {
                    if (!salidaVM.AplicaDescuento) salidaVM.NoFacturaDescuento = null;
                    var vehiculo = _vehiculoService.GetEntityById(entradaResponse.VehiculoId).Result;
                    salidaVM.Pago = _salidaService.SetPayment(salidaVM.AplicaDescuento, entradaResponse.FechaIngreso, salidaVM.FechaSalida, vehiculo.TipoVehiculoId);
                    var salidaRequest = _mapper.Map<Salida>(salidaVM);
                    var salidaResponse = await _salidaService.Add(salidaRequest);
                    salidaResponse.Entity = salidaVM;

                    return _helperController.ValidOperationStatus(salidaResponse);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error");
            }
        }
    }
}
