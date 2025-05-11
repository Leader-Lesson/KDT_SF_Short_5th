using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_08_Class_inheritance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region #1. 기본 상속
            // 클래스 실행
            // * 객체 이니셜라이저
            // ㄴ 객체를 만들자마자 속성 값을 한꺼번에 초기화하는 문법. 
            Rectangle rect = new Rectangle()
            {
                Name = "사각형",
                Width = 4,
                Height = 5
            };
            /*
             * 이거랑 같을 뿐.
             * Rectangle rect = new Rectangle();
             * rect.Name = "사각형";
             * rect.Width = 4;
             * rect.Height = 5;
             * 조건)
             * 클래스의 속성(Property)이 public { get; set; } 처럼 외부에서 설정 가능해야 함
             */

            Triangle tri = new Triangle
            {
                Name = "삼각형",
                BaseLength = 6,
                Height = 3
            };

            Circle cir = new Circle
            {
                Name = "원",
                Radius = 2
            };

            rect.PrintName(); // 상속된 속성 사용
            // Q2) 각각 넓이 구하는 메소드 작성 후 출력
            Console.WriteLine($"넓이: {rect.GetArea()}");
            tri.PrintName();

            Console.WriteLine($"넓이: {tri.GetArea()}");
            cir.PrintName();
            Console.WriteLine($"넓이: {cir.GetArea():F2}");  // 소수 둘째자리까지

            Console.ReadLine();
            Console.WriteLine("---------------------------");
            #endregion

            #region #2. 다단계 상속

            //GrandChild gc = new GrandChild(); // 손자 객체
            
            //gc.SayHello();
            //gc.SayHello2();
            //gc.SayHello3();
            //gc.SayHello4();

            Console.ReadLine();

            /* 
             * Why? 왜 부모 생성자가 먼저 호출될까?
             * 자식 클래스는 부모의 필드와 기능을 물려받기 때문에
             * 객체를 생성하기 전에 부모 부분부터 먼저 초기화해야 자식 클래스가 안정적으로 작동할 수 있음.
             * - “객체는 아래에서 생성되지만, 생성자는 위에서 호출된다.”
             */

            Console.WriteLine("---------------------------");
            #endregion

            #region #3. base(...) 키워드
            Parent dad = new Parent("홍길동", 55);
            Console.WriteLine("------------------------------");

            // Why? 그냥 부모 객체를 따로 만들면 안되는가??
            // ㄴ 부모 객체를 따로 만든다는 건, 부모 객체와 자식 객체를 분리해서 만들겠다는 의미!
            // ㄴ 상속의 의미가 없음.
            // GrandChild gc = new GrandChild();
            // ㄴ 코드의 의미: "조상부터 아빠까지 포함한 손자 객체 하나를 만든다" 는 것

            GrandChild gc2 = new GrandChild("John", 70);
            Console.WriteLine("------------------------------");
            GrandChild gc3 = new GrandChild("Sam");
            #endregion
        }
    }
}
