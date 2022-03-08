using System;

namespace Zad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 1, 2, 3, 4, 5 };

            Console.WriteLine(sumTab(tab));
        }

        static int sumTab(int[] tab, int sum = 0, int index = 0)
        {
            if (index == tab.Length)
                return sum;

            

            return sumTab(tab, sum += tab[index],index+1);
        }
    }
}
