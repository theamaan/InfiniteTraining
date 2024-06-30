using System;

namespace Solution
{
    class Doctor
    {
        private int regnNo;
        private string name;
        private decimal feesCharged;

        public int RegnNo
        {
            get { return regnNo; }
            set { regnNo = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal FeesCharged
        {
            get { return feesCharged; }
            set { feesCharged = value; }
        }

        public void DisplayDoctorDetails()
        {
            Console.WriteLine($"Registration Number: {RegnNo}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Fees Charged: {FeesCharged:C}");
        }
    }

    class Doctors
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor();

            Console.Write("Enter Registration Number: ");
            doctor.RegnNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            doctor.Name = Console.ReadLine();
            Console.Write("Enter Fees Charged: ");
            doctor.FeesCharged = decimal.Parse(Console.ReadLine());

            doctor.DisplayDoctorDetails();
            Console.ReadLine();
        }
    }
}
