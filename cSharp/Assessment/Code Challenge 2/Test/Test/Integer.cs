using System;

namespace Test
{
    class Integer
    {
        public string IntegerPositive(int num)
        {
            if (num > 0)
            {
                return "The number is positive";
            }
            else
            {
                return "The number is negative or zero";
            }
        }

        public static void Main()
        {
            Integer integer = new Integer();

            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            string result = integer.IntegerPositive(num);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
