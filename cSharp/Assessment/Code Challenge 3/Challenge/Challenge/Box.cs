using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    class Box
    {
        private int length;
        private int breadth;

        public Box(int length, int breadth)
        {
            this.length = length;
            this.breadth = breadth;
        }

        public static Box AddBoxes(Box box1, Box box2)
        {
            int newLength = box1.length + box2.length;
            int newBreadth = box1.breadth + box2.breadth;
            return new Box(newLength, newBreadth);
        }

        public void Display()
        {
            Console.WriteLine("Length: " + length);
            Console.WriteLine("Breadth: " + breadth);
        }
    }

    class Test
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(50, 10);
            Box box2 = new Box(150, 20);

            Box box3 = Box.AddBoxes(box1, box2);

            Console.WriteLine("Details of the third box (after addition):");
            box3.Display();
            Console.ReadLine();
        }
    }
}
