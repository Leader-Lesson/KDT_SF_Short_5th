using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_07_Class
{
    // #1. Square 클래스 정의
    // - 정사각형
    // - 속성: 변의 길이
    // - 메서드: 넓이를 구하는 기능.
    internal class Square
    {
        // #2. 필드
        private int length; // 변의 길이

        // #3. 속성
        public int Length
        {
            get { return length; }
            set
            {
                if (value < 0)
                    length = 0; // 음수 방지
                else
                    length = value;
            }
        }

        // #4. 기본 생성자
        public Square() 
        {
            Length = 1; // 기본 값: 한 변의 길이 1
            Console.WriteLine("기본 Square 객체가 만들어졌습니다.");
        }

        // #4-2. 매개변수 생성자
        public Square(int length)
        {
            Length = length;
            Console.WriteLine($"길이 {length}로 Square 객체가 만들어졌습니다.");
        }

        // #5. 메서드
        // - 넓이 구하는 기능
        public int GetArea()
        {
            return Length * Length;
        }
    }
}
