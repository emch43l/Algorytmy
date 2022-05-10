using System;
using System.Collections;
using System.Collections.Generic;

namespace Zad
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable table = new HashTable();
            table.Add(4);
            table.Add(3);
            table.Add(6);
            table.Add(104);
            foreach (int item in table)
                Console.WriteLine(item);
        }
    }

    class HashTable: IEnumerable<int>
    {
        List<int>[] arr = new List<int>[101];

        public bool Add(int value)
        {
            int hashCode = HashCode(value);
            if(arr[hashCode] == null)
                arr[hashCode] = new List<int>();
            if (arr[hashCode].Contains(value))
                return false;
            arr[hashCode].Add(value);
            return true;

        }

        public bool Remove(int value)
        {
            int hashCode = HashCode(value);
            if (arr[hashCode] == null || !arr[hashCode].Contains(value))
                return false;
            return arr[hashCode].Remove(value);
        }

        public bool Contains(int value)
        {
            int hashCode = HashCode(value);
            if (arr[HashCode(value)] != null && arr[hashCode].Contains(value))
                return true;
            return false;
        }

        private int HashCode(int value)
        {
            return value.GetHashCode() % arr.Length;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach(List<int> list in arr)
                if(list != null)
                    foreach(int item in list)
                        yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
