using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    public interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }
        void ShowDetails();
    }
    public class DayScholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string DaySchoolName { get; set; }
        public DayScholar(int studentId, string name, string daySchoolName)
        {
            StudentId = studentId;
            Name = name;
            DaySchoolName = daySchoolName;
        }
        public void ShowDetails()
        {
            Console.WriteLine($"The Student Id is {StudentId}. The Name is {Name}. The Day School Name is {DaySchoolName}");
        }
    }
    public class Resident : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string HostelName { get; set; }
        public Resident(int studentId, string name, string hostelName)
        {
            StudentId = studentId;
            Name = name;
            HostelName = hostelName;
        }
        public void ShowDetails()
        {
            Console.WriteLine($"The Student Id is {StudentId}. The Name is {Name}. The Hostel Name is {HostelName}");
        }

    }
    class Student
    {
        public static void Main()
        {
            DayScholar dayScholar = new DayScholar(1, "Amaan Ullah", "CMS");
            dayScholar.ShowDetails();
            Console.WriteLine();

            Resident resident = new Resident(10, "Muzammil Iqbal", "Velamma");
            resident.ShowDetails();
            Console.ReadLine();
        }
    }
}
