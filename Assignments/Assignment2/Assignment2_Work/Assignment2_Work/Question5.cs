using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Work
{
    class Question5
    {
        static void Main()
        {
            Array2.ArrayQuestion2();
            Console.Read();
        }
    }

    class Array2
    {
        public static void ArrayQuestion2()
        {
            Console.WriteLine("Enter the size of the array");
            int size = int.Parse(Console.ReadLine());

            int[] arraymembers = new int[size];

            for(int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the element {0}",i+1);
                arraymembers[i] = int.Parse(Console.ReadLine());

            }

            int total = 0;
            for (int i = 0; i < size; i++)
            {
                total += arraymembers[i];
            }

            int Average = total / size;
            Console.WriteLine("The average is {0}", Average);
            Console.WriteLine("The total is {0}",total);

            int min = arraymembers[0];
            int max = arraymembers[0];
            for (int i = 1; i < arraymembers.Length; i++)
            {
                if (arraymembers[i] < min)
                {
                    min = arraymembers[i];
                }
                if (arraymembers[i] > max)
                {
                    max = arraymembers[i];
                }
            }

            Console.WriteLine("The minimum Element is {0}", min);
            Console.WriteLine("The maximum Element is {0}", max);

            Array.Sort(arraymembers);
            Console.WriteLine("The elements are in ascending order");
            for (int i = 0; i < arraymembers.Length; i++)
            {
                Console.WriteLine(arraymembers[i]);
            }
            Console.WriteLine("The elements are in descending order");

            for(int i = arraymembers.Length-1; i>=0; i--)
            {
                Console.WriteLine(arraymembers[i]);
            }

        }

    }
}
