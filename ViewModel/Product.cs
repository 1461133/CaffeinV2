using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class Product
    {
        public string masp { get; set; }
        public string tensp { get; set; }
        public Nullable<double> gianhap { get; set; }
        public Nullable<double> giaban { get; set; }
        public Nullable<int> soluong { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2}) ", masp, tensp, soluong);
        }
    }
}
