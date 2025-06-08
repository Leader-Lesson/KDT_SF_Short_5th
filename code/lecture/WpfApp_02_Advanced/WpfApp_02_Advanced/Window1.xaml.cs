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
using Microsoft.Win32;

namespace WpfApp_02_Advanced
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            // [1] 파일 다이얼로그 열기
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "이미지 파일 (*.png; *.jpg; *.jpeg)|*.png;*.jpg;*.jpeg";

            if (dialog.ShowDialog() == true)
            {
                // [2] 이미지 경로를 URI로 가져오기
                Uri imageUri = new Uri(dialog.FileName, UriKind.Absolute);
                BitmapImage bitmap = new BitmapImage(imageUri);

                // [3] 버튼 배경 이미지 설정
                ImageBrush brush = new ImageBrush(bitmap);
                btnImage.Background = brush;

                // [4] 버튼 크기를 이미지 크기와 맞게 조정
                btnImage.Width = bitmap.PixelWidth;
                btnImage.Height = bitmap.PixelHeight;

                // [5] 텍스트 제거 (선택사항)
                btnImage.Content = null;
            }
        }
    }
}