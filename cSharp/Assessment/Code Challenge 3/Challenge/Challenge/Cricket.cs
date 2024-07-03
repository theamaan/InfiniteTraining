using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    class Cricket
    {
        private static List<int> scores = new List<int>();

        public static void pointsCalculation(int no_of_matches)
        {
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write("Enter score for match " + (i + 1) + ": ");
                int score = int.Parse(Console.ReadLine());
                scores.Add(score);
            }
        }

        public static void display(int no_of_matches)
        {
            int sum = scores.Sum();
            double average = (double)sum / no_of_matches;

            Console.WriteLine("Total Sum of Scores: " + sum);
            Console.WriteLine("Average Score: " + average);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the number of matches: ");
            int no_of_matches = int.Parse(Console.ReadLine());

            pointsCalculation(no_of_matches);
            display(no_of_matches);
            Console.ReadLine();
        }
    }
}
