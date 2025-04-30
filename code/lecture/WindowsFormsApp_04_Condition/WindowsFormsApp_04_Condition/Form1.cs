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

            // #region 이란?
            // ㄴ VS 특정 코드 블록을 접어서 숨기게 만들어주는 기능.
            // ㄴ #endregion으로 꼭 닫아주기!

            #region #1 if문 강의
            int inputNum = 10;

            if (inputNum > 20)
            {
                // inputNum은 20 보다 크지 않음: false
            }
            else if (inputNum < 5)
            {
                // inputNum 20보다 크지 않고, 5보다 작지 않음: false
            }
            else if (inputNum == 8)
            {
                // inputNum 20보다 크지 않고, 5보다 작지 않고, 8도 아님 : false
            }
            else
            {
                // 위 조건들이 모두 false 일 경우 실행
            }

            // 조건과 조건을 비교하는 연산을 수행
            bool is_true = inputNum == 10; // true

            // (조건1) or (조건2)
            // 단축평가 통해서
            bool compared = (inputNum > 10 || inputNum < 5); // false 

            #endregion

            #region #1-2 실습) if문
            if (CoinMatch(true))
            {
                textBox_result.Text = "승리 ~!";
            }
            else
            {
                textBox_result.Text = "패배 ..ㅠ";
            }
            #endregion

            #region #2. switch문 강의

            string animal = "Cat";

            switch (animal)
            {
                case "Dog":
                    // animal == "Dog" 일 때 실행되는 코드
                    break;
                case "Cat":
                    // animal == "Cat" 일 때 실행되는 코드
                    break;
                default:
                    // 위 case들에 모두 해당되지 않는다면 실행
                    break;
            }
            
            #endregion

            #region #3 Enum Ex)
            // 같은 enum 타입끼리는 비교 연산이 가능하다.
            // but, 서로 다른 enum 타입끼리는 비교할 수 없다.

            Food food = Food.Kimchi;

            if (food > Food.Pizza)
            {
                // ~
            }

            Food Menu_A = Food.Kimchi;  // 100
            Food Menu_B = Food.Pizza; // 0
            Week Menu_C = Week.Monday; // 서로 다른 enum 타입이어서 비교 연산 (X)
            if (Menu_A > Menu_B) // 같은 enum 타입이어서 비교 연산 (O)
            {
                // ~ 
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
                    int price = (int)Food.Kimchi;
                    break;
            }
            #endregion
        }

        #region #1-2 실습) if문에 사용되는 함수
        bool CoinMatch(bool type)
        {
            // 난수를 생성하기 위한 클래스
            // ㄴ 기본적으로 현재시간을 기준으로 시드 자동 생성)
            Random randomObj = new Random();
            /*
             * Random : 클래스
             * new Random() : Random 클래스를 이용해서 'randomObj' 이라는 객체를 만든 것.
             * randomObj : 객체.
             */

            // 짝수 / 홀수로 나눠서 0 or 1 결정하게 하기.
            int coin = randomObj.Next() % 2; // rnd.Next() : 0보다 크고 매우 큰 int 값을 반환.
            /*
             * rnd.Next() - 0 이상 int.MaxValue 미만 까지 (약 ~21억)
             * rnd.Next(max) - 0 이상 max 미만
             * rnd.Next(min, max) - min 이상 max 미만
             * rnd.NextDouble() - 0.0 이상 1.0 미만 소수 랜덤 생성.
             * - Random은 재사용이 좋다.
            */

            /*
             * (참고)
             * Math (=내장 클래스)
             * Math.Round() - 반올림       ex) 2.5 -> 3  / 2.2 -> 2
             * Math.Floor() - 내림, 버림   ex) 2.7 -> 2
             * Math.Ceiling() - 올림       ex) 2.1 -> 3
             */

            if ((coin == 1 && type == true) || (coin == 0 && type == false))
            {
                return true; // true 반환? : 이 함수의 결과가 성공, 일치
            }
            // 1이면 true(앞면), 0이면 false(뒷면)
            // 동전 결과(coin)와 사용자의 선택(type)이 일치할 경우에만 true 반환.

            return false;   // false 반환? : 이 함수의 결과가 일치 하지 않는다.
                            // else에 들어가는 것도 상관없음.
            /*
                else
                {
                    return false;
                }
            */

        }
        #endregion

        #region #1-3 실습) 사용자 입력 받기 - 이벤트 처리
        private void button_input_Click(object sender, EventArgs e)
        {
            textBox_result.Text = textBox_input.Text;

            bool input = false; // 기본값 설정.

            // 1. textBox_input에 문자열의 길이가 0보다 클 경우 == 뭐라도 적혀 있는 경우
            if (textBox_input.Text.Length > 0)
            {
                string inputText = textBox_input.Text;

                if (!(inputText == "true" || inputText == "false"))
                {
                    textBox_result.Text = "Error: true 또는 false 만 입력해주세요.";
                    return;
                    // void 타입 함수에서 return을 사용하면 아무것도 반환하지 않고 함수 종료.
                    // ㄴ "함수 실행을 멈추고 빠져나온다" 라는 의미.
                }
                else
                {
                    input = bool.Parse(inputText); // inputText = "true" or "false"
                }
            }
            else if (radioButton_true.Checked) // radio버튼 true의 Checked 속성 값이 true 라면~ {} 실행
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
                gameResultMessage = "승리 ~!";
            }
            else
            {
                gameResultMessage = "패배 ..ㅠ";
            }
            textBox_result.Text += gameResultMessage + "\r\n";
        }

        #endregion

        #region #3 Enum 열거형
        // ㄴ 관련된 값들을 정수 기반 상수 목록으로 이름 붙여서 그룹화한 "사용자 정의 자료형".
        // ㄴ (= 서로 관련 있는 값들을 묶어서 이름을 붙여주는 사용자 정의 자료형)
        // ㄴ 기본 값은 0부터 1씩 증가.
        // ㄴ 값 지정 가능.

        // Why?
        // ㄴ 코드의 의미가 명확해짐.
        // ㄴ 값이 바뀌어도 유지보수 쉬움.
        // ㄴ 가독성 증가.
        // ㄴ 사용: 점(.) 접근법

        enum Food
        {
            Pizza,  // 0
            Burger, // 1
            Pasta,  // 2
            Kimchi = 100  // 값 지정 가능 
        }

        enum Week
        {
            Monday, // 0
            Tuesday, 
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday, // 6
            Error = 999
        }

        #endregion

        #region #3-2 실습) switch & enum 문
        private void button_input2_Click(object sender, EventArgs e)
        {
            Week week = InputCheck(textBox_input.Text); // Week.Monday 반환.

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

        // 유효성 검사.
        Week InputCheck(string message) // 내가 입력 input 글자.
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