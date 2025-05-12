using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_10_Class_Override
{
    // # [1] 기본 음료 클래스 (부모 클래스)
    public class Beverage
    {
        // 오버로드 예제: 주문을 다양한 방법으로 받을 수 있음
        public void Order()
        {
            Console.WriteLine("기본 음료를 주문하셨습니다.");
        }

        public void Order(string name)
        {
            Console.WriteLine($"{name}을 주문하셨습니다.");
        }

        public void Order(string name, string size)
        {
            Console.WriteLine($"{size} 사이즈의 {name}을 주문하셨습니다.");
        }

        // 오버라이드 가능하도록 virtual 메서드 선언
        public virtual void Prepare()
        {
            Console.WriteLine("음료를 준비 중입니다.");
        }
    }

    // # [2] 아메리카노 클래스
    public class Americano : Beverage
    {
        public override void Prepare()
        {
            Console.WriteLine("아메리카노를 내리고 있습니다.");
        }
    }

    // # [3] 시그니처 메뉴 클래스
    public class Latte : Beverage
    {
        public sealed override void Prepare()
        {
            Console.WriteLine("시그니처 라떼를 비밀 레시피로 준비 중입니다.");
        }
    }

    // # [4] 이 클래스는 sealed 때문에 override 불가
    public class SpecialLatte : Latte
    {
        // 아래는 오류 발생! sealed 때문에 더 이상 오버라이드 불가
        //public override void Prepare()
        //{
        //    Console.WriteLine("특별한 라떼를 준비 중입니다.");
        //}
    }
}
