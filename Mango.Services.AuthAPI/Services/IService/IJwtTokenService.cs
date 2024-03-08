using Mango.Services.AuthAPI.Models;

namespace Mango.Services.AuthAPI.Services.IService
{
    public interface IJwtTokenService
    {
        string GenerateToken(ApplicationUser applicationUser,IEnumerable<string> roles);
    }
}
