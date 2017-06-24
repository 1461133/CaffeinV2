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
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.IO;

namespace View
{
    /// <summary>
    /// Interaction logic for QLSanPham.xaml
    /// </summary>
    public partial class QLSanPham : Window
    {
        public string TENDN;
        SanPham sp = new SanPham();
        LoaiSP lsp = new LoaiSP();
        public QLSanPham()
        {
            InitializeComponent();
            dataGrid.DataContext = sp.LayAllSP();
            cmbLoai.DataContext = lsp.LayAllLoaiSP();
        }
        public QLSanPham(string tendn)
        {
            InitializeComponent();
            dataGrid.DataContext = sp.LayAllSP();
            cmbLoai.DataContext = lsp.LayAllLoaiSP();
            TENDN = tendn;
        }
        public void getString(string s)
        {
            MessageBox.Show(s);
        }
        private void btnQL_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TCQuanLy tc = new TCQuanLy(TENDN);
            tc.Show();
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
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtTenSP.Text)|| cmbLoai.SelectedIndex == -1 )
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                if(txtID.Text.Substring(0,2) !="SP")
                {
                    MessageBox.Show("Nhập mã sp sai, phải bắt đầu = SP", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                int tam;
                if (int.TryParse(txtID.Text.Substring(2), out tam)==false)
                {
                    MessageBox.Show("Nhập mã sp sai sau SP phải là số", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                if(int.TryParse(txtGiaBan.Text, out tam) == false)
                {
                    
                     MessageBox.Show("Giá bán phải là số", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (int.TryParse(txtGiaNhap.Text, out tam) == false)
                {

                    MessageBox.Show("Giá nhập phải là số", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (int.TryParse(txtSL.Text, out tam) == false)
                {

                    MessageBox.Show("Số lượng phải là số", "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                string mlsp ="";
                
                {
                    
                    mlsp = lsp.LayMaLoaiSP(cmbLoai.SelectedItem);
                    
                }
            
                string mess = sp.ThemSanPham(txtID.Text, txtTenSP.Text,mlsp, txtGiaNhap.Text, txtGiaBan.Text, txtSL.Text,txtHA.Text);
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = sp.LayViewSP();
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
                string mess = sp.SuaSanPham(txtID.Text, txtTenSP.Text, mlsp, txtGiaNhap.Text, txtGiaBan.Text, txtSL.Text, txtHA.Text);
                MessageBox.Show(mess, "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = sp.LayViewSP();
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
                dataGrid.DataContext = sp.LayViewSP();
                cmbLoai.DataContext = lsp.LayAllLoaiSP();
            }
        }

        private void btnPicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QL_QuancapheEntities DB = new QL_QuancapheEntities();
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Filter = "Image files (*.bmp, *.jpg)|*.bmp;*.jpg|All files (*.*)|*.*";
                openFileDialog1.DefaultExt = ".jpg";
                txtHA.Text = openFileDialog1.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(txtHA.Text));
                image1.Source = imageSource;
            }
            catch
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
            }

        }

        //private void btnOutImage_Click(object sender, RoutedEventArgs e)
        //{

        //    var result = File.ReadAllBytes(txtHA.Text);
        //    Stream StreamObj = new MemoryStream(result);
        //    BitmapImage BitObj = new BitmapImage();
        //    BitObj.BeginInit();
        //    BitObj.StreamSource = StreamObj;
        //    BitObj.EndInit();
        //    this.image1.Source = BitObj;
        
        //}
            

      
    }
}
