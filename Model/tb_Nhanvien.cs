//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tb_Nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Nhanvien()
        {
            this.tb_HDB = new HashSet<tb_HDB>();
            this.tb_HDN = new HashSet<tb_HDN>();
        }
    
        public string manv { get; set; }
        public string tennv { get; set; }
        public string diachi { get; set; }
        public string gioitinh { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string cmnd { get; set; }
        public Nullable<bool> trangthai { get; set; }
        public string sdt { get; set; }
        public string loainv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_HDB> tb_HDB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_HDN> tb_HDN { get; set; }
    }
}
