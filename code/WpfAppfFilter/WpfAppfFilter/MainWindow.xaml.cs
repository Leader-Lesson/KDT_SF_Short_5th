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

namespace WpfAppfFilter
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        Mat img;
        public MainWindow()
        {
            InitializeComponent();
            setImage();
        }

        public void setSobel()
        {
            Mat sobelDst = new Mat();
            int ksize = 3;
            if (sobelTextBox.Text.Length > 0)
            {
                bool res = int.TryParse(sobelTextBox.Text, out ksize);
                if (res == false)
                {
                    ksize = 3;
                }
            }
            Cv2.Sobel(img, sobelDst, MatType.CV_16S, 1, 1, ksize);

            // 절대값을 취한 후 8비트 이미지로 변환
            Mat sobelAbsDst = new Mat();
            Cv2.ConvertScaleAbs(sobelDst, sobelAbsDst);

            sobelImage.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(sobelAbsDst);

            Cv2.ImShow("sobel", sobelAbsDst);
        }

        public void setImage()
        {
            try
            {
                img = Cv2.ImRead("iu.jpg");
                orgImage.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(img);

                setSobel();

                // Scharr 필터 적용
                Mat scharrDst = new Mat();
                Cv2.Scharr(img, scharrDst, MatType.CV_16S, 1, 0);  // x 방향으로 Scharr 필터 적용
                Mat scharrDstY = new Mat();
                Cv2.Scharr(img, scharrDstY, MatType.CV_16S, 0, 1); // y 방향으로 Scharr 필터 적용

                // 두 방향의 결과를 합침
                Mat scharrDstCombined = new Mat();
                Cv2.AddWeighted(scharrDst, 0.5, scharrDstY, 0.5, 0, scharrDstCombined);

                // 절대값을 취한 후 8비트 이미지로 변환
                Mat scharrAbsDst = new Mat();
                Cv2.ConvertScaleAbs(scharrDstCombined, scharrAbsDst);

                scharrImage.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(scharrAbsDst);

                // 라플라시안 필터 적용
                Mat laplacianDst = new Mat();
                Cv2.Laplacian(img, laplacianDst, MatType.CV_16S);

                // 절대값을 취한 후 8비트 이미지로 변환
                Mat laplacianAbsDst = new Mat();
                Cv2.ConvertScaleAbs(laplacianDst, laplacianAbsDst);

                laplacianImage.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(laplacianAbsDst);

                // 캐니 엣지 검출기 적용
                Mat cannyDst = new Mat();
                Cv2.Canny(img, cannyDst, 100, 200);  // 임계값은 100과 200을 사용

                cannyImage.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(cannyDst);

                Cv2.ImShow("org", img);
                Cv2.ImShow("scharr", scharrAbsDst);
                Cv2.ImShow("laplacian", laplacianAbsDst);
                Cv2.ImShow("canny", cannyDst);
            }
            catch (Exception ex)
            {
                //show exception
                throw ex;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            setSobel();
        }
    }
}
