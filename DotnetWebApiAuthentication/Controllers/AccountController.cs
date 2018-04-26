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

            IdentityResult result = await _accountService.addUser(model);
            
             if(!result.Succeeded) return BadRequest(result);
             return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]LoginViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _accountService.getApplicationUser(model);
            
            IdentityResult result = await _accountService.authenticateUser(model,user);
            
            if(!result.Succeeded) return BadRequest(result);
            
            var jwtToken = await _accountService.makeToken(user);

            return new OkObjectResult(jwtToken);
        }
    }

}