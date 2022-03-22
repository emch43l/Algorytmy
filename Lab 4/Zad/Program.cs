using System;

namespace Zad
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 9, 4, 8, 2, 5, 6, 7, 3, 1 };
            sortTab(tab);
        }

        static int sortTab(int[] tab)
        {
            int? min = tab[0];

            for(int i = 0; i < tab.Length; i++)
            {
                for(int j = 0 + i; j < tab.Length; j++)
                {
                    if(min > tab[j])
                    {
                        
                    }
                }
            }

            return 0;
        }

    }
}
