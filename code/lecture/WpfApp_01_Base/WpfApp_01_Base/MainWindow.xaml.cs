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
            listBox.ItemsSource = animals;


            // #11. web
            WebBrowser1.Navigate("http://www.naver.com");


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

}