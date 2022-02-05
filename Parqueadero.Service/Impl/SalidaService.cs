using Parqueadero.Repository.Contratc;
using Parqueadero.Repository.Repository;
using Parqueadero.Service.Contrat;
using Parqueadero.Service.Impl.Base;
using System;

namespace Parqueadero.Service.Impl
{
    public class SalidaService : BaseService<Salida>, ISalidaService
    {
        private readonly ISalidaRepository _salidaRepository;
        public SalidaService(ISalidaRepository salidaRepository) : base(salidaRepository) => _salidaRepository = salidaRepository;

        public double SetPayment(bool discount, DateTime admissionDate, DateTime departureDate, byte vehicleType)
        {
            double result = 0;
            var hours = (departureDate - admissionDate).TotalHours;
            if (discount)
            {
                switch (vehicleType)
                {
                    case 1:
                        result = Math.Round((110 * hours) * (0.7), 2);
                        break;
                    case 2:
                        result = Math.Round((50 * hours) * (0.7), 2);
                        break;
                    default:
                        result = Math.Round((10 * hours) * (0.7));
                        break;
                }
            }
            else
            {
                switch (vehicleType)
                {
                    case 1:
                        result = Math.Round(110 * hours, 2);
                        break;
                    case 2:
                        result = Math.Round(50 * hours, 2);
                        break;
                    default:
                        result = Math.Round(10 * hours, 2);
                        break;
                }
            }
            return result;
        }
    }
}
