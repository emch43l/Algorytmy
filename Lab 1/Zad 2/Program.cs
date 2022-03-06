using System;

namespace Zad_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab =  {234, 100, 23, 56, 1234, 67};
            int k = 3;
            Console.WriteLine(ArraySum(tab,k));
        }

        static int ArraySum(int[] tab, int k)
        {
            int avg = 0;
            int sum = 0;
            foreach(int val in tab)
            {
                sum += val;
            }
            avg = sum / tab.Length;
            sum = 0;
            for(int i = 0; i < tab.Length; i++)
            {
                if(tab[i] < avg && Math.Abs(tab[i]).ToString().Length == k)
                    sum += tab[i];
            }

            return sum;
        }
    }
}
