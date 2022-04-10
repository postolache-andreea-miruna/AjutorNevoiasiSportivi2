using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitieController : ControllerBase
    {
        private readonly ICompetitiiManager manager;
        public CompetitieController(ICompetitiiManager competitiiManager)
        {
            this.manager = competitiiManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompetitii()
        {
            var ListaCompetitii = manager.GetCompetitii();
            return Ok(ListaCompetitii);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetCompById([FromRoute] int id)
        {
            var competitie = manager.GetCompetitiiInfo(id);
            return Ok(competitie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitie([FromRoute] int id)
        {
            manager.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreareCompModel creareCompModel)
        {
            manager.Create(creareCompModel);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CompetitieUpdateModel competitieUpdateModel)
        {
            manager.Update(competitieUpdateModel);
            return Ok();
        }
    }
}
