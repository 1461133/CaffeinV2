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
    /// Interaction logic for RpSanPham.xaml
    /// </summary>
    public partial class RpSanPham : Window
    {
        public string TENDN;
        public RpSanPham(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RPSanPham rp = new RPSanPham();
            rp.Load(@"Myrep.rep");
            viewer.ViewerCore.ReportSource = rp;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ThongKe ql = new ThongKe(TENDN);
            ql.Show();
        }
    }
}
