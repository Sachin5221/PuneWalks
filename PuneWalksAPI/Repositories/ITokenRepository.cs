using Microsoft.AspNetCore.Identity;

namespace PuneWalksAPI.Repositories
{
    public interface ITokenRepository
    { 
       string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
