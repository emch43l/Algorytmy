using System;

namespace Zad_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 12, 11, 5, 4, 1 };
            Console.WriteLine(SearchIndex(tab));
        }

        static int SearchIndex(int[] tab, int index = 0)
        {
            int sum = 0;
            int element = tab[index];

            for(int i = index + 1; i < tab.Length; i++)
            {
                sum += tab[i];
            }

            if (element == sum)
            {
                return index;
            }
            else
            {
                if (index == tab.Length)
                {
                    return -1;
                }
                else
                {
                    return SearchIndex(tab, index + 1);
                }
            }

        }
    }
}
