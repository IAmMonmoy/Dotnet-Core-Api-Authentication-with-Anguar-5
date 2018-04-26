using System.Security.Claims;
using System.Threading.Tasks;
using DotnNetWebApiAuthentication.Models;

namespace DotnNetWebApiAuthentication.Intefaces
{
    public interface IJwtBuilder
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        Task<ClaimsIdentity> GenerateClaimsIdentity(ApplicationUser user);
    }
}
