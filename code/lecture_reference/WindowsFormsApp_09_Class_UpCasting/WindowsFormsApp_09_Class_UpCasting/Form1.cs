using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_09_Class_UpCasting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // #1. 자식 객체 생성
            Sword sword = new Sword();
            sword.Name = "롱소드";
            sword.Attack();     // 부모 메소드 호출 (사용 가능)
            sword.Sharp();      // 자식 고유 메서드 호출

            Console.WriteLine("===========================");

            // *업캐스팅: 자식(Sword)을 부모(Weapon) 타입으로 참조.
        }
    }
}
