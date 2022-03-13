using AspNetCore.Reporting;
using System.Collections.Generic;
using System.Text;

namespace AlcaldiaAraucaPortalReport
{
    public class ReportService
    {
        public ReportResult GenerateReportAsync(string reportName, Dictionary<string, object> model)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Encoding.GetEncoding("windows-1252");

            LocalReport report = new LocalReport(reportName);

            foreach (var item in model)
                report.AddDataSource(item.Key, item.Value);

            var result = report.Execute(GetRenderType("pdf"), 1, parameters);

            return result;
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
