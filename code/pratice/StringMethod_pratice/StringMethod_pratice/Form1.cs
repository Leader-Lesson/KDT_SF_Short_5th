using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringMethod_pratice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            string[,] orders = new string[,]
            {
                { "홍길동", "포도", "복숭아", "바나나" },
                { "아무개", "사과", "수박", "오렌지" },
                { "손오공", "바나나", "사과", "오렌지" }
            };

            // 1. 2차원 배열 준비 (3명, 4개 항목: 이름 + 과일3개)
            //string[,] orders = new string[3, 4];

            //// 2. 데이터 저장
            //orders[0, 0] = "홍길동"; orders[0, 1] = "포도"; orders[0, 2] = "복숭아"; orders[0, 3] = "바나나";
            //orders[1, 0] = "아무개"; orders[1, 1] = "사과"; orders[1, 2] = "수박"; orders[1, 3] = "오렌지";
            //orders[2, 0] = "손오공"; orders[2, 1] = "바나나"; orders[2, 2] = "사과"; orders[2, 3] = "오렌지";

            // 3. 문자열 내장 메서드 적용
            orders[0, 1] = (orders[0, 1].Length > 2) ? orders[0, 1] + " (인기)" : orders[0, 1];
            orders[0, 2] = (orders[0, 2].Length > 2) ? orders[0, 2] + " (인기)" : orders[0, 2];
            orders[0, 3] = orders[0, 3].Replace("바나나", "바나나 (유기농)");

            orders[1, 1] = orders[1, 1];
            orders[1, 2] = orders[1, 2].Contains("수박") ? "씨없는 수박" : orders[1, 2];
            orders[1, 3] = (orders[1, 3].Length > 2) ? orders[1, 3] + " (인기)" : orders[1, 3];

            orders[2, 1] = orders[2, 1].Replace("바나나", "바나나 (유기농)");
            orders[2, 2] = orders[2, 2];
            orders[2, 3] = (orders[2, 3].Length > 2) ? orders[2, 3] + " (인기)" : orders[2, 3];

            // 4. TextBox에 출력
            textBox_print.Text = "";

            textBox_print.Text += orders[0, 0] + ": " + orders[0, 1] + " / " + orders[0, 2] + " / " + orders[0, 3] + "\r\n";
            textBox_print.Text += "상품 첫 글자 요약: " +
                orders[0, 1].Substring(0, 1) + " / " +
                orders[0, 2].Substring(0, 1) + " / " +
                orders[0, 3].Substring(0, 1) + "\r\n\r\n";

            textBox_print.Text += orders[1, 0] + ": " + orders[1, 1] + " / " + orders[1, 2] + " / " + orders[1, 3] + "\r\n";
            textBox_print.Text += "상품 첫 글자 요약: " +
                orders[1, 1].Substring(0, 1) + " / " +
                orders[1, 2].Substring(0, 1) + " / " +
                orders[1, 3].Substring(0, 1) + "\r\n\r\n";

            textBox_print.Text += orders[2, 0] + ": " + orders[2, 1] + " / " + orders[2, 2] + " / " + orders[2, 3] + "\r\n";
            textBox_print.Text += "상품 첫 글자 요약: " +
                orders[2, 1].Substring(0, 1) + " / " +
                orders[2, 2].Substring(0, 1) + " / " +
                orders[2, 3].Substring(0, 1) + "\r\n";

        }
    }
}
