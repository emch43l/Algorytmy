using System;
using System.Collections;

namespace Zad
{
    class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
    record Student(string Name, int Ects);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = { 4, 7, 1, 6, 8, 1, 9, 2 };
            Array.Sort(arr);
            int index = Array.BinarySearch(arr, 9);
            Console.WriteLine(index);
            Console.WriteLine(String.Join(',', arr));
            Student[] students =
            {
                new Student("Ewa",34),
                new Student("Karol",44),
                new Student("Adam",3),
                new Student("Robert",74),
                new Student("Ola",38),
            };

            Array.Sort(students, (a, b) => {
                return a.Ects.CompareTo(b.Ects);
            });


            // nie przyjume delegatów
            int std = Array.BinarySearch(students, new Student("Ewa", 34), new StudentComparer());
            Console.WriteLine(std);
            Console.WriteLine(students[std]);

            TreeNode<int> root = new TreeNode<int>() { Value = 16 };
            root.Left = new TreeNode<int>() { Value = 8 };
            root.Right = new TreeNode<int>() { Value = 20 };
            root.Left.Left = new TreeNode<int>() { Value = 5 };
            root.Left.Right = new TreeNode<int>() { Value = 11 };
            root.Right.Left = new TreeNode<int>() { Value = 18 };
            root.Right.Right = new TreeNode<int>() { Value = 23 };

            BST<int> bst = new BST<int>() { Root = root };
            Console.WriteLine(bst.Contains(1));
        }
    }

    class BST<T> where T: IComparable<T>
    {
        public TreeNode<T> Root { get; init; }

        public bool Contains(T value)
        {
            return Search(Root, value);
        }

        private bool Search(TreeNode<T> node, T value)
        {
            int compare = value.CompareTo(node.Value);
            if (compare == 0)
                return true;
            if (compare < 0)
               return Search(node.Left, value);
            else
               return Search(node.Right, value);
        }
    }

    class StudentComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Student a = (Student)x;
            Student b = (Student)y;
            return a.Ects.CompareTo(b.Ects);
        }
    }
}
