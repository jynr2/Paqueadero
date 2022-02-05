using System;
using System.Collections.Generic;

#nullable disable

namespace Parqueadero.Repository.Repository
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Entrada = new HashSet<Entrada>();
        }

        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public int PersonaId { get; set; }
        public byte TipoVehiculoId { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual TiposVehiculo TipoVehiculo { get; set; }
        public virtual ICollection<Entrada> Entrada { get; set; }
    }
}
