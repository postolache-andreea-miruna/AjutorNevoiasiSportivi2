using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonatorController : ControllerBase
    {
        private readonly IDonatoriManager manager;
        public DonatorController(IDonatoriManager donatoriManager)
        {
            this.manager = donatoriManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetDonatori()
        {
            var listaDonatori = manager.GetDonatori();
            return Ok(listaDonatori);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetDonatoriById([FromRoute]int id)
        {
            var donator = manager.GetDonatorInfo(id);
            return Ok(donator);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdministratorClubUser")]//
        public async Task<IActionResult> DeleteDonator([FromRoute] int id)
        {
            manager.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "AdministratorClubUser")]
        public async Task<IActionResult> Create([FromBody] GetDonatorModel getDonatorModel )
        {
            manager.Create(getDonatorModel);
            return Ok();
        }
        [HttpPut]
        [Authorize(Policy = "DonatorUserOrAdmin")]//
        public async Task<IActionResult> Update([FromBody] DonatorUpdateModel donatorUpdateModel)
        {
            manager.Update(donatorUpdateModel);
            return Ok();
        }
    }
}
