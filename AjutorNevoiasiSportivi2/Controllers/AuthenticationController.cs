using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjutorNevoiasiSportivi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationManager authenticationManager;
        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }
        [HttpPost("sign-up")]
        public async Task<IActionResult> Signup([FromBody] SignupUserModel model)
        {
            try
            {
                await authenticationManager.Signup(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong on signup");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model)
        {
            try
            {
                var tokens = await authenticationManager.Login(model);
                if (tokens != null)
                    return Ok(tokens);
                else
                {
                    return BadRequest("Something went wrong on login");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpPost("role")]
        public async Task<IActionResult> Rol([FromBody] LoginUserModel model)
        {
            var rol = await authenticationManager.Rol(model);
            return Ok(rol);
        }
    }
}
