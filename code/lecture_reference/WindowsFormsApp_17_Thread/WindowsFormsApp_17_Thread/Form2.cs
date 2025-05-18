using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_17_Thread
{
    public partial class Form2 : Form
    {
        // [1] 기본 상수 및 상태 변수 정의
        const int FINISH_LINE = 100;
        static object lockObject = new object(); // 공유 데이터 보호용
        int rank = 1;                // 도착 순위
        int finishedCars = 0;        // 도착한 차량 수
        List<Thread> threads = new List<Thread>(); // 각 차량의 스레드 저장
        string[] carNames = { "🚗 차1", "🚙 차2", "🏎️ 차3", "🚕 차4", "🚓 차5" };

        Random rd = new Random(); // [1] Random 인스턴스 (전역 1개만);

        public Form2()
        {
            InitializeComponent();
            // [2] 레이스 시작
            StartRace();
        }
        // [3] 차량마다 스레드를 생성하여 동시에 실행
        void StartRace()
        {
            foreach (string name in carNames)
            {
                Thread t = new Thread(() => RunRace(name));
                threads.Add(t);
                t.Start(); // 스레드 실행
            }
        }

        // [4] 각 차량이 실행하는 레이스 로직
        void RunRace(string carName)
        {
            int distance = 0;
            int waitTime;

            // [5] 레이스 시작 시간 기록
            DateTime startTime = DateTime.Now;

            // [6] FINISH_LINE 도달할 때까지 반복 전진
            while (distance < FINISH_LINE)
            {
                lock (lockObject)
                {
                    waitTime = rd.Next(100, 1000); // 0.1~1초 대기 시간
                }

                distance += 10; // 10씩 전진
                Thread.Sleep(waitTime); // 랜덤 대기
            }

            // [7] 도착 시간 기록 및 걸린 시간 계산
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            // [8] 결과 출력은 UI 스레드에서만 가능하므로 lock + Invoke 처리
            lock (lockObject)
            {
                int myRank = rank++;

                Invoke((MethodInvoker)(() =>
                {
                    textBox1.Text += ($"{myRank}등 - {carName} 도착! 소요 시간: {duration.TotalSeconds:F2}초 \r\n");
                }));

                finishedCars++;

                // [9] 모든 차량 도착 시 종료 메시지 출력
                if (finishedCars == carNames.Length)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        textBox1.Text +=("\r\n🏁 모든 차량 도착! 경기 종료 🏁");
                    }));
                }
            }
        }

       
    }
}
