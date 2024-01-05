using BillPaymentViewer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentViewer.Core.DomainServices
{
    public interface IReportRepository
    {
        IEnumerable<Payments> GetAllPaymentsByID(string id);
    }
}
