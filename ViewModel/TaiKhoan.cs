using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TaiKhoan
    {
        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public List<tb_User> LayAllTaiKhoan()
        {
            List<tb_User> dstk;
            using (var qlcf = new QL_QuancapheEntities())
            {
                dstk = qlcf.tb_User.Where(m => m.trangthai == true).ToList();
            }
            return dstk;
        }
        public bool KTTaiKhoan(string username)
        {
            using (var qlcf = new Model.QL_QuancapheEntities())
            {
                int n = qlcf.tb_User.Where(m => m.Username == username).Count();
                if (n > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int DangNhap (string username, string pass)
        {
            int kq = 0;
            using (var qlcf = new QL_QuancapheEntities())
            {
                if(KTTaiKhoan(username) == false)
                {
                    kq = 0;
                }
                else
                {
                    string trans = CreateMD5(pass);
                    var tk = qlcf.tb_User.Where(m => m.Username == username && m.Password == trans).SingleOrDefault() as tb_User;
                    if (tk.trangthai == false)
                    {
                        kq = 0;
                    }
                    else
                    {
                        kq = 1;
                    }
                }
            }
            return kq;
        }
        public int ThemTaiKhoan(string username, string pass)
        {
            int kq = 0;
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTTaiKhoan(username) == false)
                {
                    
                    var tk = new tb_User { Username = username, Password = CreateMD5(pass), trangthai = true };
                    qlcf.tb_User.Add(tk);
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
        public int SuaTaiKhoan(string username, string pass)
        {
            int kq = 0;
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTTaiKhoan(username))
                {
                    var tk = qlcf.tb_User.Where(m => m.Username == username).SingleOrDefault() as tb_User;
                    if (tk.trangthai == false)
                    {
                        kq = 0;
                    }
                    else
                    {
                       
                        if (pass != "")
                        {
                            tk.Password = CreateMD5(pass);
                        }
                        
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = 1;
                        }
                        else
                        {
                            kq = 0;
                        }
                    }
                }
                else
                {
                    kq = 0;
                }

            }
            return kq;
        }

        public int XoaTaiKhoan(string username)
        {
            int kq = 0;
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTTaiKhoan(username))
                {
                    var tk = qlcf.tb_User.Where(m => m.Username == username).SingleOrDefault() as tb_User;
                    if (tk.trangthai == false)
                    {
                        kq = 0;
                    }
                    else
                    {
                        tk.trangthai = false;
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = 1;
                        }
                        else
                        {
                            kq = 0;
                        }
                    }
                }
                else
                {
                    kq = 0;
                }
            }
            return kq;
        }
        public int PhucHoiTaiKhoan(string username)
        {
            int kq = 0;
            using (var qlcf = new QL_QuancapheEntities())
            {
                if (KTTaiKhoan(username))
                {
                    var tk = qlcf.tb_User.Where(m => m.Username == username).SingleOrDefault() as tb_User;
                    if (tk.trangthai == true)
                    {
                        kq = 0;
                    }
                    else
                    {
                        tk.trangthai = true;
                        if (qlcf.SaveChanges() > 0)
                        {
                            kq = 1;
                        }
                        else
                        {
                            kq = 0;
                        }
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
