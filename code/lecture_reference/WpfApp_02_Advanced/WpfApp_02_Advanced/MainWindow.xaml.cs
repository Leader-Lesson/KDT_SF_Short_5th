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
            /*
             * new Uri(...) - 이미지 파일의 경로를 Uri 객체로 만듦.
             * 
             * UriKind.? - .? 해석하겠다는 뜻.
             * ㄴ Relative: 실행 파일 기준 경로
             * ㄴ Absolute: 전체 경로 명시
             * ㄴ RelativeOrAbsolute: 둘 중 맞는걸 자동 판별 (거의 안씀)
             * 
             * new BitmapImage(...) - Uri를 통해 실제 이미지 객체 생성
             * Uri 란?
             * ㄴ 파일, 웹주소, 리소스의 경로를 하나의 객체로 표현한 C#의 데이터 형식
             * ㄴ "리소스(파일, 이미지 등)의 위치를 식별"하는 용도
             * BitmapImage(Uri) - 이미지 파일을 불러와 화면에 보여줌
             */

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
            // - 다음 버튼 클릭 시 반대 이미지가 나오도록 상태 전환.
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

            /*
             * is 연산자
             * - 객체가 특정 타입인지 검사할 때 사용. (= 타입 확인)
             * - 결과는 bool (true/false)로 반환됨.
             * - 형 변환은 X
             * 
             * C# 7.0 이후 패턴 매칭 활용 (is + 변수 선언)
             * - is로 타입 확인 + 형변환 O
             * - as 보다 간결하며 null 체크 생략 가능 (장점)
             */

            /*
             * singleSelectDataGrid.SelectedItem
             * => Object 타입.
             * - DataGrid는 어떤 타입의 데이터가 바인딩될지 모르기 때문에, 가장 일반적인 object 타입으로 반환
             * 
             * is Person selectedPerson
             * - ↑ 위 타입이 Person 타입인지 확인함.
             * - 위 타입이 Person 타입이거나 Person 타입으로 변환될 수 있다면 (즉, true 라면)
             *   ㄴ 해당 객체를 Person 타입으로 캐스팅하여 selectedPerson 이라는 새 변수에 할당함.
             *   ㄴ selectedPerson 변수는 if 블록 내에서만 유효하며, Person 타입으로 안전하게 사용할 수 있습니다.
             */
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
                /*
                 * multiSelectDataGrid.SelectedItems
                 * - 다중 선택된 항목 가져옴
                 * - 반환 타입은 : object 형 List (하나가 아닌 여러개)    // { Person, Person, Person ... }
                 * 
                 * 
                 * Cast<Person>()
                 * - Person 타입으로 형변환해야 우리가 만든 클래스의 속성 (Name)을 사용
                 * - "이 리스트 안에 있는 모든 항목을 Person으로 하나씩 바꿔줘" 라는 뜻
                 * - LINQ의 Cast<T>() 메서드이며,
                 *   as와 달리 실패 시 예외(Exception)가 발생합니다.
                 *   모든 항목이 Person일 때만 사용 가능합니다.
                 *   
                 *   [이것 과 유사]
                 *   List<Person> people = new List<Person>();
                 *   foreach (var item in multiSelectDataGrid.SelectedItems)
                 *   {
                 *   people.Add((Person)item);  // 하나씩 형변환
                 *   }
                 *   
                 * .Select(p => p.Name)
                 * - 형변환된 Person 객체들 중에서, Name 속성만 꺼냅니다.
                 * - Select()는 LINQ의 대표적인 "추출" 기능 // ["김철수", "이영희", "박민수"]
                 * 
                 * - p => p.Name ----> 람다식
                 *   ㄴ "각 항목 p 에서 Name 속성을 꺼내라 (p = 임시 변수)
                 *   
                 *   [이것 과 유사]
                 *   foreach (Person p in people)
                 *   {
                 *   Console.WriteLine(p.Name);  // 이걸 리스트로 모은 게 Select 결과
                 *   }
                 *  
                 */
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
/*
 * - WPF에서 사진, 아이콘, 일러스트 등 Bitmap 기반 이미지 리소스를 렌더링할 때 사용하는 UI 컨트롤.
 * - 내부적으로는 System.Windows.Controls.Image 클래스
 * 
 * [이미지 파일 관리] - 폴더에 모아서 관리.
 * - Assets : 가장 보편적이고 시각 리소스 포함하는 느낌
 * - Images : 이미지 전용 폴더로 직관적.
 * 
 * [속성]
 * - Source: 표시할 이미지 경로 or URI
 * - Stretch: 이미지 크기 조정 방식 (None, Fill, Uniform(기본 값), UniformToFill) 
 */
