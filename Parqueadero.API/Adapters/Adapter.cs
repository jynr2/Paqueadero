using AutoMapper;
using Parqueadero.API.Models;
using Parqueadero.Repository.Repository;

namespace Parqueadero.API.Adapters
{
    public class Adapter : Profile
    {
        public Adapter()
        {
            CreateMap<Vehiculo, VehiculoVM>().ReverseMap();
            CreateMap<VehiculoVM, Vehiculo>().ReverseMap();

            CreateMap<Entrada, EntradaVM>().ReverseMap();
            CreateMap<EntradaVM, Entrada>().ReverseMap();

            CreateMap<Salida, SalidaVM>().ReverseMap();
            CreateMap<SalidaVM, Salida>().ReverseMap();

            CreateMap<Persona, PersonaVM>().ReverseMap();
            CreateMap<PersonaVM, Persona>().ReverseMap();
        }
    }
}
