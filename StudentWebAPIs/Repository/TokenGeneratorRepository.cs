
using Microsoft.IdentityModel.Tokens;
using StudentWebAPIs.Model.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentWebAPIs.Repository
{
    public class TokenGeneratorRepository : ITokenGeneratorRepository
    {
        private readonly IConfiguration _configuration;

        public TokenGeneratorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        

        public async Task<string> GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // create claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.firstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.lastName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            // iterating through roles and adding them 
            user.Roles.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));

            });

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            var tokenGenerated = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenGenerated.ToString();
        }
    }
}
