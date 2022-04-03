using System;
using System.Collections.Generic;

namespace Zad
{
    class App
    {
        public static void Main(string[] args)
        {

            int[] arr = { 1, 3, 2, 5, 4, 8, 6, 7 };
            string[] strarr = { "aa", "ab", "xx", "cd", "aaa", "gd", "ac" };
            foreach (var i in StringMergeSort.Sort(strarr))
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            MergeSortInPLace.Sort(arr);

            string[] HexNumbers = { "AF3", "12D", "236", "120" };
            StringHexPositionSort sort = new StringHexPositionSort();
            sort.Sort(HexNumbers, 3);
            Console.ReadKey();
            Console.ReadKey();
        }
    }
    //Cwiczenie 1
    //4 punkty
    public class StringMergeSort
    {
        public static string[] Sort(string[] arr)
        {
            return StringSortArray(arr, 0, arr.Length - 1);
        }
        private static string[] StringSortArray(string[] arr, int left, int right)
        {
            if (left == right)
            {
                return new[] { arr[left] };
            }
            if (left + 1 == right)
            {
                return new[]
                {
                    arr[left].CompareTo(arr[right]) < 0 ? arr[left] : arr[right],
                    arr[left].CompareTo(arr[right]) > 0 ? arr[left] : arr[right]
                };
            }
            var mid = (left + right) / 2;
            var leftArr = StringSortArray(arr, left, mid);
            var rightArr = StringSortArray(arr, mid + 1, right);
            var res = StringMerge(leftArr, rightArr);
            return res;
        }

        private static string[] StringMerge(string[] arr1, string[] arr2)
        {
            var result = new string[arr1.Length + arr2.Length];
            for (int i = 0, j1 = 0, j2 = 0; i < result.Length; i++)
            {
                if (j1 < arr1.Length && j2 < arr2.Length)
                {
                    result[i] = arr2[j2].CompareTo(arr1[j1]) > 0 ? arr1[j1++] : arr2[j2++];
                    continue;
                }
                if (j1 < arr1.Length)
                {
                    result[i] = arr1[j1++];
                    continue;
                }
                if (j2 < arr2.Length)
                {
                    result[i] = arr2[j2++];
                }
            }
            return result;
        }
    }
    //Cwiczenie 2
    //Zaimplementuj metodę wykonującą scalanie w miejscu
    //4 punkty
    public class MergeSortInPLace
    {
        public static void Sort(int[] arr)
        {
            SortArray(arr, 0, arr.Length - 1);
        }
        private static void SortArray(int[] arr, int left, int right)
        {
            if (left == right)
            {
                return;
            }
            if (left + 1 == right)
            {
                if (arr[left] > arr[right])
                {
                    (arr[left], arr[right]) = (arr[right], arr[left]);
                }
            }
            var mid = (left + right) / 2;
            SortArray(arr, left, mid);
            SortArray(arr, mid + 1, right);
            Merge(arr,left,mid,right);
        }
        //zaimplementuj tę metodę, tak, aby wykonać scalanie w miejscu
        //left  - indeks pierwszego elementu pierwszej podtablicy
        //mid   - indeks ostatniego elementu pierwszej podtablicy
        //right - indeks ostatniego elementu drugiej podtablicy
        //Przykład
        //arr   => {2, 4, 6, 3, 5, 8, 11, 7}
        //left  => 0
        //mid   => 2
        //right => 5
        //po wykonaniu scalania tablica arr powinna mieć postać:
        //arr => {2, 3, 4, 5, 6, 8, 11, 7}
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int arr1_Length = mid - left + 1;
            int arr2_Length = right - mid;

            var result = new int[arr1_Length + arr2_Length];

            for (int i = 0, j1 = left, j2 = mid + 1; i < arr1_Length + arr2_Length; i++)
            {
                if (j1 <= mid && j2 <= right)
                {
                    result[i] = arr[j1] < arr[j2] ? arr[j1++] : arr[j2++];
                    continue;
                }
                if (j1 <= mid)
                {
                    result[i] = arr[j1++];
                    continue;
                }
                if (j2 <= right)
                {
                    result[i] = arr[j2++];
                }
            }

            int iterator = 0;

            for(int i = left; i <= right; i ++)
            {
                arr[i] = result[iterator];
                iterator++;
            }

        }
    }
    //Cwiczenie 3
    //8 punktów
    //Zaimplementuj klasę do sortowania pozycyjnego liczb szesnastkowych zapisanych w łańcuchach 
    //Przykładowa tablica do posortowania
    //string[] HexNumbers = {"AF3", "12D", "236", "120"};
    //talica po posortowania
    //{"120", "12D", "236", "AF3"}

    class StringHexPositionSort
    {
        //Zadeklaruj tablicę kolejek dla każdej cyfry szestnastkowej
        //Każda kolejka jest typu string
        private Queue<string>[] _queueArray = new Queue<string>[16];

        public Queue<string>[] getQueue {
            get => _queueArray;
        }

        private void Init()
        {
            //zaimplementuj zainicjowanie tablicy kolejek
            for (int i = 0; i < 16; i++)
            {
                if (_queueArray[i] == null)
                {
                    _queueArray[i] = new Queue<string>();
                }
                else
                {
                    _queueArray[i].Clear();
                }
            }
        }

        private void Dequeue(string[] arr)
        {
            int index = 0;
            for (int i = 0; i < 16; i++)
            {
                while (_queueArray[i].Count > 0)
                {
                    arr[index++] = _queueArray[i].Dequeue();
                }
            }
        }

        //Zaimplementuj metodę, aby zwracała liczbę równą cyfrze szesnastkowej na podanej pozycji (position) w łańcuchu str
        //Pozycja jest numerowana od prawej do lewej
        // np. dla łańcucha "AB12"
        // cyfra na pozycji 0 to 2,
        // cyfra na pozycji 2 to 11,
        // cyfra na pozycji 8 to 0
        private int ExtractDigit(string str, uint position)
        {
            str = string.Format("{0}", str);
            if (str.Length <= position - 1)
            {
                return 0;
            }
            return Convert.ToInt32(str[(int)(str.Length - position)] + "", 16);
        }
        //zaimplementuj umieszczanie liczb łacuchów z liczbami hex w kolejce odpowiadającej cyfrze na podanej pozycji
        private void Enqueue(string[] arr, uint position)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int digit = ExtractDigit(arr[i], position);
                _queueArray[digit].Enqueue(arr[i]);
            }
        }
        //Tej metody nie zmieniaj!!!
        public void Sort(string[] arr, int d)
        {
            Init();
            for (uint position = 0; position < d; position++)
            {
                Enqueue(arr, position);
                Dequeue(arr);
            }

        }
    }
}
