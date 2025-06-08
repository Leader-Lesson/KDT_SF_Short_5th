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

            // #2. 업캐스팅: 자식(Sword)을 부모(Weapon) 타입으로 참조.

            // #3. 업캐스팅 방식 3가지
            // 1) 묵시적 업캐스팅 (중간 변수 활용) 
            Weapon weapon1 = sword;
            weapon1.Attack(); // 부모 메서드만 사용 가능
            //weapon1.Sharp(); // ❌ 에러! 부모에는 Sharp()가 없음

            // 2) 다이렉트(=묵시적) 업캐스팅 (바로 대입) - 가장 많이 사용! 
            Weapon weapon2 = new Gun();
            weapon2.Name = "AK-47";
            weapon2.Attack();

            // 3) 명시적 업캐스팅 (형변환 기호 사용) - 잘 안씀.
            Weapon weapon3 = (Weapon)new Bow();
            weapon3.Name = "강철 활";
            weapon3.Attack();

            Console.ReadLine();
            Console.WriteLine("===========================");
            // #4. 추가 내용 적용

            // 검 생성
            Sword sword2 = new Sword(30); // damage = 30
            sword2.Name = "롱소드";
            sword2.Attack();
            Console.WriteLine($"검 공격 데미지: {sword.Slash(1)}"); // 자식 메서드 호출
            Console.WriteLine("===========================");
            // 업캐스팅
            Weapon weapon4 = sword2;    // Sword -> Weapon 업캐스팅
            weapon4.Attack();           // 부모 메서드 호출 가능 (o)
            //weapon4.Slash(1);           // 자식 메서드 사용 불가 (x)

            // "다운캐스팅" 해서 다시 사용 가능
            Console.WriteLine($"검 공격 데미지: {((Sword)weapon4).Slash(1)}"); // 자식 메서드 호출
            Console.WriteLine("===========================");

            // 인스턴스를 덮어 씌우는 것으로 자식 클래스를 변경 가능.
            weapon4 = new Gun(100); // 실제 객체는 Gun
            weapon4.Name = "강철 활";
            weapon4.Attack();
            Console.WriteLine($"활 공격 데미지: {((Gun)weapon4).Fire(10)}");

            
        }
    }
}
