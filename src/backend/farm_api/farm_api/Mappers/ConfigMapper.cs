using AutoMapper;
using farm_api.Models;
using farm_api.Models.Request;
using Environment = Core.Entities.Environment;

namespace farm_api.Mappers
{
    public class ConfigMapper:Profile
    {
        public ConfigMapper() 
        {
            CreateMap<EnvironmentDTO, Environment>().ReverseMap();
            CreateMap<EnvirontmentRequest, Environment>().ReverseMap();

        }
    }
}
