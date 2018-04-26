using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DotnNetWebApiAuthentication.ViewModels;
using DotnNetWebApiAuthentication.Models;

namespace DotnNetWebApiAuthentication.Intefaces
{
    public interface IAccountService
    {
        Task<ApplicationUser> getApplicationUser(LoginViewModel model);
        Task<IdentityResult> addUser(RegistrationViewModel model);
        Task<IdentityResult> authenticateUser(LoginViewModel model);
        Task<string> makeToken(LoginViewModel model, ApplicationUser user);
    }
}