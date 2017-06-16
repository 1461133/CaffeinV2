using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public sealed class Caffein : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        List<tb_Loai> loai;
        public List<tb_Loai> Loai
        {
            get { return loai; }
            set
            {
                if (value == loai)
                {
                    return;
                }
                loai = value;
                OnPropertyChanged("Loai");
            }
        }
        List<View_SanPham> sanpham;
        public List<View_SanPham> SanPham
        {
            get { return sanpham; }
            set
            {
                if (value == sanpham)
                {
                    return;
                }
                sanpham = value;
                OnPropertyChanged("SanPham");
            }
        }
        List<tb_Nhanvien> nhanvien;
        public List<tb_Nhanvien> NhanVien
        {
            get { return nhanvien; }
            set
            {
                if (value == nhanvien)
                {
                    return;
                }
                nhanvien = value;
                OnPropertyChanged("NhanVien");
            }
        }

        List<tb_Khachhang> khachhang;
        public List<tb_Khachhang> KhachHang
        {
            get { return khachhang; }
            set
            {
                if (value == khachhang)
                {
                    return;
                }
                khachhang = value;
                OnPropertyChanged("KhachHang");
            }
        }
    }
}
