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
        List<tb_Sanpham> sanpham;
        public List<tb_Sanpham> SanPham
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
        List<View_SanPham> vsanpham;
        public List<View_SanPham> ViewSanPham
        {
            get { return vsanpham; }
            set
            {
                if (value == vsanpham)
                {
                    return;
                }
               vsanpham = value;
                OnPropertyChanged("ViewSanPham");
            }
        }
        List<View_SanPhamXoa> vsanphamxoa;
        public List<View_SanPhamXoa> ViewSanPhamXoa
        {
            get { return vsanphamxoa; }
            set
            {
                if (value == vsanphamxoa)
                {
                    return;
                }
                vsanphamxoa = value;
                OnPropertyChanged("ViewSanPhamXoa");
            }
        }
        List<View_AllSanPham> vsanphamall;
        public List<View_AllSanPham> ViewSanPhamAll
        {
            get { return vsanphamall; }
            set
            {
                if (value == vsanphamall)
                {
                    return;
                }
                vsanphamall = value;
                OnPropertyChanged("ViewSanPhamAll");
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
        List<View_NhanVien> vnhanvien;
        public List<View_NhanVien> ViewNhanVien
        {
            get { return vnhanvien; }
            set
            {
                if (value == vnhanvien)
                {
                    return;
                }
                vnhanvien = value;
                OnPropertyChanged("ViewNhanVien");
            }
        }
        List<View_NhanVienXoa> vnhanvienxoa;
        public List<View_NhanVienXoa> ViewNhanVienXoa
        {
            get { return vnhanvienxoa; }
            set
            {
                if (value == vnhanvienxoa)
                {
                    return;
                }
                vnhanvienxoa = value;
                OnPropertyChanged("ViewNhanVienXoa");
            }
        }
        List<View_AllNhanVien> vnhanvienall;
        public List<View_AllNhanVien> ViewNhanVienAll
        {
            get { return vnhanvienall; }
            set
            {
                if (value == vnhanvienall)
                {
                    return;
                }
                vnhanvienall = value;
                OnPropertyChanged("ViewNhanVienAll");
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
        List<View_KhachHang> vkhachhang;
        public List<View_KhachHang> ViewKhachHang
        {
            get { return vkhachhang; }
            set
            {
                if (value == vkhachhang)
                {
                    return;
                }
                vkhachhang = value;
                OnPropertyChanged("ViewKhachHang");
            }
        }
        List<View_KhachHangXoa> vkhachhangxoa;
        public List<View_KhachHangXoa> ViewKhachHangXoa
        {
            get { return vkhachhangxoa; }
            set
            {
                if (value == vkhachhangxoa)
                {
                    return;
                }
                vkhachhangxoa = value;
                OnPropertyChanged("ViewKhachHangXoa");
            }
        }
        List<View_AllKhachHang> vkhachhangall;
        public List<View_AllKhachHang> ViewKhachHangAll
        {
            get { return vkhachhangall; }
            set
            {
                if (value == vkhachhangall)
                {
                    return;
                }
                vkhachhangall = value;
                OnPropertyChanged("ViewKhachHangAll");
            }
        }
        public static int PageSize = 6;
        int curPage;
        public int CurPage
        {
            get { return curPage; }
            set
            {
                if (value == curPage)
                {
                    return;
                }
                curPage = value;
                OnPropertyChanged("CurPage");
            }
        }
        int totalPage;
        public int TotalPage
        {
            get { return totalPage; }
            set
            {
                if (value == totalPage)
                {
                    return;
                }
                totalPage = value;
                OnPropertyChanged("TotalPage");
            }
        }
    }
}
