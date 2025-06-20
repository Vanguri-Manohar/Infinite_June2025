using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Work
{
    class Question7
    {
        static void Main()

        {
            Console.WriteLine("Enter the String");
            string s = Convert.ToString(Console.ReadLine());
            Console.WriteLine("The length of the string  is {0}",s.Length);

            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("Enter the string to be reversed");
            string s1 = Convert.ToString(Console.ReadLine());
            string reversed = "";
            for(int i = s.Length - 1; i >= 0; i--)
            {
                reversed += s1[i];
            }
            Console.WriteLine("The reversed string is {0}",reversed);
            Console.WriteLine("___________________________________________________________________");

            Console.WriteLine("Enter the string 1");
            string string1 = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter the string 2");
            string string2 = Convert.ToString(Console.ReadLine());

            if (string1 == string2)
            {
                Console.WriteLine("Both strings are same");
            }
            else
            {
                Console.WriteLine("Both Strings are not same");
            }

            Console.Read();

        }
    }
}
