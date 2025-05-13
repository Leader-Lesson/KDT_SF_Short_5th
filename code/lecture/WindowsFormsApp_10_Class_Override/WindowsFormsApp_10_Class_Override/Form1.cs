using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_10_Class_Override
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("==== 오버로드 예시 ====");
            Beverage basic = new Beverage();
            basic.Order();
            basic.Order("콜드브루");
            basic.Order("콜드브루", "Tall");

            Console.WriteLine("==== 오버라이드 예시 ====");
            Beverage americano = new Americano();   // 업캐스팅
            // [참고]
            // americano 변수는 부모 타입인 Beverage로 선언되어 있지만,
            // 실제로는 자식 객체인 Americano를 가리키고 있음.
            americano.Prepare();    // 오버라이드된 메서드 호출

            Console.WriteLine("==== sealed 예시 ====");
            Beverage latte = new Latte();
            latte.Prepare();        // 더 이상 오버라이드 불가능한 메서드

            // ColdBrew 메서드는 호출 할 수 없음.
            Beverage coldbrew = new ColdBrew();
            coldbrew.Prepare();
            // ㄴ 호출 됨!
            // ㄴ 아무것도 재정의 하지 않았기 때문에 가장 가까운 조상인 Latte 메서드가 실행.
            // ㄴ sealed는 override를 못하게 할 뿐, 호출은 가능!

            Beverage coldbrew2 = new ColdBrew2();
            coldbrew2.Prepare();
        }
    }
}
