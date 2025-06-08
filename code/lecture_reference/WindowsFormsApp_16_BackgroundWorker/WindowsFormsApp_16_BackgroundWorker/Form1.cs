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
            worker.WorkerSupportsCancellation = false; // 취소 기능 X

            // #4. 이벤트 연결 (+=로 등록)
            worker.DoWork += Worker_DoWork;     // - 작업 내용 작성할 메서드 연결
            worker.ProgressChanged += Worker_ProgressChanged;   // 진행 상황 UI 갱신 메서드 연결
            worker.RunWorkerCompleted += Worker_Completed;      // 작업 완료 후 실행할 메서드 연결
           
        }


        // #5. 시작 버튼 클릭 → 작업 시작
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy) // 중복 실행 방지
            {
                lblStatus.Text = "작업 시작!";
                progressBar1.Value = 0; // 프로그래스 바 초기 설정
                worker.RunWorkerAsync();  // 비동기 작업 실행
            }

        }

        // #6. 실제 작업 실행 (UI 스레드와 분리)
        // - 백그라운드 스레드에서 실행
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);             // 0.05초 지연
                                              // 각 반복마다 50ms(0.05초) 동안 일시 중지
                worker.ReportProgress(i);     // 진행률 보고
                // 현재 진행 상황 i 값을 UI 스레드로 전달합니다.
            }
        }

        // #7. 진행률 UI 갱신 (UI 스레드에서 실행됨)
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = $"{e.ProgressPercentage}% 진행 중...";
        }

        // #8. 작업 완료 후 1회 실행
        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "작업 완료!";
        }

    }
}
