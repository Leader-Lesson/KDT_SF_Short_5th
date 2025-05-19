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

namespace WindowsFormsApp_16_BackgroundWorker
{

    #region BackgroundWorker 설명
    /*
     * BackgroundWorker란?
     * - 백그라운드에서 작업을 처리할 수 있게 해주는 클래스
     *   ㄴ WinForms/WPF에서 UI 멈춤 없이 무거운 작업을 처리할 때 사용
     * - System.ComponentModel 네임스페이스에 정의되어 있음.
     *   ㄴ 별도 스레드를 생성하고 관리하는 비동기 도우미
     *   
     * [대표 기능] (이벤트) - 델리게이트 기반!
     * - DoWork : 백그라운드에서 실행할 작업 정의
     * - ProgressChanged : 작업 중 진행률 (0~100)을 UI에 알림.
     * - RunWokrerCompleted : 작업 완료 후 실행
     * - RunWorkerAsync() : 비동기 작업 시작 메서드
     * 
     * Why?
     * ㄴ 1) 무거운 작업을 UI와 분리시켜 실행할 수 있음.
     *       -> UI가 멈추지 않음.
     * ㄴ 2) `ReportProgress()`로 진행률을 UI에 안전하게 전달.
     * ㄴ 3) `Completed` 이벤트로 작업이 끝났을 때 후처리 가능
     * 
     */



    #endregion

    public partial class Form1 : Form
    {
        // #1. BackgroundWorker 선언.
        BackgroundWorker worker; // 클래스 내부에서 사용할 변수
        public Form1()
        {
            InitializeComponent();

            // #2. 객체 생성
            worker = new BackgroundWorker();

            // #3. 옵션 설정
            worker.WorkerReportsProgress = true;    // ReportProgress() 사용 가능하게 설정
            // ReportProgress()
            // ㄴ 작업 중간중간 진행률을 보고할 때 사용하는 메서드
            // ㄴ 진행률: 보통 0 ~ 100 사이의 정수 (%로 표현)
            worker.WorkerSupportsCancellation = false; // 취소 기능 X

            // #4. 이벤트 연결 (+=로 등록)
            worker.DoWork += Worker_DoWork;     // - 작업 내용 작성할 메서드 연결
            // [참고] worker라는 객체에서 DoWork 이벤트가 발생하면 Worker_DoWork라는 메서드를 실행해줘!
            worker.ProgressChanged += Worker_ProgressChanged;   // 진행 상황 UI 갱신 메서드 연결
            worker.RunWorkerCompleted += Worker_Completed;      // 작업 완료 후 실행할 메서드 연결
           
        }


        // #5. 시작 버튼 클릭 → 작업 시작
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy) // 중복 실행 방지
            // worker.IsBusy
            // ㄴ BackgroundWorker가 현재 실행 중인지 아닌지 bool로 알려줌.
            // ㄴ 실행 중이면 : true, 대기 상태면 : false
            {
                lblStatus.Text = "작업 시작!";
                progressBar1.Value = 0; // 프로그래스 바 초기 설정
                worker.RunWorkerAsync();  // 비동기 작업 실행
            }

            //// UI 스레드를 막아버리는 코드 (테스트용)
            //while (true)
            //{
            //    progressBar1.Value += 1;
            //    if (progressBar1.Value >= 100) break;
            //}
            // [참고] while 루프가 너무 빠르게 실행되면서 UI 스레드를 점유해버림
        }

        // #6. 실제 작업 실행 (UI 스레드와 분리)
        // - 백그라운드 스레드에서 실행
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);             // 0.05초 지연
                                              // 각 반복마다 50ms(0.05초) 동안 일시 중지
                                              // 실제 긴 작업을 흉내내기 위한 코드(예: 다운로드, 계산 등)
                worker.ReportProgress(i);     // 진행률 보고
                // 현재 진행 상황 i 값을 UI 스레드로 전달합니다.
            }
        }

        // #7. 진행률 UI 갱신 (UI 스레드에서 실행됨)
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            // e.ProgressPercentage는 ReportProgress(int)에서 전달한 값입니다.
            // ㄴ ReportProgress()로 전달한 % 값
            lblStatus.Text = $"{e.ProgressPercentage}% 진행 중...";
        }

        // #8. 작업 완료 후 1회 실행
        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "작업 완료!";
        }

    }
}
