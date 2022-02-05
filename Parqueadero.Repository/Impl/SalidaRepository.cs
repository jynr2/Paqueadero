using Parqueadero.Repository.Context;
using Parqueadero.Repository.Contratc;
using Parqueadero.Repository.Impl.Base;
using Parqueadero.Repository.Repository;

namespace Parqueadero.Repository.Impl
{
    public class SalidaRepository : BaseRepository<Salida>, ISalidaRepository
    {
        private readonly ParqueaderoDBContext _context;

        public SalidaRepository(ParqueaderoDBContext context) : base(context) => _context = context;
    }
}
