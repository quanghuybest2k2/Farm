using Core.DTO;
using farm_api.Filter.Farm;
using farm_api.Filter.Schedule;
using farm_api.Models;
using farm_api.Models.Request;
using farm_api.Responses;
using farm_api.Services.Implementation;
using farm_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace farm_api.Controllers
{
    /// <summary>
    /// Controller to manage schedules.
    /// </summary>
    [ApiController]
    [Route("api/schedules")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        /// <summary>
        /// Initializes a new instance of <see cref="ScheduleController"/>.
        /// </summary>
        /// <param name="scheduleService">Service to manage schedules.</param>
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        /// <summary>
        /// Creates a new schedule.
        /// </summary>
        /// <param name="scheduleRequest">Schedule data.</param>
        /// <returns>Response for the request to create a schedule.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] ScheduleRequest scheduleRequest)
        {
            try
            {
                await _scheduleService.CreateScheduleAsync(scheduleRequest);
                return Ok("Schedule created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating schedule: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing schedule.
        /// </summary>
        /// <param name="id">The ID of the schedule to update.</param>
        /// <param name="scheduleRequest">Updated schedule data.</param>
        /// <returns>Response for the request to update a schedule.</returns>
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateSchedule(Guid id, [FromBody] ScheduleRequest scheduleRequest)
        {
            try
            {
                await _scheduleService.UpdateScheduleAsync(id, scheduleRequest);
                return Ok("Schedule updated successfully.");
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating schedule: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a schedule.
        /// </summary>
        /// <param name="id">The ID of the schedule to delete.</param>
        /// <returns>Response for the request to delete a schedule.</returns>
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteSchedule(Guid id)
        {
            try
            {
                await _scheduleService.DeleteScheduleAsync(id);
                return Ok("Schedule deleted successfully.");
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting schedule: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a schedule by ID.
        /// </summary>
        /// <param name="id">The ID of the schedule to retrieve.</param>
        /// <returns>Response for the request to get a schedule by ID.</returns>
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetScheduleById(Guid id)
        {
            try
            {
                var schedule = await _scheduleService.GetScheduleByIdAsync(id);
                return Ok(schedule);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving schedule: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all schedules with optional pagination.
        /// </summary>
        /// <param name="scheduleQuery">Query filters for schedules.</param>
        /// <param name="pagingModel">Paging parameters.</param>
        /// <returns>Response containing a paginated list of schedules.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedFarmResponse<ScheduleDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] ScheduleQuery scheduleQuery, [FromQuery] PagingModel pagingModel)
        {
            try
            {
                var result = await _scheduleService.GetAllAsync(scheduleQuery, pagingModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving all schedules: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves scheduled status 
        /// </summary>
        /// <returns>return a result contains scheduled status</returns>
        [HttpGet("scheduledstatus")]
        [ProducesResponseType(typeof(StastusSchedulesDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStatusSchedules()
        {
            try
            {
                var result = await _scheduleService.GetStatusSchedulesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving all schedules: {ex.Message}");
            }
        }
    }
}
