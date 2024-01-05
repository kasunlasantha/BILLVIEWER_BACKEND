using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentViewer.Core.DomainServices
{
   public interface ICustomerRepository
    {
        string GetCustomerByID(string id);
        string GetAccountNoByID(string id);
    }
}
