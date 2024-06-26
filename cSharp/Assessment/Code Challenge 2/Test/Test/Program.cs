using System;

namespace Test
{
    class Program
    {
        public abstract class Student
        {
            public string Name { get; set; }
            public int StudentId { get; set; }
            public double Grade { get; set; }

            public abstract bool IsPassed(double grade);
        }

        public class Undergraduate : Student
        {
            public override bool IsPassed(double grade)
            {
                return grade > 70.0;
            }
        }

        public class Graduate : Student
        {
            public override bool IsPassed(double grade)
            {
                return grade > 80.0;
            }
        }

        static void Main()
        {
            // Undergraduate student
            Undergraduate undergradStudent = new Undergraduate();

            Console.WriteLine("Enter UG student's name:");
            undergradStudent.Name = Console.ReadLine();

            Console.WriteLine("Enter UG student's ID:");
            if (int.TryParse(Console.ReadLine(), out int undergradId))
                undergradStudent.StudentId = undergradId;
            else
                Console.WriteLine("Invalid input for ID. Please enter a valid integer.");

            Console.WriteLine("Enter UG student's grade:");
            if (double.TryParse(Console.ReadLine(), out double undergradGrade))
                undergradStudent.Grade = undergradGrade;
            else
                Console.WriteLine("Invalid input for grade. Please enter a valid double.");

            bool undergradPassed = undergradStudent.IsPassed(undergradStudent.Grade);
            Console.WriteLine($"Undergraduate student {undergradStudent.Name} passed: {undergradPassed}");

            // Graduate student
            Graduate gradStudent = new Graduate();

            Console.WriteLine("\nEnter Graduate student's name:");
            gradStudent.Name = Console.ReadLine();

            Console.WriteLine("Enter Graduate student's ID:");
            if (int.TryParse(Console.ReadLine(), out int gradId))
                gradStudent.StudentId = gradId;
            else
                Console.WriteLine("Invalid input for ID. Please enter a valid integer.");

            Console.WriteLine("Enter Graduate student's grade:");
            if (double.TryParse(Console.ReadLine(), out double gradGrade))
                gradStudent.Grade = gradGrade;
            else
                Console.WriteLine("Invalid input for grade. Please enter a valid double.");

            bool gradPassed = gradStudent.IsPassed(gradStudent.Grade);
            Console.WriteLine($"Graduate student {gradStudent.Name} passed: {gradPassed}");

            Console.ReadLine();
        }
    }
}
