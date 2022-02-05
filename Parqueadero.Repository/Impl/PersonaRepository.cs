using Parqueadero.Repository.Context;
using Parqueadero.Repository.Contratc;
using Parqueadero.Repository.Impl.Base;
using Parqueadero.Repository.Repository;

namespace Parqueadero.Repository.Impl
{
    public class PersonaRepository : BaseRepository<Persona>, IPersonaRepository
    {
        private readonly ParqueaderoDBContext _context;

        public PersonaRepository(ParqueaderoDBContext context) : base(context) => _context = context;
    }
}
