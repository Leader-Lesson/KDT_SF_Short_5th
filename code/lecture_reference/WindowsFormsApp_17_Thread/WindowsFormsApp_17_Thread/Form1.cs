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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp_17_Thread
{
    #region Thread 설명
    #endregion
    public partial class Form1 : Form
    {
        // #1. 공유 자원 (스레드 간 충돌 발생 가능)
        static int sharedData = 0;

        // #2. 결과 저장용 변수 (단일 연산용)
        static int sharedResult = 0;

        // #5. 동기화를 위한 lock 객체
        static object lockObject = new object();

        public Form1()
        {            
            InitializeComponent();

            // 멀티스레딩
            // #3. 두 개의 스레드 생성
            Thread thread1 = new Thread(UpdateData1);
            Thread thread2 = new Thread(UpdateData2);

            // #4. 스레드 시작
            thread1.Start();
            thread2.Start();
        }

        // #3-1. 첫 번째 스레드가 실행할 작업
        private void UpdateData1()
        {
            // #5-1. 
            //lock (lockObject)
            {
                for (int i = 0; i < 10; i++)
                {
                    sharedData++;
                    Thread.Sleep(10); // CPU 점유 방지용 딜레이

                    if (textBox1.InvokeRequired)
                    // ㄴ InvokeRequired는 bool 타입 속성
                    // ㄴ true면 지금 코드가 UI 스레드가 아닌 다른 스레드에서 실행 중이다는 뜻
                    {
                        // UI 업데이트는 메인(UI) 스레드에서 실행되도록 위임
                        textBox1.Invoke(new MethodInvoker(() =>
                        {
                            textBox1.Text += $"1: {sharedData}\r\n";
                        }));
                    }
                    else // 현재 스레드가 UI 스레드일 경우엔 굳이 Invoke() 안 하고 바로 실행
                    {
                        textBox1.Text += $"1: {sharedData}\r\n";
                    }

                }
            }
        }

        // #3-2. 두 번째 스레드가 실행할 작업
        private void UpdateData2()
        {
            // #5-2.
            //lock (lockObject) // 경쟁 조건 방지용 (필요 시 사용)
            {
                for (int i = 0; i < 10; i++)
                {
                    sharedData++;
                    Thread.Sleep(10); // CPU 점유 방지

                    // UI 업데이트는 반드시 UI 스레드에서!
                    if (textBox1.InvokeRequired)
                    {
                        textBox1.Invoke(new MethodInvoker(() =>
                        {
                            textBox1.Text += $"2: {sharedData}\r\n";
                        }));
                    }
                    else
                    {
                        textBox1.Text += $"2: {sharedData}\r\n";
                    }
                }
            }
        }
    }
}
