using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    //This is my base Class
    public class Emp
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public float Salary { get; set; }

        // Constructor to initialize the properties
        public Emp(int empid, string empname, float salary)
        {
            Empid = empid;
            Empname = empname;
            Salary = salary;
        }
        // Method to display employee details
        public void DisplayDetails()
        {
            Console.WriteLine($"Empid: {Empid}, Empname: {Empname}, Salary: {Salary}");
        }
    }
    // Derived class ParttimeEmployee inheriting from Employee
    public class ParttimeEmployee : Emp
    {
        // Property for Wages
        public int Wages { get; set; }

        //Constructor to initialise the properties of both base and derived classes
        public ParttimeEmployee(int empid, string empname, float salary, int wages) : base(empid, empname, salary) //I am using constructor chaining here.
        {
            Wages = wages;
        }
        // Method to display part-time employee details including wages
        public new void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Wages: {Wages}");
        }
    }
    class Employee
    {
        public static void Main()
        {
            // Creating a ParttimeEmployee object
            ParttimeEmployee parttimeEmp = new ParttimeEmployee(07, "Amaan Ullah", 2500.0f, 5000);

            // Displaying the details of the part-time employee
            parttimeEmp.DisplayDetails();

            Console.ReadLine();
        }
    }
}
