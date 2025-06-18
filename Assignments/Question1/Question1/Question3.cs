using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Question3
    {
        static void Main()
        {
            Add();
            Console.WriteLine("***********");
            Sub();
            Console.WriteLine("**********");
            Mul();
            Console.WriteLine("**********");
            Divide();
            Console.WriteLine("Operation Completed");
            Console.ReadLine();
        }

        public static void Add()
        {
            Console.WriteLine("Enter the 1st number");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"{num1} + {num2} = {num1+num2}");
        }
        public static void Sub()
        {
            Console.WriteLine("Enter the 1st number");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        }
        public static void Mul()
        {
            Console.WriteLine("Enter the 1st number");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
        }
        public static void Divide()
        {
            Console.WriteLine("Enter the 1st number");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
        }
    }
}
