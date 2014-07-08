using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;

namespace CodeJam
{
    class Pool
    {
        
        int RackMoves(int[] triangle)
        {
            //Your code goes here
            

            Stack missolid = new Stack();
            Stack misstripe = new Stack();
            int k,stripemis = 0, solidmis = 0;
                            int[] chart = new int[15];
                            for (int i = 0; i < 15; i++)
                            {
                                if (triangle[i] < 8)
                                    chart[i] = 0;
                                if (triangle[i] == 8)
                                    chart[i] = -1;
                                if (triangle[i] > 8)
                                    chart[i] = 1;
                            }

            if (chart[4] !=-1)
            {
                swap(0, 4);//for both chart n triangle
            }


            if (chart[0] == 0)
            {
                                int p,temp=1,flag=1;
                                for(p=0;p<5;p++)
                                {   
                            
                                            if (chart[0] != chart[temp] && flag==0)
                                            {
                                                misstripe.Push(temp);
                                                stripemis++;
                                                temp++;
                                                temp += p; 
                                            }
                                            if (chart[0] == chart[temp] && flag == 1)
                                            {
                                                missolid.Push(temp);
                                                solidmis++;
                                                temp++;
                                                temp += p;
                                            }
                                            if (flag == 0) flag=1;
                                            if (flag == 1) flag = 0;
                        
                                }

                                if (stripemis > 0 && solidmis > 0)
                                {
                                    swap[missolid.Pop(), misstripe.Pop()];
                                    stripemis--;
                                    solidmis--;
                                }
                                if (chart[0] != chart[10])
                                {
                                    missolid.Push(10);
                                    solidmis++;
                                }
                                if (stripemis > 0 && solidmis > 0)
                                {
                                    swap[missolid.Pop(), misstripe.Pop()];
                                    stripemis--;
                                    solidmis--;
                                }
                                if (chart[0] == chart[14])
                                {
                                    misstripe.Push(14);
                                    stripemis++;
                                }
                                if (stripemis > 0 && solidmis > 0)
                                {
                                    swap[missolid.Pop(), misstripe.Pop()];
                                    stripemis--;
                                    solidmis--;
                                }
                                for(p=10;p<=13;p++)
                                {


             }
             
                    return 0;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            Pool pool = new Pool();
            String input = Console.ReadLine();
            do
            {
                int[] triangle = Array.ConvertAll<string, int>(input.Split(','), delegate(string s) { return Int32.Parse(s); });
                Console.WriteLine(pool.RackMoves(triangle));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion

    }
}