using AjutorNevoiasiSportivi2.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscriereController : ControllerBase
    {
        private readonly IInscriereManager manager;

        public InscriereController(IInscriereManager inscriereManager )
        {
            this.manager = inscriereManager;
        }

        [HttpGet("byIdNevoias/{id}")]
        public async Task<IActionResult> GetInscriereByIdNevoias([FromRoute] int id)
        {
            var istoric = manager.GetInscriereByIdNevoias(id);
            return Ok(istoric);
        }

        [HttpGet("byIdAntrenor/{id}")]
        public async Task<IActionResult> GetInscriereByIdAntrenor([FromRoute] int id)
        {
            var istoric = manager.GetInscriereByIdAntrenor(id);
            return Ok(istoric);
        }

    }
}
