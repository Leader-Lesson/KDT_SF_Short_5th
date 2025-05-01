using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_04_Condition_Enum_If_prac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.KeyPreview = true; // 키보드 입력을 감지하기 위해 필요한 옵션
            FileName myfunc = new FileName();
            int result = myfunc.Sum(100, 300);

            double value = myfunc.d_value;

            // #1. 폼 기본 세팅.
            ResetGame();
            textBox_result2.Text = "게임을 시작해보세요!";
        }

        // #2. 전역 변수 선언.
        Random rand = new Random();

        // 유저 점수
        int user_score = 0;
        // 컴퓨터 점수
        int com_score = 0;

        // #7. 버튼 클릭 이벤트 연결.
        private void button_scissors_Click(object sender, EventArgs e)
        {
            PlayRSPGame(RSP.scissors);
        }

        private void button_rock_Click(object sender, EventArgs e)
        {
            PlayRSPGame(RSP.rock);
        }

        private void button_paper_Click(object sender, EventArgs e)
        {
            PlayRSPGame(RSP.paper);
        }

        // #3. 초기화 함수 작성.
        void ResetGame()
        {
            user_score = 0;
            com_score = 0;
            textBox_userScore.Text = "0";
            textBox_comScore.Text = "0";
        }

        // #4. enum 선언.
        enum RSP
        {
            rock,       // 0
            scissors,   // 1
            paper       // 2
        }

        // 추가) 무승부(3가지 확률) Enum
        // 비겼을 때를 생각해서 경우의 수 3가지 형태로 인해 Enum 추가
        // 게임 결과
        enum GameResult
        {
            Win,
            Lose,
            Draw
        }

        // +추가) 무승부를 비김 (enum 추가) 후 RSPGame 승패 판단 로직
        // #5. 승패 판단 로직 작성
        GameResult RSPGame(RSP user)
        /*
         * GameResult : 결과로 반환되는 데이터의 자료형
         * Win, Lose, Draw 셋 중 하나의 값을 결과로 내놓겠다는 뜻.
         * 
         * RSPGame : 메서드 이름
         * (RSP user) : 매개변수
         * ㄴ RSP.rock, RSP.scissors, RSP.paper 중 하나를 인자로 받는다.
         */

        {
            // 컴퓨터의 선택.
            RSP pick = (RSP)rand.Next(0, 3);
            /*
             *  rand.Next(0, 3) : 0, 1, 2 중 하나 랜덤 뽑기.
             *  (RSP) : 숫자 (0, 1, 2)를 RSP 타입으로 변환.
             *  0 = RSP.rock
             *  1 = RSP.cissors
             *  2 = RSP.paper
             *  
             *  pick은 RSP(가위/바위/보) 값만 저장할 수 있다
             */


            textBox_result2.Text = $"마왕의 선택: {pick}\r\n";

            // 무승부일 경우,
            if (user == pick)
            {
                return GameResult.Draw; // 무승부
            }
            // 사용자 승리 조건 (명확하게)
            if (
                (user == RSP.scissors && pick == RSP.paper) ||
                (user == RSP.rock && pick == RSP.scissors) ||
                (user == RSP.paper && pick == RSP.rock)
                )
            {
                return GameResult.Win;
            }
            // 나머지는 패배. (= 마왕 승리)
            return GameResult.Lose;
        }

        // +추가) 무승부를 비김 (enum 추가) 후 PlayRSPGame 전체 게임 로직 
        // #6. 게임 전체 로직 작성

        void PlayRSPGame(RSP user)
        {
            GameResult result = RSPGame(user);
            /*
             * GameResult : Win/Lose/Draw 중 하나만 가능
             * RSPGame() 호출 : 승패 판단 결과 가져오기.
             */

            if (result == GameResult.Draw)
            {
                textBox_result2.Text += "비겼습니다!\r\n";
                return;
            }

            /*
             * else if 안 쓴 이유?
             * 첫 번째 if가 참이면(return) 아예 아래 코드를 실행 안하기 때문!
             * Draw일 때는 밑에 if문까지 갈 일이 없음.
             */

            if (result == GameResult.Win)
            {
                textBox_result2.Text += "용사의 승리!\r\n";
                user_score++;
                textBox_userScore.Text = user_score.ToString();

                if (user_score >= 3)
                {
                    textBox_result2.Text += "용사가 마왕을 무찔렀다~!\r\n(∩^o^)⊃━☆\r\n";
                    ResetGame();
                }
            }
            else // 마왕 승리
            {
                textBox_result2.Text += "마왕의 승리..! 으아아 분하다!!\r\n";
                com_score++;
                textBox_comScore.Text = com_score.ToString();

                if (com_score >= 3)
                {
                    textBox_result2.Text += "마왕이 우주를 정복했다...!\r\n(;´༎ຶД༎ຶ`)\r\n";
                    ResetGame();
                }
            }

            // # 키다운 이벤트!
            //private void Form1_KeyDown(object sender, KeyEventArgs e)
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        button_input.PerformClick();
            //    }
            //}
        }
    }

}
