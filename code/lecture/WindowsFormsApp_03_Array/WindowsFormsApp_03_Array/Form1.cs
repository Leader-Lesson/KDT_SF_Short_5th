using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_03_Array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // #1. 배열 (Array)
            int num1, num2, num3, num4, num5, num6, num7, num8; // 힘듦.
            int[] nums = new int[8];    // 정수형 8개 저장할 수 있는 배열


            int inputCount = 10;
            int[] inputData = new int[inputCount];

            // 배열의 각 요소에 접근, Index는 0부터 시작.
            inputData[0] = 20;
            int oneOfData = inputData[0];

            //textBox1.Text = oneOfData.ToString();

            // 배열 할당. 및 초기화
            int[] array1 = new int[5];
            int[] array2 = { 1, 2, 3, 4, 5, 6 }; // new int[6]; 와 유사
           
            
            // 2차원 배열 (행과 열로 구성)
            int[,] multiArray1 = new int[2, 3];
            int[,] multiArray2 = { { 1, 2, 3 }, { 4, 5, 6 } }; // new int[2, 3]; 와 유사.


            string[,] korean = new string[,] 
            { 
                { "가", "나", "다" }, 
                { "라", "마", "바" }, 
                { "사", "아", "자" } 
            };
            textBox1.Text = korean[0,0]; // 가
            textBox1.Text = korean[0,1]; // 나
            textBox1.Text = korean[1,0]; // 라

            // *반짝 실습
            // Quiz 1) '가자' 글씨 출력하기
            textBox1.Text = korean[0,0] + korean[2,2]; // 가자

            // Quiz 2) 3차원 배열에서 숫자 8 출력
            int[,,] nums2 = new int[,,]
            {
                {
                    { 1, 2, 3},
                    { 4, 5, 6 }
                },
                {
                    { 7, 8, 9 },
                    { 10, 11, 12 },
                }
            };
            textBox1.Text = nums2[1, 0, 1].ToString();

            textBox1.Text = "-------------- \r\n";

            // 재그드 배열 (배열의 배열)

            int[][] jaggedArray = new int[6][]; // 행은 6으로 고정, 열의 길이는 자유 (바깥쪽 배열 : 줄 6개 만듬)

            // # 각 줄에 다른 길이의 배열 넣기
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 }; // 첫 번째 줄 : 4개
            jaggedArray[1] = new int[3] { 1, 2, 3 }; // 두 번째 줄 : 3개


            multiArray2.GetLength(0);
            textBox1.Text += multiArray2.GetLength(0).ToString() + "\r\n";   // 행의 개수 물어보기.
            textBox1.Text += multiArray2.GetLength(1).ToString() + "\r\n";   // 열의 개수 물어보기.

            // #2. 문자열 내장 메서드

            // Ex1)
            string[] a = "1 2 3".Split(' ');
            //textBox1.Text = a[0] + "\r\n"; 
            //textBox1.Text += a[1] + "\r\n"; 
            //textBox1.Text += a[2] + "\r\n";

            // Ex2)
            string codingon = "codingon";
            //textBox1.Text = codingon.IndexOf('o').ToString();
            codingon.Replace("on", "ozff");

            // Ex3)
            string q = "string 5";
            string[] parsed = q.Split(' '); // [string, 5]
            int count = int.Parse(parsed[1]); //  5

            #region 문자열 실습
            // 1. 10칸짜리 문자열 배열 생성
            string[] results = new string[10];


            // 2. 각 요소에 문자열 함수 적용
            results[0] = "동해 물과 백두산이".IndexOf("백두산").ToString(); // 0번: IndexOf
            results[1] = "토요일에 먹는 토마토".LastIndexOf("토").ToString(); // 1번: LastIndexOf
            results[2] = "질서 있는 퇴장".Contains("퇴").ToString(); // 2번: Contains
            results[3] = "그 사람의 그림자는 그랬다".Replace("그", "이"); // 3번: Replace
            results[4] = "삼성 갤럭시".Insert(2, "애플"); // 4번: Insert (삼 + 성 + (3) + 애플)
            results[5] = "오늘은 왠지 더 배고프다".Remove("오늘은 왠지 더 배고프다".IndexOf("더"), 1); // 5번: Remove ("더" 삭제)

            // Split 사용
            string data = "이름, 나이, 전화번호";
            string[] splitData = data.Split(',');

            // 배열 3칸에 각각 저장
            results[6] = splitData[0].Trim(); // "이름"
            results[7] = splitData[1]; // " 나이"
            results[8] = splitData[2]; // " 전화번호"
            // Trim : 문자열의 양쪽 끝에 있는 공백을 없애주는 함수.

            // 문자열.Substring(시작위치, 가져올개수);
            // 시작위치 : 어디서부터 자를지, 인덱스 지정 (0부터)
            // 가져올 개수 : 몇 글자를 가져올지 숫자로 지정
            string message = "우리 나라 만세";

            // "나라" 꺼내기
            string sub = message.Substring(3, 2);
            results[9] = sub;
            #endregion

            // #3-1. 함수
            int num = 200;
            int result = Add(100, num);

            //textBox1.Text = result.ToString();
            // 함수 사용
            Nothing();

            // ---------------
            // 함수 실습1)
            int[] result2 = DivideNumbers(20, 10); // [ x, y ]
            //textBox1.Text = $"몫: {result2[0]}, 나머지: {result2[1]}";


        }
        // #3. 함수

        // 함수 선언
        // #1. return 값이 있는 함수.
        int Add(int x, int y)
        {
             return x + y;
        }

        // #2. return 값이 없는 함수.
        
        void Nothing()
        {
            textBox1.Text += "Nothing이 나옴!";
        }

        // 함수 실습1)
        int[] DivideNumbers(int num, int num2)
        {
            int[] result = new int[2];
            result[0] = num / num2;
            result[1] = num % num2;
            return result;
        }


    }
}
