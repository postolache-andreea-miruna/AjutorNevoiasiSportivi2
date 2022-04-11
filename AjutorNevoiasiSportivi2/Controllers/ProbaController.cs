using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProbaController : ControllerBase
    {
        private readonly IProbaManager manager;
        public ProbaController(IProbaManager probaManager)
        {
            this.manager = probaManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetProbe()
        {
            var listaProbe = manager.GetProbe();
            return Ok(listaProbe);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdministratorClubUser")]
        public async Task<IActionResult> DeleteProbe([FromRoute] int id)
        {
            manager.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "AdministratorClubUser")]
        public async Task<IActionResult>Create([FromBody] CreareProbModel creareProbModel)
        {
            manager.Create(creareProbModel);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "AdministratorClubUser")]
        public async Task<IActionResult> Update([FromBody] ProbaUpdateModel probaUpdateModel)
        {
            manager.Update(probaUpdateModel);
            return Ok();
        }
    }
}
