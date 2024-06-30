using System;

namespace Solution
{
    class Scholarship
    {
        public decimal Merit(decimal marks, decimal fees)
        {
            decimal scholarshipAmount = 0;

            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = fees * 0.20m;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = fees * 0.30m;
            }
            else if (marks > 90)
            {
                scholarshipAmount = fees * 0.50m;
            }

            return scholarshipAmount;
        }
    }

    class Scholarships
    {
        static void Main(string[] args)
        {
            Scholarship scholarship = new Scholarship();

            Console.Write("Enter the marks: ");
            decimal marks = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the fees: ");
            decimal fees = decimal.Parse(Console.ReadLine());

            decimal scholarshipAmount = scholarship.Merit(marks, fees);

            Console.WriteLine($"The scholarship amount is: {scholarshipAmount:C}");
            Console.ReadLine();
        }
    }
}
