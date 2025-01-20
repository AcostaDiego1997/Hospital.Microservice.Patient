using Microservice.Patients.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Patients.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuth_Service _authService;

        public AuthController(IAuth_Service authService)
        {
            _authService = authService;
        }


        
        [HttpPost("/auth")]
        public async Task<IActionResult> Auth(string email, string password)
        {
            try
            {
                string token = _authService.CreateToken(email, password);
                return Ok(new {
                    IsSuccess= true,
                    Message = token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }
        
    }
}
