using Parqueadero.Repository.Contratc.Base;
using Parqueadero.Repository.Models;
using Parqueadero.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parqueadero.Repository.Contratc
{
    public interface IVehiculoRepository : IBaseRepository<Vehiculo>
    {
        Task<List<vehiclesRankModel>> GetVehiclesByRank(DateTime admissionDate, DateTime departureDate);
    }
}
