using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Calc
    {
        delegate int Calculator(int x, int y);

        static void Main()
        {
            Calculator add = new Calculator(Add);
            Calculator subtract = new Calculator(Subtract);
            Calculator multiply = new Calculator(Multiply);

            Console.WriteLine("Enter the first integer:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second integer:");
            int num2 = int.Parse(Console.ReadLine());

            int additionResult = add(num1, num2);
            int subtractionResult = subtract(num1, num2);
            int multiplicationResult = multiply(num1, num2);

            Console.WriteLine($"Addition of {num1} and {num2} is: {additionResult}");
            Console.WriteLine($"Subtraction of {num1} from {num2} is: {subtractionResult}");
            Console.WriteLine($"Multiplication of {num1} and {num2} is: {multiplicationResult}");
            Console.ReadLine();
        }
        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Subtract(int x, int y)
        {
            return x - y;
        }
        static int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
