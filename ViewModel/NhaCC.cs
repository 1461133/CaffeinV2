using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class NhaCC
    {
        public bool KTNhaCC(string ID)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_NCC.Where(m => m.mancc == ID).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int ThemNhaCC(string manhacc, string tennhacc, string dc,string dt )
        {
            int kq = 0;
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTNhaCC(manhacc) == false)
                {

                    var ncc = new tb_NCC { mancc = manhacc, tenncc = tennhacc, diachi = dc, sdt = dt, trangthai = true };
                    qlcf.tb_NCC.Add(ncc);
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = 1;
                    }
                    else
                    {
                        kq = 0;
                    }
                }
                else
                {
                    kq = 0;
                }

            }
            return kq;
        }

    }
}
