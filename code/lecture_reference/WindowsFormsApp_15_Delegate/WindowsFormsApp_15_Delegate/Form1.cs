using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_15_Delegate
{
    #region 델리게이트 설명
    #endregion

    // [1] 델리게이트 기본 사용법
    // #1-1. 델리게이트 선언 (사용자 정의 타입)
    public delegate void MyDelegate(); //반환형 void, 매개변수 없음.

    // [2] 멀티캐스트 델리게이트 (Multicast Delegate)

    // #2-1. 델리게이트 선언
    public delegate void NotifyDelegate(); // 반환형 void, 매개변수 없음

    // [3] 익명 메서드
    // #3-1.
    public delegate void ActionDelegate();

    // [5] 람다식 & 델리게이트

    // #5-1.
    public delegate void CalcDelegate(int a, int b);

    public partial class Form1 : Form
    {
        // #1-2. 메서드 정의
        public void SayHello()  // 반환형 void, 매개변수 없음 => MyDelegate와 형태가 알맞음. - 저장 가능!
        {
            Console.WriteLine("안녕하세요!");
        }

        // #2-2. 멀티캐스트 메서드 정의
        public void SoundAlarm()
        {
            Console.WriteLine("[1] 경보음이 울립니다!");
        }
        
        public void FlashLight()
        {
            Console.WriteLine("[2] 경고음이 깜빡입니다.");
        }

        public void SendNotification()
        {
            Console.WriteLine("[3] 관리자에게 알림을 보냅니다!");
        }

        public Form1()
        {
            InitializeComponent();

            // #1-3. 델리게이트 객체 생성 & 메서드 참조
            // 1) 명시적 방식
            MyDelegate del = new MyDelegate(SayHello);  // SayHello 메서드를 MyDelegate 타입 변수인 del에 할당. = 메서드 저장.

            // 2) 암묵적 방식(간략화)
            MyDelegate del2 = SayHello;


            // #1-4. 델리게이트 실행. 
            del();  // 메서드 호출 - SayHello(); 와 같음.
            del2();

            Console.WriteLine("\n================ 멀티캐스트 델리게이트 ================");
            // #2-3. 델리게이트 변수 선언 + 메서드 연결
            NotifyDelegate mulDel = SoundAlarm;
            mulDel += FlashLight;
            mulDel += SendNotification;

            Console.WriteLine("\n메서드 실행");
            mulDel();   // 세 개의 메서드가 순차적으로 실행됨.

            // #2-4. 특정 메서드 제거
            Console.WriteLine("\n[경고등 제거 후 동작]");
            mulDel -= FlashLight;
            mulDel();

            Console.WriteLine("\n================ 익명 메서드 ================");
            // #3-2. 익명 메서드로 델리게이트 정의
            ActionDelegate acDel = delegate ()
            {
                Console.WriteLine("익명 메서드 입니다!.");
            };

            acDel();

            Console.WriteLine("\n================ 내장 델리게이트 타입 ================");
            // [4] 내장 델리게이트 타입 & 익명 메서드

            // 델리게이트 타입
            // ㄴ 매개변수 2개, 반환 값 1개 의미. (int a, int b, int 결과)
            // ㄴ 즉, int, int를 받아서 int를 반환하는 함수만 저장 가능한 델리게이트 타입!

            Console.WriteLine("===== Func<> =====");
            Func<int, int, int> addDel = delegate (int a, int b)
            {
                return a + b;
            };

            int result = addDel(3, 5);
            Console.WriteLine($"{result}");
            // [해석]
            // ㄴ 이 함수는 이름이 없고, 델리게이트에 직접 전달됨.

            Console.WriteLine("===== Action<> =====");
            Action<string> printMessage = delegate (string msg)
            {
                Console.WriteLine($"메세지 출력: {msg}");
            };
            printMessage("Action!");
            // predicate는 직접 알아서.. 검색!


            Console.WriteLine("\n================ 람다식 ================");
            

            // #5-2. 기본 람다식 사용
            CalcDelegate printSum = (x, y) =>
            {
                int sum = x + y;
                Console.WriteLine($"[1] {x} + {y} = {sum}");
            };
            printSum(10, 20);

            // #5-3. Func 사용 - 반환 값 있는 람다
            Func<int, int, int> multiply = (a, b) => a * b;
            int result2 = multiply(3, 5); // 람다식은 "값처럼" 변수에 저장 가능 - [참고 1]
            Console.WriteLine($"[2] {result}");

            // #5-4. Action 사용 - void 반환 람다
            Action<string> callName = name => Console.WriteLine($"[3] {name}님, 안녕하세요!");
            callName("Damon");

        }
    }
}
