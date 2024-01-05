using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace BillPaymentViewer.Core.ApplicationServices.Services
{
    public class SystemUserService : ISystemUserService
    {
        readonly ISystemUserRepository _SystemUserRepo;
        public SystemUserService(ISystemUserRepository systemUserRepo)
        {
            _SystemUserRepo = systemUserRepo;

        }

        public Systemuser Create(Systemuser user)
        {
            try
            {
                if(user.PASSWORD != "Domain")
                {
                    user.PASSWORD = this.HashPassword(user.PASSWORD);
                }
                return _SystemUserRepo.Create(user);
            }
            catch (Exception)
            {

                throw;
            }


        }

        private string GetRandomSalt()
        {
            return BC.GenerateSalt(12);
        }

        //example : var hashed = this.HashPassword(user.password);
        private string HashPassword(string password)
        {
            return BC.HashPassword(password, GetRandomSalt());
        }
    }
}
