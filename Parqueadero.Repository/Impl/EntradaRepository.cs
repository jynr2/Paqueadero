using Parqueadero.Repository.Context;
using Parqueadero.Repository.Contratc;
using Parqueadero.Repository.Impl.Base;
using Parqueadero.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parqueadero.Repository.Impl
{
    public class EntradaRepository : BaseRepository<Entrada>, IEntradaRepository
    {
        private readonly ParqueaderoDBContext _context;

        public EntradaRepository(ParqueaderoDBContext context):base(context) => _context = context;
    }
}
