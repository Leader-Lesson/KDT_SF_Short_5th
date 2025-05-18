using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_15_Delegate
{
    #region 델리게이트 설명
    /*
     * delegate 란? (= 대리자) - 메서드를 대신 실행해줌.
     * 델리게이트는 메서드에 대한 *참조*를 저장할 수 있는 형식(타입)
     * 즉, 메서드를 직접 실행하지 않고, 실행 방법만 담아두는 일종의 "포인터 함수" 역할.
     * 
     * Why?
     * ㄴ 1) 메서드를 나중에 실행하고 싶을 때.
     *       ㄴ 실행 로직을 저장해뒀다가 특정 조건이 되면 실행.
     * ㄴ 2) 메서드를 매개변수로 전달하고 싶을 때.
     * ㄴ 3) 이벤트 시스템을 만들 때.
     * 
     * [특징]
     * ㄴ 1) 타입 안정성 - 컴파일 시점에 타입 검사. (매개변수, 반환값이 동일해야 함)
     * ㄴ 2) 여러 메서드 연결 가능 - += 연산자로 메서드 체인 가능 (= Multicast Delegate)
     * ㄴ 3) 이벤트와 잘 어울림. - C# 이벤트는 사실상 델리게이트 기반이다.
     *
     *
     * [구조]
     * - [접근제한자] delegate [반환형] [델리게이트 명]([매개변수 목록]);
     * 
     * [선언 위치]
     * - namespace 안, 클래스 밖 - 타입이기 때문에.
     */
    #endregion

    // [1] 델리게이트 기본 사용법
    // #1-1. 델리게이트 선언 (사용자 정의 타입)
    public delegate void MyDelegate();  // 반환형 void, 매개변수 없음.
    // 의미
    // ㄴ 반환값이 void 이고, 매개변수가 없는 메서드를 참조할 수 있는 타입 MyDelegate를 선언.
    // ㄴ 즉, "이런 형태의 메서드를 받을 수 있습니다~" 라고 약속하는 타입 정의.


    // [2] 멀티캐스트 델리게이트 (Multicast Delegate)
    /*
     * - 하나의 델리게이트에 여러 개의 메서드를 연결해서 순차적으로 실행하는 기능.
     * += : 메서드 연결
     * -= : 메서드 제거
     * 
     * [주의]
     * - 리턴 값이 있는 델리게이트에는 일반적으로 Multicast 사용 X
     *   ㄴ 마지막 값만 사용되므로 혼란 가능성 있음!
     */

    // #2-1. 델리게이트 선언
    public delegate void NotifyDelegate();  // 반환형 void, 매개변수 없음

    // [3] 익명 메서드
    /*
     * - 메서드를 따로 만들지 않고, "델리게이트에 직접 정의" 하는 것이 특징!
     * 
     * Why?
     * ㄴ 1) 한 번만 쓸 메서드 - 굳이 이름 붙여서 만들 필요 없음 (네이밍 컨벤션 피로도 감소)
     * ㄴ 2) 로컬 함수처럼 간단한 로직 - 코드 흐름을 방해하지 않고 인라인으로 처리 가능
     * ㄴ 3) 델리게이트에 직접 연결 할 때 - delegate {...} 로 간결하게 사용 가능.
     * 
     * [구조]
     * [델리게이트 타입] 변수 = delegate([매개변수) {실행할 코드};
     */

    // #3-1.
    public delegate void ActionDelegate();

    // [5] 람다식 & 델리게이트
    /*
     * 람다식 이란?
     * - 메서드를 이름 없이 간결하게 표현하는 문법
     * - delegate 키워드 없이 () => {} 형식으로 작성.
     * - 함수 자체를 '값처럼' 전달
     *   ㄴ 변수에 저장하거나, 다른 메서드의 매개변수로 전달 할 수 있음!
     * - 코드 한 줄, 여러 줄 모두 가능.
     * 
     * Why?
     * ㄴ 1) 간결함 - delegate {} 보다 훨씬 짧음.
     * ㄴ 2) 실무에서 자주 사용.
     * 
     * [구조]
     * [델리게이트 타입] [변수명] = [매개변수] => [실행 코드];
     */

    // #5-1.
    public delegate void CalcDelegate(int a, int b);

    // Ex)
    public delegate void Runner();  // 매개변수 x , 반환형 void
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
            Console.WriteLine("[1] 경보음이 울립니다.");
        }

        public void FlashLight()
        {
            Console.WriteLine("[2] 경고음이 깜빡입니다.");
        }

        public void SendNotification()
        {
            Console.WriteLine("[3] 관리자에게 알람을 보냅니다.");
        }

        public void RunnerCall(Runner runner)   // 매개변수 1, 반환형 void // Go
        {
            runner(); // Go();
        }
        
        public void Go() => Console.WriteLine("달려");    // 매개변수 x, 반환형 void
        public void Stop() => Console.WriteLine("멈춰");  // 매개변수 x, 반환형 void

        public Form1()
        {
            InitializeComponent();

            // #1-3. 델리게이트 객체 생성 & 메서드 참조.
            // 1) 명시적 방식
            MyDelegate del = new MyDelegate(SayHello);
            // SayHello 메서드를 MyDelegate 타입 변수인 del에 할당. = 메서드 저장.

            // 2) 암묵적 방식 (간략화)
            MyDelegate del2 = SayHello;


            // #1-4. 델리게이트 실행.
            del();  // 메서드 호출 - SayHello(); 와 같음.
            del2();

            Console.WriteLine("\n=============== 멀티캐스트 델리게이트 ===============");
            // #2-3. 델리게이트 변수 선언 + 메서드 연결
            NotifyDelegate mulDel = SoundAlarm;
            mulDel += FlashLight;
            mulDel += SendNotification;

            Console.WriteLine("\n메서드 실행");
            mulDel();   // 세 개의 메서드가 순차적으로 실행됨.

            // #2-4. 특정 메서드 제거.
            Console.WriteLine("\n[FlashLight 제거 후 동작]");
            mulDel -= FlashLight;
            mulDel();

            Console.WriteLine("\n=============== 익명 메서드 ===============");
            // #3-2. 익명 메서드로 델리게이트 정의
            ActionDelegate acDel = delegate ()
            {
                Console.WriteLine("익명 메서드 입니다!");
            };
            acDel();


            Console.WriteLine("\n=============== 내장 델리게이트 타입 ===============");
            // [4] 내장 델리게이트 타입 & 익명 메서드
            /*
             * 내장 델리게이트 타입 (C# 제공)
             * - C#이 자주 쓰는 함수 형태(매개변수 + 반환 값)를 위해 특정 표준 델리게이트 타입을 미리 정의 해놓은 것.
             * 
             * Why?
             * - 간결하고 범용적인 함수 형태를 빠르게 표현 할 수 있어서
             * 
             * When?
             * - 간단한 함수, 반복적으로 많이 쓰이는 형태라면 내장 델리게이트 타입!
             * - 의미 있는 이름을 붙이거나 복잡한 구조로 사용자 정의를 원한다면 직접 delegate 선언!
             * 
             * 
             * [종류]
             * - Func<...>          - 반환 값(o) / 반드시 마지막 타입이 반환형
             * - Action<...>        - 반환 값(x) / void
             * - Predicate<...>     - bool 반환하는 특수한 Func (조건 필터용)
             * 
             * [구조]
             * Func<T1, T2, ..., TResult>
             * - 앞쪽은 매개변수 타입들
             * - 마지막은 반환(return) 타입.
             */
            // 델리게이트 타입
            // ㄴ 매개변수 2개, 반환 값 1개 의미.   (int a, int b, int 결과)
            // ㄴ 즉, int, int를 받아서 int를 반환하는 함수만 저장 가능한 델리게이트 타입!

            Console.WriteLine("====== Func<> ======");
            Func<int, int, int> addDel = delegate (int a, int b)
            {
                return a + b;
            };
            int result = addDel(3, 5);
            Console.WriteLine($"{result}");

            Console.WriteLine("====== Action<> ======");
            Action<string> printMessage = delegate (string msg)
            {
                Console.WriteLine($"메세지 출력: {msg}");
            };
            printMessage("Action!");

            // predicate는 직접 검색 알아서..!


            Console.WriteLine("\n=============== 람다식 ===============");
            // #5-2. 기본 람다식 사용.
            CalcDelegate printSum = (x, y) =>
            {
                int sum = x + y;
                Console.WriteLine($"[1] {x} + {y} = {sum}");
            };
            printSum(10, 20);

            // #5-3. Func 사용 - 반환 값이 있는 람다
            Func<int, int, int> multiply = (a, b) => a * b;
            int result2 = multiply(3, 5);   // 람다식은 "값처럼" 변수에 저장 가능.
            Console.WriteLine($"[2] {result2}");

            // #5-4. Action 사용 - void 반환 람다
            Action<string> callName = name => Console.WriteLine($"[3] {name}님, 안녕하세요!");
            callName("Damon");

            //Runner runner = new Runner(Go);
            Runner runner = Go;

            RunnerCall(runner);

            //RunnerCall(new Runner(Stop));

            Runner runner2 = Stop;

            RunnerCall(runner2);    //
        }
    }
}
