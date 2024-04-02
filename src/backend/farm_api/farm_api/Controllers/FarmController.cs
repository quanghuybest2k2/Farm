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
    [Route("farms")]
    public class FarmController:ControllerBase
    {
        private readonly IFarmService _farmService;
        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }
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
        [HttpGet]
        [ProducesResponseType(typeof(PagedFarmResponse<FarmDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] FarmQuery farmQuery, [FromQuery] PagingModel pagingModel)
        {
            var result = await _farmService.GetAllAsync(farmQuery, pagingModel);

            return Ok(result);
        }
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
