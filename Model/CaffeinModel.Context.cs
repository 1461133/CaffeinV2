﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QL_QuancapheEntities : DbContext
    {
        public QL_QuancapheEntities()
            : base("name=QL_QuancapheEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tb_CTHDB> tb_CTHDB { get; set; }
        public virtual DbSet<tb_CTHDN> tb_CTHDN { get; set; }
        public virtual DbSet<tb_HDB> tb_HDB { get; set; }
        public virtual DbSet<tb_HDN> tb_HDN { get; set; }
        public virtual DbSet<tb_Khachhang> tb_Khachhang { get; set; }
        public virtual DbSet<tb_Loai> tb_Loai { get; set; }
        public virtual DbSet<tb_NCC> tb_NCC { get; set; }
        public virtual DbSet<tb_Nhanvien> tb_Nhanvien { get; set; }
        public virtual DbSet<tb_Sanpham> tb_Sanpham { get; set; }
        public virtual DbSet<tb_User> tb_User { get; set; }
        public virtual DbSet<View_AllKhachHang> View_AllKhachHang { get; set; }
        public virtual DbSet<View_AllLoai> View_AllLoai { get; set; }
        public virtual DbSet<View_AllNCC> View_AllNCC { get; set; }
        public virtual DbSet<View_AllNhanVien> View_AllNhanVien { get; set; }
        public virtual DbSet<View_AllSanPham> View_AllSanPham { get; set; }
        public virtual DbSet<View_AllUser> View_AllUser { get; set; }
        public virtual DbSet<View_CTHDB> View_CTHDB { get; set; }
        public virtual DbSet<View_CTHDN> View_CTHDN { get; set; }
        public virtual DbSet<View_InHoaDon> View_InHoaDon { get; set; }
        public virtual DbSet<View_KhachHang> View_KhachHang { get; set; }
        public virtual DbSet<View_KhachHangXoa> View_KhachHangXoa { get; set; }
        public virtual DbSet<View_Loai> View_Loai { get; set; }
        public virtual DbSet<View_LoaiXoa> View_LoaiXoa { get; set; }
        public virtual DbSet<View_NCC> View_NCC { get; set; }
        public virtual DbSet<View_NCCXoa> View_NCCXoa { get; set; }
        public virtual DbSet<View_NhanVien> View_NhanVien { get; set; }
        public virtual DbSet<View_NhanVienXoa> View_NhanVienXoa { get; set; }
        public virtual DbSet<View_SanPham> View_SanPham { get; set; }
        public virtual DbSet<View_SanPhamXoa> View_SanPhamXoa { get; set; }
        public virtual DbSet<View_User> View_User { get; set; }
        public virtual DbSet<View_UserXoa> View_UserXoa { get; set; }
    }
}
