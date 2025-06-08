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
                color = Color.FromRgb((byte)r, (byte)g, (byte)b);
            }
            else if (radioGray.IsChecked == true)
            {
                byte avg = (byte)((r + g + b) / 3);
                color = Color.FromRgb(avg, avg, avg);
            }
            else // radioInvert
            {
                color = Color.FromRgb((byte)(255 - r), (byte)(255 - g), (byte)(255 - b));
            }

            // [5] 준비한 색을 배경색으로 적용
            mainGrid.Background = new SolidColorBrush(color);
        }
    }
}
