using OpenCvSharp;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppOpenCVBasic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //_Vector();
            //_Point2();
            //_Size();
            //_Rect();
            //_RotatedRect();
            //_Mat();
            _Image();
        }

        public void _Vector()
        {
            Vec4d vector1 = new Vec4d(1.0, 2.0, 3.0, 4.0);
            Vec4d vector2 = new Vec4d(1.0, 2.0, 3.0, 4.0);

            textBox.Text = "";
            textBox.Text += vector1.Item0.ToString() + "\r\n";//1
            textBox.Text += vector1[1].ToString() + "\r\n";//2
            textBox.Text += vector1.Equals(vector2).ToString() + "\r\n";//True
        }

        public void _Point1()
        {
            Vec3d vector = new Vec3d(1.0, 2.0, 3.0);
            Point3d pt1 = new Vec3d(1.0, 2.0, 3.0);
            Point3d pt2 = vector;

            textBox.Text += pt1.ToString() + "\r\n";// (x:1, y:2, z:3)
            textBox.Text += pt2.ToString() + "\r\n";// (x:1, y:2, z:3)
            textBox.Text += pt1.X.ToString() + "\r\n";// 1
        }

        public void _Point2()
        {
            OpenCvSharp.Point pt1 = new OpenCvSharp.Point(1, 2);
            OpenCvSharp.Point pt2 = new OpenCvSharp.Point(3, 4);

            textBox.Text = pt1.DistanceTo(pt2).ToString() + "\r\n";// 2
            textBox.Text += pt1.DotProduct(pt2) + "\r\n";// 11
            textBox.Text += pt1.CrossProduct(pt2) + "\r\n";// -2
            textBox.Text += (pt1 + pt2).ToString() + "\r\n";// (x:4 y:6)
            textBox.Text += (pt1 - pt2).ToString() + "\r\n";// (x:-2 y:-2)
            textBox.Text += (pt1 == pt2).ToString() + "\r\n";// False
            textBox.Text += (pt1 * 0.5).ToString() + "\r\n";// (x:0 y:1)
        }

        public void _Sclar()
        {
            Scalar s1 = new Scalar(252, 427);
            Scalar s2 = Scalar.Yellow;
            Scalar s3 = Scalar.All(99);

            textBox.Text = s1.ToString() + "\r\n"; // [255,127,0,0]
            textBox.Text += s2.ToString() + "\r\n"; // [0,255,255,0]
            textBox.Text += s3.ToString() + "\r\n"; // [99,99,99,99]
        }

        public void _Size()
        {
            OpenCvSharp.Size size = new OpenCvSharp.Size(640,480);
            OpenCvSharp.Size2d size2D = new OpenCvSharp.Size2d(1280.0, 720.0);
            OpenCvSharp.Size2d size2F = new OpenCvSharp.Size2d(320.0f, 240.0f);

            Mat img = new Mat(size, MatType.CV_8UC3);//8bit unsigned, 3 color

            textBox.Text = $"{size.Width}, {size.Height} \r\n";
            textBox.Text += img.Size() + "\r\n";
            textBox.Text += $"{img.Size().Width}, {img.Size().Height} \r\n";
            textBox.Text += $"{img.Width}, {img.Height} \r\n";
        }

        public void _Range()
        {
            OpenCvSharp.Range range = new OpenCvSharp.Range(0,100);
            textBox.Text = $"{range.Start}, {range.End}";// 0, 100
        }
        public void _Rect()
        {
            OpenCvSharp.Rect rect1 = new OpenCvSharp.Rect(new OpenCvSharp.Point(0, 0), new OpenCvSharp.Size(640, 480));
            OpenCvSharp.Rect rect2 = new OpenCvSharp.Rect(10,10,640,480);

            textBox.Text = rect1.ToString();
            textBox.Text += rect2.ToString();
        }

        public void _RotatedRect()
        {
            RotatedRect rotatedRect = new RotatedRect(new Point2f(100f, 100f), new Size2f(100f, 100f), 45f);

            textBox.Text = rotatedRect.BoundingRect().ToString() + "\r\n";
            textBox.Text += rotatedRect.Points().Length.ToString() + "\r\n";
            textBox.Text += rotatedRect.Points()[0].ToString() + "\r\n";
        }

        public void _Mat()
        {
            Mat m1 = new Mat(480, 640, MatType.CV_8UC3);
            Mat m2 = new Mat(new OpenCvSharp.Size(640,480), MatType.CV_8UC3);

            Mat M = new Mat();
            M.Create(MatType.CV_8UC3, new int[] { 480, 640 });
            //M.Create(new OpenCvSharp.Size(480,640), MatType.CV_8UC3);
            //M.Create(480, 640, MatType.CV_8UC3);

            M.SetTo(new Scalar(255,0,0));

            Mat m = Mat.Eye(new OpenCvSharp.Size(3, 3), MatType.CV_64FC3);

            textBox.Text = m.At<double>(0,0).ToString() + "\r\n";

            textBox.Text += m.At<Vec3d>(0, 0).Item0.ToString() + "\r\n";
            textBox.Text += m.At<Vec3d>(1, 1).Item1.ToString() + "\r\n";
            textBox.Text += m.At<Vec3d>(2, 2).Item2.ToString() + "\r\n";

            textBox.Text += m.At<Point3d>(2, 2).ToString() + "\r\n";
            textBox.Text += m.At<long>(2, 2).ToString() + "\r\n";
        }

        public void _Image()
        {
            Mat src = Cv2.ImRead("resource/cat.jpg", ImreadModes.ReducedColor2);

            Cv2.ImShow("image window", src);

            textBox.Text = src.ToString();

            imageBox.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(src);
        }
    }
}