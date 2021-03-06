﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;

namespace ViewModel
{
    
    public class SanPham
    {       
        public bool KTKSanPham(string ID)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_Sanpham.Where(m => m.masp == ID).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public bool KTKSanPhamTT(string ID)
        {
            using (var qlcf = new QL_QuancapheEntities())
            {
                int n = qlcf.tb_Sanpham.Where(m => m.masp == ID && m.trangthai==true).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public tb_Sanpham LaySP(string ID)
        {
            tb_Sanpham sp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                sp = qlcf.tb_Sanpham.Where(m => m.masp == ID).Single() as tb_Sanpham;
            }
            return sp;
        }
        public List<View_AllSanPham> TKSanPham(string ID, object Loai, string Ten)
        {
            List< View_AllSanPham > dssp =null;
            using (var qlcf = new QL_QuancapheEntities())
            {
                // ưu tiên lấy mã khách hàng
                if (ID != "")
                {
                    dssp = qlcf.View_AllSanPham.Where(m => m.masp == ID).ToList();
                    return dssp;
                }
                else
                {
                    if (Ten != "")
                    {
                        dssp = qlcf.View_AllSanPham.Where(m => m.tensp.Contains(Ten)).ToList();
                        return dssp;

                    }
                    if (Loai != null)
                    {
                        var lsp = Loai as tb_Loai;
                        dssp = qlcf.View_AllSanPham.Where(m => m.tenloai == lsp.tenloai).ToList();
                        return dssp;
                    }
                }

            }
            return dssp;
            //totalPage = (int)Math.Ceiling(dssp.Count() * 1.0 / pageSize);
            //return dssp.OrderByDescending(m => m.masp)
            //    .Skip((curPage - 1) * pageSize)
            //    .Take(pageSize).ToList();
        }
        public List<tb_Sanpham> LayAllSP()
        {
            List<tb_Sanpham> dssp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dssp = qlcf.tb_Sanpham.Where(m => m.trangthai == true).ToList();
            }
            
            return dssp;
        }
        public List<tb_Sanpham> LaySPTheoLoai(object loai)
        {
            var lsp = loai as tb_Loai;
            List<tb_Sanpham> dssp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dssp = qlcf.tb_Sanpham.Where(m => m.trangthai == true && m.maloai==lsp.maloai).ToList();
            }

            return dssp;
        }
        public List<View_SanPham> LayViewSP()
        {
            List<View_SanPham> dssp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dssp = qlcf.View_SanPham.ToList();


            }
            
