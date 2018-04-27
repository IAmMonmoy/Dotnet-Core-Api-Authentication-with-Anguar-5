using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DotnNetWebApiAuthentication.ViewModels;
using DotnNetWebApiAuthentication.Intefaces;
using DotnNetWebApiAuthentication.Data;
using DotnNetWebApiAuthentication.Models;
using DotnNetWebApiAuthentication.Helpers;

namespace DotnNetWebApiAuthentication.Services
{
    public class AccountServices : IAccountService
    {
        private readonly ApplicationDbContext _applicationDbcontext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtBuilder _jwtBuilder;

        public AccountServices(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager,
                                IJwtBuilder jwtBuilder) 
        {
            _applicationDbcontext = applicationDbContext;
            _userManager = userManager;
            _jwtBuilder = jwtBuilder;
        }

        public async Task<ApplicationUser> getApplicationUser(LoginViewModel model)
        {
            return await _userManager.FindByEmailAsync(model.Email);
        }

        public async Task<IdentityResult> addUser(RegistrationViewModel model)
        {
            try{
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };

                //ef core does not checking for duplicate email for some reason
                //this is failsafe
                var testDuplicateEmail = await _userManager.FindByEmailAsync(model.Email);
                if(testDuplicateEmail != null) 
                {
                    IdentityError error = new IdentityError { Code = "DuplicateEmail", Description = $"Email {model.Email} is already  taken" };
                    return IdentityResult.Failed(error);
                }
                
                var result = await _userManager.CreateAsync(user,model.Password);
                
                //add SimpleUser role if role exists .. otherwise user is already added returns 200 status
                if(result.Succeeded) await _userManager.AddToRoleAsync(user, Constants.Strings.UserRolls.SimpleUser);
                else return result;

                return IdentityResult.Success;
            }
            
            catch(Exception ex)
            {
                IdentityError error = new IdentityError { Code = ex.Source, Description = ex.Message };
                return IdentityResult.Failed(error);
            }
        }

        public async Task<IdentityResult> authenticateUser(LoginViewModel model, ApplicationUser findUser)
        {
            try {
                if(findUser != null)
                {
                    if(await _userManager.CheckPasswordAsync(findUser,model.Password))
                        return IdentityResult.Success;
                    else 
                    {
                        IdentityError error = new IdentityError { Code = "Wrong Password", Description = "Password Do not match" };
                        return IdentityResult.Failed(error);
                    }
                }
                else 
                {
                    IdentityError error = new IdentityError { Code = "Wrong Email", Description = "The email is not is the registered list" };
                    return IdentityResult.Failed(error);
                }
            }
            catch(Exception ex)
            {
                IdentityError error = new IdentityError { Code = ex.Source, Description = ex.Message };
                return IdentityResult.Failed(error);
            }
        }

        public async Task<string> makeToken(ApplicationUser user)
        {
            var claimsIdentity = await _jwtBuilder.GenerateClaimsIdentity(user);
            
            var token = await _jwtBuilder.GenerateEncodedToken(user.UserName,claimsIdentity);

            return token;
        }
    }
}