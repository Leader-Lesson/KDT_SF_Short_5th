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

namespace WpfAppVideo
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        Mat frame;

        public MainWindow()
        {
            InitializeComponent();

            //_video();
            _camera();
        }

        public void _video()
        {
            String filename = "file_example_MP4_480_1_5MG";
            VideoCapture capture = new VideoCapture(filename + ".mp4");
            Mat frame = new Mat();

            double time_stemp = capture.Get(VideoCaptureProperties.PosMsec);
            double frame_now = capture.Get(VideoCaptureProperties.PosFrames);
            double frame_width = capture.Get(VideoCaptureProperties.FrameWidth);
            double frame_height = capture.Get(VideoCaptureProperties.FrameHeight);
            double frame_count = capture.Get(VideoCaptureProperties.FrameCount);
            double fps = capture.Get(VideoCaptureProperties.Fps);

            textBox.Text = time_stemp.ToString() + "\r\n";
            textBox.Text += frame_now.ToString() + "\r\n";
            textBox.Text += frame_width.ToString() + "\r\n";
            textBox.Text += frame_height.ToString() + "\r\n";
            textBox.Text += frame_count.ToString() + "\r\n";
            textBox.Text += fps.ToString() + "\r\n";

            while (true)
            {
                if (capture.PosFrames == capture.FrameCount)
                    capture.Open(filename + ".mp4");

                capture.Read(frame);
                Cv2.ImShow(filename, frame);

                if (Cv2.WaitKey(33) == 'q') break;
            }

            capture.Release();
            Cv2.DestroyAllWindows();
        }

        public void _camera()
        {
            VideoCapture capture = new VideoCapture(0);
            frame = new Mat();

            capture.Set(VideoCaptureProperties.FrameWidth, 640);
            capture.Set(VideoCaptureProperties.FrameHeight, 480);


            Cv2.NamedWindow("Camera View");
            MouseCallback cvMouseCallback = new MouseCallback(MyMouseEvent);
            Cv2.SetMouseCallback("Camera View", cvMouseCallback);

            while (true)
            {
                if(capture.IsOpened())
                {
                    capture.Read(frame);

                    Cv2.ImShow("Camera View", frame);

                    if (Cv2.WaitKey(33) == 'q') break;
                }
            }
            capture.Release();
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
                Cv2.Circle(frame, x, y, 5, Scalar.Red, -1); // -1은 원을 채움
                Cv2.ImShow("Camera View", frame); // 원을 그린 후 이미지를 다시 표시
            }
        }
    }
}
