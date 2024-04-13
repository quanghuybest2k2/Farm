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
    [Route("api/controldevices")]
    public class ControlDeviceController : ControllerBase
    {

        private readonly IDeviceService _deviceService;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMQTTService _mQTTService;


        public ControlDeviceController(IDeviceService deviceService
                                       , IUnitOfWork unitOfWork
                                       , IMapper mapper
                                       , IDeviceRepository deviceRepository
                                       , IMQTTService mQTT)
        {
            _deviceService = deviceService;
            _unitOfWork = unitOfWork;
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _mQTTService = mQTT;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ControllDevices([FromBody] TopicRequest topicRequest)
        {
            if (topicRequest == null)
            {
                return BadRequest();
            }
            try
            {
                await _mQTTService.ConnectAsync();
                await _mQTTService.PublishAsync(topicRequest.TopicName, topicRequest.Payload);
                await _mQTTService.DisconnectAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return BadRequest(ex.GetType().Name);
            }
            return Ok();
        }
    }
}
