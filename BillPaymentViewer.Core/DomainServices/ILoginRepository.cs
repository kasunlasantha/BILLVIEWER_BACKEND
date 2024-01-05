using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.Core.DomainServices
{
    public interface ILoginRepository
    {

        public Task<Systemuser> Login(User user);
    }
}
