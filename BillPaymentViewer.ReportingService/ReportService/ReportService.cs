using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.ReportingService.ReportService
{
    public class ReportService : IReportService
    {
        public MemoryStream GenerateReport()
        {
            throw new NotImplementedException();

            //ReportDocument rd = null;
            //MemoryStream ms = null;
            //Stream stream = null;
            //try
            //{

            //    var dtRet = _returnservice.GetRptReturngood(retno);
            //    using (rd = new ReportDocument())
            //    {
            //        string rptname = "CRReturnNoteRPT.rpt";
            //        string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Reports//" + rptname;
            //        rd.Load(strRptPath);
            //        rd.DataSourceConnections.Clear();
            //        rd.SetDataSource(dtRet);

            //        //rd.SetParameterValue("CenterName", "CFTS");
            //        //rd.SetParameterValue("AccCode", model.ACCODE);
            //        rd.SetParameterValue("Temp", "Temp");
            //        rd.SetParameterValue("Balance", "Balance");
            //        rd.SetParameterValue("BalanceValue", 123);
            //        //rd.SetParameterValue("lblcashier", "lblcashier");

            //        //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");

            //        stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
            //        ms = new MemoryStream();
            //        stream.CopyTo(ms);
                    
            //        return ms; ;

            //    }

            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}
            //finally { ms = null; stream = null; rd = null; }
        }
    }
}
