using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region #1. Singleton 패턴
#endregion

namespace WpfApp_04_DesignPattern
{
    // 카운터 관리 매니저 클래스
    public class CounterManager
    {
        private static CounterManager? instance = null;
        // [4] lock 객체 생성
        private static readonly object lockObject = new object();

        // [1]. 카운트 상태를 저장하는 속성
        public int Count { get; private set; }

        // [2] 외부에서 직접 생성하지 못하도록 생성자 private 선언
        private CounterManager()
        {
            Count = 0;
        }

        // [3] 공유 인스턴스를 제공하는 속성 
        public static CounterManager Instance
        {
            get
            {
                // 멀티스레드 환경에서도 안전하게 하나만 생성되도록 lock 처리
                lock (lockObject)
                {
                    if (instance == null)
                        instance = new CounterManager();    // 객체 처음 한 번만 생성.
                    return instance;    // 이미 생성된 경우에는 그 인스턴스를 바로 반환.
                }
            }
        }

        // [5] 카운트 증가 메서드
        public void Increment()
        {
            Count++;
        }
    }

}
