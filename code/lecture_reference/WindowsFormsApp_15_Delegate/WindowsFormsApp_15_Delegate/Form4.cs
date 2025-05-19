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
    public partial class Form4 : Form
    {
        private EventManager eventManager;

        public Form4()
        {
            InitializeComponent();
            eventManager = new EventManager();

            // 이벤트 등록
            eventManager.RegisterEvent("OnClick", OnButtonClick);
            eventManager.RegisterEvent("OnClick", ShowMessage);  // 여러 메서드 연결 가능

            // 테스트 실행
            eventManager.InvokeEvent("OnClick");

            // 이벤트 제거 후 재실행
            eventManager.RemoveEvent("OnClick", ShowMessage);
            eventManager.InvokeEvent("OnClick");
        }

        // 메서드1
        private void OnButtonClick()
        {
            Console.WriteLine("버튼 클릭 이벤트 발생!");
        }

        // 메서드2
        private void ShowMessage()
        {
            MessageBox.Show("이벤트에 등록된 메시지!");
        }
    }

    // [1] delegate 선언
    public delegate void EventDelegate();

    // [2] 이벤트 매니저 클래스
    public class EventManager
    {
        // Key: 이벤트 이름, Value: 이벤트 델리게이트
        private Dictionary<string, EventDelegate> eventDict = new Dictionary<string, EventDelegate>();

        // [이벤트 등록]
        public void RegisterEvent(string eventName, EventDelegate callback)
        {
            if (!eventDict.ContainsKey(eventName))
            {
                eventDict[eventName] = callback;
            }
            else
            {
                eventDict[eventName] += callback; // 델리게이트는 += 로 여러 메서드 추가 가능 (Multicast Delegate)
            }
        }

        // [이벤트 삭제]
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

        // [이벤트 실행]
        public void InvokeEvent(string eventName)
        {
            if (eventDict.ContainsKey(eventName))
            {
                eventDict[eventName]?.Invoke();  // null 체크 후 실행
            }
        }

        //del()   델리게이트 실행(축약형)
        //del.Invoke() 델리게이트 실행(정식 표현)
        //del?.Invoke()   등록된 함수가 있을 때만 실행(null 안전)
    }
}
