using BookingSystem.DTOs.Service;
using BookingSystem.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepos;

        public ServiceController(IServiceRepository repos)
        {
            _serviceRepos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var services = await _serviceRepos.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var serviceDto = await _serviceRepos.GetByIdAsync(id);

            if (serviceDto == null)
                return NotFound();

            return Ok(serviceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceDto serviceDto)
        {
            var service = await _serviceRepos.CreateAsync(serviceDto);

            if (service == null)
                return BadRequest();

            return Ok(service);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var service = await _serviceRepos.DeleteAsync(id);
            
            if (service == null)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] UpdateServiceDto serviceDto, [FromRoute] int id)
        {
            var service = await _serviceRepos.UpdateAsync(serviceDto, id);

            if (service == null)
                return NotFound();

            return Ok(service);
        }
    }
}
