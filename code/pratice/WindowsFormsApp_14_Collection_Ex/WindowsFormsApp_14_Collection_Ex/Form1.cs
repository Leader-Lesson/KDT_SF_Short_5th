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

namespace WindowsFormsApp_14_Collection_Ex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 아이디/비밀번호 저장용 딕셔너리
        Dictionary<string, string> idPwDc = new Dictionary<string, string>();
        // ㄴ 아이디(key) 비밀번호(value) 저장

        // 아이디/전화번호 저장용 딕셔너리 (전화번호 없을 경우 null)
        Dictionary<string, string> idPhoneDc = new Dictionary<string, string>();
        // ㄴ 아이디(key) 전화번호(value) 저장

        // [1] 파일 불러오기 이벤트
        private void button_file_Click(object sender, EventArgs e)
        {
            // 파일 선택 다이얼로그 열기
            OpenFileDialog ofd = new OpenFileDialog();  // 파일 열기 창을 띄우는 클래스
            ofd.Filter = "텍스트 파일 (*.txt)|*.txt";    // [속성] 파일 종류 필터 설정: 텍스트 파일만 선택

            if (ofd.ShowDialog() == DialogResult.OK)    // 파일 열기 창에서 사용자가 파일을 선택하고 "열기"를 누르면 Ok
            {
                string filePath = ofd.FileName;     // [속성] 선택한 파일의 전체 경로 변수에 저장.

                // 파일 열기 -> using으로 안전하게 닫히도록 처리
                using (StreamReader sr = new StreamReader(filePath))    // 파일 한 줄씩 읽을 준비. 파일을 읽기 모드로 염
                // StreamReader: 텍스트 파일 등 내용을 한 줄씩 또는 전체 문자열로 읽어들이는 클래스
                // ㄴ using: 파일 사용이 끝나면 자동으로 닫음 (자원 누수 방지)
                // ㄴ using{}을 벗어나면 자동으로 sr.Close() 됨
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)  // 파일 끝까지 줄을 하나씩 읽음.
                    // 한 줄 읽어 line에 저장, 줄이 없으면 반복 종료
                    {
                        // 줄을 쉼표(,) 기준으로 분할
                        string[] data = line.Split(','); // ["damon","1359","01012345678"]

                        string id = data[0];
                        string pw = data[1];

                        // 전화번호는 없는 경우도 있으므로 null 처리
                        string phone = null;

                        if (data.Length >= 3 && !string.IsNullOrWhiteSpace(data[2])) // 세 번째 항목(전화번호)이 존재하고 공백이 아니라면 → phone 변수에 저장
                        {
                            phone = data[2];
                        }

                        // 딕셔너리에 저장
                        idPwDc[id] = pw;
                        idPhoneDc[id] = phone;
                    }
                }
                MessageBox.Show("파일 불러오기 완료!");
            }
        }

        // [2] 로그인 버튼 클릭 이벤트
        private void button_login_Click(object sender, EventArgs e)
        {
            // 입력값에서 공백 제거 (Trim)
            string inputId = textBox_id.Text.Trim();
            string inputPw = textBox_pw.Text.Trim();

            // 아이디 존재 여부 확인
            if (!idPwDc.ContainsKey(inputId))
            {
                MessageBox.Show("[에러]: 아이디가 존재하지 않습니다.", "로그인 실패");
                return;
            }

            // 비밀번호 일치 여부 확인
            if (idPwDc[inputId] != inputPw)
            {
                MessageBox.Show("[에러]: 비밀번호가 일치하지 않습니다.", "로그인 실패");
                return;
            }

            // 로그인 성공 → 전화번호가 없을 수도 있음
            string phone = null;

            // 딕셔너리에 해당 아이디가 있고, 전화번호가 null이 아닐 경우
            if (idPhoneDc.ContainsKey(inputId) && !string.IsNullOrWhiteSpace(idPhoneDc[inputId]))
            {
                phone = idPhoneDc[inputId];
            }

            if (phone != null)
            {
                MessageBox.Show($"로그인 성공!\n 아이디: {inputId}\n 전화번호: {phone}", "로그인 성공");
            }
            else
            {
                MessageBox.Show($"로그인 성공!\n아이디: {inputId}\n 전화번호: 없음", "로그인 성공");
            }
        }
    }    
}
