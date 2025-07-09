using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{

    class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }

        public Box(int length,int breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public static Box Add(Box b1,Box b2)
        {
            int newLength = b1.Length + b2.Length;
            int newbreadth = b1.Breadth + b2.Breadth;
            return new Box(newLength, newbreadth);
        }
    }
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter the Length of box 1");
            int l = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Breadth of box 1");
            int b = int.Parse(Console.ReadLine());
            Box b1 = new Box(l, b);
            Console.WriteLine("Enter the Length of box 2");
            int l_2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Breadth of box 2");
            int b_2 = int.Parse(Console.ReadLine());
            Box b2 = new Box(l_2, b_2);

            Box b3 = Box.Add(b1, b2);

            Console.WriteLine($"The new length is {b3.Length}");
            Console.WriteLine($"The new breadth is {b3.Breadth}");


            Console.ReadLine();


        }
    }
}
