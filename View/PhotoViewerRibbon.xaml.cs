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
        public string TENDN;
        public PhotoViewerRibbon(string ten)
        {
            InitializeComponent();
            TENDN = ten;
        }
        private void OnClose(object sender, ExecutedRoutedEventArgs e)
        {

            //Application.Current.Shutdown();
            this.Close();
        }
        

        private void OnZoomIn(object sender, RoutedEventArgs e)
        {
            imaHien.Width += 50;
            imaHien.Height += 50;

        }
        private void onclickitem1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@"pack://application:,,,/images/AppleJuice.jpg");
                bi3.EndInit();
                imaHien.Stretch = Stretch.Fill;

                imaHien.Source = bi3;
            }
            catch
            {

            }
        }
        private void onclickitem2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@"pack://application:,,,/images/CaramelMilkTea.jpg");
                bi3.EndInit();
                imaHien.Stretch = Stretch.Fill;

                imaHien.Source = bi3;
            }
            catch
            {  }
        }
        private void onclickitem3(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@"pack://application:,,,/images/ChocomintBlended.jpg");
                bi3.EndInit();
                imaHien.Stretch = Stretch.Fill;

                imaHien.Source = bi3;
            }
            catch { }
        }
        private void onclickitem4(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@"pack://application:,,,/images/CoffeeMocha.jpg");
                bi3.EndInit();
                imaHien.Stretch = Stretch.Fill;

                imaHien.Source = bi3;
            }
            catch
            {

            }
        }
        private void onclickitem5(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@"pack://application:,,,/images/GreenMilkTea.jpg");
                bi3.EndInit();
                imaHien.Stretch = Stretch.Fill;

                imaHien.Source = bi3;
            }
            catch { }
        }

        private void onclickitem6(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@"pack://application:,,,/images/HotEspresso.jpg");
                bi3.EndInit();
                imaHien.Stretch = Stretch.Fill;

                imaHien.Source = bi3;
            }
            catch { }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void RibbonWindow_Closed(object sender, EventArgs e)
        {
            TCKhachHang kh = new TCKhachHang(TENDN);
            kh.Show();
        }
    }
}
