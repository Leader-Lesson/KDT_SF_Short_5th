using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_11_Class_Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("== 문서 작업 프로그램 실행 ==\n");
            // Q) 다형성이란?
            // ㄴ 하나의 인터페이스로 여러 개의 서로 다른 객체를 동일하게 다루는 것.

            // 1. 클래스 타입으로 사용 (모든 기능 다 사용 가능)
            // ㄴ 다형성 적용 (x)
            Document doc = new Document();
            doc.Read();
            doc.Write();
            doc.Print();

            Console.WriteLine("\n-- 인터페이스 타입으로 각각 제어 --");

            // 2. 인터페이스 타입으로 사용 (각 기능별로 분리)
            // ㄴ 해당 인터페이스에 정의된 기능만 사용 할 수 있게 제한됨.
            // ㄴ 다형성 적용 (o)
            IReadable reader = new Document();
            IWritable writer = new Document();
            IPrintable printer = new Document();

            reader.Read();      // Read만 가능
            writer.Write();     // Write만 가능
            printer.Print();    // Print만 가능

            Console.WriteLine("\n== 작업 완료 ==");

            // [참고] 하나의 인터페이스 타입으로 다양한 객체를 만들어본다면?
            // IReadable reader1 = new Document();
            // IReadable reader2 = new PdfDocument();
            // IReadable reader3 = new Book();

            // reader1.Read();  // 일반 문서를 읽습니다.
            // reader2.Read();  // PDF 문서를 읽습니다.
            // reader3.Read();  // 책을 읽습니다.
            // IReadable이라는 하나의 타입으로
            // 서로 다른 클래스 객체를 동일하게 제어하면서, 동작은 다르게 나오는 것
            // → 이것이 바로 다형성입니다!
        }
    }
}
