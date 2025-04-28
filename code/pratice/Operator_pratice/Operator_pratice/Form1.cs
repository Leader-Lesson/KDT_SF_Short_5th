using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operator_pratice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string productName = "노트북";
            int price = 1200000;
            float discountRate = 0.15f;
            byte stock = 8;
            bool isAvailable = stock > 0;

            double discountedPrice = price * (1 - discountRate);

            textBox1.Text = isAvailable? "구매 가능: 할인 가격은 " + discountedPrice.ToString("N0") + "원입니다." : "품절되었습니다.";
            textBox2.Text = (stock >= 5) ? "여유 있음" : "소량 남음";

            textBox3.Text = "상품명: " + productName
                + ", 할인된 가격: " + discountedPrice.ToString("N0") + "원"
                + ", 재고: " + stock.ToString() + "개";

            /*
             * # 소수점 포맷 설정
             * - 포맷 조정은 '출력용' 변환이다. (계산 자체는 바뀌지 x)
             * 
             * "0"      - 자리수 채움 (0으로 채움)
             * "0.0"    - 소수점 첫째 자리까지, 없으면 0 채움
             * "0.00"   - 소수점 둘째 자리까지, 없으면 0 채움
             * "0.###"  - 소수점 세 자리까지, 있으면 표시 없으면 안 표시
             * "N2"     - 숫자, 소수 둘째 자리까지
             * "N0"     - 천 단위 구분 쉼표(,) 찍어주는 서식.
             * "P1"     - 퍼센트로 변환해서 소수 첫째 자리까지.
            */
        }   
    }
}
