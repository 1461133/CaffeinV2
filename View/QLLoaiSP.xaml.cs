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
    /// Interaction logic for QLLoaiSP.xaml
    /// </summary>
    public partial class QLLoaiSP : Window
    {
        LoaiSP lsp = new LoaiSP();
        public QLLoaiSP()
        {
            InitializeComponent();
            dataGrid.DataContext = lsp.LayAllLoaiSPXS();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if (txtID.Text.Length != 3)
                {
                    MessageBox.Show("Nhập sai mã loại sản phẩm!!! Vui lòng nhập lại, mã có 3 ký tự");
                    return;
                }
                int tam1;
                if (int.TryParse(txtID.Text, out tam1) == false)
                {
                    MessageBox.Show("Nhập sai mã loại!!! Vui lòng nhập lại, mã là số");
                    return;
                }
                string mess = lsp.ThemLoaiSP(txtID.Text, txtTen.Text);
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = lsp.LayAllLoaiSPXS();
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
                string mess = lsp.XoaLoaiSP(txtID.Text);
                MessageBox.Show(mess, "Tộc phèo caffein  bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = lsp.LayAllLoaiSPXS();
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
                string mess = lsp.PhucHoiLoaiSP(txtID.Text);
                MessageBox.Show(mess, "Tộc phèo caffein  bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = lsp.LayAllLoaiSPXS();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mess = lsp.SuaLoaiSP(txtID.Text, txtTen.Text);
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = lsp.LayAllLoaiSPXS();
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            QLSanPham sp = new QLSanPham();
            sp.Show();
            this.Close();
        }
    }
}
