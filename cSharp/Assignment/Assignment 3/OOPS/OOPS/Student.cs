using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class Student
    {
        private int rollNo;
        private String name;
        private int standard;
        private String semester;
        private String branch;
        private int[] marks = new int[5];

        public Student(int rollNo, String name, int standard, String semester, String branch, int[] marks)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.semester = semester;
            this.standard = standard;
            this.branch = branch;
        }
        public void getMarks()
        {
            Console.WriteLine("Enter marks for " + name + " and the Roll Number " + rollNo);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter the marks for Subject " + (i + 1));
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void DisplayResult()
        {
            int sum = 0;
            foreach (int mark in marks)
            {
                sum += mark;
            }
            double average = (double)sum / 5;
            Console.WriteLine("The Average Marks is " + average);

            bool flag = false;
            foreach (int mark in marks)
            {
                if (mark < 35)
                {
                    flag = true;
                    break;
                }
            }
            if (flag || average < 50)
            {
                Console.WriteLine("Failed");
            }
            if (average > 50)
            {
                Console.WriteLine("Passed");
            }
        }
        public void displayData()
        {
            Console.WriteLine("Roll Number " + rollNo);
            Console.WriteLine("Name " + name);
            Console.WriteLine("Standard " + standard);
            Console.WriteLine("Semester " + semester);
            Console.WriteLine("Branch " + branch);
            Console.WriteLine("Marks ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Subject{i + 1}: {marks[i]}");
            }
        }
        public static void Main(String[] main)
        {
            Console.WriteLine("Enter Roll Number: ");
            int rollNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Standard: ");
            int standard = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Semester: ");
            string semester = Console.ReadLine();

            Console.WriteLine("Enter Branch: ");
            string branch = Console.ReadLine();

            int[] marks = new int[5];

            
            Student student = new Student(rollNo, name, standard, semester, branch, marks);
            student.getMarks();
            student.DisplayResult();
            student.displayData();
            Console.ReadLine();
        }
    }
}
