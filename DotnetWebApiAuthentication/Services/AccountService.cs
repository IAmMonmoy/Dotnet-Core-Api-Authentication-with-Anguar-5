using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DotnNetWebApiAuthentication.ViewModels;
using DotnNetWebApiAuthentication.Intefaces;
using DotnNetWebApiAuthentication.Data;
using DotnNetWebApiAuthentication.Models;

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

        public async Task<bool> addUser(RegistrationViewModel model)
        {
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            try{
                var result = await _userManager.CreateAsync(user,model.Password);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}