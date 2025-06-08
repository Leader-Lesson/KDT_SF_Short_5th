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
            #region 반복문 강의 

            #region #1. 일반 반복문 강의 & 예제

            // Ex1) 0 ~ 5 출력.
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                // (참고) 윈폼에서 콘솔 보기
                // 프로젝트 - 우클릭 - output type 변경
            }

            Console.WriteLine("----------------");

            // Ex2) 5 ~ 1 출력
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
            
            Console.WriteLine("----------------");

            // Ex3) 1부터 n까지의 합 구하기.
            int n = 10;
            int sum = 0;

            for (int i = 1; i <=n; i++)
            {
                sum += i;
                Console.WriteLine("현재 i의 값: " + i + "\r\n" + "현재 합계 : " + sum + "\r\n");
            }

            Console.WriteLine("----------------");

            // Q) 1 ~ 20 중 짝수 일 때의 합 구하기.
            // Hint 1) 1 ~ 20 까지 숫자를 반복
            // Hint 2) 현재 반복 숫자가 짝수라면 (변수)에 더하기.
            // Hint 3) for문 안에 if문 조합 해보세요.

            int sum2 = 0;

            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)  // 짝수일 때만
                {
                    sum += i;
                }
            }

            Console.WriteLine("1~20 중 짝수의 합: " + sum);
            Console.WriteLine("----------------");

            // Q2) 
            /*
             * 1 부터 100까지의 수 중
             * "3의 배수이지만 5의 배수는 아닌 수"만 모두 출력,
             * 마지막에 그 개수와 총합 출력하기.
             */

            int count = 0;
            int sum3 = 0;
            string result = "";

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 != 0)
                {
                    result += i + " ";
                    count++;
                    sum3 += i;
                }
            }

            Console.WriteLine("3의 배수이지만 5의 배수가 아닌 수들:");
            Console.WriteLine(result);
            Console.WriteLine("개수: " + count);
            Console.WriteLine("총합: " + sum3);




            // Ex4) 중첩 for문.
            for (int i = 1; i <= 3; i++)
            {
                for (int j= 1; j <= 2; j++)
                {
                    Console.WriteLine($"i = {i}, j = {j}");
                }
            }

            // Q3) 구구단 2 ~ 9단 출력
            for (int gugu = 2; gugu <= 9; gugu++)
            {
                for (int i = 1; i <= 9; i++)
                {
                    Console.WriteLine($"{gugu} × {i} = {gugu * i}");
                }
                Console.WriteLine(); // 줄바꿈
            }

            Console.WriteLine("----------------");
            // Q4) 별 찍기
            /*
             *  |   *
             *  |  **
             *  | ***
             *  |****
             *  
             *  Console.Write 와 WriteLine 차이 설명
             */

            int s = 4;

            for (int i = 1; i <= s; i++) // 줄 수
            {
                // 공백 출력
                for (int j = 1; j <= s - i; j++)
                {
                    Console.Write(" ");
                }

                // 별 출력
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine(); // 줄바꿈
            }

            Console.WriteLine("----------------");

            #endregion

            #region #2. 배열 반복문 강의 & 예제
            // [Before]
            string[] fruits = { "사과", "바나나", "포도", "딸기" };
            Console.WriteLine(fruits[0]); 
            Console.WriteLine(fruits[1]); 
            Console.WriteLine(fruits[2]); 
            Console.WriteLine(fruits[3]);

            Console.WriteLine(fruits.Length); // 4 
            Console.WriteLine("----------------");

            // [After]
            string[] fruits2 = { "사과", "바나나", "포도", "딸기" };

            for (int i = 0; i < fruits2.Length; i++)
            {
                Console.WriteLine(fruits2[i]);
            }

            Console.WriteLine("----------------");

            // # foreach문 사용

            // Ex1) 위 예제 foreach 버전.
            string[] fruits3 = { "사과", "바나나", "포도", "딸기" };

            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            Console.WriteLine("----------------");

            // Ex2) for문 버전.
            int[] scores = { 85, 90, 78, 92, 88 };

            int sum4 = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                sum4 += scores[i];
            }

            double average = (double)sum4 / scores.Length;

            Console.WriteLine("총합: " + sum4);
            Console.WriteLine("평균: " + average);

            Console.WriteLine("----------------");

            // Q) Ex2) foreach문 버전.
            int[] scores2 = { 85, 90, 78, 92, 88 };

            int sum5 = 0;

            foreach (int score in scores2)
            {
                sum5 += score;
            }

            double average2 = (double)sum5 / scores2.Length;

            Console.WriteLine("총합: " + sum5);
            Console.WriteLine("평균: " + average2);

            #endregion

            #endregion

            #region 반복문 textBox 입력 버전.
            // Ex1)
            //string message = "";
            //for (int i = 0; i < 10; i++)
            //{
            //    message += "반복 횟수: " + i.ToString() + "\r\n";
            //}
            //textBox_result.Text = message;

            //// Ex2)
            //int array_size = 10;
            //int[] loopCount = new int[array_size];
            //for (int i = 0; i < array_size; i++)
            //{
            //    loopCount[i] = i; // index로 i를 사용
            //}
            //textBox_result.Text = loopCount[loopCount.Length - 1].ToString();
            #endregion

            #region #3. while문 강의

            Console.Clear();

            // Ex1) 0 ~ 99 출력
            int count2 = 0;
            while (count2 < 100)
            {
                // 반복할 소스코드
                Console.WriteLine(count2);
                count2++;
            }

            Console.WriteLine("----------------");

            // Ex2) 1 ~ 5 출력
            int a = 1;

            while (a <= 5)
            {
                Console.WriteLine(a);
                a++;  // 증감 안 하면 무한 루프 발생!
            }

            Console.WriteLine("----------------");
            // Ex3) 무한 루프
            //bool run = true;
            //while (run)
            //{
            //    // 반복할 소스코드

            //    if ("반복을 종료하고 싶다면" == "") // 항상 고정된 문자열
            //    {
            //        run = false;
            //    }
            //}

            Console.WriteLine("----------------");
            // Ex4) 무한 루프2 (벗어나기)
            int idx = 0;
            while (true) // 의도적으로 무한루프
            {
                idx += 2;
                if (idx == 10)
                {
                    break; // 반복문 제어.
                }
            }
            Console.WriteLine($"{idx}");

            // Ex5) do-while을 넣을까 말까...
            #endregion

            #region #4. break & continue
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

          
        }
        #region #1-2. 실습) For문

        // 1. 학생 수 입력 (클릭)
        private void button1_Click(object sender, EventArgs e)
        {
            textBox_result.Text = ""; // 결과창 비우고 시작.


            // 2. 숫자를 입력했을 때만 실행.
            Random rand = new Random();
            int studentCount = 0;

            if (int.TryParse(textBox_input.Text, out studentCount))
            {
                // 학생명 담을 그릇 (입력된 학생 크기만큼! 배열 공간 확보!)
                string[] studentNames = new string[studentCount];

                // 학생점수 담을 그릇 
                int[] studentScore = new int[studentCount];

                for (int i = 0; i < studentCount; i++)
                {
                    studentNames[i] = $"학생{i + 1}";
                    studentScore[i] = rand.Next(0, 101); // 0 ~ 100점

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
            return $"{name}의 점수: {score}점";
        }

        #endregion

    }
}
