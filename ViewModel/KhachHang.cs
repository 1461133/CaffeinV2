﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace ViewModel
{
    public class KhachHang
    {
        public bool KTKhachHang(string ID)
        {
            using (var qlcf = new Model.QL_QuancapheEntities())
            {
                int n = qlcf.tb_Khachhang.Where(m => m.makh == ID).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public tb_Khachhang LayKH(string ID, string CMND, string SDT)
        {
            tb_Khachhang kh=null;
            using (var qlcf = new QL_QuancapheEntities())
            {
                // ưu tiên lấy mã khách hàng
                if(ID != "")
                {
                    kh = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai == true).SingleOrDefault() as tb_Khachhang;
                }
                if(SDT != "" && ID=="")
                {
                    kh = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai == true).SingleOrDefault() as tb_Khachhang;
                }
                if(CMND !="" && ID =="")
                {
                    kh = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai == true).SingleOrDefault() as tb_Khachhang;
                }
            }
            return kh;
        }
        public List<tb_Khachhang> LayAllKH()
        {
            List<tb_Khachhang> dskh;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dskh = qlcf.tb_Khachhang.Where(m => m.trangthai == true).ToList();
            }
            return dskh;
        }
        public string ThemKhachHang(string ID, string TenKH, string gt, string CMND, string SDT, string DiaChi, string ngaysinh)
        {
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKhachHang(ID) == false)
                {
                    DateTime ngsinh;
                    if (DateTime.TryParse(ngaysinh, out ngsinh) == false)
                    {
                        ngaysinh = "13/05/1996";
                    }
                    var kh = new tb_Khachhang { makh = ID, tenkh = TenKH, gioitinh = gt, cmnd = CMND, diachi = DiaChi, ngaysinh = DateTime.Parse(ngaysinh), sdt = SDT, trangthai = true };
                    qlcf.tb_Khachhang.Add(kh);
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã có thêm khách hàng mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa thêm được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã khách hàng trùng hoặc đã từng có rồi nhá -_-";
                }

            }
            return kq;
        }
        public string SuaKhachHang(string ID, string TenKH, string gt, string CMND, string SDT, string DiaChi, string ngaysinh)
        {
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKhachHang(ID))
                {
                    var kh = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai == true).Single() as tb_Khachhang;
                    if (TenKH != "")
                    {
                        kh.tenkh = TenKH;
                    }
                    DateTime ngsinh;
                    if (ngaysinh != "")
                    {
                        if (DateTime.TryParse(ngaysinh, out ngsinh) == false)
                        {
                            ngaysinh = "13/05/1996";
                        }
                        kh.ngaysinh = DateTime.Parse(ngaysinh);
                    }

                    if (CMND != "")
                    {
                        kh.cmnd = CMND;
                    }
                    if (DiaChi != "")
                    {
                        kh.diachi = DiaChi;
                    }
                    if (SDT != "")
                    {
                        kh.sdt = SDT;
                    }
                    if (gt != "")
                        kh.gioitinh = gt;
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Cập nhật thành công!";
                    }
                    else
                    {
                        kq = "Chưa cập nhật được!";
                    }
                }
                else
                {
                    kq = "Mã khách hàng sai hoặc đã xóa rồi nhá -_-";
                }

            }
            return kq;
        }
        public string XoaKhachHang(string ID)
        {
            string kq = "Chưa xóa được!";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKhachHang(ID))
                {
                    var kh = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai == true).Single() as tb_Khachhang;
                    kh.trangthai = false;
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq="Xóa thành công!";
                    }
                    else
                    {
                        kq = "Chưa xóa được!";
                    }
                }
                else
                {
                    kq = "Mã khách hàng sai hoặc đã xóa rồi nhá -_-";
                }
            }
            return kq;
        }
        public string LayHoTen(string ID, string CMND)
        {
            string kq ="";
            if(CMND != "")
            {
                using (var qlcf = new QL_QuancapheEntities())
                {
                    int n = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai == true).Count();
                    if(n>0)
                    {
                        tb_Khachhang kh = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai == true).Single() as tb_Khachhang;
                        kq = kh.tenkh;
                    }   
                }
            }
          /*  if(ID !="")
            {
                if(KTKhachHang(ID))
                {
                    tb_Khachhang kh = LayKH(ID);
                    kq = kh.tenkh;
                }
            }  */
            return kq;
        }
    }
}
   