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
    
    public partial class tb_HDN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_HDN()
        {
            this.tb_CTHDN = new HashSet<tb_CTHDN>();
        }
    
        public string mahdn { get; set; }
        public Nullable<System.DateTime> ngaynhap { get; set; }
        public string manv { get; set; }
        public Nullable<double> tongtien { get; set; }
        public Nullable<bool> trangthai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_CTHDN> tb_CTHDN { get; set; }
        public virtual tb_Nhanvien tb_Nhanvien { get; set; }
    }
}
