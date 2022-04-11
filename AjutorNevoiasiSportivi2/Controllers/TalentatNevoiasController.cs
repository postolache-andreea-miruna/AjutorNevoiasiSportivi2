using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentatNevoiasController : ControllerBase
    {
        private readonly ITalentatNevoiasiManager manager;
        public TalentatNevoiasController(ITalentatNevoiasiManager competitiiManager)
        {
            this.manager = competitiiManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetTalentatNevoiasi()
        {
            var listaNevoiasi = manager.GetTalentatNevoiasi();
            return Ok(listaNevoiasi);
        }
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetTalentatNevoiasiById([FromRoute] int id)
        {
            var nevoiasi = manager.GetNevoiasiInfo(id);
            return Ok(nevoiasi);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "NevoiasUser")]
        public async Task<IActionResult> DeleteNevoias([FromRoute] int id)
        {
            manager.Delete(id);

            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "NevoiasUser")]
        public async Task<IActionResult> Create([FromBody] CreareNevoiasModel creareNevoiasModel)
        {
            manager.Create(creareNevoiasModel);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "NevoiasUser")]
        public async Task<IActionResult> Update([FromBody] NevoiasUpdateModel nevoiasUpdateModel)
        {
            manager.Update(nevoiasUpdateModel);
            return Ok();
        }
    }
}
