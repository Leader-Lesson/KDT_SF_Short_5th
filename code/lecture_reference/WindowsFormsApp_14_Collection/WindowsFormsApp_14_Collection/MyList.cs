using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_14_Collection
{
    // 제네릭에서 <T>는 **형식 매개변수(Type Parameter)**라고 부르며,
    // ㄴ <T>: 아직 정해지지 않은 타입.
    // ㄴ 클래스나 메서드를 선언할 때 "어떤 타입을 쓸지 나중에 지정하겠다"는 뜻으로 사용.
    // 즉, 어떤 타입이든 지정 가능한 자리

    // #1. List<T>
    public class MyList<T>
    {
        private List<T> myList = new List<T>();

        public void AddItem(T item)
        {
            myList.Add(item);
        }

        public void ShowAll()
        {
            foreach (T item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }

    // #2. Stack<T>
    public class MyStack<T>
    {
        private Stack<T> myStack = new Stack<T>();

        public void PushItem(T item)
        {
            myStack.Push(item);
        }

        public T PopItem()
        {
            return myStack.Pop();
        }

        public T PeekItem()
        {
            return myStack.Peek();
        }
    }

    // #3. Queue<T>
    public class MyQueue<T>
    {
        private Queue<T> myQueue = new Queue<T>();

        public void EnqueueItem(T item) // 외부에서 전달 받는 값의 타입도 T
        {
            myQueue.Enqueue(item);
        }

        public T DequeueItem()  // 반환 타입 T: 꺼내는 값도 T 타입.
        {
            return myQueue.Dequeue();
        }

        public T PeekItem()
        {
            return myQueue.Peek();
        }
    }

    // #4. Dicitonary<TKey, TValue>
    public class MyDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();

        public void AddItem(TKey key, TValue value)
        {
            dict[key] = value;  // [] 인덱서로 바로 접근 가능
            // dict.Add(key, value);
            
        }

        // 2. 키로 값 가져오기
        public TValue GetItem(TKey key)
        {
            return dict[key];
        }

        // 3. 안전하게 값 가져오기 (TryGetValue 사용)
        public bool TryGetItem(TKey key, out TValue value)
        {
            return dict.TryGetValue(key, out value);
        }

        // 4. 특정 키가 존재하는지 확인
        public bool ContainsKey(TKey key)
        {
            return dict.ContainsKey(key);
        }

       
        // 5. 항목 삭제
        public bool RemoveItem(TKey key)
        {
            return dict.Remove(key);
        }
        // 6. 전체 출력
        public void ShowAll()
        {
            //foreach (KeyValuePair<TKey, TValue> pair in dict)
            foreach (var pair in dict) // var : 타입 자동 추론 (편의성)

            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        // 7. count 출력
        public int Count => dict.Count;
    }
}
