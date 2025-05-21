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
        // [3] pack URI
        // #1. 상태 기억용 변수 생성
        private bool isCat = true;

        // #2. 이미지 경로 (pack URI 방식)
        private Uri uriCatImage = new Uri("pack://application:,,,/Assets/cat.jpg", UriKind.Absolute);
        private Uri uriDogImage = new Uri("pack://application:,,,/Assets/dog.jpg", UriKind.Absolute);
        public MainWindow()
        {
            InitializeComponent();

            // [1] 초기 이미지 설정
            imgTest.Source = new BitmapImage(new Uri("Assets/test2.png", UriKind.Relative));
            // new Uri(...) - 이미지 파일의 경로를 Uri 객체로 만듦.
            // UriKind.Relative - 실행파일 기준 상대 경로로 해석하겠다는 뜻.
            // ㄴ Relative: 실행 파일 기준 경로
            // ㄴ Absolute: 전체 경로 명시
            // ㄴ RelativeOrAbsolute: 둘 중 맞는걸 자동 판별 (거의 안씀)

            // new BitmapImage(...) - Uri를 통해 실제 이미지 객체 생성
            // Uri 란?
            // ㄴ 파일, 웹주소, 리소스의 경로를 하나의 객체로 표현한 C#의 데이터 형식
            // ㄴ "리소스(파일, 이미지 등)의 위치를 식별"하는 용도
            //
            // BitmapImage(Uri) - 이미지 파일을 불러와 화면에 보여줌

            // [2] Content 초기 이미지 설정
            imgTest2.Source = new BitmapImage(new Uri("Assets/test4.jpg", UriKind.Relative));

            // [3-3] 초기 이미지 설정
            imgDisplay.Source = new BitmapImage(uriCatImage);

            // [4] GirdBox
            // 예제용 데이터 리스트 생성
            List<Student> students = new List<Student>
            {
                new Student { Name = "홍길동", Age = 20, Grade = "A" },
                new Student { Name = "김철수", Age = 21, Grade = "B" },
                new Student { Name = "이영희", Age = 19, Grade = "A+" }
            };

            // DataGrid에 데이터 바인딩
            dataGrid.ItemsSource = students;

            studentGrid.ItemsSource = new List<Student>
{
            new Student { Name = "홍길동", Age = 3, Grade = "B"},
            new Student { Name = "김영희", Age = 2, Grade = "A+"}
};
        }

        // [1] Resource C# 버전
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // [2] 버튼 클릭 시 이미지 변경
            imgTest.Source = new BitmapImage(new Uri("Assets/test.png", UriKind.Relative));
        }

        // [2] Content C# 버전
        private void Btn_Content_Click(object sender, RoutedEventArgs e)
        {
            // 실행 디렉터리에 복사된 이미지 경로
            string path = "Assets/test3.jpg";

            // 이미지 불러오기
            imgTest2.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }
        // [3-3] 버튼 클릭시 이미지 전환

        private void BtnChangeImage_Click(object sender, RoutedEventArgs e)
        {
            imgDisplay.Source = new BitmapImage(isCat ? uriDogImage : uriCatImage);

            // isCat 값을 반전시킴 (true → false, false → true)
            // 다음 버튼 클릭 시 반대 이미지가 나오도록 상태 전환
            isCat = !isCat;
        }

        // [4] GridBox
        public class Student
        {
            public string Name { get; set; }    // 이름
            public int Age { get; set; }        // 나이
            public string Grade { get; set; }   // 성적
        }
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
*/
#endregion

#region 2) Content 방식
/*
 * 2) Content 방식
 * - 이미지 파일을 실행 파일(.exe)이 있는 폴더에 복사해 놓고, 거기서 직접 불러오는 방식.
 * 
 * When?
 * - 사용자 업로드 이미지 
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
 * - WPF의 표(테이블) 형태로 데이터를 표시하고 수정할 수 있는 컨트롤
 *   ㄴ 엑셀처럼 행/열이 있는 표 형식의 UI
 *   
 * When?
 * - 데이터 목록을 표 형식으로 보여줄 때
 * - 데이블 데이터를 수정하거나 삭제할 때
 * 
 * [속성]
 * - ItemSource: 보여줄 데이터 목록 - 데이터 바인딩
 * - AutoGenerateColumns: true 이면 컬럼(열) 자동 생성 (기본 True)
 * - CanUserAddRows: 사용자가 직접 행 추가 가능 여부
 * - IsReadOnly: 읽기 전용으로 설정할거니 여부 확인.
 * - SelectionMode: 단일/다중 선택 설정 ( Single / Extened )
 * 
 * [컬럼 생성 방식]
 * - 1) AutoGenerateColumns = true (자동 컬럼 생성)
 *      ㄴ 데이터 클래스의 속성 이름을 기준으로 열을 자동 생성.
 *      ㄴ string, int -> TextColumn / bool -> CheckBoxCloumn 자동 매핑.
 *      ㄴ 빠르게 개발 가능! But, 열 순서 / 헤더명 / 스타일 제어 어려움.
 *          ㄴ 속성명이 그대로 나옴 (Name → Name, IsPresent → IsPresent)
 *      
 * - 2) AutoGenerateColumns = false (수동 컬럼 정의)
 *      ㄴ <DataGrid.Columns> 요소를 수동으로 작성해 컬럼 구성
 *      ㄴ 열의 순서, 너비, 헤더 이름 등을 명확하게 설정 가능
 *      ㄴ 텍스트 외에도 CheckBox, ComboBox, 등 다양한 형태 사용 가능
 *      
 * [컬럼 종류] - DataGrid.Columns 내부에서 사용
 * - DataGridTextColumn : 텍스트 전용 컬럼
 * - DataGridCheckBoxColumn: 체크박스 컬럼 (bool용)
 * - DataGridComboBoxColumn: 드롭다운 선택 컬럼
 * - DataGridHyperlinkColumn: 링크 표시 컬럼
 * - DataGridTemplateColumn: 사용자 정의 UI (버튼, 이미지 등 삽입 가능)
 *      
 * [행 선택 후 값 가져오기]
 * - 1) 단일 선택 모드: SelectedItem 속성 사용
 * - 2) 다중 선택 모드 (SelectionMode="Extended"):
 *   
 * 
 */
#endregion