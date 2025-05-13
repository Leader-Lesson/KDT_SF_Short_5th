using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_11_Class_Interface
{
    /*
     * #1. 인터페이스 선언
     * Why? (왜 사용하는가?)
     * ㄴ 1) 공통 기능을 강제하기 위해 (일종의 규칙, 계약)
     * ㄴ 2) 다형성을 가능하게 하기 위해
     * ㄴ 3) 유연한 구조 -> 유지보수 용이
     * ㄴ 메서드만 정의 (기능은 없음)
     * ㄴ 인터페이스는 클래스가 상속받는 것이 아니라, "구현" 하는 것이기 때문에
     *    처음부터 해당 메서드를 직접 정의하는 것.
     *    ==> override 키워드 사용하지 않음!
     */
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
    // 1. Document 클래스
    public class Document : IReadable, IWritable, IPrintable
    {
        // 모든 메서드를 반드시 public으로 구현해야 함.
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

    // 2. PPT Document 클래스
    public class PptDocument : IReadable
    {
        public void Read()
        {
            Console.WriteLine("PPT 문서를 읽고 있습니다.");
        }
    }

    // 3. PDF Document 클래스
    public class PdfDocument : IReadable
    {
        public void Read()
        {
            Console.WriteLine("PDF 문서를 읽고 있습니다.");
        }
    }
}
