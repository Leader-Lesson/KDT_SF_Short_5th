using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_14_Collection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region 컬렉션
            // Why? (컬렉션을 사용하는 이유)
            // ㄴ 배열의 한계
            //      ㄴ 동적 크기 조절 불가 -> 삽입/삭제 불편
            // ㄴ 다양한 자료구조의 필요성

            /*
             * [컬렉션]
             * - 컬렉션은 "클래스"이며, 배열 처럼 여러 데이터를 묶어서 관리
             * - 자동 크기 조절 가능
             * - 삽입, 삭제, 검색 등의 기능 제공
             * - 데이터 관리의 유연성 증가
             */

            // 일반 배열 예시
            string[] fruits = new string[2];    // 배열 선언 시 크기 고정!
            fruits[0] = "사과";
            fruits[1] = "바나나";

            // 새로운 과일 추가하려면?
            //fruits[2] = "딸기"; // 오류 발생, 중간 삽입/삭제 불편

            #endregion

            #region 1. 비제네릭 컬렉션
            /*
             * 비제네릭 컬렉션
             * ㄴ 내부적으로는 object 타입으로 데이터를 저장 -> 모든 타입을 담을 수 있음.
             *      ㄴ int, string, double 등 어떤 값을 넣어도 *자동으로 object로 박싱(Boxing)*
             * ㄴ 어떤 자료형이든 추가할 수 있지만, 데이터를 꺼내어 사용할 때는 "형변환"이 필요.
             * - 옛날 방식, C# 최신 개발에서는 거의 사용하지 않음.
             * 
             * Why? (왜 사용하지 않는가?)
             * ㄴ 1) 타입 안정성 부족 - object 타입으로 저장되므로 잘못된 형변환 런타임 오류 가능성 ↑
             * ㄴ 2) 성능 저하 - 박싱(Boxing), 언박싱(UnBoxing)이 발생 -> 메모리 사용
             * ㄴ 3) 유지보수 어려움 - 요소 타입이 명확하지 않으므로 실수 잦음.
             * 
             * [용어 정리]
             * - 박싱(Boxing): 값 타입 -> 참조 타입인 object로 변환하는 과정.
             * - 언박싱(UnBoxing): 박싱된 object를 다시 원래 값 타입으로 꺼내는 과정.
             */
            #endregion

            #region #1. ArrayList
            // 배열 형태 컬렉션 - 크기 자동 조절
            Console.WriteLine("========== ArrayList ==========");

            ArrayList list = new ArrayList();
            list.Add(100); // int
            list.Add("Hello");  // string
            list.Add(3.14);     // double

            foreach (object item in list)
            {
                Console.WriteLine(item);
            }

            // 형변환 후 활용
            int num = (int)list[0]; // UnBoxing
            string str = (string)list[1];

            int result = num * 2;       // 숫자 연산
            string upper = str.ToUpper();   // 문자열 메서드 사용

            Console.WriteLine($"숫자 2배 : {result}");
            Console.WriteLine($"문자열 대문자 변환 : {upper}");

            // Ex2) Sort, Reverse
            // - 같은 타입만 있는 경우에 가능 (서로 다른 타입이 섞여있으면 오류)
            Console.WriteLine("====================");
            ArrayList numberList = new ArrayList();
            numberList.Add(30);
            numberList.Add(5);
            numberList.Add(12);

            // 정렬 전
            Console.WriteLine("========== 정렬 전 ==========");
            foreach (int n in numberList)
            {
                Console.WriteLine(n);
            }

            // 정렬 후
            numberList.Sort();
            Console.WriteLine("========== 정렬 후 ==========");
            foreach (int n in numberList)
            {
                Console.WriteLine(n);
            }

            // 역순 정렬
            numberList.Reverse();
            Console.WriteLine("========== 역순 후 ==========");
            foreach (int n in numberList)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("====================");
            #endregion

            #region #2. Stack
            /*
             * 후입선출 (LIFO, Last-In-First-Out) 방식의 컬렉션
             * ㄴ 즉, 나중에 넣은 데이터가 먼저 나오는 구조.
             */

            Console.WriteLine("\r\n========== Stack ==========");
            Stack stack = new Stack();

            // 데이터 넣기 (Push)
            stack.Push("첫 번째 데이터");
            stack.Push("두 번째 데이터");
            stack.Push("세 번째 데이터");

            // 현재 스택 상태 출력
            Console.WriteLine("\r\n========== Stack 내용 확인 ==========");
            foreach (object s in stack)
            {
                Console.WriteLine(s);
            }

            // 데이터 꺼내서 사용 (제거 X) (Peek)
            Console.WriteLine($"\n 맨 위 값(Peek): {stack.Peek()}");

            // 스택 상태 재확인
            Console.WriteLine("\r\n========== Peek 후 Stack 확인 ==========");
            foreach (object s in stack)
            {
                Console.WriteLine(s);
            }

            // 데이터 꺼내서 사용 (제거 O) (Pop)
            Console.WriteLine($"\n 맨 위 값(Pop): {stack.Pop()}");

            // 스택 상태 재확인
            Console.WriteLine("\r\n========== Pop 후 Stack 확인 ==========");
            foreach (object s in stack)
            {
                Console.WriteLine(s);
            }

            #endregion

            #region #3. Queue
            /*
             * 선입선출 (FIFO, First-In-First-Out) 방식의 컬렉션
             * ㄴ 즉, 먼저 넣은 데이터가 먼저 나오는 구조.
             */
            Console.WriteLine("\r\n========== Queue ==========");
            Queue queue = new Queue();

            // 데이터 넣기 (Enqueue)
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            Console.WriteLine("\n현재 큐 대기열:");
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }
            
            // 데이터 꺼내서 사용 (제거 X) (Peek)
            Console.WriteLine($"\n첫 번째 대기 고객: {queue.Peek()}");

            // 큐 대기열 재확인
            Console.WriteLine("\n현재 큐 대기열:");
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }

            // 데이터 꺼내서 사용 (제거 O) (Dequque)
            Console.WriteLine($"\n두 번째 대기 고객: {queue.Dequeue()}");

            // 큐 대기열 재확인
            Console.WriteLine("\n현재 큐 대기열:");
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region #4. Hashtable
            /*
             * 키(key)와 값(value) 쌍으로 데이터를 저장하는 방식의 컬렉션
             * - 키는 중복 (x)
             * - 값은 중복 (o)
             */

            Console.WriteLine("\r\n========== Hashtable ==========");
            Hashtable ht = new Hashtable();

            // 데이터 추가 (Add)
            ht.Add("name", "홍길동");
            ht.Add("age", "30");
            ht.Add("job", "개발자");

            // 데이터 출력 (조회)
            Console.WriteLine($"이름: {ht["name"]}");
            Console.WriteLine($"나이: {ht["age"]}");
            Console.WriteLine($"직업: {ht["job"]}");

            // 데이터 반복 출력
            // DictionaryEntry
            // ㄴ Hashtable의 한 요소를 나타내는 키-값 쌍 구조체.
            // ㄴ 즉, key, value 값을 따로 따로 가져올 수 있음.
            Console.WriteLine("\n전체 항목: ");
            foreach (DictionaryEntry entry in ht)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value}");
            }

            // 데이터 수정 - [] = newValue
            ht["age"] = 35;

            // 데이터 삭제 - Remove(key)
            ht.Remove("job");

            // 존재 여부 확인 - ContainsKey(key)
            if (ht.ContainsKey("name"))
            {
                Console.WriteLine($"\n ht에 'name' 키가 있습니다.");
            }

            Console.WriteLine("\n전체 항목: ");
            foreach (DictionaryEntry entry in ht)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value}");
            }
            #endregion

            #region 2. 제네릭 컬렉션
            /*
             * 제네릭 컬렉션
             * ㄴ 클래스나 메서드를 작성할 때, 내부에서 사용할 "데이터 형식"을 나중에 지정할 수 있는 구조.
             * ㄴ 일반적으로 <T>, <TKey, TValue> 형태로 사용함.
             * ㄴ 컴파일 시점에 타입이 결정되어 "형변환 없이" 안전하게 데이터 처리 가능.
             * 
             * Why?
             * ㄴ 1) 타입 안정성 향상 - 런타임 오류 ↓
             * ㄴ 2) 성능 향상 - 박싱/언박싱 (X) - 속도 ↑ 메모리 사용 ↓
             * ㄴ 3) 가독성과 유지보수 향상 - 어떤 타입의 값이 저장되는지 명확함 -> 실수 방지.
             * 
             * [용어 정리]
             * 형식 매개변수(Type Parameter): 보통 T, K, V 등으로 표현
             * ㄴ 실제 자료형은 사용 시 지정.
             * 
             * [주의]
             * - 제네릭 컬렉션은 특정 타입에만 제한되어 있으므로, 여러 타입을 저장하려면 구조체나, 클래스 등으로 묶어야 한다.
             * 
             * - 실무에서 자주 사용하는 방식 (비제네릭 컬렉션 단점 보완)
             */
            #endregion

            #region #1. List<T>
            // ㄴ 배열처럼 연속된 데이터를 저장하지만, 크기가 자동으로 조절되는 자료구조.
            // ㄴ 메서드 사용 : ArrayList 메서드와 동일.
            Console.WriteLine("\r\n========== List<T> ==========");
            // 1. 객체 생성
            List<int> numbers = new List<int>();

            // 2. 요소 추가
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);

            // 3. 요소 삽입
            numbers.Insert(1, 22);  // 1번 인덱스에 15 삽입.

            // 4. 출력
            Console.WriteLine("\n[현재 리스트 내용]");
            foreach(int n in numbers)
            {
                Console.WriteLine(n);
            }

            // 5. 요소 제거
            //numbers.Remove(20);     // 값으로 제거
            //numbers.RemoveAt(0);    // 인덱스로 제거

            // 6. 정렬 및 반전
            numbers.Sort();
            numbers.Reverse();

            Console.WriteLine("\n[현재 리스트 내용]");
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }

            // 7. 기타 메서드
            Console.WriteLine($"Count: {numbers.Count}");
            Console.WriteLine($"Contains 15? {numbers.Contains(15)}");
            Console.ReadLine();
            #endregion

            #region #2. Stack<T>
            Console.WriteLine("\r\n========== Stack<T> ==========");
            // 1. 객체 생성
            Stack<int> stack2 = new Stack<int>();

            // 2. 요소 추가 (Push)
            stack2.Push(10);
            stack2.Push(20);
            stack2.Push(30);

            Console.WriteLine("[현재 스택 상태]");
            foreach (int item in stack2)
            {
                Console.WriteLine(item);
            }

            // 3. 맨 위 요소 확인 (Peek)
            Console.WriteLine($"Peek(): {stack2.Peek()}");

            // 4. 맨 위 요소 꺼내기 (Pop)
            Console.WriteLine($"Pop(): {stack2.Pop()}");

            Console.WriteLine("[현재 스택 상태]");
            foreach (int item in stack2)
            {
                Console.WriteLine(item);
            }

            // 5. Count 확인
            Console.WriteLine($"Count: {stack2.Count}");
            #endregion

            #region #3. Queue<T>
            Console.WriteLine("\r\n========== Queue<T> ==========");

            Queue<string> queue2 = new Queue<string>();

            queue2.Enqueue("고객 1");
            queue2.Enqueue("고객 2");
            queue2.Enqueue("고객 3");

            Console.WriteLine("[현재 큐 상태]");
            foreach (string item in queue2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nPeek(): {queue2.Peek()}");

            Console.WriteLine("\n[(재확인) 큐 상태]");
            foreach (string item in queue2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nDequeue(): {queue2.Dequeue()}");

            Console.WriteLine("\n[(재확인) 큐 상태]");
            foreach (string item in queue2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Count: {queue2.Count}");
            #endregion

            #region #4. Dictionary<Tkey, Tvalue>
            // ㄴ 키(key) 값(value) 쌍으로 저장하는 컬렉션
            // ㄴ 내부적으로 해시 테이블 구조를 사용해서 검색 속도 매우 빠름.
            Console.WriteLine("\r\n========== Dictionary<Tkey, Tvalue> ==========");
            
            // 1. 객체 생성
            Dictionary<string, int> scores = new Dictionary<string, int>();

            // 2. 요소 추가
            scores.Add("홍길동", 95);
            scores.Add("흥부", 75);
            scores["이영희"] = 78;     // Add 없이도 이렇게 추가 가능

            // 3. 전체 출력
            Console.WriteLine("[학생 점수 목록]");
            //foreach (var item in scores)    // var: 타입 자동 추론 (편의성)
            //{
            //    Console.WriteLine($"{item.Key}: {item.Value}");
            //}
            foreach (KeyValuePair<string, int> item in scores)
            {
                //Console.WriteLine($"{item.Key}: {item.Value}");
                Console.WriteLine(item);
            }

            // 4. 특정 값 가져오기
            Console.WriteLine($"홍길동 점수: {scores["홍길동"]}");

            // 5. 키 존재 여부 확인
            if (scores.ContainsKey("이영희"))
            {
                Console.WriteLine("이영희의 점수가 존재합니다.");
            }

            // 6. 안전하게 가져오기 (TryGetValue)
            // - 홍길동에 해당하는 값 안전하게 가져오기 - 없으면 false 반환.
            if (scores.TryGetValue("홍길동", out int value))
            {
                Console.WriteLine($"홍길동의 점수: {value}");
            }

            // 7. 요소 제거
            scores.Remove("홍길동");
            Console.WriteLine($"총 인원: {scores.Count}");

            foreach (KeyValuePair<string, int> item in scores)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            #endregion

            #region 3. 제네릭 컬렉션 & 클래스
            // 인스턴스를 만들거나 메서드를 호출 할 때 실제 타입으로 결정됨.

            Console.WriteLine("\r\n========== List<T> ==========");
            MyList<string> names = new MyList<string>();
            names.AddItem("짱구");
            names.AddItem("유리");
            names.ShowAll();

            Console.WriteLine("\r\n========== Stack<T> ==========");
            MyStack<int> history = new MyStack<int>();
            history.PushItem(1);
            history.PushItem(2);
            history.PushItem(3);
            history.ShowAll();
            Console.WriteLine($"Peek: {history.PeekItem()}");
            history.ShowAll();
            Console.WriteLine($"Pop: {history.PopItem()}");
            history.ShowAll();

            Console.WriteLine("\r\n========== Queue<T> ==========");
            MyQueue<string> waitingLine = new MyQueue<string>();
            waitingLine.EnqueueItem("고객 1");
            waitingLine.EnqueueItem("고객 2");
            waitingLine.EnqueueItem("고객 3");
            waitingLine.ShowAll();

            Console.WriteLine($"Peek: {waitingLine.PeekItem()}");
            waitingLine.ShowAll();

            Console.WriteLine($"Dequeue: {waitingLine.DequeueItem()}");
            waitingLine.ShowAll();


            Console.WriteLine("\r\n========== Dictionary<Tkey, Tvalue> ==========");
            MyDictionary<string, int> scores2 = new MyDictionary<string, int>();
            scores2.AddItem("철수", 90);
            scores2.AddItem("영희", 88);
            scores2.AddItem("민수", 95);

            scores2.ShowAll();

            Console.WriteLine($"영희 점수: {scores2.GetItem("영희")}");
            if (scores2.TryGetItem("민수", out int score2))
            {
                Console.WriteLine($"민수의 점수: {score2}");
            }

            if (scores2.ContainsKey("철수"))
            {
                Console.WriteLine("철수가 있습니다.");
            }

            scores2.RemoveItem("영희");

            Console.WriteLine($"총 인원: {scores2.Count}");

            scores2.ShowAll();
            #endregion
        }
    }
}
