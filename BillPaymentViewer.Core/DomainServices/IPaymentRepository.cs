using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.Core.DomainServices
{
   public interface IPaymentRepository
    {
        Task <CustomerPayment> GetAllPaymentsByID(string id);
    }
}
