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

            // byte  = 20;

            textBox_print.Text += numOfCrew.GetType() +" numOfCrew : " + numOfCrew.ToString() + "\r\n";

            /*
             * #1. 실습. 변수 및 캐스팅
             * 
             */


            // # 연산자.
            /*
             * 대입 연산자 (=)
             * : 변수에 값을 "할당" 할 때 사용하는 연산자
             * 
             * 산술 연산자
             * 사칙연산: +, -, /, *
             * 나머지 연산: %
             * 거듭제곱 연산: **
             */

            int a = 5;
            int b = 2;
            // (참고)
            // TextBox 컨트롤은 "사용자에게 텍스트(문자열)"을 보여주기 위한 도구.
            // textBox_print.Text 는 자료형이 string(문자열)임.
            // ㄴ 숫자를 바로 넣을 수 없음.

            // #1. 형변환 방법
            // textBox_print.Text = (a + b).ToString(); 

            // #2. 문자열 보간 방법
            // $"{표현식}" 형태,
            // ㄴ 안에 있는 코드를 계산하고 자동으로 문자열로 만들어줌.
            // ㄴ 깔끔하고, 가독성이 좋아서 요즘 자주 사용됨.
            // textBox_print.Text = $"{a + b}";

            textBox_print.Text = $"{a - b} \r\n";
            textBox_print.Text += $"{a / b} \r\n";
            textBox_print.Text += $"{a * b} \r\n";
            textBox_print.Text += $"{a % b} \r\n";
            //textBox_print.Text += $"{a ** b} \r\n"; // Error!

            // (참고) C#에서의 거듭제곱!
            // ㄴ 문법적으로 **연산자가 존재하지 않음.
            // ㄴ Math.Pow() 라는 메서드를 사용해야함. -- 아직 메서드를 안배움.
            // ㄴ Math.Pow(밑, 지수);
            // ㄴ 결과는 항상 double로 반환됨.
            // ㄴ C, C++ pow() 메서드 사용. 파이선 ** 사용.
            textBox_print.Text += $"{Math.Pow(a,b)} \r\n";
            // Math.Sqrt() -> 제곱근!
            textBox_print.Text += $"{Math.Sqrt(9)} \r\n";

            // 비교 연산자
            // #1. 동등 비교 : 같다 / 같지 않다.
            textBox_print.Text += $"{1 == 1} \r\n"; // True
            textBox_print.Text += $"{1 == 2} \r\n"; // False
            textBox_print.Text += $"{1 != 1} \r\n"; // False
            textBox_print.Text += $"{1 != 2} \r\n"; // True
            textBox_print.Text += "--------------- \r\n";

            // #2. 크기 비교
            textBox_print.Text += $"{2 > 1} \r\n"; // True
            textBox_print.Text += $"{2 >= 2} \r\n"; // True
            textBox_print.Text += $"{2 < 1} \r\n"; // False
            textBox_print.Text += $"{2 <= 2} \r\n"; // True
            textBox_print.Text += "--------------- \r\n";

            // 논리 연산자
            // !: not (참 -> 거짓, 거짓 -> 참)
            // &&: and (여러 값 중 모두가 참 -> 참)
            // ||: or (여러 값 중 하나라도 참 -> 참)
            textBox_print.Text += $"{!true} \r\n"; // False
            textBox_print.Text += $"{!false} \r\n"; // True
            textBox_print.Text += $"{!!true} \r\n"; // True
            textBox_print.Text += $"{!!false} \r\n"; // False

            textBox_print.Text += $"{true && true} \r\n"; // True
            textBox_print.Text += $"{true && false} \r\n"; // False
            textBox_print.Text += $"{false && false} \r\n"; // False

            textBox_print.Text += $"{true || true} \r\n"; // True
            textBox_print.Text += $"{true || false} \r\n"; // True
            textBox_print.Text += $"{false || false} \r\n"; // False

            textBox_print.Text += $"{!(2 > 1)} \r\n"; // !true -> false!
            textBox_print.Text += $"{2 > 1 && -2 < 1} \r\n"; // true && true -> true
            textBox_print.Text += $"{(2 > 1 && -2 < 1) || 5 > 2} \r\n"; // (true && true) || true -> true || true -> true
            textBox_print.Text += "--------------- \r\n";

            // 증감 연산자
            // ++ : 변수 값을 1 증가
            // -- : 변수 값을 1 감소
            // 증감 연산자를 붙이는 위치에 따라 결과가 다르다.
            int result1, result2;
            int num = 10, num2 = 10;

            // 후위 증감(Postfix)
            // - 변수를 먼저 사용하고, 이후에 1 증가/감소함.
            result1 = num++;
            textBox_print.Text = result1.ToString() + "\r\n"; // 10
            textBox_print.Text += num.ToString() + "\r\n"; // 11

            // 전위 증감(Prefix)
            // - 변수를 먼저 증가/감소 시키고, 이후에 사용.
            result2 = ++num2;
            textBox_print.Text += result2.ToString() + "\r\n"; // 11
            textBox_print.Text += num2.ToString() + "\r\n"; // 11

            // 연산자 줄여쓰기
            // +=, -= 연산자를 더 자주 씀!
            textBox_print.Text += $"{num += 1} \r\n"; // 12
            textBox_print.Text += $"{num2 -= 1} \r\n"; // 10
            textBox_print.Text += $"{num *= num2} \r\n"; // 120
            textBox_print.Text += $"{num /= num2} \r\n"; // 12

            // (실습) 노션 링크
        }
    }
}
