using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Q2
    {
        static void Main()
        {
            Console.WriteLine("Enter the Size");
            int size = int.Parse(Console.ReadLine());
            string[] str = new string[size];


            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine($"Enter the element {i + 1} in the array ");
                str[i] = Console.ReadLine();
            }


            var filteredWords = from word in str
                                where word.StartsWith("a") && word.EndsWith("m")
                                select word;


            foreach (var word in filteredWords)
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();

        }
    }
}
