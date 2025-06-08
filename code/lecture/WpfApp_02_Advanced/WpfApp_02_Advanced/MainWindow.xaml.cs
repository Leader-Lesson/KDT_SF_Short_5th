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

namespace WpfApp_02_Advanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // [3] Pack URI
        // [3-1]. 상태 기억용 변수 생성
        private bool isAngry = true;

        // [3-2]. 이미지 경로 (pack URI 방식)
        private Uri uriAngryImage = new Uri("pack://application:,,,/Assets/test3.jpg", UriKind.Absolute);
        private Uri uriHappyImage = new Uri("pack://application:,,,/Assets/test4.jpg", UriKind.Absolute);

        // [6-1] 전역 변수 설정.
        private List<Person> peopleInfo; // 데이터를 저장할 List<Person>

        public MainWindow()
        {
            InitializeComponent();

            // [1] Resource 초기 이미지 설정
            imgTest.Source = new BitmapImage(new Uri("Assets/test.png", UriKind.Relative));

            // [2] Content 초기 이미지 설정
            imgTest2.Source = new BitmapImage(new Uri("Assets/test3.jpg", UriKind.Relative));

            // [3-3]. Pack URI 초기 이미지 설정
            imgDisplay.Source = new BitmapImage(uriAngryImage);

            // [4-3]. 메서드 실행
            LoadData();

            // [5-3]. 메서드 실행
            LoadData2();

            // [6-4]. 초기 데이터 바인딩
            LoadData3();
            singleSelectDataGrid.ItemsSource = peopleInfo;
            multiSelectDataGrid.ItemsSource = peopleInfo;

        }

        // [1] Resource C# 버전
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            imgTest.Source = new BitmapImage(new Uri("Assets/test2.png", UriKind.Relative));
        }

        // [2] Content C# 버전
        private void Btn_Content_Click(object sender, RoutedEventArgs e)
        {
            // 실행 디렉터리에 복사된 이미지 경로
            string path = "Assets/test4.jpg";

            // 이미지 불러오기
            imgTest2.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }

        // [3-4]. Pack URI 버튼 클릭시 이미지 전환
        private void BtnChangeImage_Click(object sender, RoutedEventArgs e)
        {
            imgDisplay.Source = new BitmapImage(isAngry ? uriAngryImage : uriHappyImage);

            // isAngry 값을 반전시킴 (true -> false, false -> true)
            isAngry = !isAngry;
        }

     

        // [4-2]. DataGird 데이터 입력 메서드
        private void LoadData()
        {

            List<Person> people = new List<Person>
            {
                new Person { Id = 1, Name = "홍길동", Age = 30, IsActive = true },
                new Person { Id = 2, Name = "데이먼", Age = 25, IsActive = false },
                new Person { Id = 3, Name = "이영희", Age = 35, IsActive = true }
            };

            myDataGrid.ItemsSource = people;
        }

        // [5-2]. 메서드 작성
        private void LoadData2()
        {
            List<Person> people2 = new List<Person>
            {
                new Person { Id = 1, Name = "홍길동", Age = 30, IsActive = true },
                new Person { Id = 2, Name = "데이먼", Age = 25, IsActive = false },
                new Person { Id = 3, Name = "이영희", Age = 35, IsActive = true }
            };

            myDataGrid2.ItemsSource = people2;
        }
        // [6-3]. 메서드 작성
        private void LoadData3()
        {
            // List<Person> 초기 데이터 생성
            peopleInfo = new List<Person>
            {
                new Person { Id = 1, Name = "홍길동", Age = 30, IsActive = true },
                new Person { Id = 2, Name = "데이먼", Age = 25, IsActive = false },
                new Person { Id = 3, Name = "이영희", Age = 35, IsActive = true },
                new Person { Id = 4, Name = "레이먼드", Age = 30, IsActive = false },
                new Person { Id = 5, Name = "손흥민", Age = 32, IsActive = true },
                new Person { Id = 6, Name = "류현진", Age = 37, IsActive = false }
            };
        }

        // [6-5]. 단일 선택 DataGrid 이벤트 메서드
        private void SingleSelectDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SelectedItem 속성을 통해 현재 선택된 항목에 접근
            if (singleSelectDataGrid.SelectedItem is Person selectedPerson)
            {
                // 실시간으로 선택된 항목 정보를 출력
                Console.WriteLine($"단일 선택: ID={selectedPerson.Id}, 이름={selectedPerson.Name}");
            }
            else
            {
                Console.WriteLine("단일 선택: 선택된 항목 없음");
            }

        }

        private void ShowSingleSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            if (singleSelectDataGrid.SelectedItem is Person selectedPerson)
            {
                MessageBox.Show($"단일 선택된 사람:\nID: {selectedPerson.Id}\n" +
                    $"이름: {selectedPerson.Name}\n" +
                    $"나이: {selectedPerson.Age}\n" +
                    $"활성: {selectedPerson.IsActive}", "단일 선택 정보", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("단일 선택된 사람이 없습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // [6-6]. 다중 선택 DataGrid 이벤트 메서드
        private void MultiSelectDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SelectedItems 속성을 통해 현재 선택된 모든 항목에 접근
            if (multiSelectDataGrid.SelectedItems.Count > 0)
            {
                // 예시: 선택된 모든 사람의 이름을 출력
                string selectedNames = string.Join(", ", multiSelectDataGrid.SelectedItems.Cast<Person>().Select(p => p.Name));
                Console.WriteLine($"다중 선택 ({multiSelectDataGrid.SelectedItems.Count}명): {selectedNames}");
            }
            else
            {
                Console.WriteLine("다중 선택: 선택된 항목 없음");
            }
        }

        private void ShowMultiSelectedItems_Click(object sender, RoutedEventArgs e)
        {
            if (multiSelectDataGrid.SelectedItems.Count > 0)
            {
                string selectedInfo = "선택된 사람들:\n";
                foreach (Person p in multiSelectDataGrid.SelectedItems.Cast<Person>())
                {
                    selectedInfo += $"- {p.Name} (ID: {p.Id})\n";
                }
                MessageBox.Show(selectedInfo, "다중 선택 정보", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("다중 선택된 사람이 없습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    // [4-1]. DataGrid 외부 클래스 생성
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}

#region #1. Image
#endregion

// [이미지 접근 방식]

#region 1) Resource 방식
/* 
* 1) Resource 방식
* - 이미지 파일을 실행 프로그램(.exe)에 포함시켜 배포하는 방식!
* 
* [코드 작성]
* [1] XAML 버전
* - 이미지가 바뀌지 않을 때, 즉 고정된 화면에 정적인 이미지를 보여줄 때 사용.
* 
* [2] C# 코드 버전
* - 동적으로 이미지 제어할 때
* 
*/
#endregion

#region 2) Content 방식
/*
 * 2) Content 방식
 * - 이미지 파일을 실행 파일(.exe)이 있는 폴더에 복사해 놓고, 거기서 직접 불러오는 방식.
 */
#endregion

#region 3) Pack URI 방식
/*
 * 3) Pack URI 방식
 * - WPF에서 Resource 방식으로 등록된 이미지 파일을 "정확하게 식별"하고 로드할 수 있게 해주는 전용 URI 방식.
 * 
 * [Pack URI 문법 형식]
 * pack://application:,,,/경로
 */
#endregion
