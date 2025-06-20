using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Work
{
    class Question6
    {
        static void Main()
        {
            Array3.Array3Question();
            Console.Read();

        }
    }

    class Array3
    {
        public static void Array3Question()
        {
            Console.WriteLine("enter the size of the array");
            int size = int.Parse(Console.ReadLine());
            int[] array1 = new int[size];
            int[] array2 = new int[size];

            for(int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the element {0}",i+1);
                array1[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Original array");
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine(array1[i]);
            }

            for (int i = 0; i < size; i++)
            {
                array2[i]=array1[i];
            }

            Console.WriteLine("The copied array is");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(array2[i]);
            }

        }
    }
}
