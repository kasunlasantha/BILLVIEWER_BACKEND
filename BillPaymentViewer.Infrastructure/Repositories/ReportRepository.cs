using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace BillPaymentViewer.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        readonly DBContextCore _ctx;
        public ReportRepository(DBContextCore ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Payments> GetAllPaymentsByID(string id)
        {
            try { 
            var cust = _ctx.LTE_CUSTOMERs
                .Where(c => c.CUSTACCNUM.Equals(id) || c.TEL.Equals(id)).FirstOrDefault();

                if (cust == null)
                {
                    throw new ApplicationException("Invalid account number or telephone number.");
                }

                //var payments = _ctx.PAYMENTs
                //        .Where(p => p.ACCOUNTNUMBER.Equals(cust.CUSTACCNUM)).OrderBy(d => d.PAYMENTDATE).Take(10);

                var param1 = new OracleParameter("ACCNO", OracleDbType.Varchar2);
                var param2 = new OracleParameter("E_Recordset", OracleDbType.RefCursor, ParameterDirection.Output);
                param1.Value = cust.CUSTACCNUM;
                var sql = "BEGIN SLTCRM.MOBIPAYVIEW_GETPAYMENT(:ACCNO,:E_Recordset); END;";
                var payments = _ctx.PAYMENTs.FromSqlRaw(sql, new object[] { param1, param2 }).AsNoTracking().ToList();

                if (payments == null || payments.Count == 0)
            {
                throw new ApplicationException("Payment not found.");
            }

                return payments;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
