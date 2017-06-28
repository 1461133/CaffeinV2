using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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

namespace View
{
    /// <summary>
    /// Interaction logic for RpInHD.xaml
    /// </summary>
    public partial class RpInHD : Window
    {
        public string mahd;
        public RpInHD(string mahoadon)
        {
            InitializeComponent();
            mahd = mahoadon;
            ReportDocument cryRpt = new ReportDocument();

            cryRpt.Load(@"C:\Users\Tuan Nguyen\Desktop\HKII - năm 3\LTUD2\Đồ án cafe\GIT\CaffeinV2\View\MyReport.rpt");
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = mahd;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["mahdb"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            viewer.ViewerCore.ReportSource = cryRpt;
        }
        
        
    }
}
