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
/*
 * 선택한 이미지 파일을 WPF에서 사용할 수 있도록 변환
 * Uri imageUri = new Uri(dialog.FileName, UriKind.Absolute);
 * - dialog.FileName: 사용자가 선택한 파일의 전체 경로 (string).
 * - UriKind.Absolute: 절대경로임을 명시
 * - BitmapImage: 이미지 파일을 WPF에서 사용할 수 있는 객체로 변환하는 클래스
 * 
 * 버튼에 이미지 적용
 * ImageBrush: 이미지로 채워주는 도구.
 * - Background 속성에 직접 이미지를 넣을 수는 없고, ImageBrush를 만들어 넣어야 합니다.
 * - btnImage.Background: 버튼 배경에 이미지 넣기.
 * 
 * - PixelWidth, PixelHeight는 이미지의 원본 크기(px)입니다.
 */