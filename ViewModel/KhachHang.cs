using System;
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
        // kiểm trả cả trạng thái kh
        public bool KTKhachHangTT(string ID)
        {
            using (var qlcf = new Model.QL_QuancapheEntities())
            {
                int n = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai==true).Count();
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
                else
                {
                    if (SDT != "")
                    {
                        kh = qlcf.tb_Khachhang.Where(m => m.sdt == SDT && m.trangthai == true).SingleOrDefault() as tb_Khachhang;
                    }
                    if (CMND != "")
                    {
                        kh = qlcf.tb_Khachhang.Where(m => m.cmnd == CMND && m.trangthai == true).SingleOrDefault() as tb_Khachhang;
                    }
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
        public List<View_KhachHang> LayViewKH(int curPage, int pageSize, out int totalPage)
        {
            List<View_KhachHang> dskh;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dskh = qlcf.View_KhachHang.OrderByDescending(m => m.makh).ToList();
            }
            totalPage = (int)Math.Ceiling(dskh.Count() * 1.0 / pageSize);
            return dskh.OrderByDescending(m => m.makh)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public List<View_KhachHangXoa> LayViewKHXoa(int curPage, int pageSize, out int totalPage)
        {
            List<View_KhachHangXoa> dskh;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dskh = qlcf.View_KhachHangXoa.OrderByDescending(m => m.makh).ToList();
            }
            totalPage = (int)Math.Ceiling(dskh.Count() * 1.0 / pageSize);
            return dskh.OrderByDescending(m => m.makh)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public List<View_AllKhachHang> LayViewKHAll(int curPage, int pageSize, out int totalPage)
        {
            List<View_AllKhachHang> dskh;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dskh = qlcf.View_AllKhachHang.OrderByDescending(m => m.makh).ToList();
            }
            totalPage = (int)Math.Ceiling(dskh.Count() * 1.0 / pageSize);
            return dskh.OrderByDescending(m => m.makh)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
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
            string kq = "Chưa sửa được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKhachHang(ID))
                {
                    var kh = qlcf.tb_Khachhang.Where(m => m.makh == ID).SingleOrDefault() as tb_Khachhang;
                    if(kh.trangthai == false)
                    {
                        kq = "Mã khách hàng đã xóa rồi nhá -_-";
                    }
                    else
                    {
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
                }
                else
                {
                    kq = "Mã khách hàng sai rồi nhá -_-";
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
                    var kh = qlcf.tb_Khachhang.Where(m => m.makh == ID).SingleOrDefault() as tb_Khachhang;
                    if(kh.trangthai == false)
                    {
                        kq = "Mã khách hàng đã xóa rồi nhá -_-";
                    }
                    else
                    {
                        kh.trangthai = false;
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = "Xóa thành công!";
                        }
                        else
                        {
                            kq = "Chưa xóa được!";
                        }
                    }
                }
                else
                {
                    kq = "Mã khách hàng sai rồi nhá -_-";
                }
            }
            return kq;
        }
        public string PhucHoiKhachHang(string ID)
        {
            string kq = "Chưa phục hồi được!";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKhachHang(ID))
                {
                    var kh = qlcf.tb_Khachhang.Where(m => m.makh == ID).SingleOrDefault() as tb_Khachhang;
                    if (kh.trangthai == true)
                    {
                        kq = "Mã khách hàng đã có rồi nhá -_-";
                    }
                    else
                    {
                        kh.trangthai = true;
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = "Phục hồi thành công!";
                        }
                        else
                        {
                            kq = "Chưa phục hồi được!";
                        }
                    }
                }
                else
                {
                    kq = "Mã khách hàng sai rồi nhá -_-";
                }
            }
            return kq;
        }
        //public string LayHoTen(string ID)
        //{
        //    string kq ="";
        //    if(CMND != "")
        //    {
        //        using (var qlcf = new QL_QuancapheEntities())
        //        {
        //            int n = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai == true).Count();
        //            if(n>0)
        //            {
        //                tb_Khachhang kh = qlcf.tb_Khachhang.Where(m => m.makh == ID && m.trangthai == true).SingleOrDefault() as tb_Khachhang;
        //                kq = kh.tenkh;
        //            }   
        //        }
        //    }
        //    if (ID != "")
        //    {
        //        if (KTKhachHang(ID))
        //        {
        //            using (var qlcf = new QL_QuancapheEntities())
        //            {

        //            }

        //    }
        //    return kq;
        //}
    }
}
   
