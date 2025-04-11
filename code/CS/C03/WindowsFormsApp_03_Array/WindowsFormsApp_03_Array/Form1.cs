using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
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

            // #1. 배열
            // 변수를 여러개를 하나의 배열로 처리.
            int num1, num2, num3, num4, num5, num6, num7, num8;
            int[] nums = new int[8];    // 정수형 8개 저장할 수 있는 배열

            // 입력되는 데이터의 크기를 알 수 없을 때, 배열로 처리
            // (참고) 사용자가 몇 개를 입력할 지 정해져 있지 않은 상황에서는 프로그램이 그 숫자를 입력받은 뒤, 해당 개수만큼 배열을 만들어야 함.
            int inputCount = 10;
            int[] inputData = new int[inputCount];

            // 배열의 각 요소에 접근, Index는 0부터 시작.
            inputData[0] = 20;
            int oneOfData = inputData[0];

            //textBox1.Text = oneOfData.ToString();

            string myName = "Leader_" + "Damon" + " " + 999.ToString();

            //textBox1.Text = myName;

            int[] array1 = new int[5];
            int[] array2 = { 1, 2, 3, 4, 5, 6 }; // new int[6]; 와 유사
            
            // 2차원 배열 (행과 열로 구성)
            int[,] multiDimensionalArray1 = new int[2, 3];
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } }; // new int[2, 3]; 와 유사.

            // 재그드 배열 (배열의 배열)
            // = 들쭉날쭉한 배열 (행마다 열 길이가 다름)
        
            int[][] jaggedArray = new int[6][]; // 행은 6으로 고정, 열의 길이는 자유
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
            jaggedArray[1] = new int[3] { 1, 2, 3 };

            for (int i = 0; i < array2.Length; i++)
            {
                textBox1.Text += array2[i].ToString() + "\r\n";
            }
            textBox1.Text = array2.Length.ToString() + "\r\n";
            textBox1.Text += multiDimensionalArray2.Length.ToString();
            textBox1.Text += "\r\n";

            multiDimensionalArray2.GetLength(0); 
            textBox1.Text += multiDimensionalArray2.GetLength(0).ToString() + "\r\n";   // 행의 개수 물어보기.
            textBox1.Text += multiDimensionalArray2.GetLength(1).ToString() + "\r\n";   // 열의 개수 물어보기.

            for (int i = 0; i<multiDimensionalArray2.GetLength(0); i++)
            {
                for(int j = 0; j<multiDimensionalArray2.GetLength(1); j++)
                {
                    textBox1.Text += multiDimensionalArray2[i, j].ToString() + "\r\n";
                }
            }

            // (참고) 재그드 배열이 잘 이해안되는 분들을 위한!
            /*
            🔹 Length (속성, property) --> 속성이므로, ()와 인자를 가질 수 없음!
            배열 전체의 "길이", 즉 요소 개수 전체

            1차원 배열에서는 → 요소 개수

            2차원 배열에서는 → 행 × 열

            🔹 GetLength(int dimension) (메서드, method)
            차원(dimension)별로 크기(길이)를 구하는 함수 

            dimension = 0이면 👉 첫 번째 차원 = 행(row)

            dimension = 1이면 👉 두 번째 차원 = 열(column)
            */

            // #2. 문자열 메서드
            // (참고) 메서드란?
            // = 클래스의 기능을 수행하는 함수!
            // 문자열도 "string" 이라는 클래스이기 때문에, 다양한 기능 메서드를 보유함!
            // Ex1)
            string[] a = "1 2 3".Split(' ');
            textBox1.Text = a[0] + "\r\n"; 
            textBox1.Text += a[1] + "\r\n"; 
            textBox1.Text += a[2] + "\r\n";

            // Ex2)
            string codingon = "codingon";
            textBox1.Text = codingon.IndexOf('o').ToString();
            codingon.Replace("on", "ozff");

            // Ex3)
            string q = "string 5";
            string[] parsed = q.Split(' '); // [string, 5]
            int count = int.Parse(parsed[1]); //  5
            textBox1.Text = "";
            for (int i = 0; i < count; i++) // 0 ~ 4
            {
                textBox1.Text += parsed[0];
            }

            // #3. 함수
            int num = 200;
            int result = Add(100, num);

            textBox1.Text = result.ToString();
            Nothing();

            int[] result2 = DivideNumbers(20, 10); // [ x, y ]
            textBox1.Text = $"몫: {result2[0]}, 나머지: {result2[1]}";


        }

        int Add(int x, int y)
        {
             return x + y;
        }

        void Nothing()
        {
            textBox1.Text += "Nothing이 나옴!";
        }
        // 함수 실습!

        int[] DivideNumbers(int num, int num2)
        {
            int[] result = new int[2];
            result[0] = num / num2;
            result[1] = num % num2;
            return result;
        }

    } 
}

/**
 * VS의 자동완성!
 * = IntelliSense (인텔리센스)
 * Visual Studio의 코드 자동 완성, 추천, 힌트, 형식 검사 기능!
 * - 자동완성
 * - 자동 괄호 닫기
 * - 자동 중괄호/배열 보완
 */