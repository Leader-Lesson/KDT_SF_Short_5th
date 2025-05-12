using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_08_Class_Inheritance
{
    // #1. 부모 클래스
    internal class Shape
    {
        // 공통으로 처리할 것
        // private string name;

        public string Name { get; set; }
        // 컴파일러가 내부적으로 이렇게 처리함 (실제로 보이진 않음)
        /*
        private string _name; // 자동 필드 생성

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        */

        public void PrintName()
        {
            Console.WriteLine($"이 도형은 {Name} 입니다.");
        }
    }

    // #2. 자식 클래스 : 사각형
    internal class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        // 넓이 구하는 메소드 작성 후 값 반환
        public double GetArea()
        {
            return Width * Height;
        }
    }

    // #3. 자식 클래스 : 삼각형
    internal class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public double GetArea()
        {
            return (BaseLength * Height) / 2;
        }
    }

    // #4. 자식 클래스 : 원
    internal class Circle : Shape
    {
        public double Radius { get; set; }
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
