using System;
using System.Collections.Generic;

#nullable disable

namespace Parqueadero.Repository.Repository
{
    public partial class Persona
    {
        public Persona()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public long NoCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
