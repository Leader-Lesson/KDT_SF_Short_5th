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

namespace WpfAppContour
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _contour();
        }

        void _contour()
        {
            Mat src = Cv2.ImRead("pepe.jpg");
            Mat gray = new Mat();
            Mat binary = new Mat();
            Mat morp = new Mat();
            Mat image = new Mat();
            Mat dst = src.Clone();

            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(2,2));
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchies;

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, binary, 100, 255, ThresholdTypes.Binary);
            //Cv2.AdaptiveThreshold(gray, binary, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 11, 2);
            Cv2.MorphologyEx(binary, morp, MorphTypes.Close, kernel, new OpenCvSharp.Point(-1, -1), 1);
            Cv2.BitwiseNot(morp, image);

            Cv2.FindContours(image, out contours, out hierarchies, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);
            Cv2.DrawContours(dst, contours, -1, new Scalar(255, 0, 0), 2, LineTypes.AntiAlias, hierarchies, 3);

            for(int i=0; i< contours.Length; i++)
            {
                for (int j = 0; j < contours[i].Length; j++)
                {
                    Cv2.Circle(dst, contours[i][j], 1, new Scalar(0, 0, 255), 3);
                }
            }
            Cv2.ImShow("dst", dst);
            Cv2.ImShow("gray", gray);
            Cv2.ImShow("binary", binary);
            Cv2.ImShow("morp", morp);
            Cv2.ImShow("image", image);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
