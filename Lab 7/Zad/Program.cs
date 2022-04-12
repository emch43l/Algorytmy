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
            // zad 3
            public Stack<T> Reverse()
            {
                Stack<T> oldStack = this;
                Stack<T> newStack = new Stack<T>();
                while(!oldStack.isEmpty())
                    newStack.Push(oldStack.Pop());
                return newStack;
            }
        }

        class Queue<T>
        {
            private Node<T> _head;
            private Node<T> _tail;
            private int _count;
            public bool IsEmpty() => _head == null;
            public void Insert(T value)
            {
                Node<T> node = new Node<T> { Value = value };
                if(IsEmpty())
                {
                    _head = node;
                    _tail = _head;
                    _count++;
                    return;
                }
                _count++;
                _tail.Next = node;
                _tail = node;
            }
            public T Remove()
            {
                if (IsEmpty())
                    throw new Exception("queue is empty");
                T result = _head.Value;
                _head = _head.Next;
                _count--;
                return result;
            }

            public T[] ToArray()
            {
                if (IsEmpty())
                    return new T[0];
                T[] array = new T[_count];
                Node<T> node = _head;
                int iterator = 0;
                while(node != null)
                {
                    array[iterator++] = node.Value;
                    // ^^^ to samo co
                    // array[iterator] = node.Value
                    // i++
                    node = node.Next;
                }

                return array;
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
            stack = stack.Reverse();
            while (!stack.isEmpty())
                Console.WriteLine(stack.Pop());

            string brackets = "((()))[](([]))(([{(())}]))";

            CheckBrackets check = new CheckBrackets(brackets);
            Console.WriteLine(check.validate());

            //Queue<string> queue = new Queue<string>();
            //queue.Insert("Adam");
            //queue.Insert("Ewa");
            //queue.Insert("Karol");
            //while (!queue.IsEmpty())
            //    Console.WriteLine(queue.Remove());

        }

        class CheckBrackets
        {
            private string _str;
            private readonly char[,] brackets = new char[,] { { '(', ')' }, { '[', ']' }, { '{', '}' } };
            private Stack<char> bracketsQ = new Stack<char>();
            public CheckBrackets(string str)
            {
                _str = str;
            }

            public bool validate()
            {
                foreach(char bracket in _str)
                {
                    for(int i = 0; i < brackets.GetLength(0); i++)
                    {
                        if (bracket == brackets[i, 1])
                            if (bracketsQ.isEmpty() || bracketsQ.Pop() != brackets[i, 0])
                                return false;
                        if (bracket == brackets[i, 0])
                            bracketsQ.Push(bracket);
                    }
                }

                if (!bracketsQ.isEmpty())
                    return false;

                return true;
            }
        }

        
    }
}
