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
    [Route("api/controldevice")]
    public class ControlDeviceController : ControllerBase
    {

        private readonly IDeviceService _deviceService;
        private readonly IDeviceRepository _deviceRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private FarmContext _farmContext;

        public ControlDeviceController(
                                        IDeviceService deviceService
                                       , IUnitOfWork unitOfWork
                                        , IMapper mapper
                                        , IDeviceRepository deviceRepository
                                        , FarmContext farmContext)
        {
            _deviceService = deviceService;
            _unitOfWork = unitOfWork;
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _farmContext = farmContext;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("controlldevice")]
        public async Task<IActionResult> ControllDevices([FromBody] TopicRequest topicRequest)
        {
            if (topicRequest == null)
            {
                return BadRequest();
            }
            try
            {
                //await _mQTTService.PublishAsync(topicRequest.TopicName, topicRequest.Payload);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, null));
            }
            return Ok();
        }
    }
}
