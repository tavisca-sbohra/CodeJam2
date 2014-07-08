using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Dating
    {
        

        String Dates(String circle, int k)
        {
            string dates = string.Empty;
            //Your code goes here
            



            return dates;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Dating dating = new Dating();

            do
            {
                string[] values = input.Split(',');
                Console.WriteLine(dating.Dates(values[0], Int32.Parse(values[1])));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}