using System;

namespace Solution
{
    class CountOccurrence
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter a string: ");
            string inputString = Console.ReadLine();


            Console.Write("Enter the letter to count: ");
            char letterToCount = Console.ReadKey().KeyChar;
            Console.WriteLine();

            
            int count = CountOccurrences(inputString, letterToCount);

            
            Console.WriteLine($"The letter '{letterToCount}' appears {count} times in the string \"{inputString}\".");
            Console.ReadLine();
        }

        public static int CountOccurrences(string str, char letter)
        {
            int count = 0;
            foreach (char ch in str)
            {
                if (ch == letter)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
