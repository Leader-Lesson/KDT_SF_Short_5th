using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #0. 네임스페이스 설정
namespace WindowsFormsApp_07_Class
{
    // #1. 클래스 선언
    // - 객체를 만들기 위한 설계도(틀)
    internal class Car
    {
        #region 2. 필드

        // --- #2-1. 일반 필드 선언 (=객체마다 다름)
        private int speed;          // 자동차 속도
        private string modelName;   // 자동차 모델명
        private int year;           // 자동차 생산년도

        // --- #2-2. readonly 필드
        private readonly string manufacturer = "Hyundai"; // 제조사

        // --- #2-3. static 필드
        private static int totalCars = 0;
        #endregion

        #region 3. 속성

        // --- #3-1. 기본 속성 형태 (유효성 검사 포함 가능)
        public int Speed
        {
            get { return speed; }
            set
            {
                if (value < 0) speed = 0;    // 음수 방지
                else speed = value;
            }
        }

        // --- #3-2. 자동 구현 속성 
        // - 특별한 조건 검사 없이 단순히 값을 저장하고 꺼낼 때 사용
        public string Color { get; set; }


        // --- #3-3. 읽기 전용 속성
        // - 외부에서는 읽기만 가능. 내부에서만 값 설정.
        public string ModelName
        {
            get { return modelName; }
            private set { modelName = value; }
        }

        // --- #3-4. 계산 결과 제공 속성 
        public bool IsNewCar    // 신차 판단
        {
            get { return year >= 2023; }
        }

        // --- #3-5. 표현 속성 (출력용) 
        // - 필드 값을 조합해서 보기 좋은 문자열 형태로 가공해서 제공하는 속성.
        public string Summary   // 읽기 쉬운 문장 형태로 만들어서 반환.
        {
            get
            {
                return $"{year}년식 {manufacturer} {ModelName} - {Color} - {Speed}km/h";
            }
        }
        #endregion

        #region 4. 생성자

        // --- #4-1. 기본 생성자 (없으면 자동 제공)
        public Car()
        {
            ModelName = "이름없는 차";
            Speed = 0;
            Color = "회색";
            year = 2000;

            totalCars++; // 자동차 총 생산량 증가

            Console.WriteLine("기본 생성자로 Car 객체가 만들어졌습니다.");
        }

        // --- #4-2 매개변수 있는 생성자
        public Car(string model, int speed, string color, int year)
        {
            ModelName = model;
            Speed = speed;
            Color = color;
            this.year = year;

            totalCars++;

            Console.WriteLine($"{model} 객체 생성 완료!");
        }
        #endregion

        #region 5. 소멸자
        ~Car()
        {
            Console.WriteLine($"{ModelName} 객체가 메모리에서 삭제됩니다.");
        }
        #endregion

        #region 6. 메서드
        // --- #6-1. 속도 증가
        public void Accelerate(int amount)
        {
            Speed += amount;
            Console.WriteLine($"{ModelName}의 속도가 {Speed}km/h로 증가했습니다.");
        }

        // --- #6-2. 속도 감소
        public void Brake(int amount)
        {
            Speed -= amount;
            if (Speed < 0) Speed = 0;
            Console.WriteLine($"{ModelName}의 속도가 {Speed}km/h로 감소했습니다.");
        }

        // --- #6-3. 자동차 정보 출력
        public void PrintInfo()
        {
            Console.WriteLine($"=== 차량 정보 ===");
            Console.WriteLine($"제조사: {manufacturer}");
            Console.WriteLine($"모델명: {ModelName}");
            Console.WriteLine($"색상: {Color}");
            Console.WriteLine($"속도: {Speed} km/h");
            Console.WriteLine($"생산년도: {year}");
            Console.WriteLine($"신차 여부: {(IsNewCar ? "신차!!" : "구형 차량")}");
            Console.WriteLine($"요약: {Summary}");
            Console.WriteLine($"총 생산 차량 수: {totalCars}대");
        }
        #endregion

        #region 7. static 메서드 (클래스 메서드)
        public static void ShowTotalCars()
        {
            Console.WriteLine($"총 생산된 자동차 수: {totalCars}대");
        }
        #endregion
    }

}
