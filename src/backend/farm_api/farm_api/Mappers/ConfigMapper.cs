using AutoMapper;
using farm_api.Models;
using Environment = Core.Entities.Environment;

namespace farm_api.Mappers
{
    public class ConfigMapper:Profile
    {
        public ConfigMapper() 
        {
            CreateMap<EnvironmentDTO, Environment>();
        }
    }
}
