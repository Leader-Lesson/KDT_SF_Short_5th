using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region #1. Singleton 패턴
/*
 * - 클래스의 인스턴스(객체)를 단 하나만 생성하고,
 *   그 하나의 인스턴스를 전역에서 공유 할 수 있도록 하는 디자인 패턴.
 *   
 * [주 목적]
 * - 공유 자원을 하나의 객체로 관리.
 * - 프로그램 전체에서 중앙 통제 지점 역할
 */
#endregion

/*
 * 시나리오 (요구사항)
 * 1. 버튼을 누르면 카운트가 1씩 증가
 * 2. Label에는 현재 카운트 값을 표시
 * 3. 카운트 상태를 전역적으로 관리.
 *    ㄴ 싱글톤 인스턴스로 공유.
 */

namespace WpfApp_04_DesignPattern
{
    // 카운터 관리 매니저 클래스
    public class CounterManager
    {
        // [1] static 전역 변수(필드)
        private static CounterManager instance = null;

        // [5] lock 객체 생성
        private static object lockObject = new object();

        // [2] 카운트 상태를 저장하는 속성.
        public int Count { get; private set; }

        // [3] 외부에서 직접 생성하지 못하도록 생성자 private 선언
        private CounterManager()
        {
            Count = 0;
        }

        // [4] 공유 인스턴스를 제공하는 속성.
        public static CounterManager Instance
        {
            get
            {
                // [6] lock 처리
                // 멀티스레드 환경에서도 안전하게 하나만 생성되도록 lock 처리.
                lock (lockObject)
                {
                    if (instance == null)
                        instance = new CounterManager(); // 객체 처음 한 번만 생성.
                    return instance;    // 이미 생성된 경우에는 그 인스턴스를 바로 반환.
                }
            }
        }

        // [7] 카운트 증가 메서드
        public void Increment()
        {
            Count++;
        }
    }
}
