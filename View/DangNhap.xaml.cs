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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            //DialogResult result;
            // Displays the MessageBox.
            MessageBoxResult result;
            result = MessageBox.Show("Chào mừng đến với tộc phèo caffein!!! Bạn có lầy không nà??? :3", "Lầy nào ^^", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Cancel)
            {
                this.Close();
            }
            if (result == MessageBoxResult.No)
            {
                
            }
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            TCNhanVien nv = new TCNhanVien();
            this.Close();
            nv.Show();
        }
    }
}
