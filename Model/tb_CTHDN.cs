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
    
    public partial class tb_CTHDN
    {
        public string mahdn { get; set; }
        public string tensp { get; set; }
        public Nullable<int> soluong { get; set; }
        public Nullable<double> dongia { get; set; }
        public string mancc { get; set; }
        public Nullable<double> thanhtien { get; set; }
    
        public virtual tb_HDN tb_HDN { get; set; }
        public virtual tb_NCC tb_NCC { get; set; }
    }
}
