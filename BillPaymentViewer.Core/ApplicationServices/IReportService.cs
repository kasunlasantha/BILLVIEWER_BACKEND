using System;
using System.Collections.Generic;
using System.Text;
using BillPaymentViewer.Core.Entities;

namespace BillPaymentViewer.Core.ApplicationServices
{
    public interface IReportService
    {
        IEnumerable<Payments> GetAllPaymentsByID(string id);
    }
}
