using System;

namespace Zad_5_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 0, 2, 0, 2 };
            Console.WriteLine(SearchIndex(tab));
        }

        static int SearchIndex(int[] tab, int index = 0)
        {
            int sum = 0;
            int element = tab[index];

            for (int i = 0; i < tab.Length; i++)
            {
                if(i != index)
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
