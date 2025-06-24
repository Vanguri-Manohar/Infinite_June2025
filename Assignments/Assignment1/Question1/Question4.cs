using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Question4
    {
        static void Main()
        {
            Console.WriteLine("Enter the number");
            int num = int.Parse(Console.ReadLine());
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} * {i} = {num*i}");
                
            }
            Console.ReadLine();
        }
    }
}
