using System;
using System.Collections.Generic;

#nullable disable

namespace Parqueadero.Repository.Repository
{
    public partial class TiposVehiculo
    {
        public TiposVehiculo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public byte Id { get; set; }
        public string TipoNombre { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
