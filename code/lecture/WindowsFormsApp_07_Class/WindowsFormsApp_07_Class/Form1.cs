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

            // --- #4-1. 기본 생성자
            Car car1 = new Car();
            car1.Speed = 20;
            car1.Color = "은색";
            car1.PrintInfo();

            Console.WriteLine("-------------------");

            // --- #4-2. 매개변수 있는 생성자
            Car car2 = new Car("그랜저", 50, "검정", 2024);
            car2.Accelerate(30);
            car2.PrintInfo();
            Console.WriteLine("-------------------");

            // --- #6. 메서드 사용
            car2.Brake(100);
            Console.WriteLine("-------------------");
            // --- #7. static 메서드 호출
            Car.ShowTotalCars();

            Console.ReadLine();
            Console.WriteLine("=========== New Square 클래스 ===========");
            // 기본 생성자 사용
            Square s1 = new Square();
            Console.WriteLine($"s1 넓이: {s1.GetArea()}");

            Console.WriteLine("--------------------------");

            // 매개변수 생성자 사용
            Square s2 = new Square(5);
            Console.WriteLine($"s2 넓이: {s2.GetArea()}");

            Console.ReadLine();
            Console.WriteLine("=========== partial 클래스 ===========");
            Square2 s3 = new Square2();
            Console.WriteLine($"s3 넓이: {s3.GetArea()}");

            Console.WriteLine("--------------------------");
            Square2 s4 = new Square2(7);
            Console.WriteLine($"s4 넓이: {s4.GetArea()}");

            Console.ReadLine();
            Console.WriteLine("=========== 구조체 & 클래스 차이점 ===========");
            // 구조체
            PointStruct ps1 = new PointStruct { x = 10, y = 20 }; // 객체 초기화자
            PointStruct ps2 = ps1;  // 값 복사

            ps2.x = 99; // ps2를 수정해도

            ps1.Print();    // (10, 20) // ps1 변함 없음.
            ps2.Print();    // (99, 20)

            Console.WriteLine();

            // 클래스
            PointClass pc1 = new PointClass { x = 10, y = 20};
            PointClass pc2 = pc1;   // 참조 복사

            pc2.x = 99; // pc2를 수정했더니..

            pc1.Print();    // (10, 20) -> (99, 20) // pc1도 변함!
            pc2.Print();    // (99, 20)
        }

        #region 구조체와 클래스의 차이점
        /*
         * 구조체 : 값 형식 (Value Type)
         * - 서로 다른 객체니까 ps1과 ps2는 독립적으로 움직임!
         * ㄴ = 깊은 복사
         */
        struct PointStruct
        {
            public int x;
            public int y;

            public void Print()
            {
                Console.WriteLine($"Struct Point: ({x}, {y})");
            }
        }

        /*
         * 클래스 : 참조 형식 (Reference Type)
         * - 같은 객체를 가리키기 때문에, 한 쪽을 수정하면 둘 다 영향 받음.
         * ㄴ = 얕은 복사
         */

        class PointClass
        {
            public int x;
            public int y;
            public void Print()
            {
                Console.WriteLine($"Class Point: ({x}, {y})");
            }
        }
        #endregion
    }
}
