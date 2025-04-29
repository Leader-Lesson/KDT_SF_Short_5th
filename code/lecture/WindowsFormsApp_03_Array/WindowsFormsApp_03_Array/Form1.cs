using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            // #1. 배열 (Array)
            // 같은 자료형 변수 여러개를 하나의 배열로 처리.
            // ㄴ 한 번에 여러 값을 저장할 수 있음.
            //int num1, num2, num3, num4, num5, num6, num7, num8; // 너무 힘듦
            //num1 = 5;
            //num2 = 6;

            int[] nums = new int[8]; // 정수형 8개를 저장할 수 있는 배열.

            // 구조
            // 배열의 이름: nums
            // 배열의 자료형 : int[]  --> 정수형 배열
            // 배열 선언 및 메모리 공간 확보 : nums = new int[8]
            // ㄴ 8개 짜리 공간을 만듦.
            // 배열의 요소(아이템) : 배열 안에 있는 데이터 하나하나
            // 배열의 위치(인덱스) : 0부터 시작 - zero based numbering
            // 배열의 길이(크기) : 요소의 개수와 동일.

            // 입력되는 데이터의 크기를 알 수 없을 때, 배열로 처리
            int inputCount = 10;
            int[] inputData = new int[inputCount];
            // = [20,0,0,0,0,0,0,0,0,0]
            // 배열의 각 요소에 접근, Index는 0부터 시작.
            inputData[0] = 20;
            int oneOfData = inputData[0]; // 20

            // 배열 할당 및 초기화
            int[] array1 = new int[5]; // = [0, 0, 0, 0, 0]
            int[] array2 = { 1, 2, 3, 4, 5, 6 }; // new int[6] 유사 = [1, 2, 3, 4, 5, 6]

            // 2차원 배열 (행과 열로 구성) 
            // ㄴ 행: 가로줄 / 열: 세로줄
            // ㄴ 배열 안에 배열이 들어갈 수 있음 (n차 중첩 가능)
            // [,] -> 배열의 '모양'을 미리 정하는 표시라고 이해.
            // [] -> 하나 (1차원 배열) / [,] -> 두개 (2차원 배열)
            // {} -> 실제 값 넣기.
            int[,] multiArray1 = new int[2, 3];
            int[,] multiArray2 = { { 1, 2, 3 }, { 4, 5, 6 } }; // new int[2, 3]; 유사.

            // 요소 접근
            string[,] korean = new string[,]
            {
                {"가", "나", "다" },
                {"라", "마", "바" },
                {"사", "아", "자" }
            };
            textBox1.Text = korean[0, 0]; // 가
            textBox1.Text = korean[0, 2]; // 다
            textBox1.Text = korean[1, 1]; // 마

            // *반짝 실습
            // Quiz 1) '가자' 글씨 출력해보기.
            textBox1.Text = korean[0, 0] + korean[2, 2]; // 가자

            // Quiz 2) 3차원 배열에서 숫자 8 출력
            int[,,] nums2 = new int[,,]
            {
                {
                    {1, 2, 3 },
                    {4, 5, 6 },
                },
                {
                    {7, 8, 9 },
                    {10, 11, 12 },
                }
            };
            textBox1.Text = nums2[1, 0, 1].ToString();

            // 재그드(jagged) 배열 (배열의 배열)
            // = 들쭉날쭉한 배열 (행마다 열 길이가 다름)
            // [][] 중첩된 대괄호 사용
            // 첫 번쨰 [] : 바깥쪽 배열
            // 두 번째 [] : 안쪽 배열

            int[][] jaggedArray = new int[6][];
            // - 행은 6으로 고정, 열의 길이는 자유
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 }; // 첫 번째 줄 : 4개
            jaggedArray[1] = new int[3] { 1, 2, 3 }; // 두 번째 줄 : 3개

            // 재그드 배열 실습
            string[][] school_class = new string[3][];

            // 각각 직접 할당
            school_class[0] = new string[2] { "철희", "미애" };
            school_class[1] = new string[3] { "철수", "영미", "민수" };
            school_class[2] = new string[1] { "수빈" };

            // TextBox에 학생 출력
            textBox2.Text = "";
            textBox2.Text += "1반 학생 목록: \r\n";
            textBox2.Text += "- " + school_class[0][0] + "\r\n"; 
            textBox2.Text += "- " + school_class[0][1] + "\r\n";


            // #2. 문자열 내장 메서드
            // ㄴ string 타입 (문자열)이 기본적으로 가지고 있는 기능

            // 문자열도 "string" 타입 이라는 클래스이기 때문에,
            // 점(.)을 찍고 다양한 기능을 사용 할 수 있음.
            // Ex1)
            string[] a = "1 2 3".Split(' ');
            textBox2.Text = a[0] + "\r\n";
            textBox2.Text += a[1] + "\r\n";
            textBox2.Text += a[2] + "\r\n";

            // Ex2)
            string codingon = "codingon";
            codingon.Replace("on", "off");
            textBox2.Text = codingon;

            // Ex3)
            string q = "string 5";
            string[] parsed = q.Split(' '); // [string, 5]
            int count = int.Parse(parsed[1]);

            // 실습 문제)
            // 1. 10칸 짜리 문자열 배열 생성
            string[] results = new string[10]; // [0,0,0,0,0,0,0,0,0,0]

            // 2. 문자열 함수 적용한 후, 배열에 할당.
            results[0] = "동해 물과 백두산이".IndexOf("백두산").ToString(); // 6
            results[1] = "토요일에 먹는 토마토".LastIndexOf("토").ToString();
            results[2] = "질서 있는 퇴장".Contains("퇴").ToString();
            results[3] = "그 사람의 그림자는 그랬다.".Replace("그", "이");
            results[4] = "삼성 갤럭시".Insert(2, "애플");
            results[5] = "오늘은 왠지 더 배고프다".Remove("오늘은 왠지 더 배고프다".IndexOf("더"), 1);
            
            // Split 사용
            string data = "이름, 나이, 전화번호";
            string[] splitData = data.Split(','); // [이름, 나이, 전화번호]

            // 배열 3칸에 각각 나눠서 저장
            results[6] = splitData[0].Trim();  // "이름"
            results[7] = splitData[1].Trim();  // " 나이"
            results[8] = splitData[2].Trim();  // " 전화번호"
            // Trim(): 문자열의 양쪽 끝에 있는 공백을 없애주는 함수.

            // 문자열.Substring(시작 위치, 가져올 개수)
            // 시작위치 : 어디서부터 자를지, 인덱스 지정 (0부터)
            // 가져올 개수 : 몇 글자를 가져올지 숫자로 지정
            string message = "우리 나라 만세";

            // "나라" 꺼내야함.
            string sub = message.Substring(3, 2);
            results[9] = sub;

            textBox1.Text = results[0] + "\r\n";
            textBox1.Text += results[1] + "\r\n";
            textBox1.Text += results[2] + "\r\n";
            textBox1.Text += results[3] + "\r\n";
            textBox1.Text += results[4] + "\r\n";
            textBox1.Text += results[5] + "\r\n";
            textBox1.Text += results[6] + "\r\n";
            textBox1.Text += results[7] + "\r\n";
            textBox1.Text += results[8] + "\r\n";
            textBox1.Text += results[9] + "\r\n";

            // #3-1. 함수 실행(사용)
            int num = 200;
            int result = Add(100, num);

            textBox1.Text = result.ToString();
            Nothing();
            
        }
        // #3. 함수
        // - 특정 작업을 수행하기 위해 독립적으로 설계된 코드 집합.
        
        // 구조
        // - int (자료형) : 이 함수가 돌려줄 값(return  값)의 타입.
        // - Add : 함수명
        // - int x, int y : parameter
        // ㄴ 함수 선언시 함수가 받아야 하는 입력값(= 매개변수)들.
        // ㄴ 함수에 전달되는 외부 데이터
        // - {} Scope : 코드 실행 범위(유효 범위)

        // 용어 정리
        // - 함수 정의(선언) : 함수를 "생성"
        // - 함수 호출 : 함수를 "사용"

        // return? (반환값)
        // : 함수 내부 코드의 "최종 결과 값"
        // - 함수 본문에서 최종 결과를 저장하고 돌려주는 키워드
        // return 키워드를 만나면 함수 실행 중단.
        
        // 함수 선언
        // #1. return 값이 있는 함수.
        int Add(int x, int y)
        {
            return x + y;
        }

        // #2. return 값이 없는 함수.
        // void
        // - 반환값이 없을 때 사용하는 키워드.
        void Nothing()
        {
            textBox1.Text += "Nothing!!!";
        }


    }
}
