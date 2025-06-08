using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_08_Class_inheritance
{

    // #1. 다단계 상속 (조부모 ~ 손자 클래스)
    // 최상위 클래스 (조부모)
    public class GrandParent // internal -> public으로 수정하기.
    {
        public GrandParent()    // Q3) 이건 뭐죠? 기본 생성자!
        {
            Console.WriteLine("GrandParent 생성자 호출됨");
        }

        // #2. base(...) 키워드
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
        public Child(string name, int age) : base(name, age)
        { 
            Console.WriteLine("Child 매개변수 생성자 호출됨");
        }

        // #3. 자식 클래스의 기본 생성자는 없고, 매개변수 생성자만 존재 할 때. (기본 생성자 주석처리 하기!)

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
        public GrandChild(string name) : base(name)
        {
            Console.WriteLine("GrandChild 기본 생성자(x) 매개변수 생성자(o) 호출됨");
        }

        // #2-3 GrandChild 클래스에 다음 두 생성자가 동시에 존재할 수 있나요?
        // public GrandChild(string name, int age) : base(name, age) { }
        // public GrandChild(string name, int age) { }
        // 처럼 매개변수가 동일한 생성자 두 개는 절대 공존할 수 없음.

        public void SayHello4()
        {
            Console.WriteLine("나는 손자입니다.");
        }
    }

    
}
