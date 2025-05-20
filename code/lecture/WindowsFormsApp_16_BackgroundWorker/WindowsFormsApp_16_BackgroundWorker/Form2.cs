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
    public partial class Form2 : Form
    {
        // #1. 객체 생성
        BackgroundWorker bcw = new BackgroundWorker();
        public Form2()
        {
            InitializeComponent();
           

            // #2. 옵션 설정
            bcw.WorkerReportsProgress = true;

            // #3. 프로그래스바 기본 값 범위 설정 (0 ~ 100)
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            // #8. 이벤트 연결
            bcw.DoWork += Bcw_DoWork;
            bcw.ProgressChanged += Bcw_ProgressChanged;
            bcw.RunWorkerCompleted += Bcw_RunWorkerCompleted;

        }

        // #4. 버튼 클릭 시, 백그라운드 worker 작업을 시작!
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // 백그라운드 작업 시작!
            bcw.RunWorkerAsync();
        }

        // #5. DoWork가 실행할 실제 작업
        private void Bcw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i<= 100; i++)
            {
                Thread.Sleep(30);   // 30ms 지연
                bcw.ReportProgress(i);  // 진행 상황 보고
            }
        }

        // #6. UI 스레드(메인)에서 프로그래스바 업데이트
        private void Bcw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        // #7. 작업 완료 시 메시지 박스 출력
        private void Bcw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("완료됨");
        }
    }
}
