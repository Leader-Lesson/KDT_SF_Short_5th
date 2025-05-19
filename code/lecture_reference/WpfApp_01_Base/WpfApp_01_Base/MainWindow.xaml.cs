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

namespace WpfApp_01_Base
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            volumeText.Text = $"현재 볼륨: {volumeSlider.Value}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 선택된 라디오 버튼 확인
            string result = "";

            if (radioMale.IsChecked == true)
            {
                result = "남성을 선택했습니다.";
            }
            else if (radioFemale.IsChecked == true)
            {
                result = "여성을 선택했습니다.";
            }

            MessageBox.Show(result, "선택 결과");
        }
        // 라디오 버튼 '남성' 선택 시 실행
        private void radioMale_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("남성을 선택했습니다.", "라디오 선택");
        }

        // 라디오 버튼 '여성' 선택 시 실행
        private void radioFemale_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("여성을 선택했습니다.", "라디오 선택");
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            volumeText.Text = $"현재 볼륨: {volumeSlider.Value}";
        }
    }

    #region #1. Tab Control
    /*
    TabControl?
    - 웹 브라우저 처럼 탭 버튼을 눌러 다른 내용의 화면 전환.
    
    1) TabContorl
    - 전체 탭 컨테이너
    - 내부의 여러 개 TabItem 가질 수 있음.

    2) TabItem
    - 각각의 탭을 나타내는 항목
    - Header : 탭 제목
    - Content : 보여줄 컨텐츠(UI) 배치
    */
    #endregion

    #region #2. StackPanel
    /*
    - 자식 요소들을 수직(Vertical) 또는 수평(Horizontal) 방향으로 자동으로 정렬해서 배치하는 레이아웃 패널.
    
    [속성]
    Orientation : 쌓는 방향 지정 - Vertical(기본 값), Horizontal
     */
    #endregion

    #region #3. TextBlock
    /*
    - 텍스트를 화면에 출력해주는 WPF 가장 기본적인 텍스트 표시용 컨트롤.
    - 화면 읽기 전용 텍스트를 표시할 때 사용.
      (사용자가 입력할 수는 없습니다. → 입력은 TextBox에서 가능)
     */
    #endregion

    #region #4. GroupBox
    /*
     * - 여러 개의 UI 요소를 하나의 그룹으로 묶어주고, 그 그룹에 제목(label)을 붙일 수 있는 컨테이너
     * - ㄴ 관련된 항목들을 시각적으로 묶어 표현할 때 사용.
     */
    #endregion

    #region #5. Radio button
    /*
     *  GroupName
     *  - 여러 개의 라디오 버튼이 서로 다른 그룹으로 동작하도록 구분하는 속성.
     *  - 같은 GroupName을 가진 버튼들끼리는 서로 하나만 선택 가능.
     *  - 다른 GroupName을 부여하면 동시 선택 가능.
     *  
     *  Checked
     *  - 라디오 버튼이 선택될 때 연결되는 이벤트 핸들러
     *  
     *  IsChecked
     *  - 현재 체크 상태를 코드로 확인할 때 사용
     */
    #endregion

    #region #6. Slider
    /*
     * - 사용자가 드래그하거나 클릭해서 숫자 값을 조절 할 수 있도록 해주는 입력 컨트롤.
     * ex) 음량 조절, 밝기 조절, 비율 조절 등.
     */
    #endregion
}