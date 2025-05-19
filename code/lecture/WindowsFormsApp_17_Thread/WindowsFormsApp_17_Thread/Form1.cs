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

#region Thread 설명
/*
Thread 란?
- C#에서 멀티스레드 작업을 수행할 수 있게 해주는 '기본 클래스'
  ㄴ System.Threading 네임스페이스에 정의됨.
- Thread 클래스를 사용하면,
  ㄴ 개발자가 직접 스레드를 만들고 제어할 수 있음.
  ㄴ 백그라운드에서 별도 작업을 실행 가능.

Why?
ㄴ 1) 긴 작업 (ex. 다운로드, 대규모 계산)을 실행할 때 UI가 멈추지 않도록
ㄴ 2) 여러 작업을 동시에 실행하고 싶을 때 (병렬 처리)

[대표 메서드]
- Start() : 스레드 실행
- Sleep(ms) : 지정 시간(ms) 동안 현재 스레드 일시 정지
- Abort() : 스레드 강제 종료 - 비권장
- Join() : 특정 스레드가 끝날 때까지 메인 스레드 대기

[주의]
- 너무 많은 스레드를 만들면 오히려 성능 저하.
- UI 스레드와의 충돌은 반드시 Invoke 처리해야 함.

## UI 스레드 (= 메인 스레드)
- 프로그램 실행 시작과 동시에 생성됨. (폼, 버튼, 텍스트박스 등 UI를 담당)

*/
#endregion

namespace WindowsFormsApp_17_Thread
{
    public partial class Form1 : Form
    {
        // #1. 공유 자원 (스레드 간 충돌 발생 가능)
        static int sharedData = 0;

        // #4. 동기화를 위한 lock 객체
        static object lockObject = new object();

        public Form1()
        {
            InitializeComponent();

            // 멀티 스레드
            // #2. 두 개의 스레드 생성
            Thread thread1 = new Thread(UpdateData1);
            Thread thread2 = new Thread(UpdateData2);

            // #3. 스레드 시작!
            thread1.Start();
            thread2.Start();
        }

        // #2-1. 첫 번째 스레드가 실행할 작업.
        private void UpdateData1()
        {
            lock (lockObject)
            {
                for (int i = 0; i < 10; i++)
                {
                    sharedData++;
                    Thread.Sleep(10); // CPU 점유 방지용 딜레이

                    // [UI 스레드 분기 처리]

                    if (textBox1.InvokeRequired)
                    // ㄴ bool 타입 속성
                    // ㄴ true면 지금 코드가 UI 스레드가 아닌 다른 스레드에서 실행 중이다는 뜻.
                    {
                        // UI 업데이트는 메인(UI)스레드에서 실행되도록 위임.
                        textBox1.Invoke(new MethodInvoker(() =>
                        // Invoke()는 UI 스레드에게 "이 메서드 대신 실행해줘"라고 요청하는 메서드
                        // MethodInvoker
                        // ㄴ 매개변수 없고, 반환값도 없는 메서드를 UI 스레드에서 실행하게 함.
                        {
                            textBox1.Text += $"1: {sharedData}\r\n";
                        }));
                    }
                    else // 현재 스레드가 UI 스레드 인 경우,
                    {
                        textBox1.Text += $"1: {sharedData}\r\n";
                    }
                }
            }
            
        }

        // #2-2. 두 번쨰 스레드가 실행할 작업.
        private void UpdateData2()
        {
            lock (lockObject)
            {
                for (int i = 0; i < 10; i++)
                {
                    {
                        sharedData++;
                        Thread.Sleep(10); // CPU 점유 방지.

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
}
