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
    /// Interaction logic for Ex2.xaml
    /// </summary>
    public partial class Ex2 : Window
    {
        public Ex2()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            // [예외 방지] 슬라이더 값 표시용 텍스트 박스가 아직 준비 안 되었을 경우 중단
            if (textR == null || textG == null || textB == null)
                return;

            // [1] 슬라이더에서 현재 RGB 값 읽기
            int r = (int)sliderR.Value;
            int g = (int)sliderG.Value;
            int b = (int)sliderB.Value;

            // [2] 오른쪽 텍스트에 숫자 보여주기.
            textR.Text = r.ToString();
            textG.Text = g.ToString();
            textB.Text = b.ToString();

            // [3] 배경에 적용할 색을 담을 변수 선언
            Color color;

            if (radioOriginal.IsChecked == true)
            {
                // 🌈 일반 색 모드: 슬라이더로 받은 R/G/B 값을 그대로 색으로 사용
                color = Color.FromRgb((byte)r, (byte)g, (byte)b);
            }
            else if (radioGray.IsChecked == true)
            {
                // ⚫ 회색톤 모드: R/G/B 값을 평균 내서 동일한 값으로 사용
                // 회색은 R=G=B일 때 나옴 → 평균으로 맞춰줌
                byte avg = (byte)((r + g + b) / 3);
                color = Color.FromRgb(avg, avg, avg);
            }
            else // radioInvert
            {
                // 🔄 반전 색 모드: 255에서 현재 값을 뺀 값을 사용 (색상 반전)
                // 예: R=255면 0, R=0이면 255 → 정반대 색
                color = Color.FromRgb((byte)(255 - r), (byte)(255 - g), (byte)(255 - b));
            }

            // [5] 준비한 색을 배경색으로 적용
            // 단순 색(Color)만으로는 배경을 못 바꾸고,
            // '색칠 도구(브러시)'인 SolidColorBrush로 감싸야 배경에 쓸 수 있음
            mainGrid.Background = new SolidColorBrush(color);
        }

        /*
         * Color.FromRgb(byte r, byte g, byte b)
         * - 색을 만드는 메서드
         * - 3가지 값을 조합해서 하나의 색 만듦
         * 
         * Why? (byte를 사용하는 이유)
         * RGB 값은 0~255 범위니까,
         * C#의 byte 타입(0~255)이 딱 맞는 범위입니다.
         * 
         * SolidColorBrush(Color c)
         * - 그 색을 칠하는 붓(Brush)
         * - WPF에서 배경, 글자, 도형 등에 색을 "칠하려면" Brush라는 도구가 필요합니다.
         *   SolidColorBrush는 단색으로 칠할 수 있는 붓이에요.
         */
    }
}
