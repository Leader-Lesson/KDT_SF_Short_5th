using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 시나리오
 * - Todo List 목록을 한번 만들어보자.
 * 1. 사용자가 입력창에 할 일을 입력하고 [추가] 버튼을 누르면 목록에 추가.
 * 2. 목록은 ListBox로 출력
 * 3. 항목을 선택하고 [삭제] 버튼을 누르면 목록에서 제거.
 */

namespace WpfApp_04_DesignPattern
{
    internal class MVVM
    {
    }
}
#region #2. MVVM 패턴
/*
 * Model - View - ViewModel의 약자.
 * ㄴ WPF 전용 디자인 패턴
 * ㄴ UI와 데이터 처리 로직을 분리하여 유지보수성과 데스트 용이성을 높이기 위한 구조.
 * 
 * [1] Model
 * - 데이터와 비즈니스 로직을 담당하는 계층.
 * - DB, 파일, API 등 외부 자원과의 상호작용 처리
 * - 예: 사용자 정보, 카운트 값, 상품 목록 등등
 * 
 * [2] View
 * - 사용자 인터페이스(UI) 계층
 * - XAML로 작성된 화면 구성 요소들 (버튼, 텍스트 등등)
 * - ViewModel에 바인딩된 데이터를 화면에 표시.
 * - 사용자의 입력을 ViewModel로 전달 (Command 사용)
 * 
 * [3] ViewModel
 * - View와 Model 사이의 중간 관리자 역할
 * - ViewModel에 있는 "속성"은 View에 바인딩되어 자동 갱신
 * - ICommand를 이용하여 사용자 입력 이벤트 처리
 * - Model과 상호작용하며 데이터를 가공해 View에 제공.
 * - 예: 버튼 클릭 시 Count 증가 처리.
 * 
 * - MVVM 패턴을 수동으로 구현하는건 굉장히 어려움.
 *   ㄴ INotifyPropertyChanged, ICommand 등등..
 *   
 * - 고로, 라이브러리 사용 권장!
 */
#endregion

#region #3. CommunityToolkit.Mvvm 라이브러리
/*
 * - Microsoft가 관리하는 공식 MVVM 보조 라이브러리.
 * - MVVM 구조를 간결하고 안전하게 작성할 수 있도록 도와주는 도구!
 * 
 * [핵심 기능]
 * - ObservalbeProperty : 자동 속성 구현
 * - RelayCommand : 커맨드 자동 생성
 * - ObservalbeObject : ViewModel 베이스 클래스
 * 
 * [설정 방법]
 * 1. ViewModel 클래스에 필요한 using 선언.
 * using CommunityToolkit.Mvvm.ComponentModel;
 * using CommunityToolkit.Mvvm.Input;
 * 
 * 2. ViewModel 클래스가 ObservableObject를 상속
 * public partial class -- 일단 패스
 * 
 * 3. 속성 자동 구현: [ObservalbeProperty]
 * ㄴ View <-> ViewModel 간 데이터 자동 연동
 * 
 * 4. 명령 자동 생성: [RelayCommand]
 * ㄴ 버튼 클릭 등 UI 이벤트를 ViewModel 메서드로 연결
 */
#endregion

#region #4. MVVM 디렉토리 구조: Views에 MainWindow.xaml 옮겼을 때!
/*
 * 1. XAML 파일 상단
 * 
 * 2. MainWindow.xaml.cs 코드 상단
 * 
 * 3. App.xaml의 StartupURI 
 */

#endregion