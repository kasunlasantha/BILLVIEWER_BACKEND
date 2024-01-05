using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillPaymentViewer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly DBContextCore _ctx;
        public CustomerRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }

        public string GetAccountNoByID(string id)
        {
            try
            {
                var customer = _ctx.LTE_CUSTOMERs
                .Where(c => c.CUSTACCNUM.Equals(id) || c.TEL.Equals(id)).FirstOrDefault();
                if (customer == null)
                {
                    throw new ApplicationException("SLT Customer not found.");
                }
                return customer.CUSTACCNUM;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetCustomerByID(string id)
        {
            try
            {
                var customer = _ctx.LTE_CUSTOMERs
                .Where(c => c.CUSTACCNUM.Equals(id) || c.TEL.Equals(id)).FirstOrDefault();
                if (customer == null)
                {
                    throw new ApplicationException("SLT Customer not found.");
                }
                return customer.NAME;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
