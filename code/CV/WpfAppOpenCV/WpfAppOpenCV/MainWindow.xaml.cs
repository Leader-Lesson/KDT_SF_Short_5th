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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenCvSharp;

namespace WpfAppOpenCV
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            textBlock.Text = Cv2.GetVersionString();

            Mat image = Cv2.ImRead("cat.jpg");
            //Cv2.ImShow("Image Test", image);
            imageBox.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(image);

            showServeralImages();
        }

        void showServeralImages()
        {
            Mat image = Cv2.ImRead("cat.jpg");
            Mat target2 = new Mat();
            Cv2.CvtColor(image, target2, ColorConversionCodes.BGR2GRAY);
            imageBox2.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(target2);

            Mat target3 = new Mat();
            Cv2.CvtColor(image, target3, ColorConversionCodes.BGR2RGB);
            imageBox3.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(target3);

            Mat target4 = new Mat();
            Cv2.CvtColor(image, target4, ColorConversionCodes.BGR2YUV);
            imageBox4.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(target2);

            Mat target5 = new Mat();
            Cv2.CvtColor(image, target5, ColorConversionCodes.BGR2HSV);
            imageBox5.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(target5);

            Mat target6 = new Mat();
            Cv2.CvtColor(image, target6, ColorConversionCodes.RGB2BGR);
            imageBox6.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(target6);
        }
    }
}
