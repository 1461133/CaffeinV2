using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
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
    public partial class PhotoViewerRibbon : RibbonWindow
    {
        public PhotoViewerRibbon()
        {
            InitializeComponent();
        }
        private void OnClose(object sender, ExecutedRoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }



        //private static RoutedUICommand zoomin;
        //public static ICommand ZoomIn
        //{
        //    set
        //    {
                
        //        //return zoomin ?? (zoomin = new RoutedUICommand("Show Book", "ShowBook", typeof(PhotoViewerRibbon)));
        //    }
        //}
        private void OnZoomIn(object sender, RoutedEventArgs e)
        {
            imaHien.Width += 50;
            imaHien.Height += 50;

        }
        private void onclickitem1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
        }
        private void onclickitem2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("C:/Users/Tuan Nguyen/Desktop/HKII - năm 3/LTUD2/LT/1461133/1461133/image/2.png");
            bi3.EndInit();
            imaHien.Stretch = Stretch.Fill;

            imaHien.Source = bi3;
        }
        private void onclickitem3(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("C:/Users/Tuan Nguyen/Desktop/HKII - năm 3/LTUD2/LT/1461133/1461133/image/3.png");
            bi3.EndInit();
            imaHien.Stretch = Stretch.Fill;

            imaHien.Source = bi3;
        }
        private void onclickitem4(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("C:/Users/Tuan Nguyen/Desktop/HKII - năm 3/LTUD2/LT/1461133/1461133/image/4.jpg");
            bi3.EndInit();
            imaHien.Stretch = Stretch.Fill;

            imaHien.Source = bi3;
        }
        private void onclickitem5(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("C:/Users/Tuan Nguyen/Desktop/HKII - năm 3/LTUD2/LT/1461133/1461133/image/5.jpg");
            bi3.EndInit();
            imaHien.Stretch = Stretch.Fill;

            imaHien.Source = bi3;
        }

        private void onclickitem6(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("C:/Users/Tuan Nguyen/Desktop/HKII - năm 3/LTUD2/LT/1461133/1461133/image/6.jpg");
            bi3.EndInit();
            imaHien.Stretch = Stretch.Fill;

            imaHien.Source = bi3;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
