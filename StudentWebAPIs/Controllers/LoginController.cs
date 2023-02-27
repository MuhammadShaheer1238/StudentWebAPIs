using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentWebAPIs.Model.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentWebAPIs.Controllers
{
    [ApiController]
    [Route("appi/[controller]")]
    public class LoginController : Controller
    {
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //[HttpPost, Route("login")]
        //public IActionResult Login(LoginRequestModel loginDTO)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(loginDTO.userName) ||
        //        string.IsNullOrEmpty(loginDTO.Password))
        //            return BadRequest("Username and/or Password not specified");
        //        if (loginDTO.userName.Equals("joydip") &&
        //        loginDTO.Password.Equals("joydip123"))
        //        {
        //            var secretKey = new SymmetricSecurityKey
        //            (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
        //            var signinCredentials = new SigningCredentials
        //           (secretKey, SecurityAlgorithms.HmacSha256);
        //            var jwtSecurityToken = new JwtSecurityToken(
        //                Configuration["Jwt:Issuer"],
        //                Configuration["Jwt:Audience"],
        //                claims: new List<Claim>(),
        //                expires: DateTime.Now.AddMinutes(10),
        //                signingCredentials: signinCredentials
        //            );
        //            Ok(new JwtSecurityTokenHandler().
        //            WriteToken(jwtSecurityToken));
        //        }
        //    }
        //    catch
        //    {
        //        return BadRequest
        //        ("An error occurred in generating the token");
        //    }
        //    return Unauthorized();
        //}
    }
}

