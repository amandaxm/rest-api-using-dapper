using Microsoft.AspNetCore.Mvc;
using repositorio_pattern.Domain;
using repository_pattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repository_pattern.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DevelopersController : Controller
    {
        protected readonly IDeveloperService developerService;

        public DevelopersController(IDeveloperService developerService)
        {
            this.developerService = developerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDevelopers() {

            var developers = await developerService.GetAllDevelopersAsync();
            return Ok(developers);
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeveloperById(int id)
        {

            var developers = await developerService.GetDeveloperByIdAsync(id);
            return Ok(developers);

        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetDeveloperByEmail(string email)
        {

            var developers = await developerService.GetDeveloperByEmailAsync(email);
            return Ok(developers);

        }
        [HttpPost]
        public IActionResult AddDeveloper([FromBody] Developer developer) {

            developerService.AddDeveloper(developer);
            return CreatedAtAction(nameof(GetDeveloperById), new { Id = developer.Id }, developer);
       
        }
        [HttpPut]
        public IActionResult UpdateDeveloper([FromBody] Developer developer) {

            developerService.UpdateDeveloper(developer);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDeveloper([FromBody] int id)
        {

            developerService.DeleteDeveloper(id);
            return Ok();

        }
    }
}
