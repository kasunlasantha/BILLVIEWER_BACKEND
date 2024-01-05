using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;

namespace BillPaymentViewer.Infrastructure.Repositories
{
    public class SystemUserRepository: ISystemUserRepository
    {
        readonly DBContextCore _ctx;
        public SystemUserRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }

        public Systemuser Create(Systemuser user)
        {
            try { 
                if (_ctx.SYSTEMUSERs.Any(x => x.USERNAME == user.USERNAME))
                    throw new ApplicationException("Username " + user.USERNAME + " is already taken");

                _ctx.SYSTEMUSERs.Add(user);
                _ctx.SaveChanges();

                return user;

            }
            catch (Exception er)
            {

                throw er;
            }

        }


    }
}
