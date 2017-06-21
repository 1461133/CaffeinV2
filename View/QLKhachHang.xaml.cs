﻿using System;
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
    /// Interaction logic for QLKhachHang.xaml
    /// </summary>
    public partial class QLKhachHang : Window
    {
        KhachHang kh = new KhachHang();
        public QLKhachHang()
        {
            InitializeComponent();
            dataGrid.DataContext = kh.LayViewKH();
        }

        private void btnThem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtHT.Text) || string.IsNullOrEmpty(txtCMND.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ!");
                return;
            }
            else
            {
                DateTime ngaysinh;
                if(DateTime.TryParse(txtNgSinh.Text,out ngaysinh) == false)
                {
                    MessageBox.Show("Nhập sai ngày sinh!!! Vui lòng nhập lại.");
                    return;
                }
                if(DateTime.Parse(txtNgSinh.Text) > DateTime.Now)
                {
                    MessageBox.Show("Nhập sai ngày sinh!!! Vui lòng nhập lại.");
                    return;
                }
                string mess = kh.ThemKhachHang(txtID.Text, txtHT.Text, cmbGT.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, txtNgSinh.Text);
                MessageBox.Show(mess, "Tộc phèo caffein hân hoan chào đón: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = kh.LayViewKH();
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
                string mess = kh.SuaKhachHang(txtID.Text, txtHT.Text, cmbGT.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, txtNgSinh.Text);
                MessageBox.Show(mess, "Tộc phèo caffein u ám mệt mỏi: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = kh.LayViewKH();
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
                string mess = kh.XoaKhachHang(txtID.Text);
                MessageBox.Show(mess, "Tộc phèo caffein bất lực than vãn: ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                dataGrid.DataContext = kh.LayViewKH();
            }
        }

        private void btnHome_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void TroVe_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TCQuanLy tcql = new TCQuanLy();
            tcql.Show();
            this.Close();

        }
    }
}
