using Microsoft.Reporting.WebForms;
using System.Linq;
using System.Web.Mvc;

namespace odh_foundation.Models
{
    public class Reports
    {
        public static FileContentResult PrintInvoice(string txnid)
        {
            UsersContext db = new UsersContext();

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;

            var comp = db.CompanyInfos.Single(a => a.Id == 1);

            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = @"Report\\RDLC\\invoice.rdlc";

            viewer.LocalReport.DataSources.Add(new ReportDataSource("invoice", db.Donars.Where(a => a.PaymentTransactionId == txnid).ToList()));
            viewer.LocalReport.Refresh();

            var setup = viewer.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            viewer.SetPageSettings(setup);

            var bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            return new FileContentResult(bytes, mimeType);
        }

        public static FileContentResult PrintCertificate(string txnid)
        {
            UsersContext db = new UsersContext();

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;

            var comp = db.CompanyInfos.Single(a => a.Id == 1);

            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = @"Report\\RDLC\\Certificate.rdlc";

            viewer.LocalReport.DataSources.Add(new ReportDataSource("certificate", db.Donars.Where(a => a.PaymentTransactionId == txnid).ToList()));
            viewer.LocalReport.Refresh();

            var setup = viewer.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            viewer.SetPageSettings(setup);

            var bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            return new FileContentResult(bytes, mimeType);
        }
    }
}