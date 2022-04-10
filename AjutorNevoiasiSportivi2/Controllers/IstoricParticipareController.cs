using AjutorNevoiasiSportivi2.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IstoricParticipareController : ControllerBase
    {
        private readonly IIstoricParticipariManager manager;
        public IstoricParticipareController(IIstoricParticipariManager istoricParticipariManager)
        {
            this.manager = istoricParticipariManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetIstoriceSpCompProba()
        {
            var istorice = manager.GetIstoriceSpCompProba();
            return Ok(istorice);
        }

        [HttpGet("istoric/{id}")]
        public async Task<IActionResult> GetIstoricByIdSp([FromRoute] int id)
        {
            var istoric = manager.GetIstoricByIdSp(id);
            return Ok(istoric);
        }
        
        [HttpGet("bestOf/{id}")]
        public async Task<IActionResult> GetBestOfcByIdSp([FromRoute] int id)
        {
            var istoric = manager.GetBestOfcByIdSp(id);
            return Ok(istoric);
        }

    }
}
