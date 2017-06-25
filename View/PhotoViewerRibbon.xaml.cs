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
    /// Interaction logic for PhotoViewerRibbon.xaml
    /// </summary>
    public partial class PhotoViewerRibbon : Window
    {
        public PhotoViewerRibbon()
        {
            InitializeComponent();
        }
        private void zoom_out_MouseUp(object sender, MouseButtonEventArgs e)
        {
            image.Width -= 50;
            image.Height -= 50;
        }

        private void zoom_in_MouseUp(object sender, MouseButtonEventArgs e)
        {
            image.Width += 50;
            image.Height += 50;
        }
    }
}
