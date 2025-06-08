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
#endregion

#region Thread, BackgroundWorker VS Task/async/await 비교


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
        private async void button1_Click(object sender, EventArgs e)
        {
            // UI는 메인 스레드에서 실행됨.
            label1.Text = "작업 시작!";

            // [2] Task.Run() 으로 백그라운드에서 무거운 작업 실행.

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


            await Task.Delay(3000);  // await: Delay가 끝날 때까지 기다려!

            label1.Text = "3초 대기 완료!";
        }

        // [4]. Task.FromResult: 이미 계산된 결과를 Task로 감싸서 반환할 때 사용
        private async void button3_Click(object sender, EventArgs e)
        {

            Task<int> task = Task.FromResult(123);  // 즉시 완료된 Task 객체
            int result = await task;  // await: task가 끝날 때까지 기다려!

            label1.Text = $"결과: {result}";
        }

        // [5]. Task.WhenAll: 여러 Task를 동시에 실행하고, 모두 끝날 때까지 기다림
        private async void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "모든 작업 시작...";


            Task t1 = Task.Run(() => Thread.Sleep(2000));   // 별도 스레드에서 2초
            Task t2 = Task.Delay(3000);                     // 3초 대기 (비동기)

            await Task.WhenAll(t1, t2);  // await: t1과 t2 둘 다 끝날 때까지 기다려!

            label1.Text = "모든 작업 완료!";
        }
    }
}
