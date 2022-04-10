using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly ICluburiManager manager;

        public ClubController(ICluburiManager cluburiManager)
        {
            this.manager = cluburiManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetCluburi()
        {
            var listaCluburi = manager.GetCluburi();
            return Ok(listaCluburi);
        }
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetClubById([FromRoute] int id)
        {
            var club = manager.GetClubuiInfo(id);
            return Ok(club);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub([FromRoute]int id)
        {
            manager.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GetCluburiModel getCluburiModel)
        {
            manager.Create(getCluburiModel);
            return Ok();
        }

        [HttpPut]
        public async Task < IActionResult> Update([FromBody] ClubUpdateModel clubUpdateModel)
        {
            manager.Update(clubUpdateModel);
            return Ok();

        }

    }
}
