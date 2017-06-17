using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstReport
{
    public partial class frmCrystalReport : Form
    {
        public frmCrystalReport()
        {
            InitializeComponent();
        }

        private void frmCrystalReport_Load(object sender, EventArgs e)
        {
            ProductsList rpt = new ProductsList();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
