using System;
using System.Collections.Generic;//responsible for generic collections such as 'List<T>'
using System.Linq;//It includes LINQ(Language- Integrated Query) which provides powerful quesry capabilities
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    class Square
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter Numbers Separated by Spaces:");
            String input = Console.ReadLine();
            String[] inputNumbers = input.Split(' '); //Splits the input string by string by spaces into an array of strings. 

            foreach (String number in inputNumbers)
            {
                if(int.TryParse(number,out int n)) //Trying to parse each string into an integer
                {
                    numbers.Add(n);//Here, I am adding the parsed integer to the list.
                }
                else
                {
                    Console.WriteLine($"Invalid input: {number} is not an Integer.");
                }
            }
            var result = numbers
                .Select(n => new { Number = n, Square = n * n })
                .Where(x => x.Square > 20)
                .ToList();

            Console.WriteLine("Numbers and their squares (square > 20):");
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Number} - {item.Square}");
            }
            Console.ReadLine();
        }
    }
}
