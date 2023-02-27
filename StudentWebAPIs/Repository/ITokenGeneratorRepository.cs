using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public interface ITokenGeneratorRepository
    {
        Task<string> GenerateToken(User user);
    }
}
