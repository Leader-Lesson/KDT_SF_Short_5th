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

namespace WpfApp_01_Base
{
    /// <summary>
    /// Interaction logic for Ex.xaml
    /// </summary>
    public partial class Ex : Window
    {
        public Ex()
        {
            InitializeComponent();
        }

       private void Slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            // [예외 방지] 슬라이더 값 표시용 텍스트 박스가 아직 준비 안되었으면 중단.
            if (textR == null || textG == null || textB == null)
                return;

            // [1] 슬라이더에서 현재 RGB 값 읽기
            int r = (int)sliderR.Value; // 0 ~ 255 
            int g = (int)sliderG.Value; // 0 ~ 255 
            int b = (int)sliderB.Value; // 0 ~ 255 

            // [2] 오른쪽 텍스트박스에 숫자 보여주기.
            textR.Text = r.ToString();
            textG.Text = g.ToString();
            textB.Text = b.ToString();

            // [3] 배경에 적용할 색을 담을 변수 선언
            Color color;

            if (radioOriginal.IsChecked == true)
            {
                // 일반 색 모드: 슬라이더로 받은 R/G/B 값을 그대로 색으로 사용.
                color = Color.FromRgb((byte)r, (byte)g, (byte)b);
            }

            else if (radioGray.IsChecked == true) 
            {
                // 회색 톤 모드 : R/G/B 값을 평균 내서 동일한 값으로 사용.
                byte avg = (byte)((r + g + b) / 3);
                color = Color.FromRgb(avg, avg, avg);
            }
            else
            {
                // 반전 색 모드 : 255에서 현재 값을 뺀 값을 사용 
                color = Color.FromRgb((byte)(255 - r), (byte)(255 - g), (byte)(255 - b));
            }

            // [4] 준비한 색을 배경색으로 적용.
            mainGrid.Background = new SolidColorBrush(color);
        }
        /*
         * Color.FromRgb(byte r, byte g, byte b)
         * - 색을 만드는 메서드
         * - 3가지 값을 조합해서 하나의 색 만듦.
         * 
         * RGB 값은 0~255 범위니까
         * C#의 Byte 타입의 크기가 0~255까지 딱 알맞다.
         * 
         * SolidColorBrush(Color c)
         * - 인수로 받은 그 색을 칠하는 붓(Brush)
         */
    }
}
