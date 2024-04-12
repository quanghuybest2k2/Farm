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
    [Route("api/environments")]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentService _environmentService;
        public EnvironmentController(IEnvironmentService environmentService) 
        {
            _environmentService = environmentService;
        }
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(EnvironmentDTO),StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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


        [HttpGet("real-time")]
        public async Task<IActionResult> GetRecentEnvironment(string sensorLocation)
        {
            var environment = await _environmentService.GetEnvironmentBySensorLocatonRecentDays(sensorLocation);
            if (environment == null)
                return NotFound("No recent environment data found.");

            return Ok(environment);
        }
        [HttpGet("specifieddate")]
        public async Task<IActionResult> GetEnvironmentsByDay(string sensorLocation, DateTime date)
        {
            var environments = await _environmentService.GetEnvironmentsByLocationAndCreationDay(sensorLocation, date);
            if (environments == null)
                return NotFound("No environment data found for the given day.");

            return Ok(environments);
        }
        [HttpGet("daily-averages")]
        public async Task<IActionResult> GetDailyAverages(string sensorLocation, DateTime startDate, DateTime endDate)
        {
            var averages = await _environmentService.GetAverageEnvironmentValues(sensorLocation, startDate, endDate);
            if (averages == null)
                return NotFound("No average data found for the given period.");

            return Ok(averages);
        }
    }
}
