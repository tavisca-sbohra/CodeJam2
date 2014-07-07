using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Anagrams
    {
        int isana(String temp1, String temp2)
        {
            int p = -1;
            //first possibility for anagram
            if (temp1.Length == temp2.Length)
            {
                int i, j; p++;
                int[] arr1 = new int[26];
                temp1 = temp1.ToUpper();
                temp2 = temp2.ToUpper();
                char[] w1 = temp1.ToCharArray();
                char[] w2 = temp2.ToCharArray();

                for (i = 0; i < temp1.Length; i++)
                {
                    Console.WriteLine("first word" + w1[i] + " " + arr1[w1[i] - 65]);
                    arr1[w1[i] - 65]++;
                    Console.WriteLine();
                    Console.WriteLine("second word" + w2[i] + " " + arr1[w2[i] - 65]);
                    arr1[w2[i] - 65]--;
                    Console.WriteLine();
                }
                for (j = 0; j < 26; j++)
                {
                    if (arr1[j] != 0)
                        p++;

                }
            }
            Console.WriteLine("value of p " + p);
            return p;
        }
        int GetMaximumSubset(string[] words)
        {
            //Your code goes here
            int temp1, temp2, anacount = 0, p;

            for (temp1 = 0; temp1 < words.Length - 1; temp1++)
            {
                for (temp2 = temp1 + 1; temp2 < words.Length; temp2++)
                {
                    p = isana(words[temp1], words[temp2]);
                    Console.WriteLine(p);
                    if (p == 0)//means anagram
                    {
                        anacount++;
                        break;
                    }
                }
            }

            return words.Length - anacount;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Anagrams anagramSolver = new Anagrams();
            do
            {
                string[] words = input.Split(',');
                Console.WriteLine(anagramSolver.GetMaximumSubset(words));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}
