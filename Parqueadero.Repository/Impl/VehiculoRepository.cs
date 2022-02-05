using Microsoft.EntityFrameworkCore;
using Parqueadero.Repository.Context;
using Parqueadero.Repository.Contratc;
using Parqueadero.Repository.Impl.Base;
using Parqueadero.Repository.Models;
using Parqueadero.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parqueadero.Repository.Impl
{
    public class VehiculoRepository : BaseRepository<Vehiculo>, IVehiculoRepository
    {
        private readonly ParqueaderoDBContext _context;

        public VehiculoRepository(ParqueaderoDBContext context) : base(context) => _context = context;

        public async Task<List<vehiclesRankModel>> GetVehiclesByRank(DateTime admissionDate, DateTime departureDate)
        {
            var innerResult = await (from vehicle in _context.Vehiculos
                               join typeVehicle in _context.TiposVehiculos on vehicle.TipoVehiculoId equals typeVehicle.Id
                               join person in _context.Personas on vehicle.PersonaId equals person.Id
                               join entrance in _context.Entrada on vehicle.Id equals entrance.VehiculoId
                               join exit in _context.Salida on entrance.Id equals exit.EntradaId
                               where entrance.FechaIngreso >= admissionDate && exit.FechaSalida <= departureDate
                               select new vehiclesRankModel 
                               { Placa = vehicle.Placa
                               , Marca = vehicle.Marca
                               , Color = vehicle.Color
                               , NoCedula = person.NoCedula
                               , TipoNombre = typeVehicle.TipoNombre
                               , FechaIngreso = entrance.FechaIngreso
                               , FechaSalida = exit.FechaSalida
                               , ValorPagado = (double)exit.Pago}).ToListAsync();

            foreach (var item in innerResult)
                item.TiempoParqueo =  (item.FechaSalida - item.FechaIngreso).TotalHours;

            return innerResult;
        }
    }
}
