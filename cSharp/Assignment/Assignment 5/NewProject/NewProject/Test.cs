using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    public class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }
        public static Box Add(Box box1, Box box2)
        {
            double newLength = box1.Length + box2.Length;
            double newBreadth = box1.Breadth + box2.Breadth;
            return new Box(newLength, newBreadth);
        }
        public void DisplayDimensions()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }
    
    public class Test
    {
        public static void Main()
        {
            Box box1 = new Box(3.5, 2.0);
            Box box2 = new Box(4.5, 3.0);
            Box box3 = Box.Add(box1, box2);

            Console.WriteLine("Box 1 Dimensions:");
            box1.DisplayDimensions();

            Console.WriteLine("Box 2 Dimensions:");
            box2.DisplayDimensions();

            Console.WriteLine("Box 3 (Result of Addition) Dimensions:");
            box3.DisplayDimensions();

            Console.ReadLine();
        }
    }
}
