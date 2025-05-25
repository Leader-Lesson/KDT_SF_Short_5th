using System.Data;
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
using ScottPlot;

namespace WpfApp_03_ScottPlot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ShowScatter();
            //ShowSignal();
            //ShowLegend();
            //ShowRightAxis();
            //ShowMultiAxis();
            ScatterPlotSample1();


        }
        #region #1. Scatter
        /*
         * - X값과 Y값을 직접 지정하여 그리는 "산점도"
         *   ㄴ X축과 Y축 좌표쌍을 기반으로 점을 찍고, 선으로 연결.
         *   ㄴ 점과 점 사이의 "관계'를 보기 위해 사용.
         */
        void ShowScatter()
        {
            double[] dataX = { 1, 2, 3, 4, 5 }; // X축 데이터
            double[] dataY = { 1, 4, 9, 16, 25 }; // Y축 데이터

            WpfPlot1.Plot.Add.Scatter(dataX, dataY);
            /*
             * WpfPlot1 : ScottPlot 컨트롤 이름
             * .Plot : 그래프 그리는 객체에 접근.
             * .Add.Scatter(...) : 산점도 형태로 데이터 추가.
             *  ㄴ dataX, dataY 배열의 쌍을 이용해 (1,1) (2,4) ... 연결해서 곡선을 그림.
             */

            WpfPlot1.Refresh(); // 위에 추가한 그래프 내용을 실제로 화면에 갱신하여 보여줌.
            // ScottPlot은 WPF 컨트롤이라서 데이터 추가 후 .Refresh()를 호출해야 즉시 업데이트가 반영됩니다.
        }
        #endregion

        #region #2. Signal Plot
        /*
         * - X축이 일정한 간격으로 나열된 경우,
         *   Y값만으로 그래프를 그릴 수 있도록 만든 고성능 라인 그래프.
         */
        void ShowSignal()
        {
            
            double[] sin = Generate.Sin(51);
            // 사인파 (sine wave)를 이루는 Y값 배열 만듬.
            // 0 ~2π 범위에서 51개의 sin(x) 값을 계산해 배열 생성
            double[] cos = Generate.Cos(40);

            WpfPlot1.Plot.Add.Signal(sin);
            WpfPlot1.Plot.Add.Signal(cos);

            WpfPlot1.Refresh();
        }
        #endregion

        #region #3. Legend (범례)
        /*
         * - 그래프에 표시된 선이나 점들이 무엇을 의미하는지 설명해주는 라벨.
         */

        void ShowLegend()
        {
            var sig1 = WpfPlot1.Plot.Add.Signal(Generate.Sin(51));
            sig1.LegendText = "Sin";

            var sig2 = WpfPlot1.Plot.Add.Signal(Generate.Cos(51));
            sig2.LegendText = "Cos";

            WpfPlot1.Refresh();
        }
        #endregion

        #region #4. RightAxis
        /*
         * - 그래프 오른쪽에 추가 축(보조 Y축)을 만들어서,
         *   기존 Y축과는 다른 기준의 데이터를 함께 표현하게 해주는 기능.
         */

        // plot data with very different scales
        void ShowRightAxis()
        {
            var sig1 = WpfPlot1.Plot.Add.Signal(Generate.Sin(mult: 0.01));  // mult: 곱하기 계수 // 천천히 변하는 사인 곡선
            var sig2 = WpfPlot1.Plot.Add.Signal(Generate.Cos(mult: 100));   // 빠르게 진동하는 코사인 곡선

            // tell each signal plot to use a different axis
            sig1.Axes.YAxis = WpfPlot1.Plot.Axes.Left;
            sig2.Axes.YAxis = WpfPlot1.Plot.Axes.Right;
            // Axes.YAxis: 각각의 선이 어떤 축에 연결될지 설정

            // add additional styling options to each axis
            WpfPlot1.Plot.Axes.Left.Label.Text = "Left Axis";
            WpfPlot1.Plot.Axes.Right.Label.Text = "Right Axis";
            WpfPlot1.Plot.Axes.Left.Label.ForeColor = sig1.Color;   // 축 글자 색과 선 색 맞춤.
            WpfPlot1.Plot.Axes.Right.Label.ForeColor = sig2.Color;
            /*
             * WpfPlot1      // WPF 컨트롤 이름
             *  .Plot        // ScottPlot의 Plot 객체 (그래프 전체)
             *  .Axes       //  축 정보에 접근 (X, Y 축 등)
             */

            WpfPlot1.Refresh();
        }

        #endregion

        #region #5. MultiAxis
        /*
         * - 하나의 그래프 안에 Y축을 3개 이상 만듦.
         * - 서로 다른 데이터 단위를 각각 독립된 축에 매핑해서 표현.
         */
        void ShowMultiAxis()
        {
            // plottables use the standard X and Y axes by default
            var sig1 = WpfPlot1.Plot.Add.Signal(Generate.Sin(51, mult: 0.01));
            sig1.Axes.XAxis = WpfPlot1.Plot.Axes.Bottom; // standard X axis
            sig1.Axes.YAxis = WpfPlot1.Plot.Axes.Left; // standard Y axis
            WpfPlot1.Plot.Axes.Left.Label.Text = "Primary Y Axis";

            // create a second axis and add it to the plot
            var yAxis2 = WpfPlot1.Plot.Axes.AddLeftAxis();

            // add a new plottable and tell it to use the custom Y axis
            var sig2 = WpfPlot1.Plot.Add.Signal(Generate.Cos(51, mult: 100));
            sig2.Axes.XAxis = WpfPlot1.Plot.Axes.Bottom; // standard X axis
            sig2.Axes.YAxis = yAxis2; // custom Y axis
            yAxis2.LabelText = "Secondary Y Axis";

            WpfPlot1.Refresh();

            /*
             * 1. Generate.Sin()을 이용해 천천히 진동하는 사인파 데이터를 생성한 후, 그것을 SignalPlot 형태로 그래프에 추가
             * 2. sig1의 X축은 기본 아래쪽 축(Bottom Axis) 을 사용
             * 3. sig1의 Y축은 기본 왼쪽 축(Left Axis) 을 사용합니다.
             * 4. 왼쪽 Y축의 이름(라벨)을 "Primary Y Axis" 로 설정합니다.
             * 5. 왼쪽에 새로운 보조 Y축을 하나 더 생성합니다.
             * 6. 빠르게 진동하는 코사인파 데이터를 생성하고, 그래프에 추가합니다.
             * 7. sig2도 동일하게 기본 X축을 사용합니다.
             * 8. sig2는 기본 왼쪽 축이 아니라 아까 새로 만든 보조 왼쪽 축(yAxis2) 를 사용
             * 9. 보조 축 yAxis2의 이름을 "Secondary Y Axis" 라고 지정
             */
        }

        #endregion

        #region sample 예제

        void ScatterPlotSample1()
        {
            Coordinates[] coordinates =
            {
                new(1, 1),
                new(2, 4),
                new(3, 9),
                new(4, 16),
                new(5, 25),
            };

            WpfPlot1.Plot.Add.Scatter(coordinates);
        }
        #endregion
    }
}

/*
 * Generate?
 * - ScottPlot에서 제공하는 정적 클래스.
 * - 그래프 테스트용 샘플 데이터를 간단하게 생성할 수 있게 도와주는 도구.
 * 
 * Generate.Sin(count)
 * Generate.Cos(count)
 * Generate.Random(count)
 */