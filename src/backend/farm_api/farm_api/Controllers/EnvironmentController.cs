using Microsoft.AspNetCore.Mvc;
using farm_api.Models;
using farm_api.Services.Interface;
using farm_api.Responses;

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
            if (id ==null)
            {
                return NotFound();
            }
            var result= await _environmentService.GetByIdAsync(id);
            
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EnvironmentDTO environmentDTO)
        {
            if (environmentDTO == null) {
                return BadRequest();
            }
           
            return Ok();
        }
    }
}
