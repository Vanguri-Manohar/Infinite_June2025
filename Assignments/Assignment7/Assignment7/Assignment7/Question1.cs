using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Asssignment2Q1
    {
        public static void Main()
        {
            Console.WriteLine("Enter the Size");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Enter the element {i + 1} in the array ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            IEnumerable<int> Squares = from v in arr where (v * v) > 20 select v;

            foreach (int x in Squares)
            {
                Console.WriteLine($"{x}--->{x * x}");
            }

            Console.ReadLine();
        }
    }
}
