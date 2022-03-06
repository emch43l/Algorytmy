using System;

namespace Zad_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 12, 4, 6, 2 };
            Console.WriteLine(SearchIndex(tab));
        }

        static int SearchIndex(int[] tab,int index = 0)
        {
            int sum = 0;
            int returningIndex = -1;

            for(int i = index + 1; i < tab.Length; i++)
            {
                sum += tab[i];
            }

            if(tab[index] )

        }
    }
}
