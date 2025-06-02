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

namespace WpfApp_04_DesignPattern.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    // [6] 싱글톤 인스턴스를 통해 카운트 증가.
        //    CounterManager.Instance.Increment();
        //    // static 객체 이므로 클래스 이름으로도 메서드 사용 가능 (객체 생성 필요 x)

        //    // [8] UI 업데이트
        //    UpdateLabel();
        //}
        ////[7] 현재 카운트 값을 읽어와서 label 갱신.
        //private void UpdateLabel()
        //{
        //    txtCount.Text = CounterManager.Instance.Count.ToString();
        //}
    }
}