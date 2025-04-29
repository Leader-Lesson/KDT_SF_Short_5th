using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_jaggedArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string[][] classes = new string[3][];

            // 각각 직접 할당
            classes[0] = new string[2] { "철수", "영희" };
            classes[1] = new string[3] { "민수", "지영", "준호" };
            classes[2] = new string[1] { "수빈" };

            // TextBox에 학생 이름 출력
            textBox_print.Text = "";

            textBox_print.Text += "1반 학생 목록:\r\n";
            textBox_print.Text += "- " + classes[0][0] + "\r\n";
            textBox_print.Text += "- " + classes[0][1] + "\r\n";

            textBox_print.Text += "\r\n"; // 한 줄 띄우기

            textBox_print.Text += "2반 학생 목록:\r\n";
            textBox_print.Text += "- " + classes[1][0] + "\r\n";
            textBox_print.Text += "- " + classes[1][1] + "\r\n";
            textBox_print.Text += "- " + classes[1][2] + "\r\n";

            textBox_print.Text += "\r\n"; // 한 줄 띄우기

            textBox_print.Text += "3반 학생 목록:\r\n";
            textBox_print.Text += "- " + classes[2][0] + "\r\n";
        }
    }
}
