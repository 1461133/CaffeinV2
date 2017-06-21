using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class HoaDonBan
    {
        public bool KTHoaDon(string ID)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_HDB.Where(m => m.mahdb == ID).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public double? LayTongTien(string _mahdb)
        {
            double? kq = 0;
            using (var qlcf = new QL_QuancapheEntities())
            {
                var hbd = qlcf.tb_HDB.Where(m => m.mahdb == _mahdb).SingleOrDefault();
                kq = hbd.tongtien;
            }
            
            return kq;
        }
        public void CapNhapTT(string _mahdb, double? tt, double? tx)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                var hbd = qlcf.tb_HDB.Where(m => m.mahdb == _mahdb).SingleOrDefault();
                hbd.tongtien = hbd.tongtien + tt - tx;
                qlcf.SaveChanges();
            }

        }
        public tb_HDB LayHDB(string _mahdb)
        {
            tb_HDB hbd;
            using (var qlcf = new QL_QuancapheEntities())
            {
                hbd = qlcf.tb_HDB.Where(m => m.mahdb == _mahdb).SingleOrDefault();
            }
            return hbd;
        }
        public List<tb_HDB> LayHDB()
        {
            List<tb_HDB> dshdb;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dshdb = qlcf.tb_HDB.ToList();
            }
            return dshdb;
        }
        public string ThemHoaDon(string _mahdb, string _manv, string _makh)
        {
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTHoaDon(_mahdb) == false)
                {
                    var hdb = new tb_HDB { mahdb = _mahdb, makh = _makh, manv = _manv, ngayban = DateTime.Now, tongtien=0 };
                    qlcf.tb_HDB.Add(hdb);
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã có thêm hóa đơn bán mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa thêm được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã hóa đơn trùng rồi nhá -_- Đợi ít phút nào";
                }

            }
            return kq;
        }
    }
}
