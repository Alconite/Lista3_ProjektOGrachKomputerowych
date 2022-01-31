using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lista3_ProjektOGrachKomputerowych
{
    /// <summary>
    /// Interaction logic for ReportShow.xaml
    /// </summary>
    public partial class ReportShow : Window
    {
        public ReportShow()
        {
            InitializeComponent();
            /*this.ReportViewer.ReportLoaded += (sen, arg) =>
            {
                List<BoldReports.Windows.DataSourceCredentials> dataSourceCredentials = new List<BoldReports.Windows.DataSourceCredentials>();
                foreach (var dataSource in this.ReportViewer.GetDataSources())
                {
                    BoldReports.Windows.DataSourceCredentials credentials = new BoldReports.Windows.DataSourceCredentials();
                    credentials.Name = dataSource.Name;
                    credentials.UserId = null;
                    credentials.Password = null;
                    credentials.IntegratedSecurity = true;
                    dataSourceCredentials.Add(credentials);
                }
                this.ReportViewer.SetDataSourceCredentials(dataSourceCredentials);
            };
            //this.ReportViewer.ReportServerUrl = "http://HOME-PC:80/Report";
            this.ReportViewer.ReportServerUrl = "http://home-pc/ReportServer";
            this.ReportViewer.ReportServerCredential = new System.Net.NetworkCredential("Alconite", "kobielkileer");
            this.ReportViewer.ReportPath = "/Resources/Report1";
            this.ReportViewer.RefreshReport();*/
            rptViewer.ServerReport.ReportServerUrl = new Uri("http://home-pc:80/ReportServer", System.UriKind.Absolute);
            rptViewer.ServerReport.ReportPath = "/Resources/Report1";
            rptViewer.RefreshReport();
        }
    }
}
