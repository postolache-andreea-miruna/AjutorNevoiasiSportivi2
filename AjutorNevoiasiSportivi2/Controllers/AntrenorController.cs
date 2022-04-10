using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntrenorController : ControllerBase
    {
        private readonly IAntrenoriManager manager;

        public AntrenorController(IAntrenoriManager antrenoriManager)
        {
            this.manager = antrenoriManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAntrenori()
        {
            var listaAntrenori = manager.GetAntrenori();
            return Ok(listaAntrenori);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetAntrenorById([FromRoute] int id)
        {
            var antrenor = manager.GetAntrenorById(id);
            return Ok(antrenor);
        }

        [HttpGet("IdClub/{id}")]
        public async Task<IActionResult> GetAntrenorByIdClub([FromRoute] int id)
        {
            var antrenor = manager.GetAntrenorByIdClub(id);
            return Ok(antrenor);
        }

        [HttpGet("IdSport/{id}")]
        public async Task<IActionResult> GetAntrenorByIdSport([FromRoute] int id)
        {
            var antrenor = manager.GetAntrenorByIdSport(id);
            return Ok(antrenor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            manager.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreareAntrenorModel creareAntrenorModel)
        {
            manager.Create(creareAntrenorModel);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AntrenorUpdateModel antrenorUpdateModel)
        {
            manager.Update(antrenorUpdateModel);
            return Ok();
        }

    }
}
