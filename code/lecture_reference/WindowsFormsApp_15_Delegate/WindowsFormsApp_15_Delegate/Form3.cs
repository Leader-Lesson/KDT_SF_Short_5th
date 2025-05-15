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
    // #1. 일반 델리게이트
    public delegate void Notify(); // 1. 델리게이트 타입 정의

    // #2. event 키워드 사용
    public delegate void Notify2(); 

   
    public partial class Form3 : Form
    {
        static void AlarmMessage()
        {
            Console.WriteLine("알람 울림");
        }

        public Form3()
        {
            InitializeComponent();

            Alarm alarm = new Alarm();

            Alarm2 alarm2 = new Alarm2();

            // 3. 델리게이트 변수에 메서드 할당
            alarm.OnRing += AlarmMessage;

            alarm2.OnRing += AlarmMessage;  // 외부에서 등록만 가능.

            // 4. 실행
            alarm.OnRing(); // AlarmMessage 실행.
            // 외부에서 마음대로 실행 가능

            //alarm2.OnRing();    // 컴파일 에러
            alarm2.Trigger();   // 클래스 내부 메서드만 가능 -> 안전함.
        }

        // # 이벤트 메서드
        /*
         * VS가 자동으로 "delegate 형식(EventHandler delegate)"에 맞춰서 만들어준 이벤트 핸들러 메서드.
         */
        private void button1_Click(object sender, EventArgs e)
        {

        }

        /*
         * // Button 클래스 내부
         * public event EventHandler Click;   // ← 델리게이트 기반 이벤트
         * // 등록 (자동 생성된 코드에서)
         * button1.Click += new EventHandler(button1_Click);
         * 
         * 즉, 우리가 button1_Click()이라고 만든 함수는
         * EventHandler라는 델리게이트에 연결되는 핸들러 함수예요.
         * 
         * EventHandler?
         * .NET에서 미리 정의된 델리게이트 타입.
         * 
         * object sender: 이벤트를 발생시킨 객체 (ex. button1)
         * EventArgs e: 이벤트에 대한 정보 (기본형: EventArgs.Empty)
         * 
         * 1. 이미 정의된 이벤트(Button.Click 등)를 사용할 때
         *    ㄴ 우리는 그냥 이벤트에 연결할 메서드만 만들면 됨
         * 2. 내가 직접 이벤트를 만들고 싶을 때 → 반드시 event 필요
         */

    }

    public class Alarm
    {
        public Notify OnRing;   // 2. Notify 타입 변수 선언
    }

    // event
    public class Alarm2
    {
        public event Notify OnRing;

        public void Trigger()
        {
            // null 체크는 꼭 해줘야함.
            // ㄴ 등록된 함수가 하나도 없을 수 있기 때문
            if (OnRing != null)
                OnRing();  // 또는 OnRing?.Invoke(); // 내부에서만 실행 가능
            // Invoke()는 델리게이트(delegate)가 참조하고 있는 메서드를 실행시키는 함수
        }

        //del()   델리게이트 실행(축약형)
        //del.Invoke() 델리게이트 실행(정식 표현)
        //del?.Invoke()   등록된 함수가 있을 때만 실행(null 안전)
    }
}
