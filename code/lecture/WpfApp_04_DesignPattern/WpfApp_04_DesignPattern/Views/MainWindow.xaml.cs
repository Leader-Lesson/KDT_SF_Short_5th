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

/*
 * 시나리오 (요구사항)
 * 1. 버튼을 누르면 카운트가 1씩 증가
 * 2. Label에는 현재 카운트 값을 표시
 * 3. 카운트 상태를 전역적으로 관리
 *    ㄴ 싱글톤 인스턴스로 공유.
 */

namespace WpfApp_04_DesignPattern.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //UpdateLabel();  // 초기 값 표시.
        }


        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    // [6] 싱글톤 인스턴스를 통해 카운트 증가
        //    CounterManager.Instance.Increment();

        //    // [7] UI 업데이트
        //    UpdateLabel();
            
        //}
        //private void UpdateLabel()
        //{
        //    // [8] 현재 카운트 값 읽어와서 Label 갱신.
        //    //txtCount.Text = CounterManager.Instance.Count.ToString();
        //}
    } 
}
