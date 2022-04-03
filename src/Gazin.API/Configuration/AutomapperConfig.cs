using AutoMapper;
using Gazin.API.DTOs;
using Gazin.Dominio.Models;

namespace Gazin.API.Configuration
{
    public static class AutomapperConfig
    {
        public static IMapper AutoMapperConfiguration()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Niveis, NiveisDTO>().ReverseMap();
                cfg.CreateMap<Desenvolvedor, DesenvolvedorDTO>().ReverseMap();
                
            });
            IMapper mapper = config.CreateMapper();

            return mapper;
        }       
    }
}
