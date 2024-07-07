using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelConcessionLib; // Import the namespace of the class library

namespace TravelBookingApp
{
    class Program
    {
        //Declaring Constansts
        private const double TotalFare = 500.0;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your Name:");
            String name = Console.ReadLine();
            Console.WriteLine("Enter your Age:");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age input. Please enter a valid number.");
                return;
            }
            //Creating an instance of TravelConcession Class
            TravelConcession concessionCalculator = new TravelConcession();
            // Calculate concession based on age
            string concession = concessionCalculator.CalculateConcession(age);

            // Display the result
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Concession: {concession}");

            Console.ReadLine();
        }
    }
}
