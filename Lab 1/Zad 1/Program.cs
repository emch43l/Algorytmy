using System;

namespace Zad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int? min = null;
            int index = -1;
            int[] tab = {2, 1, 2, 1, 1, 62};
            for(int i = 0; i < tab.Length; i++)
            {
                if(tab[i].ToString().Length == 2)
                {
                    if(tab[i] < min || min == null)
                    {
                        min = tab[i];
                        index = i;
                    }
                }
            }

            Console.WriteLine(index);
        }
    }
}
