using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_04_Condition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            #region #1 if문 강의
            int inputNum = 10;

            if (inputNum > 20)
            {
                // inputNum은 20보다 크지 않음: false
            }
            else if (inputNum < 5)
            {
                // inputNum 20보다 크지 않고, 5보다 작지 않음 : false
            }
            else if (inputNum == 8)
            {
                // inputNum은 20보다 크지 않고, 5보다 작지 않고, 8도 아님 : false
            }
            else
            {
                // 위 조건이 모두 false 일 경우 실행
            }

            // 조건과 조건을 비교하는 연산을 수행
            bool is_true = inputNum == 10; // == 의 연산결과 : true

            // (조건1) OR (조건2)
            bool compared = (inputNum > 10 || inputNum < 5);

            #endregion

            #region #1-2 실습. if 문
            if (CoinMatch(true))
            {
                textBox_result.Text = "승리 ~!"; // 일치하면 => 이김 => 이겼기에 승리!
            }
            else
            {
                textBox_result.Text = "패배 ..ㅠ ";
            }
            #endregion



            #region #2 switch문 강의

            string animal = "Cat";

            switch (animal)
            {
                case "Dog":
                    // animal == "Dog" 일 때 실행되는 코드
                    break;
                case "Cat":
                    // animal == "Cat" 일 때 실행되는 코드
                default:
                    // 위 case들에 모두 해당되지 않는다면 실행
                    break;
            }

            #endregion

            #region #3-2 Enum Ex

            // 같은 enum 타입끼리는 비교 연산이 가능하다.
            // but, 서로 다른 enum 타입끼리는 비교할 수 없다.


            Food food = Food.Kimchi;

            //if (food > Food.Pizza)
            //{
            //    // Pizza = 0, Kimchi = 100 이므로 true
            //}
            // 이 예제는 아래와 같다.

            Food Menu_A = Food.Kimchi;
            Food Menu_B = Food.Pizza;
            if (Menu_A > Menu_B)
            {
                // Pizza = 0, Kimchi = 100 이므로 true
            }

            switch (food)
            {
                case Food.Pizza:
                    break;
                case Food.Burger:
                    break;
                case Food.Pasta:
                    break;
                case Food.Kimchi:
                    // 간단하게 정수로 캐스팅해서 사용 가능.
                    int price = (int)Food.Kimchi;
                    break;
            }

            #endregion

            #region #3-3 goto 점프문

            int selection = 0;
            textBox_print.Text += "Start \r\n";

        // #2 (이동할 어딘가에 라벨 생성)
        Location1:
            // 여기에 도착!
            textBox_print.Text += "Location1 \r\n";

            if (selection == 0)
            {
                textBox_print.Text += "if 안 \r\n";

                selection = 1;
                goto Location1; // #1 goto 라벨이름;
            }

            // goto & switch

            CoffeeMenu choice = CoffeeMenu.WithIceCream; // 3

            switch (choice)
            {
                case CoffeeMenu.Plain:
                    textBox_print.Text += "Coffee";
                    break;
                case CoffeeMenu.WithMilk:
                    textBox_print.Text += "Milk-";
                    break;
                    goto case CoffeeMenu.Plain;
                case CoffeeMenu.WithIceCream:
                    textBox_print.Text += "IceCream-";
                    goto case CoffeeMenu.Plain;
            }

            #endregion
        }


        #region #1-2 실습. if문에 사용되는 Coin 함수
        // 실습 if문 함수
        bool CoinMatch(bool type)
        {
            // 난수를 생성하기 위한 클래스 (기본적으로 현재시간을 기준으로 시드 자동 생성)
            Random randomObj = new Random();



            //    // 짝수/홀수로 나눠서 0 or 1 결정하게 하기.
            int coin = randomObj.Next() % 2; // rnd.Next() : 0보다 크고 매우 큰 int 값을 반환

                if ((coin == 1 && type == true) || (coin == 0 && type == false))
            {
                return true; // true 반환? : 이 함수의 결과가 성공, 일치 맞았다는 의미.
            }
            //    // 1이면 true(앞면), 0이면 false(뒷면)'
            //    // 동전 결과와 사용자의 선택이 일치할 경우에만 true 반환.

            return false;
            //}

            //    bool CoinMatch(bool type)
            //{
            //    Random randomObj = new Random();
            //    int coin = randomObj.Next() % 2;

            //    if ((coin == 1 && type == true) || (coin == 0 && type == false))
            //    {
            //        return true; // true 반환? : 이 함수의 결과가 성공, 일치 맞았다는 의미.
            //    }

            //    return false;
        }
        #endregion

            #region #1-3 실습. 사용자 입력 받기 - 이벤트 연습
            // 사용자 입력 받기 - 이벤트 연습.

        private void button_input_Click(object sender, EventArgs e)
        {
            // Ex1) 사용자 입력 연습
            // textBox_input.Text의 문자열을
            // textBox_result.Text로 복사
            textBox_result.Text = textBox_input.Text;


            bool input = false; // 기본값 설정

            // 문자열의 길이가 0보다 클 경우 == 뭐라도 적혀 있는 경우
            if (textBox_input.Text.Length > 0)
            {
                string inputText = textBox_input.Text;

                if (!(inputText == "true" || inputText == "false"))
                {
                    textBox_result.Text = "Error: true 또는 false 만 입력해주세요.";
                    // void 타입 함수에서 return을 사용하면 아무것도 반환하지 않고 함수 종료.
                    // "함수 실행을 멈추고 빠져나온다"는 의미
                    return;
                }
                else
                {
                    input = bool.Parse(inputText); // 불리언으로 형변환.
                }
            }
            else if (radioButton_true.Checked)
            {
                input = true;
            }
            else if (radioButton_false.Checked)
            {
                input = false;
            }

            textBox_result.Text = "입력하신 값은" + input.ToString() + "입니다! \r\n";
            textBox_result.Text += "동전 던지기 결과... \r\n";

            string gameResultMessage;
            if (CoinMatch(input) == true)
            {
                gameResultMessage = "승리!!";
            }
            else
            {
                gameResultMessage = "패배 ㅠㅠ";
            }
            textBox_result.Text += gameResultMessage + "\r\n";
        }
        #endregion

        #region #3 Enum 열거형


        enum Food
        {
            Pizza,  // 0
            Burger, // 1
            Pasta,  // 2
            Kimchi = 100    // 값 지정 가능 
        }

        enum Week
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
            Error = 999
        }
        // 다른 enum 타입 간 비교 불가능(x)

        // goto & switch 예제
        enum CoffeeMenu
        {
            Plain,
            WithMilk,
            WithIceCream
        }
        #endregion

        #region #3-2 실습 switch & enum 문
        
        private void button_input2_Click2(object sender, EventArgs e)
        {
            Week week = InputCheck(textBox_input.Text);

            switch (week)
            {
                case Week.Monday:
                    textBox_result.Text = "심근경색, 월요일이 가장 위험, 출근은 안 해야..";
                    break;
                case Week.Tuesday:
                    textBox_result.Text = "뭔가 모를 힘듦.";
                    break;
                case Week.Wednesday:
                    textBox_result.Text = "시작이 반이다.. 반왔다.";
                    break;
                case Week.Thursday:
                    textBox_result.Text = "금요일인 줄 착각했다가 억장 무너지는 날";
                    break;
                case Week.Friday:
                    textBox_result.Text = "오늘은 신나는 기분이야 ╰(*°▽°*)╯";
                    break;
                case Week.Saturday:
                    textBox_result.Text = "기분 최고조";
                    break;
                case Week.Sunday:
                    textBox_result.Text = "현실 부정";
                    break;
                case Week.Error:
                    textBox_result.Text = "요일이 뭔지 모르시나보군요?";
                    break;
            }
        }

        Week InputCheck(string message)
        {
            switch (message)
            {
                case "월요일":
                    return Week.Monday;
                case "화요일":
                    return Week.Tuesday;
                case "수요일":
                    return Week.Wednesday;
                case "목요일":
                    return Week.Thursday;
                case "금요일":
                    return Week.Friday;
                case "토요일":
                    return Week.Saturday;
                case "일요일":
                    return Week.Sunday;
                default:
                    return Week.Error;
            }
        } 
        
        #endregion


    }
}
