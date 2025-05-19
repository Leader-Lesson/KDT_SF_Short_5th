﻿using System;
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

    // [1]. event 키워드 사용
    public delegate void Notify2();

    public partial class Form3 : Form
    {
        // #2. 메서드 정의
        static void AlarmMessage()
        {
            Console.WriteLine("알람 울림");
        }

        // ##1. 사용자 정의 이벤트 선언
        public event EventHandler MyEvent;
        //  object sender: 이벤트를 발생시킨 객체(ex.button1)
        //  EventArgs e: 이벤트에 대한 정보

        public Form3()
        {
            InitializeComponent();

            Alarm alarm = new Alarm();

            Alarm2 alarm2 = new Alarm2();

            // ##2. 이벤트 핸들러 등록
            MyEvent += ConsoleMessage;

            // ##3. 이벤트를 발생시켜주는 트리거 메서드
            btnTrigger.Click += BtnTrigger_Click;


            // #4. 델리게이트 변수에 메서드 할당.
            alarm.OnRing += AlarmMessage;

            // [4] Event 델리게이트 메서드 할당
            alarm2.OnRing += AlarmMessage;

            // #5. 실행
            alarm.OnRing(); // AlarmMessage 실행

            // [5]. Event 델리게이트 실행
            //alarm2.OnRing(); // 컴파일 오류
            alarm2.Trigger();   // 클래스 내부 메서드만 가능 -> 안전함.
        }

        // ##3. 메서드 작성
        private void ConsoleMessage(object sender, EventArgs e)
        {
            Console.WriteLine("[이벤트 발생]");
        }

        // ##4. 트리거 메소드 작성
        private void BtnTrigger_Click(object sender, EventArgs e)
        {
            // ##5. 이벤트 발생
            MyEvent?.Invoke(this, EventArgs.Empty);
        }


        // #3. 클래스 정의
        public class Alarm
        {
            public Notify OnRing;   // Notify 타입 변수 선언
        }

        // [3]. Event 클래스 정의
        public class Alarm2
        {
            public event Notify2 OnRing; // Notify2 타입 변수 선언

            public void Trigger()
            {
                if (OnRing != null)
                {
                    OnRing();
                }
            }
        }

        // # 이벤트 메서드
        // - VS가 자동으로 "delegate 형식(EventHandler delegate)"에 맞춰서
        //   만들어준 이벤트 핸들러 메서드.
        private void button1_Click(object sender, EventArgs e)
        {

        }
        /*
         * Button 클래스 내부
         * public event EventHandler Click; // 델리게이트 기반 이벤트
         * button.Click += new EventHandler(button1_Click);
         * 
         * 즉, 우리가 button1_Click()이라고 만든 함수는
         * EventHandler라는 델리게이트에 연결되는 핸들러 함수에요.
         * 
         * EventHandler?
         * ㄴ .NET에서 미리 정의된 델리게이트 타입.
         * 
         * object sender: 이벤트를 발생시킨 객체 (ex. button1)
         * EventArgs e: 이벤트에 대한 정보
         * 
         * 1. 이미 정의된 이벤트(Button.Click 등)를 사용할 때
         *    ㄴ 우리는 그냥 이벤트에 연결한 메서드만 만들면 됨.
         * 2. 내가 직접 이벤트를 만들고 싶을 때 -> 반드시 event 필요.
         */
    }
}
