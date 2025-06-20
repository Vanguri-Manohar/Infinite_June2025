using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Work
{
    class Question4
    {
        static void Main()
        {
            ArrayQuestion1.Array1();
            Console.Read();
        }

    }

    class ArrayQuestion1
    {
        public static void Array1()
        {
            Console.WriteLine("Enter the Size of the array");
            int size = int.Parse(Console.ReadLine());

            int[] arrayelements = new int[size];

            Console.WriteLine("Enter the elements ");

            for(int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the element {0}",i+1);
                arrayelements[i] = int.Parse(Console.ReadLine());
            }
            int total = 0;
            for(int i = 0; i < size; i++)
            {
                total += arrayelements[i];
            }

            int Average = total / size;
            Console.WriteLine("The average is {0}",Average);

            int min = arrayelements[0];
            int max = arrayelements[0];
            for(int i = 1; i < arrayelements.Length; i++)
            {
                if (arrayelements[i] < min)
                {
                    min = arrayelements[i];
                }
                if (arrayelements[i] > max)
                {
                    max = arrayelements[i];
                }
            }

            Console.WriteLine("The minimum Element is {0}",min);
            Console.WriteLine("The maximum Element is {0}",max);
        }

       
    }
        

}
