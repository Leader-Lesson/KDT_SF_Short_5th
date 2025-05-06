using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_04_2_EnumEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddFile addFile = new AddFile();
            int resultSum = addFile.Sum(100, 200);

            double value = addFile.d_value;

            // #1. 폼 기본 세팅.
            textBox_result.Text = "게임을 시작해보세요!";
            // #3-2. 초기화 함수 사용 (로딩시)
            ResetGame();
        }

        // #2. 전역 변수 선언.
        Random rand = new Random();

        // 유저(용사) 점수
        int user_score = 0;
        // 컴퓨터(마왕) 점수
        int com_score = 0;

        // #3. 초기화 함수 작성
        void ResetGame()
        {
            user_score = 0;
            com_score = 0;
            textBox_userScore.Text = "0";
            textBox_comScore.Text = "0";

        }

        // #4. Enum 선언.
        enum RSP    // 가위바위보 Enum
        {
            rock,   // 바위
            scissors,   // 가위
            paper   // 보
        }

        enum GameResult     // 승패 결과 Enum
        {
            Win,
            Lose,
            Draw
        }


        // #5. 승패 판단 로직 작성.
        GameResult RSPGame(RSP user)
        /*
         * GameResult : 결과로 반환되는 데이터의 자료형(열거형)
         * Win, Lose, Draw 셋 중 하나의 값을 결과로 내놓겠다는 뜻.
         * 
         * RSPGame : 함수 이름
         * (RSP user) : 매개변수
         * ㄴ RSP.rock, RSP.scissors, RSP.paper 중 하나를 인자로 받는다.
         */

        {

            // 컴퓨터의 선택
            RSP pick = (RSP)rand.Next(0, 3);
            /*
             * rand.Next(0, 3) : 0, 1, 2 중 하나 랜덤 뽑기.
             * (RSP) : 숫자 (0, 1, 2)를 RSP 타입으로 변환.
             * 0 = RSP.rock
             * 1 = RSP.cissors
             * 2 = RSP.paper
             * 
             * pick은 RSP(가위/바위/보) 값만 저장할 수 있다.
             */

            textBox_result.Text = $"마왕의 선택: {pick} \r\n";

            // 무승부일 경우,
            if (user == pick)
            {
                return GameResult.Draw; // 무승부
            }
            
            // 유저 승리 조건 (명확하게)
            if(
                (user == RSP.scissors && pick == RSP.paper) ||
                (user == RSP.rock && pick == RSP.scissors) ||
                (user == RSP.paper && pick == RSP.rock)
              )
            {
                return GameResult.Win;
            }
            // 나머지는 패배 (= 컴퓨터 승리)
            else
            {
                return GameResult.Lose;
            }
        }

        // #6. 게임 전체 로직 작성.
        void PlayRSPGame(RSP user)
        {
            GameResult result = RSPGame(user);
            /*
             * GameResult : Win/Lose/Draw 중 하나만 가능
             * RSPGame() 호출 : 승패 판단 결과 가져오기.
             */

            // 무승부
            if (result == GameResult.Draw)
            {
                textBox_result.Text += "비겼습니다! \r\n";
                return;
            }

            // 승리
            if (result == GameResult.Win)
            {
                textBox_result.Text += "용사의 승리! \r\n";
                user_score++;
                textBox_userScore.Text = user_score.ToString();
                
                if (user_score >= 3)
                {
                    textBox_result.Text += "용사가 마왕을 무찔렀다~!\r\n(∩^o^)⊃━☆\r\n";
                    // 점수 초기화!
                    ResetGame();
                }
            }
            // 패배 (= 컴퓨터 승리)
            else 
            {
                textBox_result.Text += "마왕의 승리..! 으아아 분하다!! \r\n";
                com_score++;
                textBox_comScore.Text = com_score.ToString();

                if (com_score >= 3)
                {
                    textBox_result.Text += "마왕이 우주를 정복했다...!\r\n(;´༎ຶД༎ຶ`)\r\n";
                    // 점수 초기화!
                    ResetGame();
                }
            }

        }
        // #7. 버튼 클릭 이벤트 연결.
        private void button_scissor_Click(object sender, EventArgs e)
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
    }
}
