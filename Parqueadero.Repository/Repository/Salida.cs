using System;
using System.Collections.Generic;

#nullable disable

namespace Parqueadero.Repository.Repository
{
    public partial class Salida
    {
        public int Id { get; set; }
        public decimal Pago { get; set; }
        public bool AplicaDescuento { get; set; }
        public string NoFacturaDescuento { get; set; }
        public DateTime FechaSalida { get; set; }
        public int EntradaId { get; set; }

        public virtual Entrada Entrada { get; set; }
    }
}
