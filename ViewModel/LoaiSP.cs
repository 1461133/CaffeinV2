using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace ViewModel
{
    public class LoaiSP
    {
        public List<tb_Loai> LayAllLoaiSP()
        {
            List<tb_Loai> dslsp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dslsp = qlcf.tb_Loai.ToList();
            }
            return dslsp;
        }
        public List<tb_Loai> LayLoaiSP()
        {
            List<tb_Loai> dslsp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dslsp = qlcf.tb_Loai.Where(m=>m.trangthai==true).ToList();
            }
            return dslsp;
        }
        public List<tb_Loai> LayAllLoaiSPXS()
        {
            List<tb_Loai> dslsp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dslsp = qlcf.tb_Loai.OrderByDescending(m => m.maloai).ToList();
            }
            return dslsp;
        }
        public string LayMaLoaiSP(object loai)
        {
            var tam = loai as tb_Loai;
            string kq = tam.maloai;
            return kq;
        }
        public bool KTTenLoai(string TenLoai)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_Loai.Where(m => m.tenloai == TenLoai).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public bool KTLoaiSP(string ID)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_Loai.Where(m => m.maloai == ID).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public bool KTLoaiSPTT(string ID)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_Loai.Where(m => m.maloai == ID && m.trangthai==true).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public string ThemLoaiSP(string ID, string TenLoai)
        {
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTLoaiSP(ID) == false && KTTenLoai(TenLoai) ==false)
                {
                    var lsp = new tb_Loai { maloai = ID, tenloai = TenLoai, trangthai = true };
                    qlcf.tb_Loai.Add(lsp);
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã thêm loại sản phẩm mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa thêm được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã hoặc loại sản phẩm trùng hoặc đã từng có rồi nhá -_-";
                }
            }
            return kq;
        }
        public string SuaLoaiSP(string ID, string TenLoai)
        {
            string kq = "Chưa sửa được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTLoaiSPTT(ID) == true)
                {
                    var lsp = qlcf.tb_Loai.Where(m => m.maloai == ID).SingleOrDefault();
                    lsp.tenloai = TenLoai;
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã sửa loại sản phẩm mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa sửa được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã loại sản phẩm sai hoặc đã xóa rồi nhá -_-";
                }
            }
            return kq;
        }
        public string XoaLoaiSP(string ID)
        {
            string kq = "Chưa xóa được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTLoaiSPTT(ID) == true)
                {
                    var lsp = qlcf.tb_Loai.Where(m => m.maloai == ID).SingleOrDefault();
                    lsp.trangthai = false;
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã xóa loại sản phẩm mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa xóa được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã loại sản phẩm sai hoặc đã xóa rồi nhá -_-";
                }
            }
            return kq;
        }
        public string PhucHoiLoaiSP(string ID)
        {
            string kq = "Chưa phục hồi được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTLoaiSP(ID) == true)
                {
                    var lsp = qlcf.tb_Loai.Where(m => m.maloai == ID).SingleOrDefault();
                    if(lsp.trangthai == false)
                    {
                        lsp.trangthai = true;
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = "Đã phục hồi loại sản phẩm mới rồi ^^";
                        }
                        else
                        {
                            kq = "Chưa phục hồi được, buồn quá đi TT.TT";
                        }
                    }
                    else
                    {
                        kq = "Loại sản phẩm đã có rồi ^^";
                    }
                }
                else
                {
                    kq = "Mã loại sản phẩm sai hoặc đã xóa rồi nhá -_-";
                }
            }
            return kq;
        }
    }
}
