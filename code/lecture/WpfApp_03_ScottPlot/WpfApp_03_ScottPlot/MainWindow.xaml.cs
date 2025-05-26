using ScottPlot;
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

            //double[] dataX = { 1, 2, 3, 4, 5 };
            //double[] dataY = { 1, 4, 9, 16, 25 };
            //WpfPlot1.Plot.Add.Scatter(dataX, dataY);
            //WpfPlot1.Refresh();

            //ShowScatter();
            ShowSignal();

        } 
        #region #1. Scatter

        void ShowScatter()
        {
            // create sample data
            double[] dataX = { 1, 2, 3, 4, 5 }; // X축 데이터
            double[] dataY = { 1, 4, 9, 16, 25 }; // Y축 데이터

            // add a scatter plot to the plot
            WpfPlot1.Plot.Add.Scatter(dataX, dataY);


            WpfPlot1.Refresh();
            // 위에 추가한 그래프 내용을 실제로 화면에 갱신하여 보여줌.
        }
        #endregion

        #region #2. Signal Plot
        void ShowSignal()
        {
            // create sample data
            double[] sin = Generate.Sin(51);
            // 사인파 (sine wave)를 이루는 Y값 배열 만듬.
            // 0 ~ 2파이 범위에서 sin(x) 값을 계산해 배열 생성.
            double[] cos = Generate.Cos(30);
            /*
             * - Generate
             * : ScottPlot에서 제공하는 정적 클래스.
             *   ㄴ 그래프 테스트용 샘플 데이터를 간단하게 생성할 수 있게 도와주는 도구.
             */

            // add a signal plot to the plot
            WpfPlot1.Plot.Add.Signal(sin);
            WpfPlot1.Plot.Add.Signal(cos);


            WpfPlot1.Refresh();
        }
        #endregion
    }
}