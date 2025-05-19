using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#region Task / async / await 개념
/*
[1] Task란?
- Task는 비동기 작업을 나타내는 "타입(클래스)". - 하나의 자료형(Type) 
- Task는 결과가 없는 작업, Task<T>는 결과가 있는 작업을 나타냄.
  Ex) Task => void 역할   / Task<int> => int 반환 역할.
- 즉, "아직 끝나지 않은 작업을 나타내는 약속 객체"라고 생각하자.

[2] async란?
- 해당 메서드가 비동기 작업을 수행함을 컴파일러에게 알리는 키워드.
- 메서드 안에서 await을 사용할 수 있게 해줌.

[3] await란?
- 해당 비동기 작업(Task)이 끝날 때까지 기다림
- await은 "비동기 작업이 끝날 때까지 기다려!" 라는 뜻.
- 다만 기다리면서도 스레드를 점유하지 않기 때문에 UI 멈춤 없이 동작!
  (기다림은 있지만 비동기적으로!)
- Task 또는 Task<T> 를 반환하는 메서드에만 붙일 수 있음.

[4] 언제 비동기 처리를 해줘야 하나? (When?)
- 1) 시간이 오래 걸리는 작업인데, UI를 멈추면 안 될 때 (ex: Thread.Sleep -> UI 프리징)
- 2) I/O 작업 (파일, DB, 웹 요청 등)을 처리할 때 - 파일 읽는것이 제일 무거운 동작 중 하나
- 3) 여러 작업을 동시에 처리하고 싶을 때
*/
#endregion

#region Thread, BackgroundWorker VS Task/async/await 비교
/*
[Thread]
- 직접 스레드 생성해서 병렬 작업 가능 (System.Threading.Thread 로 직접 스레드 생성)
- UI 스레드와 분리되므로 UI 멈춤 방지는 가능.
- 하지만, UI 변경 시 Invoke 필요, 코드 복잡
- 비동기 처리 불가 (작업이 끝날 때까지 스레드 점유)

[BackgroundWorker]
- 이벤트 기반으로 동작하는 구형 멀티스레딩 방식 ( WinForms 초창기에 쓰던 방식 )
- UI 연동 위해 따로 RunWorkerCompleted 필요
- async/await 도입 이후 거의 사용되지 않음.

[Task + async/await]
- 가장 현대적이고 권장되는 비동기 처리 방식
- 코드 간결, UI 멈춤 없음, 가독성 높음
- 예외 처리 간편 (try-catch 가능)
- Task.Run: 병렬 작업
- Task.Delay: 지연 작업
- Task.WhenAll: 병렬 대기
- Task.FromResult: 결과 Task 래핑
*/


#endregion

namespace WindowsFormsApp_18_Task_Async_Await
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // [1]. 버튼 클릭 이벤트 핸들러.
        // async?
        // ㄴ 메서드는 비동기 작업을 포함할 수 있어! 라고 선언
        // ㄴ async를 붙이면 await를 쓸 수 있게 됩니다.
        // ㄴ 단독으로는 아무 기능도 없고, 반드시 await와 함께 사용해야 의미
        private async void button1_Click(object sender, EventArgs e)
        {
            // UI는 메인 스레드에서 실행됨.
            label1.Text = "작업 시작!";

            // [2] Task.Run() 으로 백그라운드에서 무거운 작업 실행.
            // - Thread.Sleep처럼 CPU 점유하는 작업은 UI 멈추므로 반드시 Task.Run으로 백그라운드 처리
            // - await 붙이면 작업이 끝날 때까지 기다려줌 (await: 기다려!)

            await Task.Run(() => LongOperation());
         
            label1.Text = "작업 완료!";
        }
        // [2-1]. 무거운 작업 메서드 (실제론 CPU 점유함)
        private void LongOperation()
        {
            Thread.Sleep(3000);  // CPU를 점유하는 방식 (UI에서 직접 사용 금지!)
        }

        // [3]. Task.Delay: 스레드를 점유하지 않고 일정 시간 대기 (비동기 대기)
        private async void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "3초 대기 중...";

            // Task.Delay
            // - 지정한 시간만큼 비동기적으로 대기 (UI 멈추지 않음)
            // - 실제로 스레드를 점유하지 않음 → 효율적!

            await Task.Delay(3000);  // await: Delay가 끝날 때까지 기다려!

            label1.Text = "3초 대기 완료!";
        }

        // [4]. Task.FromResult: 이미 계산된 결과를 Task로 감싸서 반환할 때 사용
        private async void button3_Click(object sender, EventArgs e)
        {
            // Task.FromResult
            // - 결과가 이미 계산된 값일 때 Task<int> 형태로 감싸서 반환
            // - 테스트나 구조상 Task<T> 반환이 필요한 곳에서 유용함

            Task<int> task = Task.FromResult(123);  // 즉시 완료된 Task 객체
            int result = await task;  // await: task가 끝날 때까지 기다려!

            label1.Text = $"결과: {result}";
        }

        // [5]. Task.WhenAll: 여러 Task를 동시에 실행하고, 모두 끝날 때까지 기다림
        private async void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "모든 작업 시작...";

            // Task.WhenAll
            // - 여러 개의 비동기 작업을 병렬로 실행하고 모두 완료될 때까지 대기
            // - 가장 오래 걸리는 Task 시간만큼만 기다림

            Task t1 = Task.Run(() => Thread.Sleep(2000));   // 별도 스레드에서 2초
            Task t2 = Task.Delay(3000);                     // 3초 대기 (비동기)

            await Task.WhenAll(t1, t2);  // await: t1과 t2 둘 다 끝날 때까지 기다려!

            label1.Text = "모든 작업 완료!";
        }
    }
}
