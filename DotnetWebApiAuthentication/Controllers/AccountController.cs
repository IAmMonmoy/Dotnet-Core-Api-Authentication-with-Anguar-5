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
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = await _accountService.addUser(model);
            
             if(!result) return BadRequest();
             return Ok();
        }

        [HttpPost("login")]
        public Task<IActionResult> Post(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
    }

}