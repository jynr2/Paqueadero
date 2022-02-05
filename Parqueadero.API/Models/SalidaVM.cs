using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parqueadero.API.Models
{
    public class SalidaVM
    {
        public double Pago { get; set; }
        public bool AplicaDescuento { get; set; }
        public string NoFacturaDescuento { get; set; }
        public DateTime FechaSalida { get; } = DateTime.Now;

        [Required(ErrorMessage = "El campom 'EntradaId' es requerido")]
        public int EntradaId { get; set; }
    }
}
