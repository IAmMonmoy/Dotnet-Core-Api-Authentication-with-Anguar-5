using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DotnNetWebApiAuthentication.ViewModels;

namespace DotnNetWebApiAuthentication.Intefaces
{
    public interface IAccountService
    {
        Task<IdentityResult> addUser(RegistrationViewModel model);
        Task<string> authenticateUser(LoginViewModel model);
    }
}