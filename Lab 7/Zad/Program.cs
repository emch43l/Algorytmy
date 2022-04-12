using System;

namespace Zad
{
    class Program
    {
        class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
        }

        class Stack<T>
        {
            private Node<T> _head;
            public void Push(T value)
            {
                Node<T> newNode = new Node<T> { Value = value, Next = _head };
                _head = newNode;
            }

            public bool isEmpty() => _head == null;

            public T Pop()
            {
                if (isEmpty())
                    throw new Exception("stack is empty");
                T result = _head.Value;
                _head = _head.Next;
                return result;
            }
        }

        class Queue<T>
        {
            private Node<T> _head;
            private Node<T> _tail;
            public bool IsEmpty() => _head == null;
            public void Insert(T value)
            {
                Node<T> node = new Node<T> { Value = value };
                if(IsEmpty())
                {
                    _head = node;
                    _tail = _head;
                    return;
                }
                _tail.Next = node;
                _tail = node;
            }
            public T Remove()
            {
                if (IsEmpty())
                    throw new Exception("queue is empty");
                T result = _head.Value;
                _head = _head.Next;
                return result;
            }
        }

        static void Main(string[] args)
        {
            Node<string> node = new Node<string> { Value = "adam" };
            node.Next = new Node<string> { Value = "ewa" };
            node.Next.Next = new Node<string> { Value = "karol" };
            Node<string> head = node;
            while(node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            Stack<string> stack = new Stack<string>();
            stack.Push("Adam");
            stack.Push("Ewa");
            stack.Push("Karol");
            while (!stack.isEmpty())
                Console.WriteLine(stack.Pop());

            Queue<string> queue = new Queue<string>();
            queue.Insert("Adam");
            queue.Insert("Ewa");
            queue.Insert("Karol");
            while (!queue.IsEmpty())
                Console.WriteLine(queue.Remove());

        }

        
    }
}
