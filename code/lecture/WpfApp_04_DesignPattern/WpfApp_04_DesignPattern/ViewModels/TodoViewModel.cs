using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_04_DesignPattern.Models;

namespace WpfApp_04_DesignPattern.ViewModels
{
    // [2] ViewModel 작성
    public partial class TodoViewModel : ObservableObject
        // ㄴ 상속받는 이유 : 속성과 UI 사이의 데이터 바인딩이 자동으로 동작하게 만들기 위해서.
        // ㄴ 꼭, partial class 이여야 함.

        // [2-1] 실시간으로 바뀌는 목록
    {
        public ObservableCollection<TodoItem> TodoItems { get; } = new();
        // get; => 읽기 전용 속성
        // 이 컬렉션을 생성자에서 따로 초기화하지 않고, 바로 선언과 동시에 인스턴스 생성.

        /*
         * ObservableCollection
         * ㄴ UI와 연결될 수 있는 컬렉션(List)
         * ㄴ 변화가 있을 시 UI에 자동 반영되도록 설계된 클래스
         * ㄴ 일반 List<T>는 데이터가 바뀌어도 UI가 모름.
         */

        // [2-2] TextBox 입력값 바인딩 대상 속성
        [ObservableProperty]
        private string newTask;         // 새로 추가할 항목.

        // [2-3] ListBox에서 선택된 항목 바인딩 속성
        [ObservableProperty]
        private TodoItem selectedItem;

        // [2-4] '추가' 버튼 클릭 시 실행될 커맨드 (메서드)
        [RelayCommand]
        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTask)) // NewTask는 사용자가 TextBox에 입력한 문자열
            {
                TodoItems.Add(new TodoItem
                {
                    Task = NewTask! // 항목 추가
                });
                NewTask = string.Empty;
            }
        }

        // [2-5] '삭제' 버튼 클릭 시 실행될 커맨드 (메서드)
        [RelayCommand]
        private void RemoveTask()
        {
            if (SelectedItem != null)
            {
                TodoItems.Remove(SelectedItem); // 선택 항목 삭제
            }
        }
    }
}
