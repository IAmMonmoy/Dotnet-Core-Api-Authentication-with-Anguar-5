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
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
           
            var result = await _userManager.CreateAsync(user,model.Password);
            
            if(result.Succeeded) await _userManager.AddToRoleAsync(user, Constants.Strings.UserRolls.SimpleUser);
            else return result;

            return IdentityResult.Success;
        }

        public Task<string> authenticateUser(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}