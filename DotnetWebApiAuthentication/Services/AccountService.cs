using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
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

        public AccountServices(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager) 
        {
            _applicationDbcontext = applicationDbContext;
            _userManager = userManager;
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

        public Task<string> authenticateUser(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}