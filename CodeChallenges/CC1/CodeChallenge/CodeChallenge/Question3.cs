using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class Question3
    {
        static void Main()
        {
            Console.WriteLine("Enter 1st Number");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd Number");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 3rd Number");
            int c = int.Parse(Console.ReadLine());

            if(a>b && a > c)
            {
                Console.WriteLine($"{a},a is Greater" );
            }
            else if (b > c)
            {
                Console.WriteLine($"{b},b is Greater");
            }
            else
            {
                Console.WriteLine($"{c},c is Greater");
            }


            Console.ReadLine();

        }
    }
}
