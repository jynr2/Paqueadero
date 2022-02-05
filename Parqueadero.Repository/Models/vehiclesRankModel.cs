using System;

namespace Parqueadero.Repository.Models
{
    public class vehiclesRankModel
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public long NoCedula { get; set; }
        public string TipoNombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public double ValorPagado { get; set; }
        public double TiempoParqueo { get; set; }
    }
}
