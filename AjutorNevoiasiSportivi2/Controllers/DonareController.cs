using AjutorNevoiasiSportivi2.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonareController : ControllerBase
    {
        private readonly IDonariManager manager;

        public DonareController(IDonariManager donariManager)
        {
            this.manager = donariManager;
        }

        [HttpGet("byIdNevoias/{id}")]
        public async Task<IActionResult> GetDonareByNevoias([FromRoute] int id)
        {
            var donare = manager.GetDonareByNevoias(id);
            return Ok(donare);
        }
        [HttpGet("byIdDonator/{id}")]
        public async Task<IActionResult> GetDonareByDonator([FromRoute] int id)
        {
            var donare = manager.GetDonareByDonator(id);
            return Ok(donare);
        }

        [HttpGet("byIdDataDonatie/{id}")]
        public async Task<IActionResult> GetDonareByDataDonatie([FromRoute] DateTime id)
        {
            var donare = manager.GetDonareByDataDonatie(id);
            return Ok(donare);
        }
    }
}
