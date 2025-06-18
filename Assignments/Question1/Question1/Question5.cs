using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Question5
    {
        static void Main()
        {
            Console.WriteLine("Enter the number1");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number2");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int total = num1 + num2;
            if (num1 == num2)
            {
                Console.WriteLine($"The output is {3*total}");
            }
            else
            {
                Console.WriteLine($"The output is {total}");
            }

            Console.ReadLine();
        }
    }
}
