using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parqueadero.API.Common;
using Parqueadero.API.Enum;
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
    public class VehiculoController : Controller
    {
        private readonly IVehiculoService _vehiculoService;
        private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;
        private HelperController _helperController = new HelperController();

        public VehiculoController(IVehiculoService vehiculoService, IPersonaService personaService, IMapper mapper)
        {
            _vehiculoService = vehiculoService;
            _personaService = personaService;
            _mapper = mapper;
        }

        [HttpPost("AgregarVehiculo")]
        public async Task<IActionResult> AddVehiculo(VehiculoVM vehiculoVM)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.SelectMany(x => x.Value.Errors));

                var person = this.ExistPerson(vehiculoVM.NoCedula); 

                var IsDefined = System.Enum.IsDefined(typeof(VehicleTypeEnum), vehiculoVM.TipoVehiculoId.GetHashCode());

                if (!IsDefined) 
                    return BadRequest("El campo 'TipoVehiculoId' es incorrecto, marque: \n1 Carror \n2 Motocicleta \n3 Bicicleta");

                if (person == null) return BadRequest($"La persona con número de documento {vehiculoVM.NoCedula} no existe, por favor registrelo");
                else
                {
                    var vehiculoRequest = _mapper.Map<Vehiculo>(vehiculoVM);
                    vehiculoRequest.PersonaId = person.Id;
                    vehiculoRequest.Placa = this.SetPlateVehicle(vehiculoVM.TipoVehiculoId, vehiculoVM.Placa);
                    var vehiculoresponse = await _vehiculoService.Add(vehiculoRequest);

                    vehiculoVM.Placa = vehiculoRequest.Placa;
                    vehiculoresponse.Entity = vehiculoVM;
                    return _helperController.ValidOperationStatus(vehiculoresponse);
    }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("ObtenerInfoVehiculosPorFecha")]
        public async Task<IActionResult> GetVehiclesByRank(DateTime fechaIngreso, DateTime fechaSalida)
        {
            try
            {
                var response = await _vehiculoService.GetVehiclesByRank(fechaIngreso, fechaSalida);

                if (response == null || response.Count == 0) return NotFound("No Hay datos con las fechas especificadas");
                else return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private Persona ExistPerson(long noCedula)
        {
            try
            {
                var persons = _personaService.GetAllEntities().Result;
                var person = persons.Where(p => p.NoCedula == noCedula).FirstOrDefault();

                if (person == null) return null;
                else return person;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string SetPlateVehicle(byte TipoVehiculoId, string plateEntry)
        {
            string plate = string.Empty;

            if (plateEntry == null || TipoVehiculoId == VehicleTypeEnum.bicicleta.GetHashCode()) plateEntry = plate;
            return plateEntry;
        }
    }
}
