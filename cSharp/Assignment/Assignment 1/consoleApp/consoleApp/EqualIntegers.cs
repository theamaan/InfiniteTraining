using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleApp
{
    class EqualIntegers
    {
        public int dist1;
        public int dist2;
        public static EqualIntegers totaldistance;
        public static void Main(string[] args)
        {
            //CheckEqualIntegers();
            //CheckPositiveNumber();
            //PerformArithmeticOperations();
            //swapTwoNumber();
            //pattern();

            EqualIntegers d1 = new EqualIntegers();
            EqualIntegers d2 = new EqualIntegers();
            d1.dist1 = 50;
            d2.dist2 = 60;
            EqualIntegers.totaldistance = d1 + d2;
           // Console.WriteLine("The Overall Distance is {0}", EqualIntegers.totaldistance.dist1);
            d1++;
            d2++;
            Console.WriteLine("The incremented distance is {0}", d1.dist1);
            Console.WriteLine("The incremented distance is {0}", d2.dist2);
            Console.Read();
        }

        static void CheckEqualIntegers()
        {
            Console.WriteLine("Please enter the first integer:");
            int integerOne = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the second integer:");
            int integerTwo = Convert.ToInt32(Console.ReadLine());

            if (integerOne == integerTwo)
            {
                Console.WriteLine("The numbers are equal.");
            }
            else
            {
                Console.WriteLine("The numbers are not equal.");
            }
            Console.ReadLine();
        }
        static void CheckPositiveNumber()
        {
            Console.WriteLine("Please Enter a Number:");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 0)
            {
                Console.WriteLine("The Number is a Positive Number.");
            }
            else
            {
                Console.WriteLine("The Number is a Negative Number.");
            }
            Console.ReadLine();
        }
        static void PerformArithmeticOperations()
        {
            Console.WriteLine("Please enter the first number:");
            double numberOne = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Please enter the second number:");
            double numberTwo = Convert.ToDouble(Console.ReadLine());


            double addition = numberOne + numberTwo;
            Console.WriteLine("The addition of the two numbers is: " + addition);

            double subtraction = numberOne - numberTwo;
            Console.WriteLine("The subtraction of the two numbers is: " + subtraction);

            double multiplication = numberOne * numberTwo;
            Console.WriteLine("The multiplication of the two numbers is: " + multiplication);

            if (numberTwo != 0)
            {
                double division = numberOne / numberTwo;
                Console.WriteLine("The division of the two numbers is: " + division);
            }
            else
            {
                Console.WriteLine("Division by zero is not allowed.");
            }
            Console.ReadLine();
        }
        static void swapTwoNumber()
        {
            Console.WriteLine("Please Enter the first number:");
            int numberOne = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the second number:");
            int numberTwo = Convert.ToInt32(Console.ReadLine());

            int temp = numberOne;
            numberOne = numberTwo;
            numberTwo = temp;

            Console.WriteLine("The swapped first value is " + numberOne + " and the second value is " + numberTwo);
            Console.ReadLine();
        }
        static void pattern()
        {
            Console.Write("Enter a digit: ");
            int testData = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(testData + " ");
                    }
                    else
                    {
                        Console.Write(testData);
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        //Overloading the + Operator
        public static EqualIntegers operator +(EqualIntegers dis1, EqualIntegers dis2)
        {
            EqualIntegers temp = new EqualIntegers();
            temp.dist1 = dis1.dist1 + dis2.dist1;
            temp.dist2 = dis1.dist2 + dis2.dist2;
            return temp;
        }
        //Overloading the ++ Operator
        public static EqualIntegers operator ++(EqualIntegers dis)
        {
            EqualIntegers temp = new EqualIntegers();
            temp.dist1 = dis.dist1 + 1;
            temp.dist2 = dis.dist2 + 1;
            return temp;
        }
    }
}
