using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentViewer.Core.ApplicationServices.Services
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _CustRepo;
        public CustomerService(ICustomerRepository custRepo)
        {
            _CustRepo = custRepo;

        }
      

        public string GetCutomerByID(string id)
        {
            try
            {
                string name = "Customer Name: " + _CustRepo.GetCustomerByID(id).ToString();
                return name;
            }
            catch (Exception)
            {

                throw;
            }
           
           
        }
    }
}
