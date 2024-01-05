using BillPaymentViewer.Core.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillPaymentViewer.Core.Entities;

namespace BillPaymentViewer.APIs.Controllers
{

    [Route("api/[controller]")]
    public class SystemUserController : Controller
    {
        readonly ISystemUserService _SystemUserService;
        readonly ILoginService _loginservice;
        private readonly ILoggerService _logger;
        public SystemUserController(ILoginService loginservice, ILoggerService logger, ISystemUserService SystemUserService)
        {
            _loginservice = loginservice;
            _logger = logger;
            _SystemUserService = SystemUserService;

        }
        //api/SystemUser/register
        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] Systemuser model)
        {

            // create user
            Systemuser createdUser =  _SystemUserService.Create(model);
            if(createdUser != null)
            {
                _logger.LogInfo("Method: Register(success), Return:" + createdUser.USERNAME);
                return Ok();
            }
            else
            {
                _logger.LogInfo("Method: Register(error)");
                return BadRequest("Method: Register(error)");
            }
                

        }
    }
}
