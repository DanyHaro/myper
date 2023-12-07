using AutoMapper;
using myper.Models;
using myper.Services.DTO;

namespace myper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Trabajador, UserDto>();

        }
    }
}
