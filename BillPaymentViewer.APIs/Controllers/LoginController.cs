using BillPaymentViewer.Core.ApplicationServices;
using BillPaymentViewer.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.APIs.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        readonly ILoginService _loginservice;
        public IConfiguration _configuration;
        private readonly ILoggerService _logger;
        public LoginController(ILoginService loginservice, IConfiguration config, ILoggerService logger)
        {
            _configuration = config;
            _loginservice = loginservice;
            _logger = logger;

        }

        [HttpPost]
       
        public async Task<IActionResult> Login([FromBody] User model)
        {
            //_logger.LogInfo("Came into Login method");
            User UserDT =  await _loginservice.Login(model);
            if (UserDT != null)
            {
                _logger.LogInfo("User: " + UserDT.username + ",Logged In Success");
                //return Ok(new { token });
                return Ok(UserDT);

            }
            else
            {
                //_logger.LogInfo("LogedIn error:Invalid credentials");
                return BadRequest("Invalid credentials");
            }
           
        }

        [Route("logout")]
        [HttpPost]
        public IActionResult Logout([FromBody] string username)
        {
            _logger.LogInfo("User:" + username + " Logged out");
            return Ok(true);
        }
    }
}
