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
    public class PaymentController : Controller
    {
        private readonly IPaymentService _PaymentService;
        private readonly ILoggerService _logger;

        public PaymentController(IPaymentService PaymentService, ILoggerService loggerService)
        {
            _PaymentService = PaymentService;
            _logger = loggerService;
        }

        //api/Payment/getPayment]
        [Route("getPayment")]
        [HttpPost]
        public async Task<CustomerPayment> getPayment([FromBody] string id)
        {
            CustomerPayment payments = await _PaymentService.GetAllPaymentsByID(id);
            if(payments != null)
            {
                _logger.LogInfo("Method: getPayment(success), Return:" + id);
            }
            else
            {
                _logger.LogInfo("Method: getPayment(error)");
            }
            return payments;
        }
    }
}
