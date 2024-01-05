using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.ReportingService.ReportService
{
   public interface IReportService
    {
        MemoryStream GenerateReport();
    }
}
