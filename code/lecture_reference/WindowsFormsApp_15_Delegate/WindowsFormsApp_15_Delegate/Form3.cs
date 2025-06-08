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

        // ## 1. 사용자 정의 이벤트 선언
        public event EventHandler MyEvent;

        public Form3()
        {
            InitializeComponent();

            // ## 2. 이벤트 핸들러 등록
            MyEvent += ShowConsoleMessage;
            MyEvent += ShowPopup;

            // ## 3. 버튼 클릭 시 이벤트 실행
            btnTrigger.Click += BtnTrigger_Click;


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

        // [4] 이벤트를 발생시키는 트리거 메서드
        private void BtnTrigger_Click(object sender, EventArgs e)
        {
            // [5] 이벤트 발생 - 반드시 null 체크
            MyEvent?.Invoke(this, EventArgs.Empty);
        }

        // [6] 콘솔 출력용 핸들러
        private void ShowConsoleMessage(object sender, EventArgs e)
        {
            Console.WriteLine("[이벤트 발생] 콘솔 메시지 출력!");
        }

        // [7] 메시지박스 출력용 핸들러
        private void ShowPopup(object sender, EventArgs e)
        {
            MessageBox.Show("이벤트가 발생했습니다!", "알림");
        }


        // # 이벤트 메서드
        private void button1_Click(object sender, EventArgs e)
        {

        }



    }

    public class Alarm
    {
        public Notify OnRing;   // 2. Notify 타입 변수 선언
    }

    // event
    public class Alarm2
    {
        public event Notify2 OnRing;    

        public void Trigger()
        {
            // null 체크는 꼭 해줘야함.
            // ㄴ 등록된 함수가 하나도 없을 수 있기 때문
            if (OnRing != null)
                OnRing();  // 또는 OnRing?.Invoke(); // 내부에서만 실행 가능
            // Invoke()는 델리게이트(delegate)가 참조하고 있는 메서드를 실행시키는 함수
        }
    }
}
