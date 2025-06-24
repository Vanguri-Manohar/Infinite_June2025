using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter the number");
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                Console.WriteLine($"{num} is negative");
            }
            else
            {
                Console.WriteLine($"{num} is positive");
            }

            Console.ReadLine();
        }
    }
}
