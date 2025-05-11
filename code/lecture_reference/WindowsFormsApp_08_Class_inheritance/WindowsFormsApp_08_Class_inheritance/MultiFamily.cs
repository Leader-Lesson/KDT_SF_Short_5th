using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_08_Class_inheritance
{
    //❗문제
    // Parent는 외부에 공개된 클래스인데
    // 그 기반 클래스 GrandParent는 외부에서 접근할 수 없으므로
    // “외부에서 사용할 수 없는 클래스를 기반으로 한 공개 클래스”는 컴파일 오류

    // #1. 다단계 상속 (조부모 ~ 손자 클래스)
    // 최상위 클래스 (조부모)
    public class GrandParent // internal -> public으로 수정하기.
    {
        public GrandParent()    // Q3) 이건 뭐죠? 기본 생성자!
        {
            Console.WriteLine("GrandParent 생성자 호출됨");
        }

        // #2. base(...) 키워드
        // ㄴ 상속된 클래스에서 "자식" 생성자에서 "부모" 생성자를 선택적으로 호출하고 싶을 때 사용.
        // ㄴ 손자 -> 조상 (x) - 직접 상속받은 부모 클래스의 생성자만!
        // Why?
        // ㄴ 1) 기본 생성자 말고 특정 매개변수가 있는 부모 생성자를 "명확히 지정"하고 싶을 때
        // ㄴ 2) 자식 생성자가 받은 값 중 일부를 부모 생성자에게 넘기고 싶을 때
        public GrandParent(string name, int age) // 생성자 오버로딩!
        {
            Console.WriteLine($"GrandParent 매개변수 생성자 호출됨!");
            Console.WriteLine($"이름은 {name}, 나이는 {age} 입니다.");
        }

        public void SayHello()
        {
            Console.WriteLine("안녕하세요! 나는 할아버지입니다.");
        }
    }

    // 부모 클래스
    public class Parent : GrandParent
    {
        public Parent()
        {
            Console.WriteLine("Parent 생성자 호출됨");
        }

        // #2-1 base(...) 부모 클래스에서 조상 매개변수 생성자 호출
        public Parent(string name, int age) : base(name, age)
        {
            Console.WriteLine($"Parent 매개변수 생성자 호출됨!");
        }

        public void SayHello2()
        {
            Console.WriteLine("나는 아버지입니다.");
        }
    }

    // 자식 클래스
    public class Child : Parent
    {
        //public Child()
        //{
        //    Console.WriteLine("Child 생성자 호출됨");
        //}

        // #2-2 base(...) 손자 클래스에서 먼~ 조상 매개변수 생성자 호출
        // ㄴ 중간 다리 전체 연결 해줘야함.
        public Child(string name, int age) : base(name, age)
        { 
            Console.WriteLine("Child 매개변수 생성자 호출됨");
        }

        // #3. 자식 클래스의 기본 생성자는 없고, 매개변수 생성자만 존재 할 때. (기본 생성자 주석처리 하기!)
        // ㄴ 손자 클래스에서 반드시 부모 클래스의 생성자를 호출해야 함.
        // Why?
        // ㄴ Q) 기본 생성자 작성 안해도 자동으로 생성해주지 않나요?
        //      ㄴ 생성자가 하나라도 없으면 C#이 자동으로 기본 생성자를 만들어줌.
        //      ㄴ But, 생성자가 하나라도 존재한다면, 자동으로 만들어주지 않음..!

        public Child(string name)
        {
            Console.WriteLine("Child 기본 생성자(x) 매개변수 생성자(o) 호출됨");
        }

        public void SayHello3()
        {
            Console.WriteLine("나는 자식입니다.");
        }
    }

    // 손자 클래스
    public class GrandChild : Child
    {
        //public GrandChild()
        //{
        //    Console.WriteLine("GrandChild 생성자 호출됨");
        //}

        // #2-2 base(...) 손자 클래스에서 먼~ 조상 매개변수 생성자 호출
        public GrandChild(string name, int age) : base(name, age)
        {
            Console.WriteLine("GrandChild 매개변수 생성자 호출됨");
        }

        // #3. 손자 클래스에서도 기본 생성자 (X) -- (기본 생성자 주석 처리 하기!)
        // How? (해결 방안)
        // 1) 방법 1: 자식 클래스에 기본 생성자 추가.
        // 2) 방법 2: 손자 클래스 기본 생성자에서 base(...)로 부모 매개변수 생성자 명시 호출
        public GrandChild(string name) : base(name)
        {
            Console.WriteLine("GrandChild 기본 생성자(x) 매개변수 생성자(o) 호출됨");
        }

        // #2-3 GrandChild 클래스에 다음 두 생성자가 동시에 존재할 수 있나요?
        // public GrandChild(string name, int age) : base(name, age) { }
        // public GrandChild(string name, int age) { }
        // 처럼 매개변수가 동일한 생성자 두 개는 절대 공존할 수 없음.
        // How? (해결 방안)
        // 1) 방법 1: 구분자 매개변수를 추가
        // 2) 방법 2: 하나의 생성자에서 분기 처리 (조건절 추가)

        public void SayHello4()
        {
            Console.WriteLine("나는 손자입니다.");
        }
    }

    
}
