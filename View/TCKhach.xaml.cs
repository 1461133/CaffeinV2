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

namespace CAFFEIN
{
    /// <summary>
    /// Interaction logic for TCKhach.xaml
    /// </summary>
    public partial class TCKhach : Window
    {
        public TCKhach()
        {
            InitializeComponent();
        }

        private void TKSanPham_Click(object sender, RoutedEventArgs e)
        {
            TKSanPham f = new TKSanPham();
            f.Show();
        }
    }
}
