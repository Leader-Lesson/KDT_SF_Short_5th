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

namespace WpfAppCallback
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        Mat src;
        public MainWindow()
        {
            InitializeComponent();

            _callback();
        }

        public void _callback()
        {
            src = new Mat(new OpenCvSharp.Size(500, 500), MatType.CV_8UC3, new Scalar(255,255,255));

            Cv2.ImShow("white board", src);

            MouseCallback cvMouseCallback = new MouseCallback(MyMouseEvent);
            Cv2.SetMouseCallback("white board", cvMouseCallback, src.CvPtr);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }

        private void MyMouseEvent(MouseEventTypes @event, int x, int y, MouseEventFlags flags, IntPtr userData)
        {
            if (flags == MouseEventFlags.LButton)
            {
                //MessageBox.Show($"마우스 좌표 {x}, {y}");
            }
            if (@event == MouseEventTypes.MouseMove && flags.HasFlag(MouseEventFlags.LButton))
            {
                Cv2.Circle(src, x, y, 3, Scalar.Black, -1); // -1은 원을 채움
                Cv2.ImShow("white board", src); // 원을 그린 후 이미지를 다시 표시
            }
        }
    }
}
