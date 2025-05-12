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
        // ㄴ 같은 이름의 메서드를 매개변수만 다르게 해서 여러 개 정의 하는 것!
        // [참고] 오버로드 예제: 주문을 다양한 방법으로 받을 수 있음
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
        // ㄴ 부모 클래스의 메서드를 자식 클래스에서 다시 정의(덮어쓰기) 하는 것!
        // Why?
        // ㄴ 부모 클래스가 기본 기능을 제공하되,
        // ㄴ 자식 클래스에서는 그 기능을 자신만의 방식으로 바꿔야 할 때가 많을 때 사용!
        // 조건)
        // 1. 부모 메서드가 virtual 키워드로 선언되어 있어야 함.
        // 2. 자식 클래스에서 override 키워드로 재정의 해야 함.

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
        // ㄴ 여기까지만 재정의(override) 가능하고,
        // ㄴ 그 하위 자식들은 이 메서드를 바꿀 수 없게 막겠다. 라는 의미.
        public sealed override void Prepare()
        {
            Console.WriteLine("라떼를 준비 중입니다.");
        }
    }

    // # [4] 이 클래스는 sealed 때문에 override 불가
    // ㄴ sealed를 상속받는 자식 클래스에게 영향을 줌.
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
