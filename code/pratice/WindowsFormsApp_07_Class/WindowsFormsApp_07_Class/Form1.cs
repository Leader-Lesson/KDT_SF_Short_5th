using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_07_Class
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // ---- #4-1. 기본 생성자 ----
            Car car1 = new Car();
            car1.Speed = 20;
            car1.Color = "은색";
            car1.PrintInfo();

            Console.WriteLine("------------------------------");

            //// ---- #4-2. 매개변수 있는 생성자 ----
            Car car2 = new Car("그랜저", 50, "검정", 2024);
            car2.Accelerate(30);
            car2.PrintInfo();

            Console.WriteLine("------------------------------");

            //// ---- #6. 메서드 사용 ----
            car2.Brake(60);

            Console.WriteLine("------------------------------");

            //// ---- #7. static 메서드 호출 ----
            Car.ShowTotalCars();

            Console.ReadLine();

            Console.WriteLine("=============== New Square 클래스 ===============");
            // 기본 생성자 사용
            Square s1 = new Square();
            Console.WriteLine($"s1 넓이: {s1.GetArea()}");  // 1 * 1 = 1

            Console.WriteLine("------------------------------------------");

            // 매개변수 생성자 사용
            Square s2 = new Square(5);
            Console.WriteLine($"s2 넓이: {s2.GetArea()}");  // 5 * 5 = 25

            Console.ReadLine();
            Console.WriteLine("=============== patial 클래스 ===============");
            Square2 s3 = new Square2();
            Console.WriteLine($"s3 넓이: {s3.GetArea()}");

            Console.WriteLine("------------------------------------------");

            Square2 s4 = new Square2(5);
            Console.WriteLine($"s4 넓이: {s4.GetArea()}");

            Console.ReadLine();

            Console.WriteLine("=============== 구조체 & 클래스 차이점 ===============");
            // 구조체
            PointStruct ps1 = new PointStruct { X = 10, Y = 20 }; // 객체 초기화자
            PointStruct ps2 = ps1;  // 값 복사 (깊은 복사)

            ps2.X = 99; // ps2를 수정해도

            ps1.Print();  // (10, 20)   // ps1 변함 없음.
            ps2.Print();  // (99, 20)

            Console.WriteLine();

            // 클래스
            PointClass pc1 = new PointClass { X = 10, Y = 20 };
            PointClass pc2 = pc1;   // 참조 복사 (얕은 복사)

            pc2.X = 99; // pc2를 수정했는데...

            pc1.Print();  // (99, 20)   // pc1도 변함!
            pc2.Print();  // (99, 20)
        }

        // # 구조체와 클래스의 차이점.
        // 구조체 : 값 형식 (Value Type)
        // - 서로 다른 객체니까 ps1과 ps2는 독립적으로 움직임!
        // ㄴ = 깊은 복사
        struct PointStruct
        {
            public int X;
            public int Y;

            public void Print()
            {
                Console.WriteLine($"Struct Point: ({X}, {Y})");
            }
        }

        // 클래스 : 참조 형식 (Reference Type)
        // - 같은 객체를 가리키기 때문에, 한쪽 수정하면 둘 다 영향 받음.
        // ㄴ = 얕은 복사
        class PointClass
        {
            public int X;
            public int Y;

            public void Print()
            {
                Console.WriteLine($"Class Point: ({X}, {Y})");
            }
        }


        struct Student
        {
            public string name;
            public int age;
            public double score;

            // 생성자
            public Student(string name, int age, double score)
            {
                this.name = name;
                this.age = age;
                this.score = score;
            }

            // 학생 정보 출력 메서드
            public void Print()
            {
                Console.WriteLine($"이름: {name} / 나이: {age} / 점수: {score}");
            }
        }
    }
}
