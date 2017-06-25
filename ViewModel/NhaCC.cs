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
        public bool KTNhaCCTT(string ID)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_NCC.Where(m => m.mancc == ID && m.trangthai ==true).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public List<tb_NCC> LayAllNCC()
        {
            List<tb_NCC> dsncc;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dsncc = qlcf.tb_NCC.ToList();
            }
            return dsncc;
        }
        public List<tb_NCC> LayNCC()
        {
            List<tb_NCC> dsncc;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dsncc = qlcf.tb_NCC.Where(m=>m.trangthai==true).ToList();
            }
            return dsncc;
        }
        public string ThemNhaCC(string manhacc, string tennhacc, string dc,string dt )
        {
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTNhaCC(manhacc) == false)
                {

                    var ncc = new tb_NCC { mancc = manhacc, tenncc = tennhacc, diachi = dc, sdt = dt, trangthai = true };
                    qlcf.tb_NCC.Add(ncc);
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã có thêm sản phẩm mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa thêm được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã nhà cung cấp trùng hoặc đã từng có rồi nhá - _ - ";
                }

            }
            return kq;
        }
        public string SuaNhaCC(string manhacc, string tennhacc, string dc, string dt)
        {
            string kq = "Chưa sửa được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTNhaCCTT(manhacc) == true)
                {
                    var ncc = qlcf.tb_NCC.Where(m => m.mancc == manhacc).SingleOrDefault();
                    if(tennhacc !="")
                    {
                        ncc.tenncc = tennhacc;
                    }
                    if(dc!= "")
                    {
                        ncc.diachi = dc;
                    }
                    if(dt!="")
                    {
                        ncc.sdt = dt;
                    }
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã có sửa sản phẩm mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa sửa được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã nhà cung cấp sai hoặc đã xóa nhá - _ - ";
                }

            }
            return kq;
        }
        public string XoaNhaCC(string manhacc)
        {
            string kq = "Chưa xóa được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTNhaCCTT(manhacc) == false)
                {
                    var ncc = qlcf.tb_NCC.Where(m => m.mancc == manhacc).SingleOrDefault();
                    ncc.trangthai = false;
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã có xóa  sản phẩm mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa xóa được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã nhà cung cấp trùng hoặc đã từng có rồi nhá - _ - ";
                }

            }
            return kq;
        }
        public string PhucHoiNhaCC(string manhacc)
        {
            string kq = "Chưa phục hồi được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTNhaCC(manhacc) == false)
                {
                    var ncc = qlcf.tb_NCC.Where(m => m.mancc == manhacc).SingleOrDefault();
                    if(ncc.trangthai == false)
                    {
                        ncc.trangthai = false;
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = "Đã có phục hồi sản phẩm mới rồi ^^";
                        }
                        else
                        {
                            kq = "Chưa phục hồi được, buồn quá đi TT.TT";
                        }
                    }
                    else
                    {
                        kq = "Nhà cung cấp đã có rồi ^^";
                    }
                }
                else
                {
                    kq = "Mã nhà cung cấp trùng hoặc đã từng có rồi nhá - _ - ";
                }

            }
            return kq;
        }
    }
}
