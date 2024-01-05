using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.Core.ApplicationServices
{
    public interface IPaymentService
    {
        Task<CustomerPayment> GetAllPaymentsByID(string id);
    }
}
