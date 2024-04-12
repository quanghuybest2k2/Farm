using farm_api.Filter.Device;
using farm_api.Models.Request;
using farm_api.Models;
using farm_api.Responses;
using farm_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using farm_api.Filter.Camera;
using FluentValidation;
using farm_api.Services.Implementation;

namespace farm_api.Controllers
{
    [ApiController]
    [Route("api/camera")]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService _cameraService;
        
        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(CameraDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var result = await _cameraService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(PagedFarmResponse<CameraDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] CameraQuery cameraQuery, [FromQuery] PagingModel pagingModel)
        {
            var result = await _cameraService.GetAllAsync(cameraQuery, pagingModel);

            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(CameraRequest cameraRequest)
        {
            if (cameraRequest == null)
            {
                return BadRequest();
            }
            try
            {
                await _cameraService.AddCameraAsync(cameraRequest);
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
        public async Task<IActionResult> Update(Guid id, [FromBody] CameraRequest cameraRequest)
        {
            try
            {
                await _cameraService.UpdateCameraAsync(id, cameraRequest);
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
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _cameraService.DeleteCameraAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, null));
            }
            return NoContent();
        }     
    }
}
