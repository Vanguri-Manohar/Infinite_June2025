using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number1");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number2");
            int num2 = int.Parse(Console.ReadLine());
            if (num == num2)
            {
                Console.WriteLine($"{num} and {num2} are Equal");
            }
            else
            {
                Console.WriteLine($"{num} and {num2} are Equal");
            }
            Console.ReadLine();
        }
     
    }
}
