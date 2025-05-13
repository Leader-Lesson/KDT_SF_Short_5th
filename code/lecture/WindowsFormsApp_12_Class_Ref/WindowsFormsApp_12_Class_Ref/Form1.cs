using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_12_Class_Ref
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // #1. 기본 값 전달 방식
            // ㄴ 메서드에 인자를 전달할 때 기본적으로 C#은 값을 복사하여 전달함.
            // ㄴ 즉, 원래 변수의 복사본이 전달되므로, 메서드 안에서 값을 변경해도 원본 변수는 영향을 받지 않음.
            int num = 1;
            ChangeValue(num);   // 값을 복사해서 전달
            Console.WriteLine(num); // 
        }

    void ChangeValue(int x)
        {
            x = 99;
        }
    }
}