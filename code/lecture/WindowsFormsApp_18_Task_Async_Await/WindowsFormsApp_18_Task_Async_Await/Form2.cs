using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_18_Task_Async_Await
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // [1] 비동기 파일 읽기 메서드
        private async Task<string> ReadFileAsync(string filepath)
        {
            using (StreamReader reader = new StreamReader(filepath))
            {
                // [2] StreamReader에 내장된 비동기 메서드 사용
                string content = await reader.ReadToEndAsync(); // Task<string>
                // 파일 전체를 끝까지 한 번에 읽는 비동기 함수
                // content <- "파일 안의 전체 텍스트" 형태의 string 값.

                // await
                // 역할
                // 1) 비동기 Task를 기다리는 것. - 비동기 작업이 끝날 때까지
                // 2) 결과값이 있는 경우 (Task<T>) - 결과값 T를 꺼내서 사용.
                // 3) 결과값이 없는 경우 (Task)     - 그냥 끝날 때까지 기다림.

                return content; // < 파일 전체 텍스트 반환
            }
        }

        private async void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "텍스트 파일 (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                // ex) C:\Users\test\test.txt

                // 비동기 파일 읽기 메서드 호출 및 결과 표시
                string fileContent = await ReadFileAsync(filePath); // Task<string>

                textBox1.Text = fileContent;
            }
        }
    }
}
