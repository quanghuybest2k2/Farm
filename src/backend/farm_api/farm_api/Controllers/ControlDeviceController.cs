using Core.Entities;
using farm_api.Models.Request;
using farm_api.Responses;
using farm_api.Services.Implementation;
using farm_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace farm_api.Controllers
{
    [ApiController]
    [Route("socketmangement")]
    public class ControlDeviceController : ControllerBase
    {
        private SocketMangement _socketMangement {  get; set; } 
        private SocketResultManagement _socketResultManagement { get; set; }

        public  ControlDeviceController(SocketMangement socketMangement, SocketResultManagement socketResultManagement) 
        {
            _socketMangement = socketMangement;
            _socketResultManagement= socketResultManagement;
        }   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SendMessageAll(string message)
        {
            await _socketMangement.SendMessageToAllAsync(message);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> SendMessageToSocketSpecified(string deviceId,string action)
        {
            var socket = _socketMangement.GetSocketById(deviceId);
            if (socket is null)
            {
                return NotFound("Device not found.");
            }

            try
            {
                 await _socketMangement.SendMessageAsync(deviceId,action);
                var result=await _socketResultManagement.GetWeatherData(deviceId);
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
    }
}
