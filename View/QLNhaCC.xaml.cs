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
    /// Interaction logic for QLNhaCC.xaml
    /// </summary>
    public partial class QLNhaCC : Window
    {
        NhaCC ncc = new NhaCC();
        public QLNhaCC()
        {
            InitializeComponent();
         
            dataGrid.DataContext = ncc.LayAllNCC();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (txtID.Text.Substring(0, 3) != "NCC")
                {
                    MessageBox.Show("Nhập mã ncc sai, phải bắt đầu = NCC", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (txtID.Text.Length != 6)
                {
                    MessageBox.Show("Nhập sai mã nhà cung cấp!!! Vui lòng nhập lại, mã có 6 ký tự");
                    return;
                }

                string tam = txtID.Text.Substring(3);
                int tam1;
                if (int.TryParse(tam, out tam1) == false)
                {
                    MessageBox.Show("Nhập sai mã sản phẩm!!! Vui lòng nhập lại, sau NCC phải là số");
                    return;
                }
                string mess = ncc.ThemNhaCC(txtID.Text, txtTen.Text, txtDiaChi.Text,txtSDT.Text);
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = ncc.LayAllNCC();
            }
        }

        private void btnXoùa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mess = ncc.XoaNhaCC(txtID.Text);
                MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = ncc.LayAllNCC();
            }
        }

        private void btnPhucHoi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mess = ncc.PhucHoiNhaCC(txtID.Text);
                MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = ncc.LayAllNCC();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mess = ncc.SuaNhaCC(txtID.Text,txtTen.Text,txtDiaChi.Text,txtSDT.Text);
                MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = ncc.LayAllNCC();
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            QLNhapHang nh = new QLNhapHang();
            nh.Show();
            this.Close();
        }
    }
}
