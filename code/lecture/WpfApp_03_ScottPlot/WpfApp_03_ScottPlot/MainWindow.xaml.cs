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
        void ShowScatter()
        {
            double[] dataX = { 1, 2, 3, 4, 5 }; // X축 데이터
            double[] dataY = { 1, 4, 9, 16, 25 }; // Y축 데이터

            WpfPlot1.Plot.Add.Scatter(dataX, dataY);

            WpfPlot1.Refresh(); // 위에 추가한 그래프 내용을 실제로 화면에 갱신하여 보여줌.
            // ScottPlot은 WPF 컨트롤이라서 데이터 추가 후 .Refresh()를 호출해야 즉시 업데이트가 반영됩니다.
        }
        #endregion

        #region #2. Signal Plot
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

            WpfPlot1.Refresh();
        }

        #endregion

        #region #5. MultiAxis
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
