using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AysmmTest.WebAPI.Dtos;
using AysmmTest.WebAPI.Entities;
using AysmmTest.WebAPI.Services;

namespace AysmmTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly ICustomService<Developer> _developerService;
        private readonly IMapper _mapper;

        public DevelopersController(ICustomService<Developer> developerService, IMapper mapper)
        {
            _developerService = developerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeveloperDto>>> GetAllAsync()
        {
            var developers = await _developerService.GetAllAsync();
            var developersDto = _mapper.Map<List<DeveloperDto>>(developers);

            return Ok(developersDto);
        }

        [HttpGet("{id:int}", Name = "GetDeveloper")]
        public async Task<ActionResult<Developer>> GetAsync(int id)
        {
            var developer = await _developerService.GetAsync(id);
            var developerDto = _mapper.Map<DeveloperDto>(developer);

            return Ok(developerDto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAysnc([FromBody] DeveloperRequestDto developerRequestDto)
        {
            var developer = _mapper.Map<Developer>(developerRequestDto);
            var result = await _developerService.InsertAsync(developer);

            return new CreatedAtRouteResult("GetDeveloper", new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] DeveloperDto developerDto)
        {
            var developer = _mapper.Map<Developer>(developerDto);
            await _developerService.UpdateAsync(developer);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _developerService.DeleteAsync(id);

            return NoContent();
        }
    }
}
