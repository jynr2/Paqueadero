using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parqueadero.API.Common;
using Parqueadero.API.Models;
using Parqueadero.Repository.Repository;
using Parqueadero.Service.Contrat;
using Parqueadero.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parqueadero.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntradaController : Controller
    {
        private readonly IEntradaService _entradaService;
        private readonly IVehiculoService _vehiculoService;
        private readonly IMapper _mapper;
        private HelperController _helperController = new HelperController();

        public EntradaController(IEntradaService entradaService, IVehiculoService vehiculoService, IMapper mapper)
        {
            _entradaService = entradaService;
            _vehiculoService = vehiculoService;
            _mapper = mapper;
        }

        [HttpPost("CrearEntrada")]
        public async Task<IActionResult> AddEntrada(EntradaVM entradaVM)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.SelectMany(x => x.Value.Errors));

                var vehiculo = this.ExistVehiculo(entradaVM.Placa);

                if (vehiculo == null)
                    return BadRequest($"El vehiculo con placa {entradaVM.Placa} no existe, por favor registrelo");
                else
                {
                    var entradaRequest = _mapper.Map<Entrada>(entradaVM);
                    entradaRequest.VehiculoId = vehiculo.Id;
                    var entradaresponse = await _entradaService.Add(entradaRequest);

                    entradaresponse.Entity = entradaVM;
                    return _helperController.ValidOperationStatus(entradaresponse);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error");
            }
        }

        private Vehiculo ExistVehiculo(string placa)
        {
            try
            {
                var vehiculos = _vehiculoService.GetAllEntities().Result;
                var person = vehiculos.Where(v => v.Placa == placa).FirstOrDefault();

                if (person == null) return null;
                else return person;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
