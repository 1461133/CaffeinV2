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
    /// Interaction logic for RpHoaDonBan.xaml
    /// </summary>
    public partial class RpHoaDonBan : Window
    {
        public RpHoaDonBan()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RPHoaDonBan rp = new RPHoaDonBan();
            rp.Load(@"Myrep.rep");
            viewer.ViewerCore.ReportSource = rp;
        }
    }
}
