using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DotnNetWebApiAuthentication.Data;
using DotnNetWebApiAuthentication.Models;

namespace DotnNetWebApiAuthentication.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _appDbcontext;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _appDbcontext = context;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public Task<IActionResult> Post()
        {
            throw new NotImplementedException();
        }

        [HttpPost("login")]
        public Task<IActionResult> Post(int x)
        {
            throw new NotImplementedException();
        }
    }

}