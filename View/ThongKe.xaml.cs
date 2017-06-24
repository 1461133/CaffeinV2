using CrystalDecisions.CrystalReports.Engine;
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

namespace View
{
    /// <summary>
    /// Interaction logic for ThongKe.xaml
    /// </summary>
    public partial class ThongKe : Window
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void reportViewer_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ReportDocument rd = new ReportDocument();
                rd.Load("C:/Users/Tuan Nguyen/Desktop/HKII - năm 3/LTUD2/Đồ án cafe/GIT/CaffeinV2/View/ReportSanPham.rpt");
                reportViewer.ViewerCore.ReportSource = rd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
