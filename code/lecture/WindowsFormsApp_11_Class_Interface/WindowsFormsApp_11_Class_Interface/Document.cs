using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_11_Class_Interface
{
    // #1. 인터페이스 선언
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
