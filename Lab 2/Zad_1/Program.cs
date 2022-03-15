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

        /// <summary>
        /// Zad 1
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="sum"></param>
        /// <param name="index"></param>
        /// <returns></returns>

        static int sumTab(int[] tab, int sum = 0, int index = 0)
        {
            if (index == tab.Length)
                return sum;

            

            return sumTab(tab, sum += tab[index],index+1);
        }

        /// <summary>
        /// Zad 2
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <param name="elementCount"></param>
        /// <returns></returns>

        static int countElement(int[] tab, int element, int index = 0, int elementCount = 0)
        {

            if (index == tab.Length)
                return elementCount;

            if (element == tab[index])
                elementCount++;

            return countElement(tab, element, index + 1, elementCount);
        }

        /// <summary>
        /// Zad 3
        /// </summary>
        /// <param name="number"></param>

        public static void FizzBuzz(int number = 1)
        {
            if (number > 100)
                return;

            if (Modulo(number, 15) == 0)
                Console.WriteLine("FizzBuzz");
            else if (Modulo(number, 5) == 0)
                Console.WriteLine("Buzz");
            else if (Modulo(number, 3) == 0)
                Console.WriteLine("Fizz");
            else
                Console.WriteLine(number);

            FizzBuzz(number += 1);
        }

        public static int Modulo(int number, int divisior)
        {
            while (number >= divisior)
            {
                number -= divisior;
            }

            return number;
        }

        /// <summary>
        /// Zad 4
        /// </summary>
        /// <param name="S"></param>
        /// <param name="n"></param>
        /// <param name="prevElement"></param>
        /// <param name="count"></param>
        /// <returns></returns>

        static float Element(int S, int n, float prevElement = 0, int count = 0)
        {
            float Xn;

            if (count == 0)
                Xn = (1 / 2) * ((S / 2) + S / (S / 2));
            else
                Xn = (float)(1 / 2) * (float)(prevElement + (float)((float)S / prevElement));

            if (count == n)
                return Xn;

            Console.WriteLine(Xn);

            count++;
            return Element(S, n, Xn, count + 1);

        }
    }
}
