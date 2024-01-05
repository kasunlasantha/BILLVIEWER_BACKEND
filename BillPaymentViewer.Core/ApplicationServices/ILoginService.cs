using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.Core.ApplicationServices
{
   public interface ILoginService
    {
        Task <User> Login(User user);
        string Logoff(User user);
    }
}
