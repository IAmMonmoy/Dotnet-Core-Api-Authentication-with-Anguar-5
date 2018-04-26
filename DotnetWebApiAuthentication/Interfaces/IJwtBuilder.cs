using System.Security.Claims;
using System.Threading.Tasks;

namespace DotnNetWebApiAuthentication.Intefaces
{
    public interface IJwtBuilder
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}
