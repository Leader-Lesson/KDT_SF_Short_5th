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

            // 일반 배열 예시
            string[] fruits = new string[2];    // 배열 선언 시 크기 고정!
            fruits[0] = "사과";
            fruits[1] = "바나나";

            // 새로운 과일 추가하려면?
            //fruits[2] = "딸기";   // 오류 발생, 배열 크기 고정 - 중간 삽입/삭제 불편
            #endregion

            #region 1. 비제네릭 컬렉션
            #endregion

            #region #1. ArrayList
            // 배열 형태 컬렉션 - 크기 자동 조절


            Console.WriteLine("====== ArrayList ======");
            // Ex1)
            ArrayList list = new ArrayList();

            list.Add(100);      // int
            list.Add("Hello");  // string
            list.Add(3.14);     // double

            foreach (object item in list)
            {
                Console.WriteLine(item);
            }

            // [추가] Ex2) Sort, Reverse
            // - 같은 타입만 있는 경우에 가능 (서로 다른 타입 섞여 있다면 예외 발생)
            ArrayList numberList = new ArrayList();
            numberList.Add(30);
            numberList.Add(5);
            numberList.Add(12);

            // 정렬 전 
            Console.WriteLine("======== 정렬 전 ========");
            foreach (int n in numberList)
            {
                Console.WriteLine(n);
            }

            // 정렬 후
            numberList.Sort();
            Console.WriteLine("======== 정렬 후 ========");
            foreach (int n in numberList)
            {
                Console.WriteLine(n);
            }

            // 역순 정렬
            numberList.Reverse();
            Console.WriteLine("======== 역순 후 ========");
            foreach (int n in numberList)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("=======================");
            // 형변환 후 활용
            int num = (int)list[0]; // 꺼내서 사용시 원래 타입으로 명시적 형변환
            string str = (string)list[1];

            int result = num * 2;           // 숫자 연산
            string upper = str.ToUpper();   // 문자열 메서드 사용

            Console.WriteLine($"숫자 두 배: {result}");
            Console.WriteLine($"문자열 대문자 변환: {upper}");

            #endregion

            #region #2. Stack

            Console.WriteLine("\n====== Stack ======");
            Stack stack = new Stack();

            // 데이터 넣기 (Push)
            stack.Push("첫 번째 데이터");
            stack.Push("두 번째 데이터");
            stack.Push("세 번째 데이터");

            // 현재 스택 상태 출력
            Console.WriteLine("====== 스택 내용 확인 ======");
            foreach (object s in stack)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("========================");
            // 데이터 꺼내서 사용 (제거 X) (Peek)
            Console.WriteLine($"\n맨 위 값(Peek): {stack.Peek()}");

            // 데이터 꺼내서 사용 (제거 O) (Pop)
            Console.WriteLine($"\n꺼낸 값(Pop): {stack.Pop()}");

            // 스택 상태 재확인
            Console.WriteLine("====== Pop 후 남은 내용 ======");
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }

            // 데이터 꺼내서 사용 (제거 O) (Pop)
            Console.WriteLine($"\n꺼낸 값(Pop): {stack.Pop()}");
            // 스택 상태 재확인
            Console.WriteLine("====== Pop 후 남은 내용 ======");
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("========================");
            Console.ReadLine();
            #endregion

            #region #3. Queue

            Console.WriteLine("\n====== Queue ======");
            Queue queue = new Queue();

            // 데이터 넣기 (Enquque)
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            Console.WriteLine("현재 큐 대기열:");
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }
            // 데이터 꺼내서 사용 (제거 X) (Peek)
            Console.WriteLine($"\n첫 번째 대기 고객: {queue.Peek()}");

            // 데이터 꺼내서 사용 (제거 O) (Dequeue)
            Console.WriteLine($"\n호출된 고객: {queue.Dequeue()}");

            // ▶ 남은 대기열
            Console.WriteLine("\n[남은 대기열] ");
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }

            // [참고] 데이터 꺼내서 사용하려면 형변환 해줘야함.
            Queue q = new Queue();

            q.Enqueue(10);
            q.Enqueue("hello");

            int num2 = (int)q.Dequeue();      // 10
            string str2 = (string)q.Dequeue(); // "hello"

            #endregion

            #region #4. Hashtable

            Console.WriteLine("\n====== Hashtable ======");
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
            Console.WriteLine("\n전체 항목:");
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
                Console.WriteLine($"\n ht에는 'name' 키가 있습니다.");
            }
            #endregion


            #region 2. 제네릭 컬렉션
            #endregion

            #region #1. List<T>
            // ㄴ 배열처럼 연속된 데이터를 저장하지만, 크기가 자동으로 조절되는 자료구조.

            Console.WriteLine("\n====== List<T> ======");
            // 1. List<int> 생성
            List<int> numbers = new List<int>();

            // 2. 요소 추가
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);

            // 3. 요소 삽입
            numbers.Insert(1, 15); // 1번 인덱스에 15 삽입

            // 4. 출력
            Console.WriteLine("[현재 리스트 내용]");
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }

            // 5. 요소 제거
            numbers.Remove(20);       // 값으로 제거
            numbers.RemoveAt(0);      // 인덱스로 제거

            // 6. 정렬 및 반전
            numbers.Sort();           // 오름차순 정렬
            numbers.Reverse();        // 순서 뒤집기

            Console.WriteLine("[최종 리스트 내용]");
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

            Console.WriteLine("\n====== Stack<T> ======");
            // 1. Stack<int> 생성
            Stack<int> stack2 = new Stack<int>();

            // 2. 요소 추가 (Push)
            stack2.Push(10);
            stack2.Push(20);
            stack2.Push(30);

            Console.WriteLine("[현재 스택 상태]");
            foreach (int item in stack2)
            {
                Console.WriteLine(item);  // 출력: 30 → 20 → 10 (후입선출 순서)
            }

            // 3. 맨 위 요소 확인 (Peek)
            Console.WriteLine($"Peek(): {stack2.Peek()}");  // 30

            // 4. 맨 위 요소 꺼내기 (Pop)
            Console.WriteLine($"Pop(): {stack2.Pop()}");    // 30 꺼내짐

            // 5. 상태 다시 확인
            Console.WriteLine("[Pop 후 스택 상태]");
            foreach (int item in stack2)
            {
                Console.WriteLine(item);  // 출력: 20 → 10
            }

            // 6. Count 확인
            Console.WriteLine($"Count: {stack2.Count}");    // 2
            #endregion

            #region #3. Queue<T>

            Console.WriteLine("\n====== Queue<T> ======");
            // 1. Queue<string> 생성
            Queue<string> queue2 = new Queue<string>();

            // 2. 요소 추가 (Enqueue)
            queue2.Enqueue("고객1");
            queue2.Enqueue("고객2");
            queue2.Enqueue("고객3");

            Console.WriteLine("[현재 큐 상태]");
            foreach (string name in queue2)
            {
                Console.WriteLine(name);  // 출력: 고객1 → 고객2 → 고객3
            }

            // 3. 맨 앞 요소 확인 (Peek)
            Console.WriteLine($"Peek(): {queue2.Peek()}");  // 고객1

            // 4. 맨 앞 요소 꺼내기 (Dequeue)
            Console.WriteLine($"Dequeue(): {queue2.Dequeue()}");  // 고객1 꺼냄

            // 5. 다시 큐 출력
            Console.WriteLine("[Dequeue 후 큐 상태]");
            foreach (string name in queue2)
            {
                Console.WriteLine(name);  // 출력: 고객2 → 고객3
            }

            // 6. 개수 확인
            Console.WriteLine($"Count: {queue2.Count}");     // 2

            #endregion

            #region #4. Dictionary<TKey, TValue>


            Console.WriteLine("\n====== Dictionary<TKey, TValue> ======");

            // 1. Dictionary 생성
            Dictionary<string, int> scores = new Dictionary<string, int>();

            // 2. 요소 추가
            scores.Add("홍길동", 95);
            scores.Add("흥부", 87);
            scores["이영희"] = 78;   // Add 없이도 이렇게 추가 가능

            // 3. 전체 출력
            Console.WriteLine("[학생 점수 목록]");
            foreach (KeyValuePair<string, int> entry in scores)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            // 4. 특정 값 가져오기
            Console.WriteLine($"김철수 점수: {scores["김철수"]}");

            // 5. 키 존재 여부 확인
            if (scores.ContainsKey("이영희"))
            {
                Console.WriteLine("이영희의 점수가 존재합니다.");
            }

            // 6. 안전하게 가져오기 (TryGetValue)
            // - 홍길동에 해당하는 값 안전하게 가져오기 - 없으면 false 반환
            if (scores.TryGetValue("홍길동", out int value))
            {
                Console.WriteLine($"홍길동의 점수: {value}");
            }

            // 7. 요소 제거
            scores.Remove("김철수");
            Console.WriteLine($"총 인원: {scores.Count}");

            Console.WriteLine("=======================");
            Console.ReadLine();
            #endregion

            #region 3. 제네릭 컬렉션 & 클래스

            // 인스턴스를 만들거나 메서드를 호출할 때 실제 타입으로 결정됨
            //  T를 string로 사용하겠다는 뜻
            MyList<string> names = new MyList<string>();
            names.AddItem("짱구");
            names.AddItem("유리");
            names.ShowAll();

            Console.WriteLine("=======================");

            MyStack<int> history = new MyStack<int>();
            history.PushItem(1);
            history.PushItem(2);
            Console.WriteLine($"Peek: {history.PeekItem()}");
            Console.WriteLine($"Pop: {history.PopItem()}");

            Console.WriteLine("=======================");

            MyQueue<string> waitingLine = new MyQueue<string>();
            waitingLine.EnqueueItem("고객1");
            waitingLine.EnqueueItem("고객2");
            Console.WriteLine($"Peek: {waitingLine.PeekItem()}");
            Console.WriteLine($"Dequeue: {waitingLine.DequeueItem()}");

            Console.WriteLine("=======================");

            MyDictionary<string, int> scores2 = new MyDictionary<string, int>();
            scores2.AddItem("철수", 90);
            scores2.AddItem("영희", 95);
            scores2.AddItem("민수", 88);

            scores2.ShowAll();  // 전체 출력

            Console.WriteLine($"영희의 점수: {scores2.GetItem("영희")}");

            if (scores2.TryGetItem("민수", out int score2)) // 안전하게 값 가져오기
            {
                Console.WriteLine($"민수의 점수: {score2}");
            }

            if (scores2.ContainsKey("철수"))
            {
                Console.WriteLine("철수가 있습니다.");
            }

            scores2.RemoveItem("영희");

            Console.WriteLine($"총 인원: {scores2.Count}");
            #endregion
        }
    }
}
