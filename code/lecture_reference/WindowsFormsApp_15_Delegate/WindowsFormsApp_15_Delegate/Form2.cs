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
            // 초기화 리스트 문법 (컬렉션 초기화)
            // 리스트 등 컬렉션을 객체를 직접 생성하면서 내부에 값을 동시에 넣는 방식입니다.

            // - 제네릭컬렉션 : 클래스
            // - 클래스면? -> 참조 형식 -> 힙 메모리 영역에 저장
            // 리스트 안에는 [0], [1] 등 각 인덱스마다 주소값(참조)
            // 각 주소는 실제 Product 객체가 저장된 힙 메모리의 위치를 가리킵니다
            /*
            [ items ]
            ┌────────────┬────────────┬────────────┬────────────┬────────────┬────────────┐
            │ [0]        │ [1]        │ [2]        │ [3]        │ [4]        │ [5]        │
            │ 참조 → 📦  │ 참조 → 📦  │ 참조 → 📦  │ 참조 → 📦  │ 참조 → 📦  │ 참조 → 📦    │
            │ (노트북)    │ (청소기)   │ (커피)     │ (책상)     │ (키보드)   │ (의자)     │
            └────────────┴────────────┴────────────┴────────────┴────────────┴────────────┘
            */

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
