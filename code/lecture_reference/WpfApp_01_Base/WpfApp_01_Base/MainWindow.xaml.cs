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

            // #10-1. 리스트 박스 - 데이터 바인딩
            // [2] 데이터 리스트 생성
            List<Animals> animals = new List<Animals>()
            {
                new Animals { Name = "하마", Percent = 10 },
                new Animals { Name = "타조", Percent = 90 },
                new Animals { Name = "토끼", Percent = 50 }
            };

            // [3] ListBox에 데이터 바인딩
            // - ListBox는 animals 리스트의 항목 개수만큼 줄을 만들어 화면에 표시하게 됨
            listBox.ItemsSource = animals;


            // #11. web
            WebBrowser1.Navigate("http://www.naver.com");
            //WebBrowser1.GoBack();     // 뒤로가기
            //WebBrowser1.GoForward();  // 앞으로가기


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

        // 슬라이더 실시간 값 변화 이벤트
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (volumeText != null)  // 초기 로딩 중 오류 방지
                volumeText.Text = $"현재 값: {volumeSlider.Value}";
        }

        // 체크박스
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // 체크된 항목들을 문자열로 조합
            List<string> selectedFruits = new List<string>();

            if (checkBoxApple.IsChecked == true)
                selectedFruits.Add("사과");

            if (checkBoxBanana.IsChecked == true)
                selectedFruits.Add("바나나");

            if (checkBoxOrange.IsChecked == true)
                selectedFruits.Add("오렌지");

            // 결과 표시
            textResult.Text = $"선택한 과일: {string.Join(", ", selectedFruits)}";
        }

        // 중간 체크 박스 이벤트
        private void checkBoxState_Click(object sender, RoutedEventArgs e)
        {
            bool? state = checkBoxState.IsChecked;

            if (state == true)
                textStatus.Text = "현재 상태: 체크됨 (true)";
            else if (state == false)
                textStatus.Text = "현재 상태: 해제됨 (false)";
            else
                textStatus.Text = "현재 상태: 중간상태 (null)";
        }

        // #9. 콤보 박스 이벤트
        private void comboFruits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 선택된 항목 가져오기 (ComboBoxItem에서 Content를 꺼냄)
            ComboBoxItem selectedItem = comboFruits.SelectedItem as ComboBoxItem;

            /*
             * [참고] 설명
             *  WPF에서 사용되는 모든 컨트롤 요소들은 전부 클래스
             *  ex)
             * ComboBoxItem item = new ComboBoxItem();
             * item.Content = "사과";
             * 
             * comboFruits.SelectedItem
             * - 사용자가 선택한 항목 가져오기.
             * - 사용자가 선택한 항목(SelectedItem)은 ComboBoxItem 타입의 객체가 됨.
             * 
             * as ComboBoxItem
             * - 이 항목이 실제로 ComboBoxItem 타입인지 확인하고,
             * - 맞으면 그 타입으로 변환해서 selectedItem에 넣습니다.
             * 
             * as 연산자
             * - 안전하게 형변환 할 수 있게 도와주는 키워드
             * - 형변환에 실패하면 'null" 반환.
             * - 즉, 예외를 발생시키지 않고 변환 시켜줌.
             */

            if (selectedItem != null) // as로 null이 반환 될 수도 있으니.
            {
                string selectedText = selectedItem.Content.ToString();
                // selectedItem은 ComboBoxItem 클래스의 인스턴스입니다
                // 그 안에 있는 Content 속성은 object 타입입니다.

                // [참고]
                // 사용자가 어떤 객체든 넣을 수 있게 하기 위해
                // → Content의 자료형을 object로 설계해둔 거예요.

                textResult2.Text = $"선택한 과일: {selectedText}";
            }
        }
        // #10. 리스트박스 이벤트
        private void listColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedItem = listColors.SelectedItem as ListBoxItem;

            if (selectedItem != null)
            {
                string selectedColor = selectedItem.Content.ToString();
                textSelected.Text = $"선택한 색상: {selectedColor}";
            }
        }

        private void listFruits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> selectedFruits = new List<string>();

            foreach (ListBoxItem item in listFruits.SelectedItems)
            {
                selectedFruits.Add(item.Content.ToString());
            }

            textSelected.Text = $"선택된 과일: {string.Join(", ", selectedFruits)}";
        }

        // #10-1. 리스트박스 - 데이터 바인딩
        // [1] 데이터 바인딩용 클래스 정의
        public class Animals
        {
            public string Name { get; set; }
            public int Percent { get; set; }
        }

        // #11. Web
        // ▶ [1] 네이버로 이동 버튼
        private void btnNaver_Click(object sender, EventArgs e)
        {
            WebBrowser1.Navigate("https://www.naver.com");
        }

        // ▶ [2] 뒤로 가기 버튼
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (WebBrowser1.CanGoBack)
                WebBrowser1.GoBack();
        }

        // ▶ [3] 앞으로 가기 버튼
        private void btnForward_Click(object sender, EventArgs e)
        {
            if (WebBrowser1.CanGoForward)
                WebBrowser1.GoForward();
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
    - 요소들을 순서대로 쌓음.
    - 마우스 조작으로 요소 이동 불가

    [속성]
    Orientation : 쌓는 방향 지정 - Vertical(기본 값), Horizontal
     */
    #endregion

    #region #3. Grid
    /*
     * - 행과 열을 나누어서 엑셀 표처럼 UI 요소를 격자(Grid) 구조로 배치할 수 있는 레이아웃 컨트롤.
     * 
     * [속성]
     * - RowDefinition: 행(가로줄) 만들기
     * - ColumnDefinition: 열(세로줄) 만들기
     * 
     * [Height / Width]
     * - Auto : 내부 요소의 크기에 맞게
     * - * : 나머지 공간을 비율로 자동 분배
     * - 숫자(px) : 고정 크기
     * 
     * When?
     * - 1) 요소들이 표 형태로 정리되어야 할 때
     * - 2) 요소들이 정확한 위치에 있어야 할 때
     * - 3) 반응형 비율 기반 배치가 필요 할 때
     */
    #endregion

    // 실습 문제!

    #region #4. TextBlock
    /*
    - 텍스트를 화면에 출력해주는 WPF 가장 기본적인 텍스트 표시용 컨트롤.
    - 화면 읽기 전용 텍스트를 표시할 때 사용.
      (사용자가 입력할 수는 없습니다. → 입력은 TextBox에서 가능)
     */
    #endregion

    #region #5. GroupBox
    /*
     * - 여러 개의 UI 요소를 하나의 그룹으로 묶어주고, 그 그룹에 제목(label)을 붙일 수 있는 컨테이너
     * - ㄴ 관련된 항목들을 시각적으로 묶어 표현할 때 사용.
     */
    #endregion

    #region #6. Radio button
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

    #region #7. Slider
    /*
     * - 사용자가 드래그하거나 클릭해서 숫자 값을 조절 할 수 있도록 해주는 입력 컨트롤.
     * ex) 음량 조절, 밝기 조절, 비율 조절 등.
     * 
     * [속성]
     * - Minimum : 최소 값 (기본값은 0)
     * - Maximum : 최대 값 (기본값은 10)
     * - Value : 현재 값 (기본값은 0)
     * - Orientation : 방향 설정
     * - TickFrequency : 눈금 간격 설정
     * - IsSnapToTickEnabled : 눈금에 딱딱 맞춰지게 할지 여부
     * - Ticks : 눈금 위치를 직접 설정 (= 배열처럼)
     *   - 특별한 위치에만 눈금이 필요 할 때
     */
    #endregion

    #region #8. CheckBox
    /*
     * - 여러 개의 항목을 복수 선택 가능하게 할 때 사용
     * 
     * [속성]
     * - IsChecked: true, false, null 값을 가지는 bool 타입 / 체크 여부를 나타냄.
     * - Checked : 체크되었을 때 발생하는 이벤트
     * - UnChecked
     * - Indeterminate : 중간 상태일때 발생하는 이벤트
     * - IsThreeState : true로 설정하면 중간 상태까지 허용. (기본값: false)
     */
    #endregion

    #region #9. ComboBox
    /*
     * - 드롭다운 목록에서 항목을 하나 선택할 수 있게 해주는 컨트롤.
     * - 사용자는 미리 정의된 목록 중 하나를 선택하거나, 필요 시 직접 입력도 가능!
     * 
     * [속성]
     * - Items : 콤보박스에 표시할 항목 목록
     * - SelectedItem : 현재 선택된 항목 객체 (보통 문자열)
     * - SelectedIndex : 선택된 항목의 인덱스 번호 (0부터 시작)
     * - SelectedValue : SelectedValuePath로 지정된 항목의 속성값  ---?? GPT 검색
     * - IsEditable : true 이면 사용자가 직접 입력 가능
     */
    #endregion

    #region #10. ListBox
    /*
     * - 여러 개의 항목들을 목록 형태로 나열해 보여주고,
     *   사용자가 항목을 하나 이상 선택할 수 있도록 해주는 컨트롤.
     * - Combobox: 펼쳐지는 드롭다운 (공간 절약)
     * - ListBox: 펼쳐진 채로 보임 (한눈에 보기 좋음)
     * 
     * [속성]
     * - Items : 항목을 직접 추가할 수 있음.
     * - ItemsSource : 외부 데이터 리스트를 바인딩 할 수 있음
     * - SelectedItem : 현재 선택된 항목 (기본 단일 선택)
     * - SelectedItems : 다중 선택 모드에서 선택된 모든 항목들
     * - SelectedIndex : 선택된 항목의 인덱스 번호
     * - SelectionMode : 선택 방식 (Single, Multiple, Extended)
     * - SelectionChanged : 항목이 선택되거나 해제될 때 발생하는 이벤트
     */

    /*
     * [참고] 데이터 바인딩 설명
     * 1) ItemsSource ?
     * - Listbox, ComboBox 처럼 여러 항목을 보여주는 컨트롤에 데이터를 바인딩(연결) 해주는 속성.
     * 
     * 역할: 연결한 리스트의 각 항목이 ListBox 안에 자동으로 하나씩 표시됨.
     * 
     * 2) ItemTemplate ?
     * - ListBox, ComboBox, 등 목록 컨트롤에서 각 항목 하나를 어떻게 보여줄지 정의하는 틀(템플릿)
     * - 즉, 데이터가 들어왔는데? 그걸 어떤 UI로 표현할지 정해준다.
     * 
     * 3) DataTemplate ?
     * - ItemTemplate 속성.
     * - Listbox에서 각 항목이 어떻게 보일지를 정의하는 틀(템플릿).
     * - 기본적으로 항목이 ToString() 값으로 표시되지만,
     *   DataTemplate를 사용하면, 항목마다 원하는 UI 요소(TextBlock, ProgressBar, Image 등)를 조합해서 보여줄 수 있음.
     *   
     * 4) {Binding Name} ?
     * - 바인딩된 데이터의 Name 속성 값을 UI에 표시.
     * 
     * 5) {Binding Percent} ?
     * - 바인딩된 데이터의 Percent 값을 꺼내서 ProgressBar의 Value로 넣는 것
     *   
     */

    /*
     * [참고]
     * WPF는 MVVM 패턴 기반으로 만들어졌기 때문에,
       디자인(XAML)과 로직(C# 코드)을 분리해서 관리하는 걸 권장합니다.

       그래서 XAML에서는 직접 ListBoxItem을 나열하지 않고,
       ItemTemplate을 통해 자동으로 항목을 그리도록 만들어야 유지보수와 재사용에 좋습니다.
     */
    #endregion

    #region #11. Web Browser
    /*
     * - WPF에서 제공하는 웹 페이지를 보여주는 컨트롤
     * - Internet Explorer(IE)의 웹 엔진을 기반 (2022년 이후로 지원 중지)
     * 
     * - Edge 기반 WebView2를 사용하는 것이 더 좋습니다
     * 
     * Why?
     * - 프로그램 안에서 웹 페이지를 보여주고 싶을 때
     * 
     * [속성]
     * - Navigate(string url): 지정한 웹 주소로 이동
     * - GoBack(): 뒤로 이동
     * - GoForward(): 앞으로 이동
     * - Refresh(): 현재 페이지 새로고침
     */
    #endregion
}