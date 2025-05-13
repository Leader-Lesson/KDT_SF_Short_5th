using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_09_Class_UpCasting
{
    #region #1. 부모 클래스 (무기)
    public class Weapon
    {
        // 필드
        // private string name;
        protected int damage;

        // 속성
        public string Name { get; set; }

        // 생성자
        public Weapon() { }
        public Weapon(int damage)
        {
            this.damage = damage;
        }

        // 메서드
        public void Attack()
        {
            Console.WriteLine($"{Name} (으)로 공격!");
        }

        // [추가] 데미지 리턴 메서드 (화살표 함수)
        public int AttackPower() => damage;
    }
    #endregion

    #region #2. 자식 클래스
    // 자식 클래스: Sword (검)
    public class Sword : Weapon
    {
        // [추가] 공격 사거리
        int attack_range = 1;

        
        // 생성자
        public Sword() { }
        public Sword(int damage) : base(damage) { }

        // 메소드
        public void Sharp()
        {
            Console.WriteLine("검이 날카롭게 빛납니다.");
        }

        // [추가] 범위 내 공격 데미지 리턴
        public int Slash(int range)
        {
            // 공격 사거리가 공격할 거리보다 같거나 길으면 = 공격 성공
            if (this.attack_range >= range)
            {
                return this.damage;
            }
            return 0;
            // return 0; : OS(운영체제)에게 "정상적으로 잘 끝났다~" 라고 신호.
            // return -1, 1; : 문제가 있다~ 라고 신호.
        }
    }

    // 자식 클래스: Gun (총)
    public class Gun : Weapon
    {
        // [추가] 공격 범위
        int attack_range = 10;

        // [추가] 생성자
        public Gun() { }
        public Gun(int damage) : base(damage) { }

        public void Reload()
        {
            Console.WriteLine("총을 재장전 합니다.");
        }

        // [추가]
        public int Fire(int range)
        {
            if (this.attack_range >= range)
            {
                return this.damage;
            }
            return 0;
        }
    }

    // 자식 클래스: Bow (활)
    public class Bow : Weapon
    {
        public void Aim()
        {
            Console.WriteLine("활을 당겨 조준합니다.");
        }
    }
    #endregion
}
