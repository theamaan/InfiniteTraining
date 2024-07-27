using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };

            //1. Display a list of all the employee who have joined before 1 / 1 / 2015
            var employeesJoinedBefore2015 = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1)).ToList();
            Console.WriteLine("Employees who joined before 1/1/2015: ");
            employeesJoinedBefore2015.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));
            

            //2. Display a list of all the employee whose date of birth is after 1 / 1 / 1990
            var employeesBornAfter1990 = empList.Where(e => e.DOB > new DateTime(1990, 1, 1)).ToList();
            Console.WriteLine("\nEmployees DOB after 1/1/1990:");
            employeesBornAfter1990.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));

            //3. Display a list of all the employee whose designation is Consultant and Associate
            var consultantsAndAssociates = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate").ToList();
            Console.WriteLine("\nEmployees who are Consultants and Associates:");
            consultantsAndAssociates.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));

            //4. Display total number of employees
            var totalNumberOfEmployees = empList.Count();
            Console.WriteLine($"\nTotal number of employees: {totalNumberOfEmployees}");

            //5. Display total number of employees belonging to “Chennai”
            var countOfChennaiEmployees = empList.Where(e => e.City == "Chennai").ToList();
            Console.WriteLine($"\nPeople working in Chennai are:");
            countOfChennaiEmployees.ForEach(e => Console.WriteLine($"{e.FirstName}{e.LastName}"));

            //6. Display highest employee id from the list
            var highestEmployeeID = empList.Max(e => e.EmployeeID);
            Console.WriteLine($"\nHighest Employee ID: {highestEmployeeID}");

            //7. Display total number of employee who have joined after 1/1/2015
            var totalNumberOfEmployeeAfter2015 = empList.Count(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"\nTotal number of employees joined after 1/1/2015: {totalNumberOfEmployeeAfter2015}");

            //8. Display total number of employee whose designation is not “Associate”
            var employeeWhoAreNotAssociate = empList.Count(e => e.Title != "Associate");
            Console.WriteLine($"\ntotal number of employee whose designation is not “Associate”: {employeeWhoAreNotAssociate}");

            //9. Display total number of employee based on City
            var employeeByCity = empList.GroupBy(e => new { e.City }).Select(f => new { f.Key.City, Count = f.Count() }).ToList();
            Console.WriteLine("\nTotal number of employee based on City are:");
            employeeByCity.ForEach(e => Console.WriteLine($"{e.City} : {e.Count}"));

            //10. Display total number of employee based on City and Title
            var employeesByCityAndTitle = empList.GroupBy(e => new { e.City, e.Title }).Select(f => new { f.Key.City, f.Key.Title, Count = f.Count() }).ToList();
            Console.WriteLine("\nTotal number of employees based on City and Title:");
            employeesByCityAndTitle.ForEach(e => Console.WriteLine($"{e.City} - {e.Title}: {e.Count}"));

            //11. Display total number of employee who is youngest in the list
            var youngestEmployee = empList.OrderByDescending(e => e.DOB).FirstOrDefault();
            Console.WriteLine($"\nThe youngest employee is: {youngestEmployee.FirstName} {youngestEmployee.LastName}");

            Console.ReadLine();
        }
    }
}
