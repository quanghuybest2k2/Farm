﻿using AutoMapper;
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
using System.Globalization;
using Environment = Core.Entities.Environment;

namespace farm_api.Mappers
{
    public class ConfigMapper : Profile
    {
        public ConfigMapper()
        {
            CreateMap<EnvironmentDTO, Environment>().ReverseMap();
            CreateMap<EnvirontmentRequest, Environment>().ReverseMap();
            CreateMap<EnvironmentQueryDTO, EnvironmentQuery>().ReverseMap();
            CreateMap<DeviceDTO, Device>();
            CreateMap<Device, DeviceDTO>().ForMember(des => des.ControllerCode, opt => opt.MapFrom(src => src.Farm.ControllerCode));
            CreateMap<DeviceQueryDTO, DeviceQuery>().ReverseMap();
            CreateMap<DeviceRequest, Device>().ReverseMap();
            CreateMap<CameraDTO, Camera>().ReverseMap();
            CreateMap<CameraQueryDTO, CameraQuery>().ReverseMap();
            CreateMap<ScheduleQuery, ScheduleQueryDTO>().ReverseMap();
            CreateMap<CameraRequest, Camera>().ReverseMap();
            CreateMap<FarmRequest, Farm>().ReverseMap();
            CreateMap<FarmDTO, Farm>().ReverseMap();
            CreateMap<FarmQueryDTO, FarmQuery>().ReverseMap();
            CreateMap<ScheduleRequest, Schedule>().ReverseMap();
            CreateMap<ScheduleRequest, Schedule>()
                 .ForMember(dest => dest.StartDate, opt => opt.Ignore())
                .ForMember(dest => dest.EndDate, opt => opt.Ignore());
            CreateMap<ScheduleDTO, Schedule>().ReverseMap();
            CreateMap<Device, DeviceTrans>().ReverseMap();
            CreateMap<DeviceSchedule, DeviceScheduleDTO>().ReverseMap();
            CreateMap<Schedule, ScheduleDTO>().ForMember(des => des.FarmName, opt => opt.MapFrom(src=>src.Farm.Name));
            CreateMap<DeviceSchedule, DeviceInfoSchedule>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Device.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Device.Type))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Device.Order))
            .ForMember(dest => dest.FarmId, opt => opt.MapFrom(src => src.Device.FarmId))
            .ForMember(dest => dest.DeviceId, opt => opt.MapFrom(src => src.DeviceId))
            .ForMember(dest => dest.StatusDevice, opt => opt.MapFrom(src => src.StatusDevice))
            .ForMember(dest => dest.ScheduleId, opt => opt.MapFrom(src => src.ScheduleId))
            .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt))
            .ForMember(dest => dest.UpdateAt, opt => opt.MapFrom(src => src.UpdateAt));
        }
    }
}