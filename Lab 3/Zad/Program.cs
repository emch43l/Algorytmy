using System;

namespace Zad
{
    static class SinTable
    {
        private static double[] sinTable;
        static SinTable()
        {
            sinTable = new double[360];
            for(int i = 0; i < 360; i++)
            {
                sinTable[i] = Math.Sin((double)i * Math.PI / 180);
            }
        }
        public static double Sin(int degree)
        {
            if (degree < 0)
                return -sinTable[Math.Abs(degree)];
            return sinTable[degree];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SinTable.Sin(-70));
            Console.WriteLine(fibonacci(42));
        }

        public static long fibonacci(int n)
        {
            long[] tab = new long[n];
            Array.Fill<long>(tab, -1);
            return fib(n, tab);
        }

        static private long fib(int n, long[] mem)
        {
            if (n < 0)
                throw new ArgumentException();
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if(mem[n-1] == -1)
            {
                mem[n - 1] = fib(n - 1,mem);
            }
            if(mem[n-2] == -1)
            {
                mem[n - 2] = fib(n - 2,mem);
            }
            //Console.WriteLine($"f({n}) = f({n - 1}) + f({n - 2})");
            return mem[n-1] + mem[n-2];
        }
    }
}
