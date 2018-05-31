using Caliburn.Micro;
using DevExpress.XtraReports.UI;
using Employee_Training.Models;
using Employee_Training.Reports;

namespace Employee_Training.ViewModels
{
    class ReportShowViewModel : Screen
    {
        public ReportShowViewModel(BindableCollection<ReportResultsModel> model, string reportName)
        {
            PrintReport(model, reportName);
        }

        public XtraReport report { get; set; }

        public void PrintReport(BindableCollection<ReportResultsModel> model, string reportName)
        {
            switch (reportName)
            {
                case "EmpInfo":
                    report = new EmpInfoRpt();
                    break;

                case "EmpTrain":
                    report = new EmpTrainRpt();
                    break;
            }

            report.DataSource = model;
            report.CreateDocument();
        }
    }
}
