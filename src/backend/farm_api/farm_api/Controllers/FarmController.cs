using farm_api.Filter.Environment;
using farm_api.Models.Request;
using farm_api.Models;
using farm_api.Responses;
using farm_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using farm_api.Filter.Farm;
using FluentValidation;

namespace farm_api.Controllers
{
    [ApiController]
    [Route("api/farms")]
    public class FarmController:ControllerBase
    {
        private readonly IFarmService _farmService;
        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }
        /// <summary>
        /// Retrieves a farm by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the farm.</param>
        /// <returns>Returns the farm DTO if found, otherwise returns Not Found.</returns>
        /// <response code="200">Returns the farm DTO if the farm is found.</response>
        /// <response code="404">Returned when no farm is found for the provided ID.</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(FarmDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var result = await _farmService.GetByIdAsync(id);
            return Ok(result);
        }
        /// <summary>
        /// Retrieves all farms based on the specified query and paging parameters.
        /// </summary>
        /// <param name="farmQuery">The farm query parameters.</param>
        /// <param name="pagingModel">The paging parameters.</param>
        /// <returns>Paged list of farms.</returns>
        /// <response code="200">Returns a paged list of farms.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedFarmResponse<FarmDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] FarmQuery farmQuery, [FromQuery] PagingModel pagingModel)
        {
            var result = await _farmService.GetAllAsync(farmQuery, pagingModel);

            return Ok(result);
        }
        /// <summary>
        /// Adds a new farm with the provided details.
        /// </summary>
        /// <param name="farmRequest">The farm details to add.</param>
        /// <returns>A status code indicating success or failure.</returns>
        /// <response code="400">Returned when the input model validation fails.</response>
        /// <response code="200">Returned when the farm is successfully added.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(FarmRequest farmRequest)
        {
            if (farmRequest == null)
            {
                return BadRequest();
            }
            try
            {
                await _farmService.AddFarmAsync(farmRequest);
            }
            catch (ValidationException ex)
            {

                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, ex.Errors.Select(x => $"{x.PropertyName} {x.ErrorMessage}")));
            }
            return Ok();
        }
        /// <summary>
        /// Updates a farm record.
        /// </summary>
        /// <param name="id">The unique identifier of the farm.</param>
        /// <param name="farmRequest">The farm data to update.</param>
        /// <remarks>
        /// This method allows updating the details of an existing farm in the database.
        /// </remarks>
        /// <response code="204">Returns no content if the update was successful.</response>
        /// <response code="400">Returns bad request if the update fails.</response>
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, [FromBody] FarmRequest farmRequest)
        {
            try
            {
                await _farmService.UpdateFarmAsync(id, farmRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, null));
            }
            return NoContent();
        }
        /// <summary>
        /// Deletes a farm by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the farm to delete.</param>
        /// <returns>Returns no content if the deletion was successful, otherwise bad request.</returns>
        /// <response code="204">Returns no content if the farm is successfully deleted.</response>
        /// <response code="400">Returned if an error occurs during deletion.</response>
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _farmService.DeleteFarmAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, null));
            }
            return NoContent();
        }
    }
}
