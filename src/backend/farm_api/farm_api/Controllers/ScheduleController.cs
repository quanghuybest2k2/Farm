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
    [ApiController]
    [Route("api/schedules")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

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
    }
}