#endregion

// [이미지 접근 방식]

#region 1) Resource 방식
/* 
* 1) Resource 방식
* - 이미지 파일을 실행 프로그램(.exe)에 포함시켜 배포하는 방식!
*   ㄴ 즉, 프로그램 안에 이미지가 "포함 되어 있는"형태라서 외부 파일을 따로 챙길 필요가 없음.
* - 수정은 불가능하지만 정적인 리소스(아이콘, 배경, 버튼 등)에 매우 적합함.
* 
* [특징]
* - 배포 간편              [참고] 이미지가 실행파일에 포함되므로 따로 복사하거나 관리할 필요 없음.
* - 경로 문제 없음           [참고] 경로가 하드코딩 되지 않아 OS 마다 달라지는 경로 문제 없음.
* - 유지보수 용이
* 
* [방법]
* - 솔루션 탐색기에서 이미지 추가.
* - 추가한 이미지 선택 -> 속성
*   ㄴ 빌드 작업(Build Action) => Resource로 설정
* - 출력 디렉토리에 복사: 필요 없음.
*   ㄴ [참고] 실행 파일이 생성되는 폴더에 이 파일을 같이 복사할 건지 설정. - 복사하지 않으면 프로그램이 실행될 때 해당 파일을 찾을 수 없음.
*
* - XAML 또는 C# 코드에서 Source="파일명" 으로 간단하게 이미지 사용 가능.
*   ㄴ VS 프로젝트의 루트 기준 상대경로로 동작.
* 
* [코드 작성]
* [1] XAML 버전
* - 이미지가 바뀌지 않을 때, 즉 고정된 화면에 정적인 이미지를 보여줄 때 사용.
* 
* [2] C# 코드 버전
* - 동적으로 이미지 제어할 때
* 
* 
 * ## 추가 ## ###############################################
 * [주의]
 * - WPF 에서는 Resource 파일 접근 시 반드시 Pack URI 형식 사용 권장.
 * - XAML에서는 상대경로처럼 보여도 내부적으로 Pack URI로 해석됨
*/
#endregion

#region 2) Content 방식
/*
 * 2) Content 방식
 * - 이미지 파일을 실행 파일(.exe)이 있는 폴더에 복사해 놓고, 거기서 직접 불러오는 방식.
 * 
 * When?
 * - 사용자 업로드 이미지  ( -- 잘못 설명)
 * - ## 추가 ################################################
 * - 앱에서 제공하는 설명 이미지, 도움말 문서, 예제 파일 등
 *   ㄴ 외부 파일처럼 다루되, 실행파일과 함께 배포하고 싶을 때
 * ❗사용자가 업로드한 파일은 Content 방식이 아닌 '절대경로 방식'으로 접근해야 함
 * 
 * [특징]
 * - 실행 파일 외부에 따로 존재하는 이미지
 * - 프로그램이 실행될 때 이미지 파일을 같이 복사해서 사용하는 구조.
 * 
 * [방법]
 * - 이미지 추가
 * - 추가한 이미지 선택 -> 속성
 *   ㄴ 빌드 작업(Build Action): Content
 *   ㄴ 출력 디렉토리에 복사: Copy if newer (권장)
 *      ㄴ 그래야 실행 폴더 (bin/...)에 같이 복사됨.
 *      
 *      [Copy to Output Directory]
 *      - Do not copy : 복사 안함
 *      - Copy if newer : 새로 고칠때만 복사 (=원본이 바뀌었을 때만 복사)
 *      - Copy always : 항상 복사
 */
#endregion

