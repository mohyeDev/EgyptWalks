using Microsoft.AspNetCore.Identity;

namespace EgyptWalks.Repositiory
{
    public interface ITokenRepository
    {

        public string CreateJwtToken(IdentityUser user,List<string> roles);
    }
}
