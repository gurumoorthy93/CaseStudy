using CaseStudy.Core.Dtos;
using CaseStudy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController: ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var result = usersService.ValidateLogin(loginDto.Email, loginDto.Password);

            if(!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }

            return BadRequest("Invalid UserName / Password");
        }
    }
}
