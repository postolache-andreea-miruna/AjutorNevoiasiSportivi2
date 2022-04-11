using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly ISporturiManager manager;

        public SportController(ISporturiManager sporturiManager)
        {
            this.manager = sporturiManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetSporturi()
        {
            var listaSporturi = manager.GetSporturi();
            return Ok(listaSporturi);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdministratorClubUser")]
        public async Task<IActionResult> DeleteSport([FromRoute] int id)
        {
            manager.Delete(id);

            return Ok();
        }
        [HttpPost]
        [Authorize(Policy = "AdministratorClubUser")]
        public async Task<IActionResult> Create([FromBody] CreareSportModel creareSportModel)
        {
            manager.Create(creareSportModel);
            return Ok();
        }
        [HttpPut]
        [Authorize(Policy = "AdministratorClubUser")]
        public async Task<IActionResult> Update([FromBody] SportModel sportModel)
        {
            manager.Update(sportModel);
            return Ok();
        }
    }
}
