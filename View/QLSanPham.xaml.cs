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
using Model;
namespace View
{
    /// <summary>
    /// Interaction logic for QLSanPham.xaml
    /// </summary>
    public partial class QLSanPham : Window
    {
        SanPham sp = new SanPham();
        LoaiSP lsp = new LoaiSP();
       
        public QLSanPham()
        {
            InitializeComponent();
            dataGrid.DataContext = sp.LayAllSP();
            cmbLoai.DataContext = lsp.LayAllLoaiSP();
            //TCNhanVien tcnv = new TCNhanVien();
            // tcnv.sender = new TCNhanVien.SEND(getString);

            TCNhanVien test = new TCNhanVien();
            test.sender= new   TCNhanVien.SEND(getString);
        }
        public void getString(string s)
        {
            MessageBox.Show(s);
        }
        private void btnQL_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void btnThem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mlsp ="";
                if (cmbLoai.SelectedIndex == -1)
                {
                    mlsp = "";
                }
                else
                {
                    //var lsp = new LoaiSP();
                    //var lsp = cmbLoai.SelectedItem as tb_Loai;
                    //mlsp = lsp.maloai;
                    mlsp = lsp.LayMaLoaiSP(cmbLoai.SelectedItem);
                }
                string mess = sp.ThemSanPham(txtID.Text, txtTenSP.Text,mlsp, txtGiaNhap.Text, txtGiaBan.Text, txtSL.Text);
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = sp.LayAllSP();
                cmbLoai.DataContext = lsp.LayAllLoaiSP();
            }
        }

        private void btnSua_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mlsp;
                if (cmbLoai.SelectedIndex == -1)
                {
                    mlsp = "";
                }
                else
                {
                    var lsp = cmbLoai.SelectedItem as LoaiSP;
                    mlsp = lsp.LayMaLoaiSP(cmbLoai.Text);
                }
                string mess = sp.SuaSanPham(txtID.Text, txtTenSP.Text, mlsp, txtGiaNhap.Text, txtGiaBan.Text, txtSL.Text);
                MessageBox.Show(mess, "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = sp.LayAllSP();
                cmbLoai.DataContext = lsp.LayAllLoaiSP();

            }
        }

        private void btnXoa_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                string mess = sp.XoaSanPham(txtID.Text);
                MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = sp.LayAllSP();
                cmbLoai.DataContext = lsp.LayAllLoaiSP();
            }
        }
    }
}
