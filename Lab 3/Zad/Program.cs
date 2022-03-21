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
            CashRegister cash = new CashRegister(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            foreach (var coin in cash.Payment(new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 0 }, 20))
                Console.WriteLine(coin);
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
        static readonly int[] VALUES = {1,2,5,10,20,50,100,200,500};

        private readonly int[] _coins = new int[VALUES.Length];
        public int[] Payment(int[] income, int amount)
        {

            if (amount > getAmount(income) || amount < 0 || income.Length > VALUES.Length)
                return new int[] { };
            int rest = getRemainer(income,amount);
            registerCash(income);
            return calcRest(rest,new int[VALUES.Length]);
        }

        public int[] calcRest(int rest, int[] money)
        {

            for (int i = this._coins.Length - 1; i >= 0; i--)
            {
                if (rest >= VALUES[i] && _coins[i] > 0)
                {
                    money[i]++;
                    rest -= VALUES[i];
                    return calcRest(rest, money);
                }
            }
            if (rest > 0)
            {
                return new int[] { };
            }

            deregisterCash(money);
            return money;

        }

        private int getRemainer(int[] income, int amount)
        {
            return getAmount(income) - amount;
        }

        public void deregisterCash(int[] coins)
        {
            for (int i = 0; i < this._coins.Length; i++)
            {
                this._coins[i] -= coins[i];
            }
        }

        public void registerCash(int[] income)
        {
            for (int i = 0; i < this._coins.Length; i++)
            {
                this._coins[i] += income[i];
            }
        }

        private int getAmount(int[] coins)
        {
            int amount = 0;
            for(int i = 0; i < this._coins.Length; i++)
            {
                amount += coins[i] * VALUES[i];
            }
            return amount;
        }

        public CashRegister(int[] coins)
        {
            registerCash(coins);
        }
    }
}
