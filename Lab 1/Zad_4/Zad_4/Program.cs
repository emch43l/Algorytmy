using System;

namespace Zad_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 1, 2, 3, 4, 6, 9, 10, 11, 12, 13 };
            Console.WriteLine(SumSequence(tab));
        }

        static int SumSequence(int[] tab)
        {
            int longestSum = 0;
            int sum = 0;
            int longestSequence = 0;
            int sequenceCount = 0;
            int sequenceJump = 0;
            int prevElement = tab[0];

            for(int i = 1; i < tab.Length; i++)
            {
                

                if(tab[i] - prevElement != sequenceJump)
                {
                    sequenceCount = 2;
                    sum = tab[i] + prevElement;
                    sequenceJump = tab[i] - prevElement;
                }
                else
                {
                    sum += tab[i];
                    sequenceCount++;
                }

                if (sequenceCount > longestSequence)
                {
                    longestSequence = sequenceCount;
                    longestSum = sum;
                }

                Console.WriteLine(sequenceCount+" "+sequenceJump);

                prevElement = tab[i];
            }

            return longestSum;
        }
    }
}
