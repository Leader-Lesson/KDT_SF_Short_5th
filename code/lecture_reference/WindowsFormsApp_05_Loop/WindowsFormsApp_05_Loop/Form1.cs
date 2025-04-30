using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_05_Loop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.KeyPreview = true; // 키보드 입력을 감지하기 위해 필요한 옵션

            #region #1. 반복문 강의 
            // Ex1)
            string message = "";
            for (int i = 0; i < 10; i++)
            {
                message += "반복 횟수: " + i.ToString() + "\r\n";
            }
            textBox_result.Text = message;

            // Ex2)
            int array_size = 10;
            int[] loopCount = new int[array_size];
            for (int i = 0; i < array_size; i++)
            {
                loopCount[i] = i; // index로 i를 사용
            }
            textBox_result.Text = loopCount[loopCount.Length - 1].ToString();
            #endregion

            #region #2. while문 강의
            int count = 0;
            while (count < 100)
            {
                // 반복할 소스코드
                count++;
            }

            // # 무한 루프
            //bool run = true;
            //while (run)
            //{
            //    // 반복할 소스코드

            //    if ("반복을 종료하고 싶다면" == "")
            //    {
            //        run = false;
            //    }
            //}

            // # 무한 루프2 (벗어나기)
            int idx = 0;
            while (true) // 의도적으로 무한루프
            {
                idx += 2;
                if (idx == 10)
                {
                    break; // 반복문 제어.
                }
            }
            textBox_result.Text = idx.ToString();
            textBox_result.Clear();


            // # break & continue
            // - 반복문에서 사용되는 제어문.

            // # break
            // - 반복문을 완전히 중단하고 빠져나옴.
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    break;
                }
                textBox_result.Text += i.ToString() + "\r\n";
            }
            // 출력 결과 : 1, 2, 3, 4

            textBox_result.Clear();
            // # continue
            // - 현재 반복을 중지하고 다음 반복으로 넘어감. (이번 회차 건너뛰기)
            for (int i = 1; i <= 5; i++)
            {
                if (i == 3)
                {
                    continue;
                }
                textBox_result.Text += i.ToString() + "\r\n";
            }
            // 출력 결과 : 1, 2, 4, 5

            #endregion

            // #2-2 while문 실습
            //textBox_userScore.Text = "0";
            //textBox_comScore.Text = "0";
            ResetGame();
            textBox_result2.Text = "게임을 시작해보세요!";
        }
        #region #1-2. 실습) For문

        // 학생 수 입력 (클릭)
        private void button1_Click(object sender, EventArgs e)
        {
            textBox_result.Text = ""; // 결과창 비우고 시작.

            /**
             * (참고)
             * int.TryParse(string 입력 값, out number)
             * - 문자열을 숫자로 변환할 때, 변환이 가능한 경우에만 값을 저장하고 true를 반환.
             * 변환에 실패하더라도 오류를 발생시키지 않고 false를 반환함.
             */
            // 숫자를 입력했을 때만 실행.
            Random rand = new Random();
            int studentCount = 0;

            if (int.TryParse(textBox_input.Text, out studentCount))
            {
                // 학생명 담을 그릇
                string[] studentNames = new string[studentCount];
                // 학생점수 담을 그릇 
                int[] studentScore = new int[studentCount];

                for (int i = 0; i < studentCount; i++)
                {
                    studentNames[i] = "학생 " + (i + 1).ToString();
                    studentScore[i] = rand.Next(0, 101);

                    textBox_result.Text += CombineNameAndScore(studentNames[i], studentScore[i]) + "\r\n";
                }
            }
            else
            {
                textBox_result.Text = "숫자를 입력하라고 했을텐데..?";
            }


        }
        // 결과 출력문 함수
        string CombineNameAndScore(string name, int score)
        {
            return name + "의 점수: " + score.ToString() + "점";
        }


        #endregion

        #region #2-2. 실습) While문

        Random rand = new Random();
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

        enum RSP
        { 
            rock,       // 0
            scissors,   // 1
            paper       // 2
        }
        RSP userRSP;
        RSP comRSP;
        //

        #region +추가) 무승부 (3가지 확률) Enum
        // 비겼을 때를 생각해서 경우의 수 3가지 형태로 인해 Enum 추가
        // 게임 결과
        enum GameResult
        {
            Win,
            Lose,
            Draw
        }
        #endregion

        int user_score = 0;
        int com_score = 0;

        // 모든 게임 로직을 관리하는 함수
        //void PlayRSPGame(RSP user)
        //{
        //    if (RSPGame(user))
        //    {
        //        textBox_result2.Text += "용사의 승리!\r\n";
        //        user_score++;
        //        textBox_userScore.Text = user_score.ToString();

        //        if (user_score >= 3)
        //        {
        //            textBox_result2.Text += "용사가 마왕을 무찔렀다~!\r\n(∩^o^)⊃━☆";
        //            //this.user_score = this.com_score = 0; // 0으로 바꿈.

        //             ResetGame(); // 초기화 함수 호출
        //        }
        //    }
        //    else
        //    {
        //        textBox_result2.Text += "마왕의 승리..! 으아아 분하다!!\r\n";
        //        com_score++;
        //        textBox_comScore.Text = com_score.ToString();

        //        if (com_score >= 3)
        //        {
        //            textBox_result2.Text += "마왕이 우주를 정복했다...!\r\n(;´༎ຶД༎ຶ`)";
        //            //this.user_score = this.com_score = 0;
        //             ResetGame(); // 초기화 함수 호출
        //        }
        //    }
           
        //}
        // 가위바위보 승패 판단 로직.
        //bool RSPGame(RSP user)
        //{
        //    // 컴퓨터의 선택.
        //    RSP pick = (RSP)rand.Next(0, 3);

        //    textBox_result2.Text = $"마왕의 선택: {pick}\r\n";

        //    // 무승부일 경우,
        //    if (user == pick)
        //    {
        //        textBox_result2.Text += "비겼습니다!\r\n";
        //        return false; // 승리도 패배도 아님
        //    }
        //    // 사용자 승리 조건
        //    if (
        //        (user == RSP.scissors && pick == RSP.paper) ||
        //        (user == RSP.rock && pick == RSP.scissors) ||
        //        (user == RSP.paper && pick == RSP.rock)
        //        )
        //    {
        //        return true;
        //    }
        //    // 나머지는 패배. (= 마왕 승리)
        //    return false;
        //}
        // 초기화 함수
        void ResetGame()
        {
            user_score = 0;
            com_score = 0;
            textBox_userScore.Text = "0";
            textBox_comScore.Text = "0";
        }

        #region +추가) 무승부를 비김 (enum 추가) 후 RSPGame 승패 판단 로직
        // 가위바위보 승패 판단 로직.
        
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
        #endregion

        #region +추가) 무승부를 비김 (enum 추가) 후 PlayRSPGame 전체 게임 로직 
        
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
        }
        #endregion

        // # 키다운 이벤트!
        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        button_input.PerformClick();
        //    }
        //}
        #endregion

    }
}
