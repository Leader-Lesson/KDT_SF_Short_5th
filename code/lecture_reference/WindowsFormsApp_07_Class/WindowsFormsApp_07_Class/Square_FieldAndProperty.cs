using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_07_Class
{
    public partial class Square2
    // ㄴ 세 파일에 나눠 쓴 Square2 클래스 -> 컴파일 할 때 하나로 합쳐짐. (컴파일 시 자동 병합)
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
                    length = 0; // 음수 방지 -> 0으로 설정
                else
                    length = value;
            }
        }
    }
}
