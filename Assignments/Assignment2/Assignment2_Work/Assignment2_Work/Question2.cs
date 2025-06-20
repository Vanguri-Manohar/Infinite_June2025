using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Work
{
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter a digit ");
            int num1 = int.Parse(Console.ReadLine());
            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0} {0} {0} {0}",num1,num1,num1,num1);
                Console.WriteLine("{0}{0}{0}{0}", num1, num1, num1, num1);
            }

            Console.Read();


        }


    }
}
