using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parqueadero.API.Models
{
    public class PersonaVM
    {
        [Required (ErrorMessage = "El campom 'NoCedula' es requerido")]
        [MaxLength(10, ErrorMessage = "El número de documento no debe superar los 10 caracteres")]
        public long NoCedula { get; set; }

        [Required(ErrorMessage = "El campom 'Nombre' es requerido")]
        [MaxLength(10, ErrorMessage = "El nombre no debe superar los 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campom 'Apellido' es requerido")]
        [MaxLength(10, ErrorMessage = "El apellido no debe superar los 30 caracteres")]
        public string Apellido { get; set; }
    }
}
