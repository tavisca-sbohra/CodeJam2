using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace CodeJam
{
    class LOTR
    {
        int GetMinimum(int[] replies)
        {
            //Your code goes here
            int count=0;
            int k,j;
            int[] distinctanswers = replies.Distinct().ToArray();
            int[] distinctvalues=new int[distinctanswers.Length];
            //to get the count of each distinct reply
            for (k = 0; k < replies.Length; k++)
            {
                for (j = 0; j < distinctanswers.Length; j++)
                {
                    if (distinctanswers[j] == replies[k])
                        distinctvalues[j]++;
                    
                }
            }
            int pairs,leftalone;
            for (j = 0; j < distinctanswers.Length; j++)
            {
                pairs=distinctvalues[j]/(distinctanswers[j]+1);
                
                count  += pairs*(distinctanswers[j]+1);
                
                leftalone = distinctvalues[j] % (distinctanswers[j]+1);
                if (leftalone > 0)
                {
                    
                    count += distinctanswers[j] + 1;
                }
               
            }
                return count;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            LOTR lotr = new LOTR();
            String input = Console.ReadLine();
            do
            {
                int[] replies = Array.ConvertAll<string, int>(input.Split(','), delegate(string s) { return Int32.Parse(s); });
                Console.WriteLine(lotr.GetMinimum(replies));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion

    }
}