using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Dating
    {
        
        
        int countFemales(string c)
        {
            int i,femalecount=0;
            char[] ch = c.ToCharArray();
            for (i = 0; i < c.Length; i++)
            {
                if (ch[i] >= 'a' && ch[i] <= 'z')
                    femalecount++;
            }
            return femalecount;
        }
        int countMales(string c)
        {
            int i,malecount=0;
            char[] ch = c.ToCharArray();
            for (i = 0; i < c.Length; i++)
            {
                if (ch[i] >= 'A' && ch[i] <= 'Z')
                    malecount++;
            }
            return malecount;
        }

        
        char choseMale(char choser,string circle)
        {
            int j;
            char[] c=circle.ToCharArray();
            Array.Sort(c);
            for(j=0;j<c.Length;j++)
            {
                if(c[j]>=65 && c[j]<92 )
                break;
            }
            return c[j];
        }
        char choseFemale(char choser,string circle)
        {
            int j;
            char[] c = circle.ToCharArray();
            Array.Sort(c);
            for (j = 0; j < c.Length; j++)
            {
                if (c[j] >= 97)
                    break;
            }
            return c[j];
        }
        String removest(char m,char f,String c)
        {
            int j;
            String newcircle="";
            char[] ch = c.ToCharArray();
            for (j = 0; j < ch.Length; j++)
            {
                if (ch[j] == m || ch[j] == f)
                {
                    Console.WriteLine("value matched with " + ch[j]);
                    newcircle = newcircle + " ";
                    Console.WriteLine(newcircle);
                }
                else newcircle = newcircle + ch[j];

            }
            newcircle = newcircle.Replace(" ", "");
            Console.WriteLine("newcircle val:"+newcircle);
            return newcircle;
        }

        String Dates(String circle, int k)
        {
            String pairs="";
            char chosen,choser;
            char[] ch;  
            string dates = string.Empty;
            //Your code goes here

            Console.WriteLine("Value of k:"+k);
            
            int femalecount, malecount;
  
            ch = circle.ToCharArray();
            
            int latestvalue;
            

            malecount=countMales(circle);
            femalecount =countFemales(circle);

            Console.WriteLine("total males {0} and females {1}",malecount,femalecount);

            latestvalue = (k % circle.Length) - 1;
            if (k % circle.Length == 0)
            {
                if (k > circle.Length)
                    latestvalue = circle.Length-1;
                else latestvalue = k-1;
            }
            Console.WriteLine("lv initially: " + latestvalue);
            do
            {
                
                if (latestvalue < circle.Length)
                    break;
                else 
                    latestvalue = latestvalue % circle.Length;
            } while (latestvalue > circle.Length);
                
                choser = ch[latestvalue];
            while (femalecount != 0 && malecount != 0)
            {
                            Console.WriteLine("chooser:"+choser);
                            //if female is the choser,she'll chose male
                            if (choser >= 'a' && choser <= 'z')
                            {

                               malecount= countMales(circle);
                                //calulate the no of males

                                if (malecount > 0)
                                {
                                    chosen = choseMale(choser, circle);
                                    Console.WriteLine("chosen :"+chosen);
                                    femalecount--;
                                    malecount--;
                                    Console.WriteLine(choser+chosen);
                                    circle=removest(chosen, choser, circle);
                                    Console.WriteLine("new string "+circle);
                                    pairs = pairs+choser+ chosen + " ";
                                }


                             }


                                    //male is chosen to chose his female partner 
                                    if (choser >= 'A' && choser <= 'Z')
                                    {
                                       femalecount= countFemales(circle);
                                        //calulate the no of males

                                        if (femalecount > 0)
                                        {
                                            chosen = choseMale(choser, circle);
                                            Console.WriteLine("chosen :" + chosen);
                                            malecount--;
                                            femalecount--;
                                           circle= removest(chosen, choser, circle);
                                           Console.WriteLine("new string " + circle);
                                            pairs = pairs  + choser + chosen + " ";
                                        }

                                    }
                        ch = circle.ToCharArray();
                Console.WriteLine("ch ka length :"  + ch.Length);
                Console.WriteLine("latestvalue:" + latestvalue);
                        //calculate the next choser
                        latestvalue = (latestvalue + k) - 1;
                        if (k % circle.Length == 0)
                        {
                            if (k > circle.Length)
                                latestvalue = circle.Length - 1;
                            else latestvalue = k - 1;
                        } 
                           do
                        {
                            if (latestvalue < circle.Length)
                                break;
                            else
                                latestvalue = latestvalue % circle.Length;
                        } while (latestvalue > circle.Length);
                        Console.WriteLine("latestvalue:" + latestvalue);
                        Console.WriteLine("lv again:" + latestvalue);
                        choser = ch[latestvalue];
                       
            }
            
            dates = pairs;
            Console.WriteLine(pairs);
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