using System;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace DotnNetWebApiAuthentication.Helpers
{
    public class JwtToken
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        //take the timespan from ValidFor and add it to issued at to find expiration
        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public DateTime IssuedAt => DateTime.UtcNow;

        public DateTime NotBefore => DateTime.UtcNow;

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(120);

        public Task<string> GenerateJti() { return Task.FromResult(Guid.NewGuid().ToString()); }

        public SigningCredentials SigningCredentials { get; set; }
    }
}