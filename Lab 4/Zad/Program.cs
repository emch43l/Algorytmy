using System;

namespace Zad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strTab = { "aaaaa", "aa", "a" ,"aaa", "aaaa", "aaaaaa" };
            int[] tab = { 9, 4, 8, 2, 5, 6, 7, 3, 1 };
            foreach (var i in sortTab(tab))
                Console.Write(i + " ");

            foreach (var i in sortTabAlph(strTab))
                Console.Write(i + " ");
        }
        /// Selection Sort
        static int[] sortTab(int[] tab, int iterator = 0)
        {

            int min = tab[iterator];
            int switchElement = 0;

            for(int i = 0 + iterator; i < tab.Length; i++)
            {
                if (min >= tab[i])
                {
                    min = tab[i];
                    switchElement = tab[iterator];
                }
            }

            int tabIndex = Array.IndexOf(tab, min);
            tab[iterator] = min;
            tab[tabIndex] = switchElement;

            if (iterator < tab.Length - 1)
                return sortTab(tab, iterator + 1);

            return tab;

        }

        /// Alphabet sort
        static string[] sortTabAlph(string[] tab, int iterator = 0)
        {

            string min = tab[iterator];
            string switchElement = "";

            for (int i = 0 + iterator; i < tab.Length; i++)
            {
                if (min.Length >= tab[i].Length)
                {
                    min = tab[i];
                    switchElement = tab[iterator];
                }
            }

            int tabIndex = Array.IndexOf(tab, min);
            tab[iterator] = min;
            tab[tabIndex] = switchElement;

            if (iterator < tab.Length - 1)
                return sortTabAlph(tab, iterator + 1);

            return tab;

        }

    }
}
