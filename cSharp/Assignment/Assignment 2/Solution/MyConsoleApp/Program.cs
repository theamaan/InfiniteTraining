using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(computeSum(10, 10));
            numberToDay(2);
            int[] arrayOne = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            processArray(arrayOne);
            processedArray(arrayOne);
            copyArrayElement(arrayOne);
            Console.WriteLine(lengthOfWord("amaanullah"));
            Console.WriteLine(reverseWord("amaanullah"));
            checkAlikeWords("amaanullah", "amaan");
            Console.ReadLine();
        }
        public static int computeSum(int numberOne, int numberTwo)
        {
            int sum = numberOne + numberTwo;
            if (numberTwo == numberOne)
            {
                return sum * 3;
            }
            return sum;

        }
        public static void numberToDay(int day)
        {
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
            }
        }
        public static void processArray(int[] array)
        {
            int sum = 0;
            foreach (int i in array)
            {
                sum = sum + i;
            }
            Console.WriteLine("The Average of the Array Elements is " + (sum / array.Length));
            int minimum = 9;
            int maximum = 0;

            foreach (int i in array)
            {
                if (i < minimum)
                {
                    minimum = i;
                }
                if (i > maximum)
                {
                    maximum = i;
                }
            }
            Console.WriteLine("The Maximum Number is " + maximum);
            Console.WriteLine("The Minimum Number is " + minimum);
        }
        public static void processedArray(int[] array)
        {
            int sum = 0;
            foreach (int i in array)
            {
                sum = sum + i;
            }
            Console.WriteLine("The Sum of the Marks in the array is " + sum);
            Console.WriteLine("The Average of the Marks of the array is " + sum / array.Length);
            int minimum = 9;
            int maximum = 0;

            foreach (int i in array)
            {
                if (i < minimum)
                {
                    minimum = i;
                }
                if (i > maximum)
                {
                    maximum = i;
                }
            }
            Console.WriteLine("The Maximum Marks is " + maximum);
            Console.WriteLine("The Minimum Marks is " + minimum);

            Array.Sort(array);
            Console.WriteLine("Marks in ascending order are: ");
            Console.WriteLine("(" + String.Join(",", array) + ")");
            Console.WriteLine("Marks in Descending order are: ");
            Array.Reverse(array);
            Console.WriteLine("("+String.Join(",", array)+")");
        }
        public static void copyArrayElement(int[] arr)
        {
            Console.WriteLine("Copied Element from one array to another");
            int[] array = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                array[i] = arr[i];
            }
            // Print the elements of the copied array
            foreach (int element in array)
            {
                Console.WriteLine(element);
            }
        }

        public static int lengthOfWord(String str)
        {
            return str.Length;
        }

        public static String reverseWord(String word)
        {
            String str = "";
            for(int i = word.Length-1 ; i >= 0 ; i--)
            {
                str+= word[i];
            }
            return str;
        }
        public static void checkAlikeWords(String wordOne, String wordTwo)
        {
            if (wordOne.Equals(wordTwo))
            {
                Console.WriteLine("The words are same");
            } else
            {
                Console.WriteLine("The words aren't same.");
            }
        }
    }
}
