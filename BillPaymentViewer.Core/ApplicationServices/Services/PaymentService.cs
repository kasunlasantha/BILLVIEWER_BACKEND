using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.Core.ApplicationServices.Services
{
    public class PaymentService : IPaymentService
    {
        readonly IPaymentRepository _payRepo;
 
        public PaymentService(IPaymentRepository payRepo)
        {
            _payRepo = payRepo;
            

        }


        public async Task<CustomerPayment> GetAllPaymentsByID(string id)
        {
            return await _payRepo.GetAllPaymentsByID( id);
        }
    }
}
