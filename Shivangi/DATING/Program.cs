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
                if (ch[j] != m || ch[j] != f)
                    newcircle +=  ch[j];

            }
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
            
            int temp;
            temp=(k%circle.Length)-1;
            choser = ch[temp];

            malecount=countMales(circle);
            femalecount =countFemales(circle);

            Console.WriteLine("total males {0} and females {1}",malecount,femalecount);
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
                        pairs = pairs+" " +" "+ choser+" "  +" "+ chosen + "    ";
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
                       pairs = pairs + " " + " " + choser + " " + " " + chosen + "    ";
                    }

                }
                ch = circle.ToCharArray();
                //calculate the next choser
                choser = ch[((k % circle.Length)+temp)%circle.Length-1];
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