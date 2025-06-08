using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_06_Struct
{
    #region #1. 구조체 정의
    struct Point
    {
        public int x;
        internal int y; // internal (접근제한자) - 같은 프로젝트 안에서만 접근 가능.
        public int z;

        public int Diff_xy()
        {
            return x - y;
        }
    }
    #endregion


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region #2. 구조체 사용
            Point point1 = new Point(); // 인스턴스 생성 // new: 기본 값 (0)으로 초기화 해줌.
            Point point2;               // new 없이 선언 가능.

            point1.x = 10;
            point2.x = 31;

            Point point3 = new Point();
            point3.x = 20;
            point3.y = 40;
            int diff = point3.Diff_xy();

            //textBox1.Text = $"point ({point.x}, {point.y}, {point.z})";
            Console.WriteLine($"point ({point3.x}, {point3.y}, {point3.z}), 함수값: {diff}");
            #endregion

            #region #3. 구조체 배열 사용
           
            Point[] p = new Point[3];   // Point 구조체 3개를 담을 배열
            // p[0], p[1], p[2]
            
            for (int i = 0; i < p.Length; i++)
            {
                p[i].x = i;
                p[i].y = i * i;
                p[i].z = -i;

                Console.WriteLine($"/point[{i}] ({p[i].x}, {p[i].y}, {p[i].z})");
            }
            #endregion

            #region #4. 표현식 본문 (화살표 함수)
            // 한 줄만 가능.
            // 여러 줄이면 반드시 블록 본문으로 작성 해야 함.

            this.button1.Click += new System.EventHandler(button1_Click);

            // 표현식 사용 -> 한 줄로 표현
            this.button1.Click += (sender, e) => ((Button)sender).BackColor = Color.Red;

            Hi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Red;
        }

        // 일반 함수 선언문
        int Add(int a, int b)
        {
            return a + b;
        }

        // 표현식 함수 선언문 (한 줄 선언)
        int Add2(int a, int b) => a + b;

        void Hi() => Console.WriteLine("표현식");
       

        #endregion
    }
}
