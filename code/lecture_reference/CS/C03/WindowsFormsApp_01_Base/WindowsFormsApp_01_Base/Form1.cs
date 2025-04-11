// # 기본 구조 파악.

// using 키워드는 "네임스페이스"를 가져온다는 의미.
// ㄴ 네임스페이스(namespace)란?
//    - 여러 클래스들을 논리적으로 묶은 공간. (폴더 처럼 그룹지어 놓은 개념!)
using System;
// 가장 기본적인 .NET 네임스페이스로, (Consle, Math, 등 자주 쓰이는 클래스들이 포함되어 있음.)
using System.Collections.Generic;
// *컬렉션* (여러 데이터를 담는 구조)과 관련된 기능들을 제공하는 네임스페이스
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
// LINQ를 사용하기 위한 네임스페이스
// - 리스트나 배열에서 필터링, 정렬등을 쉽게 할 수 있게 도와주는 기능들
using System.Text;
// 문자열과 관련된 기능을 제공하는 네임스페이스
using System.Threading.Tasks;
// *비동기 처리*와 관련된 기능을 제공하는 네임스페이스
using System.Windows.Forms;

namespace WindowsFormsAppBase // 프로젝트 이름.
{
    public partial class Form1 : Form
    // Form1 이라는 이름의 클래스, Form 클래스를 상속받음.
    // ㄴ .NET에서 제공하는 기본 윈도우 창인 Form 클래스를 상속받아서, 윈도우 창의 기본 동작과 속성을 물려받음.
    // ㄴ partial : 이 클래스는 코드가 여러 파일로 나눠져 있음을 의미.
    {
        public Form1()
        // Form1 클래스의 생성자.
        {
            InitializeComponent();
            // 폼에 포함된 UI 요소들을 초기화하는 메서드 호출.
            // ㄴ 버튼, 텍스트박스 등 디자인 도구에서 만든 컨트롤들을 실제로 생성하고 속성 설정하는 코드들이 있음.
            // ㄴ 폼이 실행될 때 꼭 호출되어야 윈도우 폼이 제대로 보임.
        }
    }
}



//namespace Practice01 
//{
//    internal class Program // 클래스 이름.
//    // ㄴ internal : 접근 제한자로 , 같은 프로젝트 안에서만 접근 가능하게 만든다는 뜻!
//    {
//        static void Main(string[] args)
//        // 프로그램의 "시작 지점(Entry Point)"
//        // C# 콘솔 프로그램은 실행 시 Main 메서드부터 실행함.
//        // static : 객체를 만들지 않고도 실행할 수 있도록 함.
//        // void : 반환값이 없다는 뜻.
//        // string[] args : 외부에서 입력된 인자값을 배열로 받을 수 있게 해준다.

//        {
//            // 우리가 작성해야 할 실행 코드를 입력하는 곳.
//            // Main 메서드의 본문

//            Console.WriteLine("글자 찍기");
//            // Ctrl 키 + Shift키 + B키 ==> 빌드
//            // Ctrl 키 + F5 키==> 실행
//        }
//    }
//}
