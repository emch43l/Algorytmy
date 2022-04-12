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
            
        }
    }
}
