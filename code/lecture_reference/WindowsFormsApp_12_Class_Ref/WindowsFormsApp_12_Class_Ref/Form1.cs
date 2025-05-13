using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_12_Class_Ref
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // #1. 기본 값 전달 방식
            // ㄴ C#에서는 메서드에 값을 인자로 넘길 때(매개변수 전달),
            // ㄴ 기본적으로 "값을 복사" 하여 전달함.
            // ㄴ 즉, 원본 변수와는 전혀 다른 "복사본"을 만들어 함수에 넘긴다는 뜻.
            // ㄴ 그로 인해, 메서드 안에서 변수 값을 변경해도 원본 변수는 영향을 받지 않음.
            // [참고] 코드 먼저 작성 후 결과 확인.
            int num = 10;

            ChangeValue(num);   // 값을 복사해서 전달 (num 복사)

            Console.WriteLine(num); // 10 - 원본 num은 전혀 바뀌지 않았음.

            /*
             * ref, out 키워드 값 전달 방식
             * Why?
             * - 메서드에서 변수의 **원본 값을 직접 수정하거나**, 
             *   return을 보완하여 **여러 값을 반환**하고 싶을 때 사용함.
             *   => 값 복사(X) 대신 **참조 전달(O)** 방식!
             *
             * 공통점:
             * - 둘 다 "참조 전달" 방식이므로, 메서드 내부에서 변경된 값이 **외부에도 반영**됨.
             * - ref나 out을 사용할 때는, 함수 정의부와 호출부 모두 키워드를 명시해야 하며,
             *   그렇지 않으면 컴파일 오류가 발생. (C# 문법상 필수)
             * 
             * 차이점:
             * [ref]
             * - "입력 + 출력" 목적
             * - 호출 전 변수는 반드시 "초기화"되어 있어야 함
             * - 메서드 안에서 값을 바꿀 수도, 안 바꿀 수도 있음 (선택)
             * 
             * [out]
             * - "출력 전용" 목적
             * - 호출 전 변수는 초기화되어 있을 필요 없음
             * - 메서드 안에서 반드시 값을 할당해야 함 (필수)
             * 
             * When?:
             * - ref: 기존 값을 받아서 내부에서 수정하고 싶을 때
             * - out: return처럼 내부에서 새 값을 만들어서 돌려주고 싶을 때 (여러 값 반환 가능)
             */

            // #2. ref 
            int numRef = 10;    // 변수 초기화
            
            ChangeRef(ref numRef); // 참조 전달.

            Console.WriteLine(numRef); // 99 (원본 값 변경)


            // #3. out
            int numOut;  // 초기화하지 않아도 됨

            ChangeByOut(out numOut);  // out으로 전달

            Console.WriteLine(numOut);  // 100 - 메서드에서 할당한 값


            // #3-2. out 다중 값 반환
            int result1, result2; // 몫, 나머지 받을 변수

            Divide(10, 3, out result1, out result2);    // out 매개변수 전달

            Console.WriteLine($"몫: {result1}, 나머지: {result2}");

            #region ref, out 실습

            // [1] ref 배열 사용
            int[] numbers = new int[5]; // 배열 생성
            RefArray(ref numbers);

            Console.Write("\r\n[ref] 배열 값: ");
            foreach (int n in numbers)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            // [2] out 배열 사용
            int[] outNumber;    // 초기화 안함.
            OutArray(out outNumber, 3);


            Console.Write("\r\n[out] 배열 값: ");
            foreach (int n in outNumber)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            #endregion
        }
        #region 값의 참조

        // #1. 기본 값 전달 방식 (복사된 값만 바뀜, 원본은 그대로)
        // [참고] 값을 받아 내부에서 변경하려 해도 원본은 안 바뀜.
        void ChangeValue(int x) => x = 99; // 복사된 값 x만 바뀌고 num은 여전히 10


        // #2. ref 키워드를 사용한 참조 전달 방식 (참조 전달 -> 원본 값이 바뀜)
        void ChangeRef(ref int x)
        {
            // ref로 받은 x는 num의 참조(주소)를 가리킴
            // 따라서 x를 바꾸면 원본도 같이 바뀜
            x = 99;
        }

        // #3. out 키워드를 사용한 참조 전달 방식 (참조 전달 -> 반드시 값 할당)
        void ChangeByOut(out int x)
        {
            // [참고] 초기화 해도 됨. 대신 그 값은 무시되고 내부에서 반드시 새로 할당해야함.
            x = 100;
        }

        // #3-2. out 키워드를 사용한 여러 값 반환 
        void Divide(int a, int b, out int result1, out int result2)
        {
            result1 = a / b;    // 몫
            result2 = a % b;    // 나머지
        }
        #endregion

        #region ref 실습
        void RefArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
        }

        void OutArray(out int[] arr, int size)
        {
            arr = new int[size]; // out 변수는 반드시 할당!
            for (int i = 0; i< arr.Length; i++)
            {
                arr[i] = i + 1;
            }
        }
        #endregion
    }
}