
using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public class TokenGeneratorRepository : ITokenGeneratorRepository
    {
        private readonly IConfiguration _configuration;

        public TokenGeneratorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        

        public Task<string> GenerateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
