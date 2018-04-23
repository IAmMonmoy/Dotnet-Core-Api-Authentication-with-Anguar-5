using System;
using System.Threading.Tasks;
using DotnNetWebApiAuthentication.ViewModels;

namespace DotnNetWebApiAuthentication.Intefaces
{
    public interface IAccountService
    {
        Task<bool> addUser(RegistrationViewModel model);
    }
}