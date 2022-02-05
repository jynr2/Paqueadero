using Parqueadero.Repository.Models;
using Parqueadero.Repository.Repository;
using Parqueadero.Service.Contrat.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parqueadero.Service.Contrat
{
    public interface IVehiculoService : IBaseService<Vehiculo> 
    {
        Task<List<vehiclesRankModel>> GetVehiclesByRank(DateTime admissionDate, DateTime departureDate);
    }
}
