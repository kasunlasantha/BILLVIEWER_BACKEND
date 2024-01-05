using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.DirectoryServices.AccountManagement;
using BC = BCrypt.Net.BCrypt;
using Oracle.ManagedDataAccess.Client;
using Dapper;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BillPaymentViewer.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        readonly DBContextCore _ctx;
        public LoginRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }

        public async Task<Systemuser> Login(User user)
        {
            try
            {
                //Stopwatch watch = new Stopwatch();
                //watch.Start();
                var result = await _ctx.SYSTEMUSERs
                .Where(x => x.USERNAME == user.username).AsNoTracking().FirstOrDefaultAsync(); ;
                //watch.Stop();
                //Debug.WriteLine(watch.Elapsed.ToString());
                if (result != null)
                {
                    if (result.PASSWORD == "Domain")
                    {
                        using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                        {
                            //return context.ValidateCredentials(user.username, user.password);
                            //return true;
                            if(context.ValidateCredentials(user.username, user.password))
                            {
                                return result;
                            }
                            else
                            {
                                throw new ApplicationException("Username or password is invalid.");
                            }

                        }
                    }
                    //this is BCrypt algorithm that is used to verfiy pass
                    else if (BC.Verify(user.password,result.PASSWORD)) 
                    {
                        return result;
                    }

                    else
                    {
                        //Password is invalid.
                        throw new ApplicationException("Username or password is invalid.");
                    }
                }
                else
                {
                    throw new ApplicationException("Username or password is invalid.");
                }
            }
            catch (Exception e)
            {

                throw e;
            }          

        }

        
        //public bool LoginWithDapper(User user)
        //{
        //    Stopwatch watch = new Stopwatch();

        //    using (var dbConn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=172.25.18.196)(Port=1521)))(CONNECT_DATA=(SERVICE_NAME=SLTBILL)));User Id=SLTCRM;Password=sltcrm#555"))
        //    {
        //        dbConn.Open();
        //        var strQuery = @"select * from paybillview_users where username='008954'" ;
        //        watch.Start();
        //        User result = dbConn.Query<User>(strQuery).FirstOrDefault();
        //        watch.Stop();
        //        Debug.WriteLine(watch.Elapsed.ToString());
        //        //return false;

        //        if (result != null)
        //        {
        //            if (result.password == "Domain")
        //            {
        //                using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
        //                {
        //                    bool isDomin = context.ValidateCredentials(user.username, user.password);
        //                    if (isDomin)
        //                    {
        //                        return isDomin;
        //                    }
        //                    else
        //                    {
        //                        throw new ApplicationException("Domin username or password is invalid.");
        //                    }

        //                }
        //            }
        //            //this is BCrypt algorithm that is used to verfiy pass
        //            else if (BC.Verify(user.password, result.password))
        //            {
        //                return true;
        //            }

        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}


    }
}
