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

    public class CashRegister
    {
        static readonly int ONE = 0;
        static readonly int TWO = 1;
        static readonly int FIVE = 2;
        private readonly int[] _coins = new int[3];
        int[] Payment(int[] income, int amount)
        {

            if (amount > getAmount(income) || amount < 0 || income.Length > 3)
                return new int[] { };
            int rest = getRemainer(income,amount);
            registerCash(income);
        }

        public int[] calcRest(int rest)
        {

        }
        private int getRemainer(int[] income, int amount)
        {
            return getAmount(income) - amount;
        }

        public void registerCash(int[] income)
        {
            this._coins[ONE] += income[ONE];
            this._coins[TWO] += income[TWO];
            this._coins[FIVE] += income[FIVE];
        }

        private int getAmount(int [] coins)
        {
            return (coins[ONE] * 1) + (coins[TWO] * 2) + (coins[FIVE] * 5);
        }

        public CashRegister(int coins)
        {

        }
    }
}
