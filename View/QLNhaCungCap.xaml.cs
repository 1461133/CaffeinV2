using System;
using System.Collections.Generic;
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

namespace CAFFEIN
{
    /// <summary>
    /// Interaction logic for QLNhaCungCap.xaml
    /// </summary>
    public partial class QLNhaCungCap : Window
    {
       //private CAFEINDataContext db = new CAFEINDataContext();
        public QLNhaCungCap()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            //this.DataContext = db.tb_NCC.ToList();
        }

        private void BtnThemNCC_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            /*if ((db.tb_NCC.SingleOrDefault(c => c.mancc == txtid.Text)) != null)
            {
                MessageBox.Show("Ma NCC bi trung!!!");
                return;
            }
            db.tb_NCC.Add(new tb_NCC() { mancc = txtid.Text, diachi = txtdc.Text, sdt = txtsdt.Text, tenncc = txtname.Text});
            db.SaveChanges();
            Refresh();*/
        }

        private void BtnSuaNCC_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
           /* var ncc = (tb_NCC) DataGrid.SelectedItem;
            ncc.mancc = txtid.Text;
            ncc.diachi = txtdc.Text;
            ncc.sdt = txtsdt.Text;
            ncc.tenncc = txtname.Text;
            db.SaveChanges();
            Refresh();*/
        }

        private void BtnXoaNCC_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            /*db.tb_NCC.Remove((tb_NCC) DataGrid.SelectedItem);
            db.SaveChanges();
            Refresh();*/
        }
    }
}
