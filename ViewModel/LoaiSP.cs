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
    }
}
