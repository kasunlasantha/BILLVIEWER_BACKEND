using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentViewer.Core.ApplicationServices
{
   public interface ICustomerService
    {
        string GetCutomerByID(string id);
    }
}
