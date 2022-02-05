using System;
using System.ComponentModel.DataAnnotations;

namespace Parqueadero.API.Models
{
    public class EntradaVM
    {
        [Required(ErrorMessage = "El campom 'Puesto' es requerido")]
        [MaxLength(10, ErrorMessage = "El campo 'puesto' no debe superar los 5 caracteres")]
        public string Puesto { get; set; }
        public DateTime FechaIngreso { get; } = DateTime.Now;

        
        public string Placa { get; set; }
    }
}
