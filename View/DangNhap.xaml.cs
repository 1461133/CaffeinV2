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
using ViewModel;

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
        TaiKhoan tk = new TaiKhoan();
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
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Password.ToString()))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                int mess = tk.DangNhap(txtUser.Text, txtPass.Password.ToString());
                if (mess == 1)
                {
                    if(txtUser.Text == "Admin")
                    {
                        MessageBox.Show("Đăng nhập thành công!!", "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        TCQuanLy ql = new TCQuanLy(txtUser.Text);
                        this.Close();
                        ql.Show();
                    }
                    else
                    {
                        string user = txtUser.Text;
                        string test = user.Substring(0, 2);
                        if(test == "KH"|| test == "kh" )
                        {
                            MessageBox.Show("Đăng nhập thành công!!", "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            TCNhanVien nv = new TCNhanVien(txtUser.Text);
                            this.Close();
                            nv.Show();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thành công!!", "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            TCKhachHang kh = new TCKhachHang(txtUser.Text);
                            this.Close();
                            kh.Show();
                        }
                    }
                    
                }
            }
        }
    }
}
