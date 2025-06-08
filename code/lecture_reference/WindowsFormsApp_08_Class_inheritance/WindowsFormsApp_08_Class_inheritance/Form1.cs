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
            Rectangle rect = new Rectangle()
            {
                Name = "사각형",
                Width = 4,
                Height = 5
            };
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


            Console.WriteLine("---------------------------");
            #endregion

            #region #3. base(...) 키워드
            Parent dad = new Parent("홍길동", 55);
            Console.WriteLine("------------------------------");

            GrandChild gc2 = new GrandChild("John", 70);
            Console.WriteLine("------------------------------");
            GrandChild gc3 = new GrandChild("Sam");
            #endregion
        }
    }
}
