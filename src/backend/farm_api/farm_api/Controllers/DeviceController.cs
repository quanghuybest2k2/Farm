using farm_api.Filter.Environment;
using farm_api.Models.Request;
using farm_api.Models;
using farm_api.Responses;
using farm_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using farm_api.Filter.Device;
using FluentValidation;

namespace farm_api.Controllers
{
    [ApiController]
    [Route("devices")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DeviceDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var result = await _deviceService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(PagedFarmResponse<DeviceDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] DeviceQuery deviceQuery, [FromQuery] PagingModel pagingModel)
        {
            var result = await _deviceService.GetAllAsync(deviceQuery, pagingModel);

            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(DeviceRequest deviceRequest)
        {
            if (deviceRequest == null)
            {
                return BadRequest();
            }
            try
            {
                await _deviceService.AddDeviceAsync(deviceRequest);
            }
            catch (ValidationException ex)
            {

                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, ex.Errors.Select(x => $"{x.PropertyName} {x.ErrorMessage}")));
            }
            return Ok();
        }
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(string id, [FromBody] DeviceRequest deviceRequest)
        {
            try
            {
                await _deviceService.UpdateDeviceAsync(id, deviceRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, null));
            }
            return NoContent();
        }
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _deviceService.DeleteDeviceAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, null));
            }
            return NoContent();
        }
    }
}
