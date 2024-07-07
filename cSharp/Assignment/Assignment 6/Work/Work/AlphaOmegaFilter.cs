using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Work
{
    class AlphaOmegaFilter
    {
        public static void Main(String[] args)
        {
            List<String> cityNames = new List<string>();

            Console.WriteLine("Enter names separated by spaces:");
            String input = Console.ReadLine();
            String[] inputNames = input.Split(' ');

            foreach (String name in inputNames)
            {
                if (IsAlphabetic(name))
                {
                    cityNames.Add(name);
                }
                else
                {
                    Console.WriteLine($"Invalid Input: '{name}' is not a valid name (contains non-alphabetic characters).");
                }
            }

            var result = cityNames
                .Where(city => city.StartsWith("a", StringComparison.OrdinalIgnoreCase) && city.EndsWith("m", StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine("Names that start with 'a' and end with 'm':");
            foreach (var name in result)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();
        }

        private static bool IsAlphabetic(string name)
        {
            // Regular expression to match alphabetic characters
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
    }
}
