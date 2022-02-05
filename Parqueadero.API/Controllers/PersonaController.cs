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
    public class PersonaController : Controller
    {
        private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;
        private HelperController _helperController = new HelperController();

        public PersonaController(IPersonaService personaService, IMapper mapper)
        {
            _personaService = personaService;
            _mapper = mapper;
        }

        [HttpPost("AgregarPersona")]
        public async Task<IActionResult> AddPerson(PersonaVM personaVM)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.SelectMany(x => x.Value.Errors));

                var personaRequest = _mapper.Map<Persona>(personaVM);
                var responseService = await _personaService.Add(personaRequest);
                responseService.Entity = personaVM;
                return _helperController.ValidOperationStatus(responseService);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error");
            }
        }

        [HttpGet("ObtenerPersonas")]
        public async Task<IActionResult> GetAllPerson()
        {
            try
            {
                var persons = await _personaService.GetAll();
                return _helperController.ValidOperationStatus(persons);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error");
            }
        }
    }
}
