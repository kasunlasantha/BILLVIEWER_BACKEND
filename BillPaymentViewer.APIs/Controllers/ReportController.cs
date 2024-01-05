using BillPaymentViewer.Core.ApplicationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using AspNetCore.Reporting;
using System.Text;

namespace BillPaymentViewer.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        private readonly IWebHostEnvironment _env;

        private readonly ICustomerService _custService;

        private readonly ILoggerService _logger;

        //private readonly IHttpContextAccessor _httpContextAccessor;

        public ReportController(IReportService ReportService, IWebHostEnvironment env, ICustomerService custService, ILoggerService loggerService)
        {
            _reportService = ReportService;
            _env = env;
            _custService = custService;
            _logger = loggerService;
            // _httpContextAccessor = httpContextAccessor;
        }

        //api/Payment/getReport]
        [Route("getReport")]
        [HttpPost]
        public IActionResult getReport([FromBody] string id)
        {

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("BillPaymentViewer.APIs.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "PayHistoryReport");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            LocalReport report = new LocalReport(rdlcFilePath);

            var returnPayments = _reportService.GetAllPaymentsByID(id);
            //Convert.ToString(defaultValue, CultureInfo.InvariantCulture)
            var cusName = _custService.GetCutomerByID(id);

            parameters.Add("CUSNameParameter", cusName);

            report.AddDataSource("DataSet1", returnPayments);
            var result = report.Execute(GetRenderType("pdf"), 1, parameters);
            //return result.MainStream;

            FileContentResult returnFile =  File(result.MainStream, System.Net.Mime.MediaTypeNames.Application.Octet,"PaymentReport" +".pdf");

            if(returnFile != null)
            {
                _logger.LogInfo("Method: getReport(success), Return:" + id);
                return returnFile;
            }
            else
            {
                _logger.LogInfo("Method: getReport(error)");
                return BadRequest("Method: getReport(error)");
            }


        }

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;
            switch (reportType.ToLower())
            {
                default:
                case "pdf":
                    renderType = RenderType.Pdf;
                    break;
                case "word":
                    renderType = RenderType.Word;
                    break;
                case "excel":
                    renderType = RenderType.Excel;
                    break;
            }

            return renderType;
        }
    }
}
