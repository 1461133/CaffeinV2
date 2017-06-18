using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CTHDB
    {
        public bool KTKSanPham(string _mahdb, string _masp)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_CTHDB.Where(m => m.mahdb == _mahdb && m.masp == _masp).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public List<tb_CTHDB> LayALLCTHDB(string _mahdb)
        {
            List<tb_CTHDB> dscthdb;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dscthdb= qlcf.tb_CTHDB.Where(m => m.mahdb == _mahdb).ToList();
            }
            return dscthdb;
        }
        public List<View_CTHDB> LayViewCTHDB(string _mahdb)
        {
            List<View_CTHDB> dscthdb;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dscthdb = qlcf.View_CTHDB.Where(m=>m.mahdb == _mahdb).ToList();
            }
            return dscthdb;
        }
        public string ThemSanPham(string _mahdb, object tam, int sl)
        {
            var sp = tam as tb_Sanpham;
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (sl > sp.soluong || sl ==0)
                {
                    kq = "Số lượng mua phải nhỏ hơn số lượng có nhá -_-";
                }
                else
                {
                    if (KTKSanPham(_mahdb, sp.masp) == false)
                    {
                        var tt = sl * sp.giaban;
                        var cthdb = new tb_CTHDB { mahdb = _mahdb, masp = sp.masp, soluong = sl, thanhtien =tt  };
                        qlcf.tb_CTHDB.Add(cthdb);
                        HoaDonBan hdb = new HoaDonBan();
                        hdb.CapNhapTT(_mahdb, tt, 0);
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = "Đã có thêm thức uống mới rồi ^^";
                        }
                        else
                        {
                            kq = "Chưa thêm được, buồn quá đi TT.TT";
                        }
                    }
                    else
                    {
                        var cthdb = qlcf.tb_CTHDB.Where(m => m.mahdb == _mahdb && m.masp == sp.masp).SingleOrDefault();
                        if(sp.soluong < cthdb.soluong + sl)
                        {
                            kq = "Số lượng mua phải nhỏ hơn số lượng có nhá -_-";
                        }
                        else
                        {
                            cthdb.thanhtien = (cthdb.soluong + sl) * sp.giaban;
                            HoaDonBan hdb = new HoaDonBan();
                            hdb.CapNhapTT(_mahdb, sl * sp.giaban, 0);
                            cthdb.soluong = cthdb.soluong + sl;
                            
                            if (qlcf.SaveChanges() > 0)
                            {
                                kq = "Đã có thêm số lượng thức uống mới rồi ^^";
                            }
                            else
                            {
                                kq = "Chưa thêm được, buồn quá đi TT.TT";
                            }
                        }
                        
                    }

                }
            }
            return kq;
        }
        public string SuaSanPham(string _mahdb, object tam, int sl)
        {
            var sp = tam as tb_Sanpham;
            string kq = "Chưa sửa được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (sl > sp.soluong)
                {
                    kq = "Số lượng mua phải nhỏ hơn số lượng có nhá -_-";
                }
                else
                {
                    if (KTKSanPham(_mahdb, sp.masp))
                    {
                        var cthdb = qlcf.tb_CTHDB.Where(m => m.mahdb == _mahdb && m.masp == sp.masp).SingleOrDefault();
                        cthdb.thanhtien = (sl) * sp.giaban;
                        if(cthdb.soluong > sl)
                        {
                            HoaDonBan hdb = new HoaDonBan();
                            hdb.CapNhapTT(_mahdb, 0, (cthdb.soluong - sl) * sp.giaban);
                        }
                        else
                        {
                            HoaDonBan hdb = new HoaDonBan();
                            hdb.CapNhapTT(_mahdb, (sl - cthdb.soluong) * sp.giaban,0);
                        }
                        cthdb.soluong = sl;
                       
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = "Đã sửa số lượng thức uống mới rồi ^^";
                        }
                        else
                        {
                            kq = "Chưa sửa được, buồn quá đi TT.TT";
                        }
                    }
                    else
                    {
                        kq = "Mã sản phẩm sai hoặc đã xóa rồi nhá -_-";
                    }
                }

            }
            return kq;
        }
        public string XoaSanPham(string _mahdb, object tam)
        {
            var sp = tam as tb_Sanpham;
            string kq = "Chưa xóa được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKSanPham(_mahdb, sp.masp))
                {
                    var cthdb = qlcf.tb_CTHDB.Where(m => m.mahdb == _mahdb && m.masp == sp.masp).SingleOrDefault();
                    HoaDonBan hdb = new HoaDonBan();
                    hdb.CapNhapTT(_mahdb, 0, cthdb.thanhtien);
                    qlcf.tb_CTHDB.Remove(cthdb);
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã xóa thức uống rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa xóa được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã sản phẩm sai -_-";
                }

            }
            return kq;
        }
    }
}
