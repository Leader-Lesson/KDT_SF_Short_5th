using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Struct_Ex
{
    struct Point
    {
        public int x;
        public int y;

        // 두 점 사이 거리 계산 메서드
        // 정적(static) 메서드: 객체 없이도 호출 가능.
        public static double Distance(Point p1, Point p2)
            // p1 (x,y) , p2 (x,y)
        {
            int dx = p2.x - p1.x;
            int dy = p2.y - p1.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.Write("첫 번째 좌표 (x, y) 입력: ");
            string[] input1 = Console.ReadLine().Split();
            // 공백 기준으로 사용자 입력을 나눠서 배열로 반환.
            // 2 6 입력
            // input1 = [2, 6]

            Point p1 = new Point(); // p1(0, 0);
            p1.x = int.Parse(input1[0]); // 2 -> p1(2, 0);
            p1.y = int.Parse(input1[1]); // 6 -> p1(2, 6); (완성)

            Console.Write("두 번째 좌표 (x, y) 입력: ");
            string[] input2 = Console.ReadLine().Split();
            // 3 5 입력
            // input2 = [3, 5]

            Point p2 = new Point(); // p2(0, 0);
            p2.x = int.Parse(input2[0]); // 3 -> p2(3,0);
            p2.y = int.Parse(input2[1]); // 5 -> p2(3,5); (완성)

            double distance = Point.Distance(p1, p2);
            Console.WriteLine($"두 점 사이의 거리: {distance:F4}");
            // F는 Fixed-point (고정 소수점) 형식 의미.
            // 4는 소수점 이하 자리 수를 의미.
        }
    }
}
