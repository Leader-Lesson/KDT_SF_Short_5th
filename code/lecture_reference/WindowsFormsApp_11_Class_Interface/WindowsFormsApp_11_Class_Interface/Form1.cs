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
            // 1. 클래스 타입으로 사용 (모든 기능 다 사용 가능)
            Document doc = new Document();
            doc.Read();
            doc.Write();
            doc.Print();

            Console.WriteLine("\n-- 인터페이스 타입으로 각각 제어 --");

            // 2. 인터페이스 타입으로 사용 (각 기능별로 분리)
            // ㄴ 해당 인터페이스에 정의된 기능만 사용 할 수 있게 제한됨.
            IReadable reader = new Document();
            IWritable writer = new Document();
            IPrintable printer = new Document();

            reader.Read();      // Read만 가능
            writer.Write();     // Write만 가능
            printer.Print();    // Print만 가능

            Console.WriteLine("\n== 작업 완료 ==");

        }
    }
}
