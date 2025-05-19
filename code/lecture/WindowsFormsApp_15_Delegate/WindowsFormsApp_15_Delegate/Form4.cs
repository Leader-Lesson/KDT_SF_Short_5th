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
    // [1] delegate 선언
    public delegate void EventDelegate();

    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            EventManager em = new EventManager();

            // [6]. 이벤트 등록
            em.RegisterEvent("Click", ButtonClick);
            em.RegisterEvent("Click", TextClick);

            // 테스트 실행.
            em.InvokeEvent("Click");

            // [7] 이벤트 삭제
            em.RemoveEvent("Click", TextClick);
            em.InvokeEvent("Click");
        }

        // 메서드 1
        public void ButtonClick()
        {
            Console.WriteLine("버튼 클릭 이벤트");
        }
        // 메서드 2
        public void TextClick()
        {
            Console.WriteLine("텍스트 클릭 이벤트");
        }
    }

    // [2] 이벤트 매니저 클래스
    public class EventManager
    {
        // Key: 이벤트 이름, Value: 이벤트 델리게이트
        private Dictionary<string, EventDelegate> eventDict = new Dictionary<string, EventDelegate>();

        // [3] 이벤트 등록 메서드
        public void RegisterEvent(string eventName, EventDelegate callback)
        {
            if(!eventDict.ContainsKey(eventName))
            {
                eventDict[eventName] = callback;
            }
            else
            {
                eventDict[eventName] += callback;
            }
        }

        // [4] 이벤트 삭제 메서드
        public void RemoveEvent(string eventName, EventDelegate callback)
        {
            if (eventDict.ContainsKey(eventName))
            {
                eventDict[eventName] -= callback;

                // 모든 델리게이트가 제거되면 키도 제거
                if (eventDict[eventName] == null)
                {
                    eventDict.Remove(eventName);
                }
            }
        }

        // [5] 이벤트 실행 메서드
        public void InvokeEvent(string eventName)
        {
            if (eventDict.ContainsKey(eventName))
            {
                eventDict[eventName]?.Invoke();  // null 체크 후 실행.
            }
        }

        // del() - 델리게이트 실행 (축약형)
        // del.Invoke() - 델리게이트 실행 (정식 표현)
        // del?.Invoke() - 등록된 함수가 있을 때만 실행(null 안전)
    }
}
