using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_15_Delegate
{
    public class Product
    {
        public string Name { get; set; }    // 제품명
        public int Price { get; set; }      // 제품 가격
        public string Category { get; set; }    // 제품 품목

        public Product(string name, int price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
        public override string ToString()
        {
            return $"{Name} / {Price}원 / {Category}";
        }

        /*
         * ToString()은 System.Object 클래스에서 제공하는 기본 메서드.
         * C#의 모든 클래스는 Object를 자동으로 상속받기 때문에,
         * 별도로 상속을 명시하지 않아도 ToString() 같은 메서드를 사용할 수 있다.
         * 
         * 기본 ToString()은 클래스 이름만 반환 하므로,
         * 우리가 원하는 형태로 보이게 하려면 반드시 override를 해줘야 한다.
         */
    }
}
