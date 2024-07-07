using System;
using System.Collections.Generic;
using System.Linq;

namespace Work
{
    class Employee : IComparable<Employee>
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public string EmpCity { get; set; }
        public int EmpSalary { get; set; }

        public int CompareTo(Employee other)
        {
            if (other == null) return 1;
            return string.Compare(this.empName, other.empName, StringComparison.Ordinal);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeDetails = new List<Employee>
            {
                new Employee { empId = 1, empName = "Amaan", EmpCity = "Chennai", EmpSalary = 30000 },
                new Employee { empId = 2, empName = "Jamsher", EmpCity = "Hyderabad", EmpSalary = 25000 },
                new Employee { empId = 3, empName = "Avinash", EmpCity = "Bangalore", EmpSalary = 46000 }
            };

            // a. To display all employees data
            DisplayEmployees(employeeDetails);

            // b. To display all employees data whose salary is greater than 45000
            Console.WriteLine("The Employees whose salary is greater than 45000 are: ");
            var highSalaryEmployees = employeeDetails.Where(e => e.EmpSalary > 45000);
            DisplayEmployees(highSalaryEmployees);

            // c. To display all employees data who belong to Bangalore Region
            Console.WriteLine("The Employees whose work location in Bangalore are: ");
            var bangaloreEmployees = employeeDetails.Where(e => e.EmpCity.Equals("Bangalore"));
            DisplayEmployees(bangaloreEmployees);

            // d. To display all employees data by their names in Ascending order
            Console.WriteLine("The Sorted order of the Employees based on their names are: ");
            var sortedEmployees = employeeDetails.OrderBy(e => e.empName);
            DisplayEmployees(sortedEmployees);

            Console.ReadLine();
        }

        static void DisplayEmployees(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.empId}");
                Console.WriteLine($"Name: {employee.empName}");
                Console.WriteLine($"City: {employee.EmpCity}");
                Console.WriteLine($"Salary: {employee.EmpSalary}");
                Console.WriteLine();
            }
        }
    }
}
