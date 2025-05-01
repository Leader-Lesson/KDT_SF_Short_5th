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

            ResetGame();
            textBox_result2.Text = "게임을 시작해보세요!";
        }

        Random rand = new Random();

        int user_score = 0;
        int com_score = 0;

        // #1. 가위, 바위, 보 버튼 3개 생성
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

        void ResetGame()
        {
            user_score = 0;
            com_score = 0;
            textBox_userScore.Text = "0";
            textBox_comScore.Text = "0";
        }

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
        GameResult RSPGame(RSP user)
        {
            // 컴퓨터의 선택.
            RSP pick = (RSP)this.rand.Next(0, 3);

            textBox_result2.Text = $"마왕의 선택: {pick}\r\n";

            // 무승부일 경우,
            if (user == pick)
            {
                return GameResult.Draw; // 승리도 패배도 아님
            }
            // 사용자 승리 조건
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

        void PlayRSPGame(RSP user)
        {
            GameResult result = RSPGame(user);

            if (result == GameResult.Draw)
            {
                textBox_result2.Text += "비겼습니다!\r\n";
                return;
            }

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
