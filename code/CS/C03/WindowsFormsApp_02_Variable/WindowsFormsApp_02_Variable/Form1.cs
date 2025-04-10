using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace WindowsFormsApp_02_Variable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 변수의 선언
            int numOfCrew;

            // 변수의 사용 (값 복사)
            numOfCrew = 19;

            // 변수의 초기화
            string className = "말하기 듣기";

            // 변수의 값 덮어쓰기.
            className = "수학";

            // 선언보다 밑에 줄에서 사용가능
            // lineCount = 10;
            int lineCount;

            // 같은 이름 사용 불가
            byte buffer;
            // float buffer;

            // 데이터 타입이 완전히 다르면 복사 불가
            int number = 10;
            //string word = "안녕";
            
            // 같은 형식에서 데이터 타입의 크기 따라 복사 가능 or 불가능
            short word = 20;

            // int > short 더 큰 범위의 데이터 타입
            number = word;    // 복사 가능
                              // word = number;    // 복사 불가능

            // 변수끼리 값 복사
            int var_x = 10;
            int var_y = var_x; // x -> y로 복사

            // 사칙 연산 및 괄호 활용
            int var_z = var_x * var_y;
            int result = var_z + (var_x + 5);

            {
                int inside = 100;
            }

            // inside와 Scope가 달라서 사용 불가
            // int outside = inside + 50;

            //byte  = 20;

            textBox_print.Text += numOfCrew.GetType() +" numOfCrew : " + numOfCrew.ToString() + "\r\n";

            /*
             * #1. 실습. 변수 및 캐스팅
             * 
             */ 
        }
    }
}
