using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_15_Delegate
{
    // 조건 델리게이트 타입 정의
    public delegate bool ProductCondition(Product p);
    public class ProductFilter
    {
        public static List<Product> Filter(List<Product> products, ProductCondition condition)
        {
            List<Product> result = new List<Product>();
            // 조건을 만족하는 제품만 따로 저장할 결과 리스트를 미리 생성해 둠
            foreach (var p in products) // 제품 리스트 전체를 하나씩 순회하며 조건 검사
            {
                if (condition(p))   
                    // 델리게이트에 담긴 조건 함수를 실행하여 
                    // 조건을 만족하는 경우에만 아래 코드 실행
                    result.Add(p);
            }
            return result;
            // 최종적으로 조건에 맞는 제품 리스트를 반환
        }
    }
}