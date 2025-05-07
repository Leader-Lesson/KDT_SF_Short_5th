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
    /*
     * 구조체
     * - 여러 데이터를 하나로 묶어서 새로운 데이터 타입 생성.
     * 
     * Why?
     * - 관련 있는 데이터들을 하나로 묶기 위해! (작은 데이터 묶음)
     * 
     * #1. 메모리 저장
     * - 값 형식
     * - ㄴ 데이터를 직접 저장. 변수끼리 복사하면 값이 복제됨.
     * 
     * #2. 구조체 선언 위치
     * - 클래스 밖, namesapce 안 (일반적)
     * - 전역처럼 어디서든 사용 가능
     */
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
            // point1과 point2는 서로 같은 형태를 가졌으나
            // 서로 다른 객체 (다른 메모리 공간을 차지함.)
            Point point1 = new Point(); // 인스턴스 생성 // new: 기본 값 (0)으로 초기화 해줌.
            Point point2;               // new 없이 선언 가능.
            // ㄴ 값 형식이기 때문에 선언만 하면 스택 메모리에  공간이 자동으로 잡힘.

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

                Console.WriteLine($"point[{i}] ({p[i].x}, {p[i].y}, {p[i].z})");
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
       

        /*
         * (참고) - 람다식 설명
         * 여러 줄 선언은 원래 하던대로 일반함수 처럼 (델리게이트 없이)
         * => 자체는 "값(데이터)"라서 변수에 담거나 전달할 때만 쓸 수 있음.
         * 람다식(=>)은 이름 없는 함수 (무명 함수) 이기 때문에, 누군가 받아줘야 쓸 수 있다.
         * 그게 바로 델리게이트, (Func<>, Action<>)임.
         * 그래서 델리게이트 없이는 독립적으로 람다식을 선언해서 사용할 수 없음.
         */
        #endregion
    }
}
