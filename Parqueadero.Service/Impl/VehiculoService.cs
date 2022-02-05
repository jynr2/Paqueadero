using Parqueadero.Repository.Contratc;
using Parqueadero.Repository.Models;
using Parqueadero.Repository.Repository;
using Parqueadero.Service.Contrat;
using Parqueadero.Service.Impl.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parqueadero.Service.Impl
{
    public class VehiculoService : BaseService<Vehiculo>, IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        public VehiculoService(IVehiculoRepository vehiculoRepository) : base(vehiculoRepository) => _vehiculoRepository = vehiculoRepository;

        public async Task<List<vehiclesRankModel>> GetVehiclesByRank(DateTime admissionDate, DateTime departureDate)
        {
            try
            {
                var result = await _vehiculoRepository.GetVehiclesByRank(admissionDate, departureDate);

                if (result.Count > 0 || result != null) return result;
                else return null;
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error");
            }
        }

    }
}
