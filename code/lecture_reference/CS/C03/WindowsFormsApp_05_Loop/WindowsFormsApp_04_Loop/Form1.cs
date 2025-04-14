using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_04_Loop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // #region?
            // ㄴ VS에서 특정 코드 블록을 접어서 숨기게 만들어주는 기능.
            #region 반복문 강의 
            // Ex1)
            string message = "";
            for (int i = 0; i < 10; i++)
            {
                message += "반복 횟수: " + i.ToString() + "\r\n";
            }
            textBox_result.Text = message;

            // Ex2)
            int array_size = 10;
            int[] loopCount = new int[array_size];
            for (int i = 0; i < array_size; i++)
            {
                loopCount[i] = i; // index로 i를 사용
            }
            textBox_result.Text = loopCount[loopCount.Length - 1].ToString();

            #endregion

            int count = 0;
            while (count < 100)
            {
                // 반복할 소스코드
                count++;
            }

            //bool run = true;
            //while (run)
            //{
            //    // 반복할 소스코드

            //    if ("반복을 종료하고 싶다면" == "")
            //    {
            //        run = false;
            //    }
            //}

            //while (true)
            //{
            //    if ("반복을 종료하고 싶다면" == "")
            //    {
            //        break;
            //    }
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    if (i == 5)
            //    {
            //        // i가 5일때 반복문 다시 시작 
            //        // 결과적으로 i = 6 이 실행됨
            //        continue;
            //    }
            //}
        }
    }
}
