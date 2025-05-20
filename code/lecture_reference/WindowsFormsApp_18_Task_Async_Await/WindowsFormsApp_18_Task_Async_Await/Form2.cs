using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp_18_Task_Async_Await
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // [1] 비동기 파일 읽기 메서드
        private async Task<string> ReadFileAsync(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // StreamReader에 내장된 비동기 메서드 사용
                string content = await reader.ReadToEndAsync();
                // 파일 전체를 끝까지 한 번에 읽는 비동기 함수
                // ⬆️ 파일 전체 내용을 비동기적으로 문자열로 읽어서 content에 저장됨
                // ⬅️ content = "파일 안의 전체 텍스트" 형태의 string 값
                
                // 이 함수는 Task<string> 타입을 반환합니다.
                // 작업이 끝나면 그 안에 담긴 string 값을 꺼냅니다.
                // 그리고 그 값(string) 을 변수 content에 담습니다.

                // await란?
                // 비동기 Task를 기다리는 것 비동기 작업이 끝날 때까지
                // 결과값이 있는 경우(Task<T>) 결과값 T를 꺼내서 사용
                // 결과값이 없는 경우(Task)    그냥 끝날 때까지 기다림

                return content;  // ⬅️ 호출자에게 파일 전체 텍스트 반환
            }
        }

        // [2] 버튼 클릭 이벤트
        private async void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "텍스트 파일 (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                // ⬅️ filePath = 선택한 파일의 경로 예: "C:\Users\me\sample.txt"

                // 비동기 파일 읽기 호출 및 결과 표시
                string fileContent = await ReadFileAsync(filePath);
                // ⬅️ fileContent = "파일 안의 전체 텍스트" (ReadFileAsync에서 반환된 값)

                textBox1.Text = fileContent;
            }
        }
    }
}