#region 3) Pack URI 방식
/*
 * 3) Pack URI 방식
 * - WPF에서 Resource 방식으로 등록된 이미지 파일을 "정확하게 식별"하고 로드할 수 있게 해주는 전용 URI 방식.
 * - WPF의 스타일, 리소스 딕셔너리, 외부 DLL 등 다양한 곳에서 이미지와 리소스를 참조할 때 필수로 사용됩니다.
 * 
 * [특징]
 * - Resource 방식 이미지에 대한 절대 경로 지정 가능
 * - 외부 DLL에 포함된 리소스도 접근 가능
 * - UriKind.Absolute 와 함께 사용됨 (필수)
 * 
 * When?
 * - 외부 라이브러리(DLL)에 포함된 리소스 접근할 때
 * - C# 코드에서 Resource 이미지에 대해 명확한 식별이 필요할 때
 * - 프로젝트 구조가 복잡하거나, 리소스 공유가 많을 때 안정적
 * 
 * [Pack URI 문법 형식]
 * pack://application:,,,/경로
 * 
 *
 * [구문 분석]
 * - `pack://` : WPF 전용 URI 스킴
 * - `application:` : 현재 실행 중인 애플리케이션의 어셈블리를 의미
 * - `,,,` : 구분자 역할을 하는 문법적 요소이며, 고정된 형태로 사용됩니다 (공식 문법임)
 * - `/경로` : 리소스 경로, 프로젝트 루트 기준 (예: /Resources/cat.jpg)
 * 
 * [방법]
 * 1. 이미지 추가 → Resources 폴더 등
 * 2. 속성에서 Build Action = Resource
 * 3. 출력 디렉터리에 복사: 필요 없음
 * 4. pack URI 사용해 이미지 로드
 */
#endregion

#region #2. DataGrid
/*
 * - 데이터를 표(테이블) 형태로 데이터를 표시하고 조각할 수 있는 유연한 컨트롤.
 *   ㄴ 엑셀처럼 행/열이 있는 표 형식의 UI
 *   
 * 
 * [특징]
 * 1) 데이터 바인딩
 *    ㄴ ItemsSource 속성을 사용하여 컬렉션(예: List<T>)에 바인딩하면, 해당 컬렉션의 데이터가 자동으로 DataGrid에 표시됨!
 * 2) 컬럼 자동/수동 생성 가능
 * 3) 정렬/필터/스크롤 등 기본적인 테이블 기능 지원
 *
 * 
 * When?
 * - 데이터 목록을 표 형식으로 보여줄 때
 * - 데이블 데이터를 수정하거나 삭제할 때
 * 
 * [속성]
 * - ItemSource: 보여줄 데이터 목록 - 데이터 바인딩용 컬렉션
 * - AutoGenerateColumns: 자동으로 열 생성 여부 (true / false) - 기본 값: true
 * 
 * [편집 관련 속성]
 * - CanUserAddRows: 사용자가 직접 행 추가 가능 여부 - 기본 값: true
 *   ㄴ 이 빈 행에 데이터를 입력하면, 새로운 데이터 항목이 DataGrid의 ItemsSource 컬렉션에 자동으로 추가 됨.
 * - CanUserDeleteRows: 사용자가 직접 행 삭제 가능 여부 - 기본 값: true
 * - CanUserSortColumns: 컬럼 정렬 허용 여부 - 기본 값: true
 * - IsReadOnly: DataGrid 전체를 읽기 전용으로 설정. - 기본 값: false
 * - IsReadOnly (컬럼 속성명): 특정 컬럼만 읽기 전용 설정.
 * 
 * [ ##### 여기 까지 작성하고, [4]  DataGrid 코드 작성 ㄱ ]  * 
 * [컬럼 생성 방식]
 * - 1) AutoGenerateColumns = true (자동 컬럼 생성)
 *      ㄴ 바인딩된 객체의 속성을 기반으로 컬럼 자동 생성! - 개발 시간 크게 단축!
 *      ㄴ string, int -> TextColumn / bool -> CheckBoxCloumn 자동 매핑.
 *      ㄴ 빠르게 개발 가능! But, 열 순서 / 헤더명 / 스타일 제어 어려움.
 *          ㄴ 속성명이 그대로 나옴 (Name → Name, IsPresent → IsPresent)
 *      
 * - 2) AutoGenerateColumns = false (수동 컬럼 정의)
 *      ㄴ <DataGrid.Columns> 요소를 수동으로 작성해 컬럼 구성
 *      ㄴ 열의 순서, 너비, 헤더 이름 등을 명확하게 설정 가능
 *      ㄴ 텍스트 외에도 CheckBox, ComboBox, 등 다양한 형태 사용 가능
 *      
 * [사용자 정의 컬럼 속성 종류] - DataGrid.Columns 내부에서 사용
 * - DataGridTextColumn : 일반 텍스트 데이터를 표시하고 편집. - Binding 속성으로 데이터 원본의 속성을 지정.
 * - DataGridCheckBoxColumn: bool 타입의 데이터를 체크박스로 표시.
 * - DataGridComboBoxColumn: 드롭다운 선택 컬럼
 * - DataGridTemplateColumn: 셀의 내용을 원하는 WPF 컨트롤로 구성 가능 (버튼, 이미지 등 삽입 가능) - 가장 유연한 컬럼 타입
 *      
 * [ ##### 여기 까지 작성하고, [5]  DataGrid - 수동 컬럼 ㄲ ] 
 * 
 * [행 선택 및 데이터 접근 관련 속성]
 * - SelectionMode: 단일/다중 선택 설정 ( Single / Extened )
 *   ㄴ Single: 단일 행만 선택 가능
 *   ㄴ Extended: Shift/Ctrl 키 사용하여 다중 행 선택 가능
 * 
 * - SelectionUnit:
 *   ㄴ Cell: 셀 단위로 선택
 *   ㄴ FullRow: 행 전체를 선택. (가장 일반적)
 *   ㄴ CellOrRowHeader: 셀 또는 행 헤더 선택
 * 
 * - SelectedItem: 현재 선택된 단일 항목을 가져옴 (단일 선택 모드)
 * - SelectedItems: 현재 선택된 모든 항목의 컬렉션 가져옴 (다중 선택 모드)
 * - SelectedIndex: 현재 선택된 항목의 인덱스 가져옴.
 *  
 * [ ##### 여기 까지 작성하고, [6]  DataGrid 데이터 선택 ] 
 */
