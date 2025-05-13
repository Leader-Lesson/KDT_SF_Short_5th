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
            sword.Attack();     // 부모 메소드 호출 (사용 O)
            sword.Sharp();      // 자식 고유 메서드 호출

            Console.WriteLine("======================");

            // #2. 업캐스팅: "자식(Sword)" 클래스를 "부모(Weapon)" 클래스 타입으로 참조.
            // Why?
            // ㄴ 다형성을 통해 여러 자식 객체를 부모 타입 하나로 통합하여 유연하고
            // ㄴ 재사용 가능한 코드로 작성하기 위해.
            // - 자식 클래스의 고유 기능은 숨겨지고, 부모 클래스의 메서드만 사용할 수 있다.

            // #3. 업캐스팅 방식 3가지
            // 1) 묵시적 업캐스팅 (중간 변수 활용)
            //Sword sword = new Sword();
            Weapon weapon1 = sword;
            weapon1.Attack();   // 부모 메서드 호출
            //weapon1.Sharp();  // 자식 고유 메서드 호출 - X 에러!

            // 2) 다이렉트(=묵시적) 업캐스팅 (바로 대입) - 가장 많이 사용!
            Weapon weapon2 = new Gun();
            weapon2.Name = "AK-47";
            weapon2.Attack();   // 부모 메서드 호출
            //weapon2.Reload(); // 자식 고유 메서드 호출 - X 에러!

            // 3) 명시적 업캐스팅 (형변환 기호 사용) - 잘 안씀.
            Weapon weapon3 = (Weapon)new Bow();
            weapon3.Name = "강철 활";
            weapon3.Attack();
            //weapon3.Aim();

            Console.ReadLine();
            Console.WriteLine("======================");

            // #4. 추가 내용 적용

            // 검 생성
            Sword sword2 = new Sword(30); // damage = 30
            sword2.Name = "롱소드";
            sword2.Attack();
            Console.WriteLine($"검 공격 데미지: {sword2.Slash(1)}");
            Console.WriteLine("======================");

            // 업캐스팅
            Weapon weapon4 = sword2; // Sword -> Weapon 업캐스팅
            weapon4.Attack();   // 부모 메서드 호출
            //weapon4.Slash(1);

            // "다운캐스팅" 해서 다시 사용 가능
            // ㄴ 권장하지 않음!
            // ㄴ 다운캐스팅은 실제 타입을 정확히 알고 있을 때는 안전!
            // ㄴ 실행 중 타입이 맞지 않으면 예외(오류)가 발생하기 때문에,
            // ㄴ 안전성이 떨어지며 유지보수와 확장성에도 불리함.

            Console.WriteLine($"검 공격 데미지: {((Sword)weapon4).Slash(1)}");
            Console.WriteLine("======================");

            // 인스턴스를 덮어 씌우는 것으로 자식 클래스를 변경 가능.
            weapon4 = new Gun(100); // 실제 객체는 Gun
            weapon4.Name = "기본 활";
            weapon4.Attack();
            Console.WriteLine($"활 공격 데미지: {((Gun)weapon4).Fire(10)}");

        }
    }
}
