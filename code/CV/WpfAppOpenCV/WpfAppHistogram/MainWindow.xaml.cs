using OpenCvSharp;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppHistogram
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Mat src = Cv2.ImRead("cat.jpg");
            Mat gray = new Mat();
            Mat hist = new Mat();

            Mat result = Mat.Ones(new OpenCvSharp.Size(256, src.Height), MatType.CV_8UC1);
            Mat dst = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            Cv2.CalcHist(new Mat[] {gray}, new int[] {0}, null, hist, 1, new int[] {256}, 
                new Rangef[] {new Rangef(0,256)});

            Cv2.Normalize(hist, hist, 0,255, NormTypes.MinMax);

            for (int i = 0; i < hist.Rows; i++)
            {
                Cv2.Line(result, new OpenCvSharp.Point(i, src.Height), 
                    new OpenCvSharp.Point(i, src.Height - hist.Get<float>(i)* src.Height*0.5), Scalar.White);
                Console.WriteLine(hist.Get<float>(i));
            }

            Cv2.HConcat(new Mat[] { gray, result }, dst);
            //Cv2.Resize(dst, dst, new OpenCvSharp.Size(600, 600));
            Cv2.NamedWindow("dst", WindowFlags.Normal);
            Cv2.ImShow("dst", dst);

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
