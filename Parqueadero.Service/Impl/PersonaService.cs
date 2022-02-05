using Parqueadero.Repository.Contratc;
using Parqueadero.Repository.Repository;
using Parqueadero.Service.Contrat;
using Parqueadero.Service.Impl.Base;

namespace Parqueadero.Service.Impl
{
    public class PersonaService : BaseService<Persona>, IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaService(IPersonaRepository personaRepository) : base(personaRepository) => _personaRepository = personaRepository;
    }
}
