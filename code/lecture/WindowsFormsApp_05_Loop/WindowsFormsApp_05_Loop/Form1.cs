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
            /*
             * - 어떤 코드를 정해진 횟수만큼 반복 실행할 때 사용.
             * 
             * 구조
             * for (초기식; 조건식; 증감식)
             * {
             *      반복할 코드
             * }
             * 
             * 초기식 : 변수 선언 or 초기화
             * 조건식 : 반복할 조건 -> true면 계속 실행
             * 증감식 : 변수 값을 변화시켜 반복 실행 제어 -> ++/--
             */

            // Ex1) 0 ~ 5 출력
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
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

            for (int i = 1; i <= n; i++)
            {
                //sum = sum + i;
                sum += i;
                Console.WriteLine("현재 i의 값: " + i + "\r\n" + "현재 합계 : " + sum + "\r\n");
            }

            Console.WriteLine("----------------");
            // Quiz) 1 ~ 20 중에 짝수 일 때의 합 구하기.
            // Hint 1) 1 ~ 20 까지 숫자를 반복.
            // Hint 2) 현재 반복 숫자가 짝수라면 (변수)에 더하기.
            // Hint 3) for문 안에 if문 조합을 해보세요.

            int sum2 = 0;

            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0) // 짝수 일 때만
                {
                    sum2 += i;
                }
            }
            Console.WriteLine("1~20 중 짝수의 합: " + sum2);
            Console.WriteLine("----------------");

            // Quiz2)
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
            Console.WriteLine("3의 배수이지만 5의 배수가 아닌 수들: ");
            Console.WriteLine(result);
            Console.WriteLine("개수: " + count);
            Console.WriteLine("총합: " + sum3);

            Console.WriteLine("----------------");

            // Ex4) 중첩 for문.
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    Console.WriteLine($"i = {i}, j = {j}");
                }
            }
            Console.WriteLine("----------------");

            // Quiz 3) 구구단 2 ~ 9단 출력
            /*
             * 출력 예시)
             * 2 x 1 = 2
             * 2 x 2 = 4
             * ..
             * ...
             * 
             * 9 x 9 = 81
             */

            for (int gugu = 2; gugu <= 9; gugu++)
            {
                for (int i = 1; i <= 9; i++)
                {
                    Console.WriteLine($"{gugu} x {i} = {gugu * i}");
                }
                Console.WriteLine(); // 줄 바꿈
            }

            Console.WriteLine("----------------");


            // Quiz 4) 별 찍기
            /*
             * |   *    // " " x 3개 + "*" x 1개 ==>
             * |  **    // " " x 2개 + "*" x 2개
             * | ***    // " " x 1개 + "*" x 3개
             * |****    // " " x 0개 + "*" x 4개
             * 
             * i = 줄 수,  ==> i
             * j = " " 수, ==> s - i;
             * k = * 수    ==> i
             *
             */

            int s = 4;

            for (int i = 1; i <= s; i++)  // 줄 수
            {
                // 공백 출력
                for (int j = 1; j <= s - i; j++) // s - i = 3
                {
                    Console.Write(" ");
                }

                // 별 출력
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            // Quiz 5) 별 찍기 lv. 2
            /*
            * |   *     // " " x 3개 + "*" x 1개 + " " x 3개
            * |  ***    // " " x 2개 + "*" x 3개 + " " x 2개    
            * | *****   // " " x 1개 + "*" x 5개 + " " x 1개
            * |*******  // " " x 0개 + "*" x 7개 + " " x 0개
            */
            int s2 = 4;

            for (int i = 1; i <= s2; i++)
            {
                // 공백 출력
                for (int j = 1; j <= s2 - i; j++)
                {
                    Console.Write(" ");
                }

                // 별 출력 (홀수 개)
                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            #endregion

            #region #2. 배열 반복문 강의 & 예제
            /*
             * Why? 배열-반복문을 사용하는 이유
             * - 하나하나 출력하기에 너무 비효율적!
             * 
             * .Length : 배열의 크기(길이)
             */

            // [Before]
            string[] fruits = { "사과", "바나나", "포도", "딸기" };
            Console.WriteLine(fruits[0]);
            Console.WriteLine(fruits[1]);
            Console.WriteLine(fruits[2]);
            Console.WriteLine(fruits[3]);
            Console.WriteLine(fruits.Length); // 4


            Console.WriteLine("--------------");

            // [After]
            string[] fruits2 = { "사과", "바나나", "포도", "딸기" };
            for (int i = 0; i < fruits2.Length; i++)
            {
                Console.WriteLine(fruits2[i]);
            }
            Console.WriteLine("--------------");
            // # foreach문 사용
            /*
             * ㄴ 배열의 모든 항목(요소)을 "처음부터 끝까지 하나씩" 꺼내며 반복 실행하는 문법
             * ㄴ 배열을 순회하면서 각 요소에 대해 "동일한 작업"을 수행할 때 사용
             * ㄴ "순서가 있는 구조 반복"에 적합!
             * 
             * 구조
             * foreach (자료형 변수명 in 배열이름)
             * {
             *      // 배열의 항목 하나씩 사용
             * }
             */

            // Ex1) 위 예제 foreach 버전.
            string[] fruits3 = { "사과", "바나나", "포도", "딸기" };
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            Console.WriteLine("--------------");

            // Ex2) for문 버전.
            int[] scores = { 85, 90, 78, 92, 88 }; // 배열의 크기 : 5

            int sum4 = 0;
            
            for (int i = 0; i < scores.Length; i++)
            {
                sum4 += scores[i];
            }

            double average = (double)sum4 / scores.Length;

            Console.WriteLine("총합: " + sum4);
            Console.WriteLine("평균: " + average);

            Console.WriteLine("--------------");

            // Quiz) Ex2) foreach문 버전으로 바꾸기.
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
        }

        #region #1-2. 실습) For문
        // 1. 학생 수 입력 받고 (클릭)
        private void button1_Click(object sender, EventArgs e)
        {
            // 7. 결과창 비우고 시작. 
            textBox_result.Text = "";

            // 2. 숫자를 입력했을 때, 실행!
            // 난수 생성기.
            Random rand = new Random();
            int studentCount = 0;
            bool success = int.TryParse(textBox_input.Text, out studentCount); // true / studentCount: 10
            /*
             * 구조
             * int.TryParse(string 입력 값, out 변수명(number))
             * ㄴ 사용자 입력이 숫자인지 안전하게 확인하게 해주는 메서드.
             * ㄴ 문자열을 숫자로 변환할 때, 변환이 가능한 경우에만 값을 저장하고, true를 반환.
             * ㄴ 변환에 실패하더라도 오류를 발생시키지 않고 false를 반환함.
             * 
             * TryParse()는 성공 여부와 변환된 값을 동시에 반환해야 하기 때문에, 두 개의 값을 반환해야함.
             * 그래서 bool은 리턴값, 정수 결과는 out 키워드를 사용해서 바깥 변수에 저장하는 구조.
             * 
             * ㄴ "문자열을 int로 바꿔보려고 시도해서, 성공하면 그 값을 number 저장하고 true를 반환한다"
             */

            if (success)
            {
                // 3. 학생명(이름)을 담는 그릇 (입력된 학생 크기만큼! 배열 공간을 확보!)
                string[] studentNames = new string[studentCount];

                // 4. 학생점수를 담는 그릇
                int[] studentScore = new int[studentCount];

                for (int i = 1; i <= studentCount; i++)
                {
                    studentNames[i - 1] = $"학생{i}";
                    studentScore[i - 1] = rand.Next(0, 101); // 0 ~ 100점

                    // 6. 함수 사용
                    textBox_result.Text += CombieNameAndScore(studentNames[i - 1], studentScore[i - 1]);
                }
            }
            else
            {
                textBox_result.Text = "숫자를 입력하라고 했잖습니까  ^ ^?";
            }
        }
        // 5. 결과 출력문 함수 선언
        string CombieNameAndScore(string name, int score)
        {
            return $"{name}의 점수: {score}점 \r\n";
        }

        #endregion
    }
}
