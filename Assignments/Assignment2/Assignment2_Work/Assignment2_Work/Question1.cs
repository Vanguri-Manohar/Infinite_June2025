using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Work
{
    class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the 1st number");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Before Swapping the numbers are {0} {1}",num1,num2);

            int temp;
            temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine("After swapping the numbers are {0} {1}",num1,num2);

            Console.Read();

        }
    }
}
