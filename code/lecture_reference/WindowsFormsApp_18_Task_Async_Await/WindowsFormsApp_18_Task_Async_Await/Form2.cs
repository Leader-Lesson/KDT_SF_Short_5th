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

                // 비동기 파일 읽기 호출 및 결과 표시
                string fileContent = await ReadFileAsync(filePath);

                textBox1.Text = fileContent;
            }
        }
    }
}
