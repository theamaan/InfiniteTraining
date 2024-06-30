using System;

namespace Solution
{
    class Program
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Program(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static void Display(string firstName, string lastName)
        {
            Console.WriteLine(firstName);
            Console.WriteLine(lastName.ToUpper());
        }

        static void Main(string[] args)
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Program person = new Program(firstName, lastName);
            Display(person.FirstName, person.LastName);
            Console.ReadLine();
        }
    }
}
