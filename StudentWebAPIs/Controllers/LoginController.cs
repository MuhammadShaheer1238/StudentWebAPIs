using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentWebAPIs.Model.DTOs;
using StudentWebAPIs.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentWebAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        public ITokenGeneratorRepository _tokenGenerator { get; }
        public IUserRepository _userRepository { get; }
        public LoginController(ITokenGeneratorRepository tokenGenerator, IUserRepository userRepository)
        {

            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }


        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginDTO)
        {
            var user = await _userRepository.AuthenticateUser(loginDTO.userName, loginDTO.Password);

            if(user != null)
            {
                var token = await _tokenGenerator.GenerateToken(user);

                return Ok(token);
            }

            return BadRequest("username or password is incorrect");
        }
    }
}

