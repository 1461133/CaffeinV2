﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class HoaDonNhap
    {
        public bool KTHoaDon(string ID)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_HDN.Where(m => m.mahdn == ID).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public double? LayTongTien(string _mahdn)
        {
            double? kq = 0;
            using (var qlcf = new QL_QuancapheEntities())
            {
                var hbn = qlcf.tb_HDN.Where(m => m.mahdn == _mahdn).SingleOrDefault();
                kq = hbn.tongtien;
            }

            return kq;
        }
        public tb_HDN LayHDN(string _mahdn)
        {
            tb_HDN hdn;
            using (var qlcf = new QL_QuancapheEntities())
            {
                hdn = qlcf.tb_HDN.Where(m => m.mahdn == _mahdn).SingleOrDefault();
            }
            return hdn;
        }
        public string ThemHoaDon(string _mahdn, string _manv, string _mancc)
        {
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTHoaDon(_mahdn) == false)
                {
                    var hdn = new tb_HDN { mahdn = _mahdn, mancc = _mancc, manv = _manv, ngaynhap = DateTime.Now, tongtien = 0 };
                    qlcf.tb_HDN.Add(hdn);
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã có thêm hóa đơn nhập mới rồi ^^";
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