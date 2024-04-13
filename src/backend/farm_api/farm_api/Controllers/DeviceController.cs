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
    [Route("api/devices")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IMQTTService _mQTTService;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceController"/> class.
        /// </summary>
        /// <param name="deviceService">The service that will handle device operations.</param>
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        /// <summary>
        /// Retrieves a device by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the device.</param>
        /// <returns>Returns the device DTO if found, otherwise returns Not Found.</returns>
        /// <response code="200">Returns the device DTO if the device is found.</response>
        /// <response code="404">Returned when no device is found for the provided ID.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DeviceDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id==Guid.Empty)
            {
                return NotFound();
            }
            var result = await _deviceService.GetByIdAsync(id);
            return Ok(result);
        }
        /// <summary>
        /// Retrieves all devices based on the specified query and paging parameters.
        /// </summary>
        /// <param name="deviceQuery">The device query parameters.</param>
        /// <param name="pagingModel">The paging parameters.</param>
        /// <returns>Paged list of device DTOs.</returns>
        /// <response code="200">Returns a paged list of devices.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedFarmResponse<DeviceDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] DeviceQuery deviceQuery, [FromQuery] PagingModel pagingModel)
        {
            var result = await _deviceService.GetAllAsync(deviceQuery, pagingModel);

            return Ok(result);
        }
        /// <summary>
        /// Adds a new device with the provided details.
        /// </summary>
        /// <param name="deviceRequest">The device details to add.</param>
        /// <returns>A status code indicating success or failure.</returns>
        /// <response code="400">Returned when the input model validation fails.</response>
        /// <response code="200">Returned when the device is successfully added.</response>
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
        /// <summary>
        /// Updates a device record.
        /// </summary>
        /// <param name="id">The unique identifier of the device.</param>
        /// <param name="deviceRequest">The device data to update.</param>
        /// <returns>Returns no content if the update was successful, otherwise bad request.</returns>
        /// <response code="204">Returns no content if the update was successful.</response>
        /// <response code="400">Returned if an error occurs during the update.</response>
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, [FromBody] DeviceRequest deviceRequest)
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
        /// <summary>
        /// Deletes a device by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the device to delete.</param>
        /// <returns>Returns no content if the deletion was successful, otherwise bad request.</returns>
        /// <response code="204">Returns no content if the device is successfully deleted.</response>
        /// <response code="400">Returned if an error occurs during deletion.</response>
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
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
