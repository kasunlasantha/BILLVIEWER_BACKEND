using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentViewer.Core.ApplicationServices.Services
{
    public class ReportService : IReportService
    {
        readonly IReportRepository _reportRepo;
        public ReportService(IReportRepository reportRepo)
        {
            _reportRepo = reportRepo;

        }
        public IEnumerable<Payments> GetAllPaymentsByID(string id)
        {
            try
            {
                return _reportRepo.GetAllPaymentsByID(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
