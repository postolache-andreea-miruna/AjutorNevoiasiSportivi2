using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresaController : ControllerBase
    {
        private readonly IAdreseManager manager;
        public AdresaController(IAdreseManager adreseManager)
        {
            this.manager = adreseManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdrese()
        {
            var listaAdrese = manager.GetAdrese();
            return Ok(listaAdrese);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetAdreseById(int id)
        {
            var adresa = manager.GetAdreseInfo(id);
            return Ok(adresa);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "NevoiasUser")]
        public async Task<IActionResult> DeleteAdresa([FromRoute]int id)
        {
            manager.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "NevoiasUser")]
        public async Task<IActionResult>Create([FromBody]CreareAdresaModel creareAdresaModel)
        {
            manager.Create(creareAdresaModel);
            return Ok();
        }
        [HttpPut]
        [Authorize(Policy = "NevoiasUser")]
        public async Task <IActionResult>Update([FromBody]AdresaUpdateModel adresaUpdateModel)
        {
            manager.Update(adresaUpdateModel);
            return Ok();
        }
    }
}
