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
        /// <summary>
        /// Retrieves a camera by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the camera.</param>
        /// <returns>Returns the camera DTO if found, otherwise returns Not Found.</returns>
        /// <response code="200">Returns the camera DTO if the camera is found.</response>
        /// <response code="404">Returned when no camera is found for the provided ID.</response>
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
        /// <summary>
        /// Retrieves all cameras based on the specified query and paging parameters.
        /// </summary>
        /// <param name="cameraQuery">The camera query parameters.</param>
        /// <param name="pagingModel">The paging parameters.</param>
        /// <returns>Paged list of camera DTOs.</returns>
        /// <response code="200">Returns a paged list of cameras.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedFarmResponse<CameraDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] CameraQuery cameraQuery, [FromQuery] PagingModel pagingModel)
        {
            var result = await _cameraService.GetAllAsync(cameraQuery, pagingModel);

            return Ok(result);
        }
        /// <summary>
        /// Adds a new camera with the provided details.
        /// </summary>
        /// <param name="cameraRequest">The camera details to add.</param>
        /// <returns>A status code indicating success or failure.</returns>
        /// <response code="400">Returned when the input model validation fails.</response>
        /// <response code="200">Returned when the camera is successfully added.</response>
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
        /// <summary>
        /// Updates a camera record.
        /// </summary>
        /// <param name="id">The unique identifier of the camera.</param>
        /// <param name="cameraRequest">The camera data to update.</param>
        /// <returns>Returns no content if the update was successful, otherwise bad request.</returns>
        /// <response code="204">Returns no content if the update was successful.</response>
        /// <response code="400">Returned if an error occurs during the update.</response>
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
        /// <summary>
        /// Deletes a camera by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the camera to delete.</param>
        /// <returns>Returns no content if the deletion was successful, otherwise bad request.</returns>
        /// <response code="204">Returns no content if the camera is successfully deleted.</response>
        /// <response code="400">Returned if an error occurs during deletion.</response>
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
