using AutoMapper;
using Core.Common;
using Core.Entities;
using DAL.Context;
using DAL.Repositories.Implementation;
using DAL.Repositories.Interface;
using DAL.Repositories.UnitOfWork;
using farm_api.Filter.Farm;
using farm_api.Models;
using farm_api.Models.Request;
using farm_api.Responses;
using farm_api.Services.Implementation;
using farm_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using static Core.Enums.MessageSocket;

namespace farm_api.Controllers
{
    [ApiController]
    [Route("socketmanagement")]
    public class ControlDeviceController : ControllerBase
    {
        private readonly SocketMangement _socketManagement;
        private readonly SocketResultManagement _socketResultManagement;
        private readonly IDeviceService _deviceService;
        private readonly IDeviceRepository _deviceRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private FarmContext _farmContext;

        public ControlDeviceController(SocketMangement socketManagement
                                       , SocketResultManagement socketResultManagement
                                       , IDeviceService deviceService
                                       , IUnitOfWork unitOfWork
                                        , IMapper mapper
                                        , IDeviceRepository deviceRepository
                                        , FarmContext farmContext)
        {
            _socketManagement = socketManagement;
            _socketManagement = socketManagement;
            _socketResultManagement = socketResultManagement;
            _deviceService = deviceService;
            _unitOfWork = unitOfWork;
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _farmContext = farmContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SendMessageAll(string message)
        {
            await _socketManagement.SendMessageToAllAsync(message);
            return Ok();
        }

        [HttpGet]
        [Route("messageToSocketSpecified")] // Added route to distinguish between Get methods
        public async Task<IActionResult> SendMessageToSocketSpecified(string farmId)
        {
            var socket = _socketManagement.GetSocketById(farmId);
            if (socket is null)
            {
                return NotFound("Device not found.");
            }

            try
            {
                var socketMessage = new WebSocketMessage<DeviceDTO>(null, farmId, MessageType.WeatherData);

                await _socketManagement.SendMessageAsync(farmId,socketMessage);
                var result = await _socketResultManagement.GetWeatherData(farmId);
                return Ok(result);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("messageToDeviceSpecified")] // Added route to distinguish between Get methods
        public async Task<IActionResult> SendMessageToDeviceSpecified([FromQuery] DeviceControlQuery deviceControlQuery)
        {
            var socket = _socketManagement.GetSocketById(deviceControlQuery.FarmId);
            if (socket is null)
            {
                return NotFound("Device not found.");
            }

            try
            {
                var device = _farmContext.Devices.FirstOrDefault(x => x.Id == deviceControlQuery.DeviceId);
                if (device is null)
                {
                    throw new KeyNotFoundException(); 
                }
                var deviceDTO = _mapper.Map<DeviceDTO>(device);
                deviceDTO.Status= deviceControlQuery.Action;
                device.Status= deviceControlQuery.Action;
                _unitOfWork.Save();
                var socketMessage = new WebSocketMessage<DeviceDTO>(deviceDTO, deviceControlQuery.DeviceId, MessageType.DeviceInfo);
                await _socketManagement.SendMessageAsync(deviceControlQuery.FarmId, socketMessage);
                return Ok();
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
