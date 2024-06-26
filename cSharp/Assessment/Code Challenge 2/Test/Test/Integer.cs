using System;

namespace Test
{
    class Integer
    {
        public void CheckPositive(int num)
        {
            if (num <= 0)
            {
                throw new ArgumentException("The number must be positive.");
            }
        }

        public static void Main()
        {
            Integer integer = new Integer();

            Console.Write("Enter a number: ");
            int num;

            try
            {
                num = int.Parse(Console.ReadLine());
                integer.CheckPositive(num);
                Console.WriteLine("The number is positive.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid integer.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            Console.ReadLine();
        }
    }
}
