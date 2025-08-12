using BookingSystem.DTOs.Master;
using BookingSystem.Interface;
using BookingSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/masters")]
    public class MasterController : ControllerBase
    {
        private readonly IMasterRepository _masterRepos;

        public MasterController(IMasterRepository repos)
        {
            _masterRepos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _masterRepos.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var master = await _masterRepos.GetByIdAsync(id);

            if(master == null)
                return NotFound();

            return Ok(master);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMasterDto masterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var master = await _masterRepos.CreateAsync(masterDto);

            if (master == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new {id = master.Id}, master);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] UpdateMasterDto masterDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var master = await _masterRepos.UpdateAsync(masterDto, id);

            if (master == null)
                return NotFound();

            return Ok(master);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var master = await _masterRepos.DeleteByIdAsync(id);

            if (master == null)
                return NotFound();

            return Ok(master);
        }

        [HttpPost("{masterId:int}/master-services/{serviceId:int}")]
        public async Task<IActionResult> LinkServicesToMaster(int masterId, int serviceId)
        {
            var master = await _masterRepos.LinkServiceToMasterAsync(masterId, serviceId);

            if (master == null)
                return BadRequest();

            return Ok(master);
        }

        [HttpDelete("{masterId:int}/master-services/{serviceId:int}")]
        public async Task<IActionResult> RemoveServicesFromMaster(int masterId, int serviceId)
        {
            var master = await _masterRepos.RemoveServiceToMasterAsync(masterId, serviceId);

            if (master == null)
                return BadRequest();

            return Ok(master);
        }
    }
}
