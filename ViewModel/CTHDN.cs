using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class CTHDN
    {
        public bool KTKSanPham(string _mahdn, string _tensp)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_CTHDN.Where(m => m.mahdn == _mahdn && m.tensp == _tensp).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public List<tb_CTHDN> LayALLCTHDN(string _mahdn)
        {
            List<tb_CTHDN> dscthdn;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dscthdn = qlcf.tb_CTHDN.Where(m => m.mahdn == _mahdn).ToList();
            }
            return dscthdn;
        }
        public List<View_CTHDN> LayViewCTHDN(string _mahdn)
        {
            List<View_CTHDN> dscthdn;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dscthdn = qlcf.View_CTHDN.Where(m => m.mahdn == _mahdn).ToList();
            }
            return dscthdn;
        }
        public string ThemSanPham(string _mahdn, string _tensp, int sl, float dongia, object ncc)
        {
            var nhaccc = ncc as tb_NCC;
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if(KTKSanPham(_mahdn,_tensp)==false)
                {

                    var cthdn = new tb_CTHDN { mahdn = _mahdn, tensp = _tensp, soluong = sl, thanhtien = dongia * sl };
                    qlcf.tb_CTHDN.Add(cthdn);
                    HoaDonNhap hdn = new HoaDonNhap();
                    hdn.CapNhapTT(_mahdn, dongia * sl, 0);
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã có thêm thức uống mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa thêm được, buồn quá đi TT.TT";
                    }
                }
            }
            return kq;
        }

    }
}
