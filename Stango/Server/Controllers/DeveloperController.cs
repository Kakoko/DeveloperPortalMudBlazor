using Stango.Server.Data.Repositories;
using Stango.Shared.Models;
using Stango.Shared.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stango.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperController(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository ?? throw new ArgumentNullException(nameof(developerRepository));
        }
        // GET: api/<DeveloperController>
        [HttpGet]
        public async Task<ActionResult<List<Developer>>> Get()
        {
            return Ok(await _developerRepository.GetDevelopers());
        }

        // GET api/<DeveloperController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> Get(Guid id)
        {
            var developer = await _developerRepository.GetDeveloper(id);
            if(developer != null)
            {
                return Ok(developer);
            }

            return NotFound();
        }

        // POST api/<DeveloperController>
        [HttpPost]
        public async Task<ActionResult> Post(CreateDeveloperDto developerDto)
        {
            var developerToCreate = new Developer()
            {
                Company = developerDto.Company,
                Email = developerDto.Email,
                UserName = developerDto.UserName
            };

            await _developerRepository.AddDeveloper(developerToCreate);
            return Ok("Developer Added");
        }

        // PUT api/<DeveloperController>/5
        [HttpPut]
        public async Task<ActionResult> Put(Developer developer)
        {
            await _developerRepository.UpdateDeveloper(developer);
            return Ok("Developer Updated");

        }

        // DELETE api/<DeveloperController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _developerRepository.DeleteDeveloper(id);
            return Ok("Developer Deleted");
        }
    }
}
