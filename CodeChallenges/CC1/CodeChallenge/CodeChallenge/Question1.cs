using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the String");
            string str = Console.ReadLine();
            Console.WriteLine("Enter the index to be removed");
            int ind = int.Parse(Console.ReadLine());

            string result = str.Remove(ind, 1);
            Console.WriteLine("Resulting string: " + result);


            Console.ReadLine();




        }
    }
}
