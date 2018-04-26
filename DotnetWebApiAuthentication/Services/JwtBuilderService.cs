using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using DotnNetWebApiAuthentication.Models;
using DotnNetWebApiAuthentication.Intefaces;
using DotnNetWebApiAuthentication.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotnNetWebApiAuthentication.Services
{
    public class JwtBuilderService : IJwtBuilder
    {
        private readonly JwtToken _jwtToken;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public JwtBuilderService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
                                IOptions<JwtToken> jwtToken)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtToken = jwtToken.Value;
        }
        public async Task<ClaimsIdentity> GenerateClaimsIdentity(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>(new[] {
                new Claim("Id", user.Id)
            });

            foreach(var roleName in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if(role != null)
                {
                    var roleClaim = new Claim("Rol", role.Name);
                    claims.Add(roleClaim);
                }
            }

            return new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"), claims);
        }

        public async Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtToken.GenerateJti()),
                new Claim(JwtRegisteredClaimNames.Iat, _jwtToken.IssuedAt.ToString()),
                identity.FindFirst("Id"),
                identity.FindFirst("Rol")
            };

             var jwt = new JwtSecurityToken(
                issuer: _jwtToken.Issuer,
                audience: _jwtToken.Audience,
                claims: claims,
                notBefore: _jwtToken.NotBefore,
                expires: _jwtToken.Expiration,
                signingCredentials: _jwtToken.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                id = identity.FindFirst("Id").Value,
                auth_token = encodedJwt,
                expires_in = (int)_jwtToken.ValidFor.TotalSeconds
            };

            return JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}