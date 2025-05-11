using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_07_Class
{
    public partial class Square2
    {
        // #4. 생성자
        public Square2()
        {
            Length = 1; // 기본 값: 한 변의 길이 1
            Console.WriteLine("기본 Square 객체가 만들어졌습니다.");
        }

        // #5. 매개변수 생성자 (생성자 오버로딩)
        public Square2(int length)
        {
            Length = length;
            Console.WriteLine($"길이 {length}로 Square 객체가 만들어졌습니다.");
        }
    }
}