            return dssp;
        }
        public List<View_SanPham> LayViewSP(int curPage, int pageSize, out int totalPage)
        {
            List<View_SanPham> dssp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dssp = qlcf.View_SanPham.OrderByDescending(m => m.masp).ToList();
            }
            totalPage = (int)Math.Ceiling(dssp.Count() * 1.0 / pageSize);
            return dssp.OrderByDescending(m => m.masp)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public List<View_SanPhamXoa> LayViewSPXoa(int curPage, int pageSize, out int totalPage)
        {
            List<View_SanPhamXoa> dssp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dssp = qlcf.View_SanPhamXoa.OrderByDescending(m => m.masp).ToList();
            }
            totalPage = (int)Math.Ceiling(dssp.Count() * 1.0 / pageSize);
            return dssp.OrderByDescending(m => m.masp)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public List<View_AllSanPham> LayViewSPAll(int curPage, int pageSize, out int totalPage)
        {
            List<View_AllSanPham> dssp;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dssp = qlcf.View_AllSanPham.OrderByDescending(m => m.masp).ToList();
            }
            totalPage = (int)Math.Ceiling(dssp.Count() * 1.0 / pageSize);
            return dssp.OrderByDescending(m => m.masp)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
        public byte[] ImageToBinary(string imagePath)
        {
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            fileStream.Close();
            return buffer;
        }
        public string ThemSanPham(string ID, string TenSP, string mlsp, string Gianhap, string Giaban, string Soluong, string Hinhanh)
        {
            string kq = "Chưa thêm được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKSanPham(ID) == false)
                {
                    float tam = 10;
                    int sl = 10;
                    if (int.TryParse(Soluong, out sl) == false)
                    {
                        Soluong = "10";
                    }
                    if (float.TryParse(Giaban, out tam) == false)
                    {
                        Giaban = "100";
                    }
                    if (float.TryParse(Gianhap, out tam) == false)
                    {
                        Gianhap = "100";
                    }
                    
                    var sp = new tb_Sanpham { masp = ID, tensp = TenSP, maloai = mlsp, giaban = float.Parse(Giaban), gianhap = float.Parse(Gianhap), soluong = int.Parse(Soluong), trangthai = true, hinhanh = File.ReadAllBytes(Hinhanh) };
                
                    qlcf.tb_Sanpham.Add(sp);
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
                    kq = "Mã sản phẩm trùng hoặc đã từng có rồi nhá -_-";
                }
            }
            return kq;
        }
        public string SuaSanPham(string ID, string TenSP, string mlsp, string Gianhap, string Giaban, string Soluong, string Hinhanh)
        {
            string kq = "Chưa cập nhật được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKSanPhamTT(ID))
                {
                    var sp = qlcf.tb_Sanpham.Where(m => m.masp == ID && m.trangthai == true).SingleOrDefault() as tb_Sanpham;
                    float tam = 10;
                    int sl = 10;
                    if (TenSP != "")
                    {
                        sp.tensp = TenSP;
                    }

                    if (Giaban != "")
                    {
                        if (float.TryParse(Giaban, out tam) == false)
                        {
                            Giaban = "100";
                        }
                        sp.giaban = float.Parse(Giaban);
                    }


                    if (Gianhap != "")
                    {
                        if (float.TryParse(Gianhap, out tam) == false)
                        {
                            Gianhap = "100";
                        }
                        sp.gianhap = float.Parse(Gianhap); ;
                    }


                    if (mlsp != "")
                    {
                        sp.maloai = mlsp;
                    }

                    if (Soluong != "" && int.TryParse(Soluong, out sl))
                    {
                        sp.soluong = int.Parse(Soluong);
                    }

                    if (Hinhanh != "")
                    {
                        sp.hinhanh = File.ReadAllBytes(Hinhanh);
                    } 

                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã có cập nhật sản phẩm mới rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa cập nhật được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã sản phẩm sai hoặc đã xóa rồi nhá -_-";
                }
            }
            return kq;
        }
        public string XoaSanPham(string ID)
        {
            string kq = "Chưa cập nhật được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKSanPhamTT(ID))
                {
                    var sp = qlcf.tb_Sanpham.Where(m => m.masp == ID && m.trangthai == true).SingleOrDefault() as tb_Sanpham;
                    sp.trangthai = false;
                    if (qlcf.SaveChanges() > 0)
                    {
                        kq = "Đã xóa sản phẩm rồi ^^";
                    }
                    else
                    {
                        kq = "Chưa xóa được, buồn quá đi TT.TT";
                    }
                }
                else
                {
                    kq = "Mã sản phẩm sai hoặc đã xóa rồi nhá -_-";
                }
            }
            return kq;
        }
        public string PhucHoiSanPham(string ID)
        {
            string kq = "Chưa phục hồi được, buồn quá đi TT.TT";
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTKSanPham(ID))
                {
                    var sp = qlcf.tb_Sanpham.Where(m => m.masp == ID).SingleOrDefault() as tb_Sanpham;
                    if(sp.trangthai == false)
                    {
                        sp.trangthai = true;
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = "Đã phục hồi sản phẩm mới rồi ^^";
                        }
                        else
                        {
                            kq = "Chưa phục hồi được, buồn quá đi TT.TT";
                        }
                    }
                    else
                    {
                        kq = "Sản phẩm đã có rồi ^^";
                    }
                   
                }
                else
                {
                    kq = "Mã sản phẩm sai rồi nhá -_-";
                }
            }
            return kq;
        }
        // Extension method
        public static string GetName(tb_Sanpham sp, tb_Loai lsp)
        {
            return sp.tensp + " - " + lsp.tenloai;
        }
    }
}
