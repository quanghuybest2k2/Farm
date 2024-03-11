﻿using AutoMapper;
using Core.Queries;
using farm_api.Filter.Environment;
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
            CreateMap<EnvironmentQueryDTO, EnvironmentQuery>().ReverseMap();


        }
    }
}