#endregion

#region 부연 설명
/*
 * 설명 순서
 * 1. 어제 시간에 쫓겨 잘못 언급드린 부분이 있는거 같아 정정
 * 2. 그리고 추가적으로 더 설명드려야 할 부분 설명
 *    ㄴ resource 먼저 설명, content 내용 수정 , 전체 부연 설명 진행
 * [[ 부연 설명 ]]
 * - 사용자가 업로드하거나 수정하는 이미지에는 Content 방식을 잘 쓰지 않음.
 *   ㄴ 프로그램 외부경로에 따로 저장되며, 접근할 땐 절대경로를 사용.
 * 
 * Content 방식은 결국 '빌드 시점'에 포함되는 리소스를 의미하기 때문.
 * 
 * [ 정리 ]
 * - 앱 개발자가 미리 넣어두는 이미지 -> 빌드 시 포함되어 배포 : Resource , Content
 * - 앱 실행 중 사용자 입력으로 생긴 이미지 -> 외부 경로에 저장 (DB, 서버 등) : 절대경로 (UriKind.Absolute)
 * 
 * [ Resource VS Content 차이 정리 ]
 * # Resoure
 * - 빌드 결과 : 어셈블리 안에 내장됨.
 * - 경로 접근 : pack://... URI 방식
 * - 파일 존재 위치 : 실행중에는 실제 파일 없음 (메모리 상에 존재)
 * - 수정/삭제 : 불가능 (읽기전용)
 * - 대표 용도 : 아이콘, UI 이미지, 버튼 배경 등 정적 리소스
 * 
 * 
 * # Content
 * - 빌드 결과 : 실행파일 옆에 복사됨
 * - 경로 접근 : 상대/절대 경로 방식
 * - 파일 존재 위치 : 실행 폴더에 파일이 있음.
 * - 수정/삭제 : 가능
 * - 대표 용도 : 설명 이미지, PDF, 문서, 동영상 등 실제 파일이 필요할 때
 * 
 * Content 왜 쓰는가?
 *   ㄴ 이미지 뿐 아니라, PDF, 동영상, 등도 포함해서 사용자에게 보여줘야 할 때 
 *   ㄴ 실행 중 수정 가능 여부: 유저가 설정을 바꾸거나, 게임 세이브 데이터를 저장하거나 - 실행 중에도 수정 가능
 *   ㄴ 용량 이슈 / 관리 용이성 : Content는 실행 파일이 가볍고, 파일은 옆에 따로 존재   <-> Resource는 실행파일 크기가 커짐.
 *      ㄴ 유지보수 시 Content는 파일만 바꾸면 되므로 유리
 *      
 * 요약 : 수정할 필요가 없음(아이콘, 배경 이미지) -> Resource 적합
 *        파일로 접근해서 열거나 수정 가능해야 함 -> Content 적합
 *        
 * - 유저가 열람/수정/저장해야 할 리소스는 무조건 Content 또는 외부 경로로!     
 * 
 * 
 * [ build Action vs UriKind ]
 * - Resource, Content 인지는 "파일의 빌드 방식"에 대한 설정
 * - UriKind는 해당 파일을 어떻게 접근할지에 대한 방식 일뿐  둘은 직접적인 연결이 없다.
 * 
 * Resource - Pack URI(pak://...) 사용 -> UriKind.Absoulte (항상)
 * Content - 상대 / 절대 사용 -> Relative or Absolute 사용
 * (외부 파일) - 물리 경로 or URL -> 보통 Absolute 사용
 * 
 * 
 * [ Resource 왜 꼭 Pack URI를 써야 할까? ]
 * - Resource 방식은 이미지나 파일이 실행 파일(.exe)에 내장되기 때문에 물리적인 파일 경로가 존재하지 않기 때문!
 * 그래서 WPF는 .exe 안에 있는 리소스 파일을 찾을 수 있도록 Pack URI 라는 전용 주소 체계를 사용하는 것!
 * 
 * 사실 우리가 했던 Resource 방식인데 UriKind.Relative 형식으로 처리하게 되면 잘못된 것!
 * ㄴ 상대경로로 처리 했는데 잘 됐다?
 *      ㄴ 그건 WPF의 내부 처리 규칙으로 인해 내부에서 Pack URI로 자동 해석해서 처리 했기 때문일 것임.
 *      ㄴ 그래도 간단한 테스트에서는 문제가 없어보이지만, 복잡한 구조로 이어지면 이미지가 깨질수 있으므로 비권장!
 *      
 * [@ 는 언제 사용하는가?]
 * - 주요 용도!
 * - 이스케이프 시퀀스 무시!
 *      ㄴ 일반 문자열에서 \(백슬래시)가 이스케이프 문자로 사용되어 \n 줄바꿈 \t 탭 등 나타내는데
 *         파일 경로에서는 \가 경로 구분자로 사용되기 때문에 경로 작성할때 \\ 두 번 입력해야하는 불편함이 있음.
 *      ㄴ @를 사용하면 \를 한번만 입력해도 됨. 
 *          ㄴ @가 붙은 문자열은 \를 이스케이프 문자로 해석하지 않고 문자 그대로 받아들여줌.
 * 
 * * 이스케이프 문자란?
 * -> 프로그래밍 언어나 텍스트 형식에서 특수한 의미를 가지는 문자를 일반 문자처럼 취급, 특수 문자를 표현하기 위해 사용되는 문자
 * 보통 백슬래시 (\)와 함께 사용되어 일련의 이스케이프 시퀀스를 만듦.
 * -> 즉, 문자열 내에서 특수문자를 표현하기 위해,
 *    ㄴ " 가 문자열의 시작 과 끝을 나타내듯이
 *    ㄴ \ 도 출력 시 특별한 동작을 지시하기 위해서 특수문자를 표현! : \t \n \r 같이
 *          
 * Why? 리더님! 그럼 그냥 / 이거 사용하면 되는데 왜 @, \ 이걸 사용하는거에요?
 * - Windows 환경에 익숙하기 때문에 (C# 개발은 Windows 운영체제에서 이루어짐.)
 * - 보통 탐색기나 프로그램에서 파일 경로를 복사해오는데 기본적으로 \(백슬래시)로 된 경로가 제공됨.
 *   이걸 개발자들은 보통 그대로 코드에 붙여 넣기 때문에 @를 붙이는 것이 가장 빠르고 익숙한 방법!
 * - 또한, 역사가 긴 언어이기 때문 기존 프로젝트 및 코드베이스가 존재할 것. 과거에는 / 로 경로 구분자를 사용하는 것이 덜 보편화 되어 있었을 거임.
 * C:\Users\jae hyeon\Desktop  => @"C:\Users\jae hyeon\Desktop";
 */
#endregion