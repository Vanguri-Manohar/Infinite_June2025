using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter the String");
            string str = Console.ReadLine();

            Console.WriteLine(SwapFisrtLast(str)); 

            Console.ReadLine();
        }

        public static string SwapFisrtLast(string str)
        {
            if (str.Length < 1)
            {
                return str;
            }

            char first = str[0];
            char last = str[str.Length - 1];
            string middle = "";
            for(int i = 1; i <=str.Length - 2; i++)
            {
                middle += str[i];
            }

            return last + middle + first;

        }
    }
}
