using AutoMapper;
using Entidades.DTDs;
using Entidades.Entidades;

namespace LogicaNegocio.Negocio
{
    public class MapperConfigSucursal : Profile
    {
        public MapperConfigSucursal()
        {
            CreateMap<Sucursales, SucursalDTO>().ReverseMap();
            CreateMap<Sucursales, SucursalInsertarDTO>().ReverseMap();
        }

    }
}
