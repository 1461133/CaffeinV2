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
    
    public partial class tb_HDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_HDB()
        {
            this.tb_CTHDB = new HashSet<tb_CTHDB>();
        }
    
        public string mahdb { get; set; }
        public Nullable<System.DateTime> ngayban { get; set; }
        public string manv { get; set; }
        public string makh { get; set; }
        public Nullable<double> tongtien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_CTHDB> tb_CTHDB { get; set; }
        public virtual tb_Khachhang tb_Khachhang { get; set; }
        public virtual tb_Nhanvien tb_Nhanvien { get; set; }
    }
}
