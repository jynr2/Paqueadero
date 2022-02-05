using System;
using System.Collections.Generic;

#nullable disable

namespace Parqueadero.Repository.Repository
{
    public partial class Entrada
    {
        public Entrada()
        {
            Salida = new HashSet<Salida>();
        }

        public int Id { get; set; }
        public string Puesto { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int VehiculoId { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
        public virtual ICollection<Salida> Salida { get; set; }
    }
}
