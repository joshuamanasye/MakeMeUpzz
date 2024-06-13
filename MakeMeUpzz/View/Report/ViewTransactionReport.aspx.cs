using MakeMeUpzz.Controller;
using MakeMeUpzz.Dataset;
using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using MakeMeUpzz.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View.Report
{
    public partial class ViewTransactionReport : System.Web.UI.Page
    {
        TransactionController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new TransactionController();

            controller.CheckAdmin(Response, Session);

            LoadReport();
        }

        private void LoadReport()
        {
            TransactionReport report = new TransactionReport();
            ReportViewer.ReportSource = report;

            TransactionDataSet data = controller.GetTransactionReportData();
            report.SetDataSource(data);
        }
    }
}