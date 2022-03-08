using System;

namespace Zad_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 1, 2, 3, 4, 5, 2 };
            int element = 6;
            Console.WriteLine(countElement(tab, element));
        }

        static int countElement(int[] tab, int element, int index = 0, int elementCount = 0)
        {

            if (index == tab.Length)
                return elementCount;

            if (element == tab[index])
                elementCount++;

            return countElement(tab, element, index + 1, elementCount);
        }
    }
}
