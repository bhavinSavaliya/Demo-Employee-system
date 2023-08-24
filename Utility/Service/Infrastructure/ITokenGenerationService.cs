using Entity.DTOs;

namespace Utility.Service.Infrastructure
{
    public interface ITokenGenerationService
    {
        string GenerateToken(TokenDTO login);
    }
}
