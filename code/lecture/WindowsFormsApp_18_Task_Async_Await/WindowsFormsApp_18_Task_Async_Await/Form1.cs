﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

#region Task / async / await 개념
/*
[1] Task란?
- Task는 비동기 작업을 나타내는 "타입(클래스)". - 하나의 자료형(Type)
- Task: 결과가 없는 작업       // void
- Task<T>: 결과가 있는 작업.   // Task<int> => int 반환 역할.

[2] async란?
- 해당 메서드가 "비동기 작업을 수행함"을 컴파일러에게 알리는 키워드.
- 메서드 안에서 await을 사용할 수 있게 해줌.

[3] await란?
- 해당 비동기 작업(Task)이 끝날 때까지 기다림.
- await은 "비동기 작업이 끝날 때까지 기다려!" 라는 뜻.
- 다만, 기다리면서도 스레드를 점유하지 않기 때문에 UI 멈춤 없이 동작!
- Task 또는 Task<T>를 반환하는 메서드에만 붙일 수 있음.

[4] 언제 비동기 처리를 해줘야 하나? (When?)
- 1) 시간이 오래 걸리는 작업인데, UI를 멈추면 안될 때 (ex. Thread.Sleep -> UI 프리징)
- 2) I/O 작업 (파일, DB, 웹 요청 등) 처리할 때
- 3) 여러 작업을 동시에 처리하고 싶을 때
 */
#endregion

#region Thread, BackgroundWorker VS Task/async/await 비교
/*
[Thread]
- 직접 스레드 생성해서 병렬 작업 가능
- UI 스레드와 분리되므로 UI 멈춤 방지는 가능.
- 하지만, UI 변경 시 Invoke 필요, 코드 복잡
- 비동기 처리 불가 (작업이 끝날 때까지 스레드 점유)

[BackgroundWorker]
- 이벤트 기반으로 동작하는 구형 멀티스레딩 방식 (WinForms 초창기에 쓰던 방식)
- UI 연동 위해 따로 RunWorkerCompleted 필요
- async/await 도입 이후 거의 사용되지 않음 -> 레거시 프로젝트로만 관리됨.

[Task + async/await]
- 가장 현대적이고 권장되는 비동기 처리 방식
- 코드 간결, UI 멈춤 없음, 가독성 높음
- 예외 처리 간편 (try-catch 가능)

[메서드]
Task.Run: 병렬 작업
Task.Delay: 지연 작업
Task.WhenAll: 병렬 대기
Task.FromResult: 결과 Task 래핑
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

        // [1]. 버튼 클릭 이벤트 핸들러
        // async?
        // ㄴ 이 메서드는 비동기 작업을 포함할 수 있어! 라고 선언
        // ㄴ async를 붙이면 await를 쓸 수 있게 된다.
        // ㄴ 단독으로 아무 기능도 없고, 반드시 await와 함께 사용해야 의미.
        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "작업 시작";

            // [2] Task.Run()으로 백그라운드에서 무거운 작업 실행.
            await Task.Run(() => LongWork());
            //LongWork();
            label1.Text = "작업 완료!";
        }

        // [2-1] 무거운 작업 메서드 (실제로는 CPU 점유함)
        private void LongWork()
        {
            Thread.Sleep(3000); // CPU 점유함.
        }

        // [3] Task.Delay: 스레드를 점유하지 않고 일정 시간 대기 (비동기 대기)
        private async void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "4초 대기 중...";

            await Task.Delay(4000); // Delay가 끝날 때까지 기다려!

            label1.Text = "4초 대기 완료!";
        }

        // [4] Task.FromResult: 이미 계산된 결과를 Task를 감싸서 반환할 때 사용.
        // 
        private async void button3_Click(object sender, EventArgs e)
        {
            Task<int> task = Task.FromResult(123); // 즉시 완료된 Task 객체.
            int result = await task;

            label1.Text = $"결과 : {result}";
            //label1.Text = $"결과 : {task}";
        }
        // [5] Task.WhenAll: 여러 Task를 동시에 실행하고, 모두 끝날 때까지 기다림.
        // - 가장 오래 걸리는 Task 시간만큼만 기다림.
        private async void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "모든 작업 시작!";

            Task t1 = Task.Run(() => Thread.Sleep(2000)); // 스레드에서 2초
            Task t2 = Task.Delay(3000);     // 3초 대기 (비동기)

            await Task.WhenAll(t1, t2);

            label1.Text = "모든 작업 완료!";
        }

        // 보충 설명!
        // Task는 C#에서 비동기 작업을 나타내는 객체.
        // - '작업이 진행 중이고, 나중에 완료된다"는 개념.
        // - Task: 결과가 없는 작업       // void
        // - Task<T>: 결과가 있는 작업.   // Task<int> => int 반환 역할.

        // await란?
        // Task 또는 Task<T> 또는 await 가능한 객체를 반환하는 메서드에만 붙일 수 있음.

        /*
        private async void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "4초 대기 중...";

            await Task.Delay(4000); // Task를 반환하는 메서드!

            label1.Text = "4초 대기 완료!";
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            int result = await Add(3, 5);
        }
        */

        public async Task<int> Add(int a, int b)
        {
            //await Task.Delay(1000);
            return a + b;
        }
        // int를 반환.
        // -> await은 비동기 결과(Task)가 필요.

        // async Task<int> 작업 한 메서드는
        // -> Task<int> 반환.

    }
}
