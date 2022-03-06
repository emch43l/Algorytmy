using System;

namespace Zad_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 1, 2, 1, 2, 5, 10, 1, 2, 3, 4, 5, 6 };
            int k = 6;
            Console.WriteLine(SearchNumberInIncreasing(tab, k));
        }

        static int SearchNumberInIncreasing(int[] tab, int k)
        {
            int? prev = null;
            int iterator = 0;
            for(int i = 0; i < tab.Length; i++)
            {
                if(tab[i] > prev || prev == null)
                {
                    iterator++;
                    if (iterator == k)
                        return tab[i];
                }
                else
                {
                    iterator = 1;
                }
                prev = tab[i];
            }

            return -1;
        }

    }
}
