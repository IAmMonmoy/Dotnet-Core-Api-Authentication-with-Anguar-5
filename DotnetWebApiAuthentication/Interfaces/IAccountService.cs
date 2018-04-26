using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DotnNetWebApiAuthentication.ViewModels;

namespace DotnNetWebApiAuthentication.Intefaces
{
    public interface IAccountService
    {
        Task<IdentityResult> addUser(RegistrationViewModel model);
        Task<IdentityResult> authenticateUser(LoginViewModel model);
        Task<string> makeToken(LoginViewModel model);
    }
}