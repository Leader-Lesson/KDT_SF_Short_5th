using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_15_Delegate
{
        public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // 제품 목록
            List<Product> items = new List<Product>()
            {
                new Product("노트북", 1200000, "전자기기"),
                new Product("청소기", 300000, "가전"),
                new Product("커피", 5000, "식품"),
                new Product("책상", 150000, "가구"),
                new Product("키보드", 60000, "전자기기"),
                new Product("의자", 85000, "가구")
            };
            // 제품 목록 초기화 (Product 객체들을 리스트로 생성)

            // 조건 전달
            List<Product> expensive = ProductFilter.Filter(items, p => p.Price >= 100000);
            // Product 객체 하나를 받아서, 조건을 평가하는 익명 함수
            // ProductFilter.Filter 메서드에 조건 전달 (p는 그저 매개변수)
            // 조건: 제품 가격이 10만 원 이상인 경우만 true
            // items: 전체 제품 목록

            // 람다식 (p => p.Price >= 100000)은 익명 함수이며,
            // ProductCondition 델리게이트에 자동으로 연결됨
            // ㄴ 람다식이 델리게이트로 전달된다

            Console.WriteLine("\n[100,000원 이상 제품]");
            foreach (var item in expensive)
            {
                Console.WriteLine($"- {item}");
            }

            // item은 Product 객체이며, 출력에서는 item.ToString()이 자동 호출됨
            // ㄴ C#에서는 문자열 보간($"...")이나 문자열 연결(+)을 할 때 
            //    객체를 문자열처럼 넣으면 ToString()이 자동 호출
            // (→ 우리가 Product 클래스에서 override한 ToString()이 실행됨)

            // 카테고리가 '가구'인 제품만
            List<Product> furniture = ProductFilter.Filter(items, p => p.Category == "가구");

            Console.WriteLine("\n[가구 카테고리 제품]");
            foreach (var item in furniture)
            {
                Console.WriteLine($"- {item}");
            }

        }
    }
}
