using CrystalDecisions.CrystalReports.Engine;
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
using Model;

namespace ProductsReport
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
        }

        

        private void CrystalReportViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //ReportDocument rd = new ReportDocument();
                //rd.Load("C:/Users/Tuan Nguyen/Desktop/HKII - năm 3/LTUD2/Đồ án cafe/GIT/CaffeinV2/ProductsReport/MyReport.rpt");
                //using (QL_QuancapheEntities context = new QL_QuancapheEntities())
                //{
                //    var q = (from c in context.tb_Sanpham
                //             join p in context.tb_Loai
                //             on c.maloai equals p.maloai
                //             select new
                //             {
                //                 c.masp
                //             }).ToList();
                //    rd.SetDataSource(q);

                //    //CrystalReportViewer1.ViewerCore.ReportSource = rd;
                //}

                ReportDocument rd = new ReportDocument();
                rd.Load("C:/Users/ASUS/Source/Repos/CaffeinV2/ProductsReport/MyReport.rpt");
                using (QL_QuancapheEntities context = new QL_QuancapheEntities())
                {
                    var q = (from c in context.tb_Sanpham
                             join p in context.tb_Loai
                             on c.maloai equals p.maloai
                             select new
                             {
                                 //c.maloai,
                                 c.masp,
                                 c.tensp,
                                 c.maloai

                                 //p.tenloai,

                             }).ToList();
                    rd.SetDataSource(q);
                    //   CrystalReportViewer1.ViewerCore.ReportSource = rd;
            //        CrystalReportViewer1.ViewerCore.ReportSource = rd;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
