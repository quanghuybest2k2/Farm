using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Queries;
using farm_api.Filter.Camera;
using farm_api.Filter.Device;
using farm_api.Filter.Environment;
using farm_api.Filter.Farm;
using farm_api.Filter.Schedule;
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
            CreateMap<DeviceDTO, Device>();
            CreateMap<Device, DeviceDTO>().ForMember(des=>des.ControllerCode,opt=>opt.MapFrom(src=>src.Farm.ControllerCode));
            CreateMap<DeviceQueryDTO, DeviceQuery>().ReverseMap();
            CreateMap<DeviceRequest, Device>().ReverseMap();
            CreateMap<CameraDTO, Camera>().ReverseMap();
            CreateMap<CameraQueryDTO, CameraQuery>().ReverseMap();
            CreateMap<ScheduleQuery, ScheduleQueryDTO>().ReverseMap();
            CreateMap<CameraRequest, Camera>().ReverseMap();
            CreateMap<FarmRequest, Farm>().ReverseMap();
            CreateMap<FarmDTO, Farm>().ReverseMap();
            CreateMap<FarmQueryDTO, FarmQuery>().ReverseMap();
            CreateMap<ScheduleRequest,Schedule>().ReverseMap();
            CreateMap<ScheduleDTO, Schedule>().ReverseMap();
            CreateMap<Device, DeviceTrans>().ReverseMap();

        }
    }
}
