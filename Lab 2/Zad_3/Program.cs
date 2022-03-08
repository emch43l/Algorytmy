using System;

namespace Zad_3
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz();
        }

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
            while(number >= divisior)
            {
                number -= divisior;
            }

            return number;
        }
    }
}
