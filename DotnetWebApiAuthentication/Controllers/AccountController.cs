using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DotnNetWebApiAuthentication.Data;
using DotnNetWebApiAuthentication.Models;
using DotnNetWebApiAuthentication.ViewModels;
using DotnNetWebApiAuthentication.Intefaces;

namespace DotnNetWebApiAuthentication.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public Task<IActionResult> Post(RegistrationViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost("login")]
        public Task<IActionResult> Post(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
    }

}