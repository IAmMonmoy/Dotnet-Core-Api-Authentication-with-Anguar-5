using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DotnNetWebApiAuthentication.ViewModels;
using DotnNetWebApiAuthentication.Intefaces;

namespace DotnNetWebApiAuthentication.Services
{
    public class AccountServices : IAccountService
    {
        public Task<bool> addUser(RegistrationViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}