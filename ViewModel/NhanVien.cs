using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace ViewModel
{
    public class NhanVien
    {
        public bool KTNhanVien(string ID)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_Nhanvien.Where(m => m.manv == ID).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public tb_Nhanvien LayNV(string ID)
        {
            tb_Nhanvien nv;
            using (var qlcf = new QL_QuancapheEntities())
            {
                nv = qlcf.tb_Nhanvien.Where(m => m.manv == ID).SingleOrDefault() as tb_Nhanvien;
            }
            return nv;
        }
        public List<tb_Nhanvien> LayAllNV()
        {
            List<tb_Nhanvien> dsnv;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dsnv = qlcf.tb_Nhanvien.Where(m => m.trangthai == true).ToList();
            }
            return dsnv;
        }
        public List<View_NhanVien> LayViewNV(int curPage, int pageSize, out int totalPage)
        {
            List<View_NhanVien> dsnv;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dsnv = qlcf.View_NhanVien.OrderByDescending(m => m.manv).ToList();
            }
            totalPage = (int)Math.Ceiling(dsnv.Count() * 1.0 / pageSize);
            return dsnv.OrderByDescending(m => m.manv)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public List<View_NhanVienXoa> LayViewNVXoa(int curPage, int pageSize, out int totalPage)
        {
            List<View_NhanVienXoa> dsnv;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dsnv = qlcf.View_NhanVienXoa.OrderByDescending(m => m.manv).ToList();
            }
            totalPage = (int)Math.Ceiling(dsnv.Count() * 1.0 / pageSize);
            return dsnv.OrderByDescending(m => m.manv)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public List<View_AllNhanVien> LayViewNVAll(int curPage, int pageSize, out int totalPage)
        {
            List<View_AllNhanVien> dsnv;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dsnv = qlcf.View_AllNhanVien.OrderByDescending(m => m.manv).ToList();
            }
            totalPage = (int)Math.Ceiling(dsnv.Count() * 1.0 / pageSize);
            return dsnv.OrderByDescending(m => m.manv)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public string ThemNhanVien(string ID, string TenNV, string gt, string CMND, string SDT, string DiaChi, string ngaysinh, string loainv)
        {
            //if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(txtCMND.Text) || string.IsNullOrEmpty(txtSDT.Text))
            //{
            //    MessageBox.Show("Dữ liệu chưa đầy đủ!");
            //    return;
            //}
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTNhanVien(ID) == false)
                {
                    DateTime ngsinh;
                    if (DateTime.TryParse(ngaysinh, out ngsinh) == false)
                    {
                        ngaysinh = "23/06/1996";
                    }
                    var nv = new tb_Nhanvien { manv = ID, tennv = TenNV, sdt = SDT, gioitinh = gt, diachi = DiaChi, cmnd = CMND, loainv = loainv, ngaysinh = DateTime.Parse(ngaysinh),  trangthai = true };
                    qlcf.tb_Nhanvien.Add(nv);
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã có thêm nhân viên mới rồi nha ^^";
                    }
                    else
                    {
                        kq = "Chưa thêm được, buồn quá đi TT.TT";
                    }
                }
                else
                    kq = "Mã nhân viên trùng hoặc đã từng có rồi nhá -_-";
            }
            return kq;
        }
       
        public string XoaNhanVien(string ID)
        {
            string kq = "Chưa xóa được!";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTNhanVien(ID))
                {
                    var nv = qlcf.tb_Nhanvien.Where(m => m.manv == ID).SingleOrDefault() as tb_Nhanvien;
                    if(nv.trangthai == false)
                    {
                        kq = "Không có hoặc đã xóa mã nhân viên này!!!";
                    }
                    nv.trangthai = false;
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Xóa thành công!";
                    }
                    else
                    {
                        kq = "Chưa xóa thành công!";
                    }
                }
                else
                {
                    kq = "Không có hoặc đã xóa mã nhân viên này!!!";
                }
            }
            return kq;
        }
        public string SuaNhanVien(string ID, string TenNV, string gt, string CMND, string SDT, string DiaChi, string ngaysinh, string loainv)
        {
            string kq = "Chưa sửa được!";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTNhanVien(ID))
                {
                    var nv = qlcf.tb_Nhanvien.Where(m => m.manv == ID).SingleOrDefault() as tb_Nhanvien;
                    if (TenNV != "")
                    {
                        nv.tennv = TenNV;
                    }
                    DateTime ngsinh;
                    if (ngaysinh != "")
                    {
                        if (DateTime.TryParse(ngaysinh, out ngsinh) == false)
                        {
                            ngaysinh = "23/06/1996";
                        }
                        nv.ngaysinh = DateTime.Parse(ngaysinh);
                    }

                    if (CMND!= "")
                    {
                        nv.cmnd = CMND;
                    }
                    if (DiaChi!= "")
                    {
                        nv.diachi = DiaChi;
                    }
                    if (SDT != "")
                    {
                        nv.sdt = SDT;
                    }
                    if (gt != "")
                        nv.gioitinh = gt;
                    if (loainv != "")
                        nv.loainv = loainv;
                        if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Sửa thành công!";
                    }
                    else
                    {
                        kq = "Chưa sửa thành công!";
                    }
                }
                else
                {
                    kq = "Không có hoặc đã xóa mã nhân viên này!!!";
                }
            }
            return kq;
        }
    }
}
