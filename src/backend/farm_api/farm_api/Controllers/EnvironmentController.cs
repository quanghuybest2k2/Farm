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
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentController"/> class.
        /// </summary>
        /// <param name="environmentService">The service that will handle environmental data operations.</param>
        public EnvironmentController(IEnvironmentService environmentService) 
        {
            _environmentService = environmentService;
        }
        /// <summary>
        /// Retrieves an environment record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the environment record.</param>
        /// <returns>Returns the environment DTO if found, otherwise returns Not Found.</returns>
        /// <response code="200">Returns the environment DTO if the record is found.</response>
        /// <response code="404">Returned when no environment record is found for the provided ID.</response>
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
        /// <summary>
        /// Retrieves all environment records based on the specified query and paging parameters.
        /// </summary>
        /// <param name="environmentQuery">The environment query parameters.</param>
        /// <param name="pagingModel">The paging parameters.</param>
        /// <returns>Paged list of environment DTOs.</returns>
        /// <response code="200">Returns a paged list of environment records.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedFarmResponse<EnvironmentDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery]EnvironmentQuery environmentQuery,[FromQuery] PagingModel pagingModel)
        {
            var result= await _environmentService.GetAllAsync(environmentQuery, pagingModel);

            return Ok(result);
        }
        /// <summary>
        /// Adds a new environment record with the provided details.
        /// </summary>
        /// <param name="environtmentRequest">The environment details to add.</param>
        /// <returns>A status code indicating success or failure.</returns>
        /// <response code="400">Returned when the input model validation fails.</response>
        /// <response code="200">Returned when the environment is successfully added.</response>
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
        /// <summary>
        /// Updates an environment record.
        /// </summary>
        /// <param name="id">The unique identifier of the environment record.</param>
        /// <param name="environtmentRequest">The environment data to update.</param>
        /// <returns>Returns no content if the update was successful, otherwise bad request.</returns>
        /// <response code="204">Returns no content if the update was successful.</response>
        /// <response code="400">Returned if an error occurs during the update.</response>
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
        /// <summary>
        /// Deletes an environment record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the environment record to delete.</param>
        /// <returns>Returns no content if the deletion was successful, otherwise bad request.</returns>
        /// <response code="204">Returns no content if the environment is successfully deleted.</response>
        /// <response code="400">Returned if an error occurs during deletion.</response>
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

        /// <summary>
        /// Retrieves the most recent environmental data for a specified sensor location.
        /// </summary>
        /// <param name="sensorLocation">The location of the sensor.</param>
        /// <returns>Returns the most recent environmental data if found, otherwise Not Found.</returns>
        [HttpGet("real-time")]
        public async Task<IActionResult> GetRecentEnvironment(string sensorLocation)
        {
            var environment = await _environmentService.GetEnvironmentBySensorLocatonRecentDays(sensorLocation);
            if (environment == null)
                return NotFound("No recent environment data found.");

            return Ok(environment);
        }
        /// <summary>
        /// Retrieves environment data for a specified sensor location on a specific day.
        /// </summary>
        /// <param name="sensorLocation">The location of the sensor.</param>
        /// <param name="date">The date to retrieve the data for.</param>
        /// <returns>Returns the environment data for the specified day if found, otherwise Not Found.</returns>
        [HttpGet("specifieddate")]
        public async Task<IActionResult> GetEnvironmentsByDay(string sensorLocation, DateTime date)
        {
            var environments = await _environmentService.GetEnvironmentsByLocationAndCreationDay(sensorLocation, date);
            if (environments == null)
                return NotFound("No environment data found for the given day.");

            return Ok(environments);
        }
        /// <summary>
        /// Retrieves daily average environmental values for a specified sensor location over a given period. Format input day is YYYY/MM/DD
        /// </summary>
        /// <param name="sensorLocation">The sensor location.</param>
        /// <param name="startDate">The start date of the period.</param>
        /// <param name="endDate">The end date of the period.</param>
        /// <returns>Returns average environmental data if found, otherwise Not Found.</returns>
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
