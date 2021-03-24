using System;

namespace Homework4_1
{
    class Program
    {
        public class Node<T>
        {
            public Node<T> Next
            {
                get; set;
            }
            public T data { get; set; }
            public Node(T t) {
                Next = null;
                data = t;
            }
        }
        public class GenericList<T>
        {
            private Node<T> head;
            private Node<T> tail;
            public GenericList()
            {
                head = tail = null;
            }
            public Node<T> Head
            {
                get => head;
            }
            public void Add(T t)
            {
                Node<T> n = new Node<T>(t);
                if(tail == null)
                {
                    head = tail = n;
                }
                else
                {
                    tail.Next = n;
                    tail = n;
                }
            }
            
        }
        public static int GetRandomNumber()
        {
            Random r = new Random();
            return r.Next(0, 100);
        }
        public static void ForEach<T>(GenericList<T> genericList, Action<T> action)
        {
            Node<T> node = genericList.Head;
            while (node.Next != null)
            {
                action(node.data);
                node = node.Next;
            }
            action(node.data);
        }
        static void Main(string[] args)
        {
            GenericList<int> genericList = new GenericList<int>();
            for(int i = 0; i < 10; i++)
            {
                genericList.Add(GetRandomNumber());
            }
            Program.ForEach(genericList, m => Console.Write("{0}\t", m));
            Console.WriteLine();

            int sum = 0;
            Program.ForEach(genericList, m => sum += m);
            Console.WriteLine("Sum = {0}", sum);
            int max = 0, min = 100;
            Program.ForEach(genericList, m => { if (m > max) max = m; });
            Program.ForEach(genericList, m => { if (m < min) min = m; });
            Console.WriteLine("Max = {0}, Min = {1}", max, min);
        }
    }
}
