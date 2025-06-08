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

    }
}
