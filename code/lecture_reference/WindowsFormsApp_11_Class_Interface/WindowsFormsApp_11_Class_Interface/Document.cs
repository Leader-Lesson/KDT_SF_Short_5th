using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_11_Class_Interface
{
    // #1. 인터페이스 선언
    // Why? (왜 사용하는가?)
    // ㄴ 1) 공통 기능을 강제하기 위해 (일종의 규칙, 계약) // [참고] 이 인터페이스를 상속 받았다면, 반드시 이 기능은 구현해! 라는 약속
    // ㄴ 2) 다형성을 가능하게 하기 위해     // [참고] 인터페이스는 공통된 타입으로 다룰 수 있게 해줌.
    // ㄴ 3) 유연한 구조 -> 유지보수 용이
    // ㄴ 메서드만 정의 (기능은 없음)
    public interface IReadable 
    {
        void Read();    // 문서를 읽는 기능
    }

    public interface IWritable
    {
        void Write();   // 문서를 쓰는 기능
    }

    public interface IPrintable
    {
        void Print();   // 문서를 인쇄하는 기능
    }

    // #2. 클래스 선언 - 3개의 인터페이스 "다중 상속"
    public class Document : IReadable, IWritable, IPrintable
    {
        // 모든 메서드를 반드시 public으로 구현해야 함
        // Why?
        // ㄴ 인터페이스는 외부에서 "공통적으로 접근 가능한 기능"을 정의하는 계약이기 때문.
        public void Read()
        {
            Console.WriteLine("문서를 읽고 있습니다.");
        }

        public void Write()
        {
            Console.WriteLine("문서에 내용을 쓰고 있습니다.");
        }

        public void Print()
        {
            Console.WriteLine("문서를 프린터로 출력합니다.");
        }
    }
}
