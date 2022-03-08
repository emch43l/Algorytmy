using System;

namespace Zad_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Element(3,2));
        }

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
