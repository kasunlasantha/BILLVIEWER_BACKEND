using BillPaymentViewer.Core.ApplicationServices;
using BillPaymentViewer.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillPaymentViewer.APIs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _custService;
        private readonly ILoggerService _logger;

        public CustomerController(ICustomerService custService, ILoggerService logger)
        {
            _custService = custService;
            _logger = logger;
        }

        [Route("getCustomer")]
        [HttpPost]
        public IActionResult getCustomer([FromBody] string id)
        {
            string custname = _custService.GetCutomerByID(id);
            if(custname != null)
            {
                _logger.LogInfo("Method: getCustomer(success), Return:" + custname);
                return Ok(new { custname });
            }
            else
            {
                _logger.LogInfo("Method: getCustomer(error)");
                return BadRequest("Method: getCustomer(error)");
            }
            
        }
    }
}
