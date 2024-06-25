using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            removeChar("Python", 0);
            Console.WriteLine(ExchangeCharacters("abcd"));
            Console.WriteLine("The Largest Number is "+ LargestNumber(1, 2, 40));
            multiplicaitonNumber(10);
            Console.ReadLine();
        }
        public static void removeChar(String str, int digit)
        { 
            String sub1 = (str.Substring(0,digit));
            String sub2 = str.Substring(digit + 1);
            Console.WriteLine(sub1+sub2);

        }
        public static String ExchangeCharacters(String str)
        {
            if (str.Length <= 1)
            {
                return str;
            }
            else
            {
                char firstChar = str[0];
                char lastChar = str[str.Length - 1];
                string middle = str.Substring(1, str.Length - 2);
                string newWord = lastChar + middle + firstChar;
                return newWord;
            }
        }
        public static int LargestNumber(int num1,int num2,int num3)
        {
            if ((num1 > num2)&& (num1 > num3)){
                return num1;
            }
            if ((num2 > num1)&& (num2 > num3)){
                return num2;
            } else
            {
                return num3;
            }
        }
        public static void multiplicaitonNumber(int number)
        {
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine(number+"*"+i+"="+number*i);
            }
        }
    }
}
