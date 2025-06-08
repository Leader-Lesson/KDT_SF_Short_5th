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
    // [2]. ViewModel 작성.
    public partial class TodoViewModel : ObservableObject
    {
        // [2-1] 실시간으로 바뀌는 목록
        public ObservableCollection<TodoItem> TodoItems { get; } = new();
        // 읽기 전용 속성 


        // [2-2] TextBox 입력값 바인딩 대상 속성
        [ObservableProperty]    // ** 인터페이스를 자동으로 구현해주는 속성!
        private string? newTask;

        // [2-3] ListBox에서 선택된 항목 바인딩 속성
        [ObservableProperty]
        private TodoItem? selectedItem;

        // [2-4] '추가' 버튼 클릭 시 실행될 커맨드
        [RelayCommand]          // 버튼 클릭 등의 명령을 처리하는 메서드에 붙이는 속성.
        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTask))    // NewTask는 사용자가 TextBox에 입력한 문자열
            {
                TodoItems.Add(new TodoItem { Task = NewTask! }); // 항목 추가
                NewTask = string.Empty; // 입력창 초기화
            }
        }

        // [2-5] '삭제' 버튼 클릭 시 실행될 커맨드
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
