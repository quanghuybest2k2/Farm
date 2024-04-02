﻿using AutoMapper;
using Core.Entities;
using Core.Queries;
using farm_api.Filter.Camera;
using farm_api.Filter.Device;
using farm_api.Filter.Environment;
using farm_api.Filter.Farm;
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
            CreateMap<DeviceDTO, Device>().ReverseMap();
            CreateMap<DeviceQueryDTO, DeviceQuery>().ReverseMap();
            CreateMap<DeviceRequest, Device>().ReverseMap();
            CreateMap<CameraDTO, Camera>().ReverseMap();
            CreateMap<CameraQueryDTO, CameraQuery>().ReverseMap();
            CreateMap<CameraRequest, Camera>().ReverseMap();
            CreateMap<FarmRequest, Farm>().ReverseMap();
            CreateMap<FarmDTO, Farm>().ReverseMap();
            CreateMap<FarmQueryDTO, FarmQuery>().ReverseMap();
        }
    }
}
