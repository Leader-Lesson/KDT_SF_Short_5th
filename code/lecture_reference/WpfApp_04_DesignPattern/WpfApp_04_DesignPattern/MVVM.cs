using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_04_DesignPattern
{
    public class MVVM
    {

    }
}
#region #2. MVVM 패턴
/*
 * Model - View - ViewModel 의 약자.
 * ㄴ WPF 전용 디자인 패턴
 * ㄴ UI와 데이터 처리 로직을 분리하여 유지보수성과 테스트 용이성을 높이기 위한 구조.
 * 
 * [1] Model
 * - 데이터와 비즈니스 로직을 담당하는 계층
 * - DB, 파일, API 등 외부 자원과의 상호작용 처리
 * - 예: 사용자 정보, 카운트 값, 상품 목록 등등
 * 
 * [2] View
 * - 사용자 인터페이스 (UI) 계층
 * - XAML로 작성된 화면 구성 요소들 (버튼, 텍스트 등등)
 * - ViewModel에 바인딩된 데이터를 화면에 표시
 * - 사용자의 입력을 ViewModel로 전달 (Command 사용)
 * 
 * [3] ViewModel
 * - View와 Model 사이의 중간 관리자 역할
 * - ViewModel에 있는 속성은 View에 바인딩되어 자동 갱신
 * - ICommand를 이용하여 사용자 입력 이벤트 처리
 * - Model과 상호작용하며 데이터를 가공해 View에 제공
 * - 예: 버튼 클릭 시 Count 증가 처리.
 * 
 * - MVVM 패턴을 수동으로 구현하는건 굉장히 어려움.
 *   ㄴ (참고) INotifyPropertyChanged, ICommand 등등..
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
 * - ObservableObject : ViewModel 베이스 클래스 
 * 
 * [설정 방법]
 * 1. ViewModel 클래스에 필요한 using 선언
 * using CommunityToolkit.Mvvm.ComponentModel;
 * using CommunityToolkit.Mvvm.Input;
 * 
 * 2. ViewModel 클래스가 ObservableObject를 상속       --> INotifyPropertyChanged 포함된 클래스 상속
 * public partial class TodoViewModel : ObservableObject
 * 
 * 3. 속성 자동 구현: [ObservableProperty]  --> View <-> ViewModel 간 데이터 자동 연동
 * [ObservableProperty]
 * private string? newTask;  // → NewTask 속성 자동 생성 + 변경 알림 자동 구현됨
 * 
 * 4. 명령 자동 생성: [RelayCommand]  --> 버튼 클릭 등 UI 이벤트를 ViewModel 메서드로 연결
 * [RelayCommand]
    private void AddTask()
    {
        // 버튼 클릭 시 실행될 로직
    }
 */
#endregion