using Microsoft.AspNetCore.Mvc;
using farm_api.Models;
using farm_api.Services.Interface;
using farm_api.Responses;
using farm_api.Models.Request;
using FluentValidation;
using farm_api.Filter.Environment;
using System;

namespace farm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentService _environmentService;
        public EnvironmentController(IEnvironmentService environmentService) 
        {
            _environmentService = environmentService;
        }
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(EnvironmentDTO),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id==Guid.Empty)
            {
                return NotFound();
            }
            var result= await _environmentService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(PagedFarmResponse<EnvironmentDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery]EnvironmentQuery environmentQuery,[FromQuery] PagingModel pagingModel)
        {
            var result= await _environmentService.GetAllAsync(environmentQuery, pagingModel);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EnvirontmentRequest environtmentRequest)
        {
            if (environtmentRequest == null) {
                return BadRequest();
            }
            try
            {
                await _environmentService.AddEnvironmentAsync(environtmentRequest);
            }
            catch (ValidationException  ex)
            {

                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, ex.Errors.Select(x =>$"{x.PropertyName} {x.ErrorMessage}")));
            }
            return Ok();
        }
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] EnvirontmentRequest environtmentRequest)
        {
            try
            {
                await _environmentService.UpdateEnvironmentAsync(id, environtmentRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(new FarmErrrorResponse(ex.GetType().Name,null));
            }
            return NoContent();
        }
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _environmentService.DeleteEnvironmentAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new FarmErrrorResponse(ex.GetType().Name, null));
            }
            return NoContent();
        }
    }
}
