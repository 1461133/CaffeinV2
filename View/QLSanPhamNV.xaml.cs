using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for QLSanPhamNV.xaml
    /// </summary>
    public partial class QLSanPhamNV : Window
    {
        private ObservableCollection<UIControlInfo> userControls = new ObservableCollection<UIControlInfo>();
        public IEnumerable<UIControlInfo> Controls
        {
            get
            {
                return userControls;
            }
        }
        public string TENDN;
        public QLSanPhamNV()
        {
            InitializeComponent();

        }
        public QLSanPhamNV(string tendn)
        {
            InitializeComponent();
            TENDN = tendn;
            QLSanPhamNVus tam1 = new QLSanPhamNVus(TENDN);
            //tam.DataContext = tam1;
            userControls.Add(new UIControlInfo { Title = "", Content = tam1});

        }
    }
}
