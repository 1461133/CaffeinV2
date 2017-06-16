using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class SanPhamvLoaiSP
    {
        // Sử dụng Eager loading 
        public void LaySPLoai1()
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                var spl = qlcf.tb_Sanpham.Include("tb_Loai").Where(m=> m.maloai=="001").ToList();
            }
        }
        // Extension method
        public static string GetName(tb_Sanpham sp, tb_Loai lsp)
        {
            return sp.tensp + " - " + lsp.tenloai;
        }

    }
}
