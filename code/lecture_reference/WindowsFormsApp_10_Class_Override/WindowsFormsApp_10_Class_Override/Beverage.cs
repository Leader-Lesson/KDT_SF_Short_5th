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
        // #1. 오버로드
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

        // #2. 오버라이드

        // virtual : 오버라이드 허용
        public virtual void Prepare()
        {
            Console.WriteLine("음료를 준비 중입니다.");
        }
    }

    // # [2] 아메리카노 클래스
    public class Americano : Beverage
    {
        // override : 부모 메서드 덮어쓰기.
        public override void Prepare()
        {
            Console.WriteLine("아메리카노를 내리고 있습니다.");
        }
    }

    // # [3] 라떼 클래스
    public class Latte : Beverage
    {
        // sealed : override 더 이상 못하게 막기.
        public sealed override void Prepare()
        {
            Console.WriteLine("라떼를 준비 중입니다.");
        }
    }

    // # [4] 이 클래스는 sealed 때문에 override 불가
    public class ColdBrew : Latte
    {
        // 아래는 오류 발생! sealed 때문에 더 이상 오버라이드 불가
        //public override void Prepare()
        //{
        //    Console.WriteLine("콜드브루를 준비 중입니다.");
        //}
    }

    // # [5] 모든 메뉴가 Beverage만 상속하는 구조라면?
    public class ColdBrew2 : Beverage
    {
        // Latte 클래스를 상속 받지 않았기 때문에, sealed 영향을 받지 않음. -> override 가능!
        public override void Prepare() { } // 가능 (o)
    }
}
