using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        readonly DBContextCore _ctx;
        public PaymentRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }

        public async Task<CustomerPayment> GetAllPaymentsByID(string id)
        {
            string strCustName = string.Empty;
            try
            {
                //Stopwatch watch = new Stopwatch();
                //watch.Start();
                var customer = await _ctx.LTE_CUSTOMERs
               .Where(c => c.CUSTACCNUM.Equals(id) || c.TEL.Equals(id)).AsNoTracking().FirstOrDefaultAsync();

                if (customer == null)
                {
                    throw new ApplicationException("Invalid account number or telephone number.");
                    //strCustName = "Customer not found";
                }
                else
                {
                    strCustName = customer.NAME;
                }

                //call SP
                var param1 = new OracleParameter("ACCNO", OracleDbType.Varchar2);
                var param2 = new OracleParameter("E_Recordset", OracleDbType.RefCursor, ParameterDirection.Output);
                param1.Value = customer.CUSTACCNUM;
                var sql = "BEGIN SLTCRM.MOBIPAYVIEW_GETPAYMENT(:ACCNO,:E_Recordset); END;";
                var payments = await _ctx.PAYMENTs.FromSqlRaw(sql, new object[] { param1, param2 }).AsNoTracking().ToListAsync();


                //watch.Stop();
                //Debug.WriteLine(watch.Elapsed.ToString());
                if (payments == null)
                {
                    throw new ApplicationException("Invalid account number or telephone number.");
                }

                if (payments.Count == 0)
                {
                    throw new ApplicationException("Payment not found.");
                }

                return new CustomerPayment() { NAME = "Customer Name: " + strCustName, payments = payments };
               
            }
            catch (Exception er)
            {

                throw er;
            }
        }
    }
}
