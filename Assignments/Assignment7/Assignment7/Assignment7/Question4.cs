using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classconsession;

namespace Assignment7
{
    class Q4
    {
        static void Main()
        {
            Console.WriteLine("Enter the Name of the Person");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter age");
            int age = int.Parse(Console.ReadLine());
            Class1 c = new Class1();
            c.CalculateConcession(500, Name, age);

            Console.ReadLine();

        }
    }
}
