using System;
using System.Linq;
using System.Collections.Generic;

namespace Zad
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            if(
                LessonTasks.IsPalindrome("a")
                && LessonTasks.IsPalindrome("aaa")
                && LessonTasks.IsPalindrome("")
                && LessonTasks.IsPalindrome("zakaz")
                && LessonTasks.IsPalindrome("ZaKAZ")
                && LessonTasks.IsPalindrome("KamilŚlimak")
                && !LessonTasks.IsPalindrome("abc"))
            {
                Console.WriteLine("Zadadnie 1: OK");
                points++;
            }

            if(
                LessonTasks.IsAnagrams("abcd","bcda")
                && LessonTasks.IsAnagrams("aa", "aa")
                && !LessonTasks.IsAnagrams("AA", "aa")
                && LessonTasks.IsAnagrams("","")
                && !LessonTasks.IsAnagrams("abc", "abca")
                )
            {
                Console.WriteLine("Zadadnie 2: OK");
                points++;
            }

            if (
                LessonTasks.LongestIdenticalString("aaaa").Equals("aaaa")
                && LessonTasks.LongestIdenticalString("abcddddaaass").Equals("dddd")
                && LessonTasks.LongestIdenticalString("abcd").Equals("a")
                && LessonTasks.LongestIdenticalString("abbcdd").Equals("bb")
                )
            {
                Console.WriteLine("Zadadnie 3: OK");
                points+=2;
            }

            Console.WriteLine($"Liczba punktów: {points}");
        }

    }

    class LessonTasks
    {
        public static bool IsPalindrome(string str)
        {
            str = str.ToLower();
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return Enumerable.SequenceEqual(str.ToCharArray(), arr);
        }

        //czy łańcuchy są anargramami
        public static bool IsAnagrams(string a, string b)
        {
            char[] arr1 = a.ToCharArray();
            char[] arr2 = b.ToCharArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            return Enumerable.SequenceEqual(arr2, arr1);
        }

        public static string LongestIdenticalString(string input)
        {
            char[] chars = input.ToCharArray();
            List<char> result = new List<char>();
            List<char> longest = new List<char>();
            longest.Add(chars[0]);
            int length = 1;
            for(int i = 1; i < chars.Length; i++)
            {
                if(chars[i].Equals(longest[length - 1]))
                {
                    longest.Add(chars[i]);
                    if (longest.Count() > result.Count())
                    {
                        result = new List<char>(longest);
                    }
                    length++;
                }
                else
                {
                    if(result.Count() == 0)
                        result = new List<char>(longest);
                    longest.Clear();
                    longest.Add(chars[i]);
                    length = 1;
                }
            }

            return new String(result.ToArray());
        }
    }
}
