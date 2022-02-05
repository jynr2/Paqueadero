using System.ComponentModel.DataAnnotations;

namespace Parqueadero.API.Models
{
    public class VehiculoVM
    {
        public string Placa { get; set; }

        [Required(ErrorMessage = "El campom 'Marca' es requerido")]
        [MaxLength(10, ErrorMessage = "La marca del vehiculo no debe superar los 20 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El campom 'Color' es requerido")]
        [MaxLength(10, ErrorMessage = "El color no debe superar los 20 caracteres")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El campom 'NoCedula' es requerido")]
        public long NoCedula { get; set; }

        [Required(ErrorMessage = "El campom 'NoCedula' es requerido")]
        public byte TipoVehiculoId { get; set; }

    }
}
