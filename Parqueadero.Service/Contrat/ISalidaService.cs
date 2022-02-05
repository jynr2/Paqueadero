using Parqueadero.Repository.Repository;
using Parqueadero.Service.Contrat.Base;
using System;

namespace Parqueadero.Service.Contrat
{
    public interface ISalidaService : IBaseService<Salida> 
    {
        double SetPayment(bool discount, DateTime admissionDate, DateTime departureDate, byte vehicleType);
    }
}
