using Parqueadero.Repository.Contratc;
using Parqueadero.Repository.Repository;
using Parqueadero.Service.Contrat;
using Parqueadero.Service.Impl.Base;

namespace Parqueadero.Service.Impl
{
    public class EntradaService : BaseService<Entrada>, IEntradaService
    {
        private readonly IEntradaRepository _entradaRepository;
        public EntradaService(IEntradaRepository entradaRepository) : base(entradaRepository) => _entradaRepository = entradaRepository;
    }
}
