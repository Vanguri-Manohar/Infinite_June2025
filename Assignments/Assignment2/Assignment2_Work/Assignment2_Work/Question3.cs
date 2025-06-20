using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Work
{
    enum days { Monday = 1, Tuesday = 2, Wednesday = 3, Thursady = 4, Friday = 5, Saturday = 6, Sunday = 7 }
    class Question3
    {
        static void Main()
        {
            Enumeration.Daycount();
            Console.Read();
        }

    }

    class Enumeration
    {
        public static void Daycount()
        {
            Console.WriteLine("Enter the day number");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num == 1)
            {
                Console.WriteLine(Enum.GetName(typeof(days), num));
            }
            else if (num == 2)
            {
                Console.WriteLine(Enum.GetName(typeof(days), num));
            }
            else if (num == 3)
            {
                Console.WriteLine(Enum.GetName(typeof(days), num));
            }
            else if (num == 4)
            {
                Console.WriteLine(Enum.GetName(typeof(days), num));
            }
            else if (num == 5)
            {
                Console.WriteLine(Enum.GetName(typeof(days), num));
            }
            else if (num == 6)
            {
                Console.WriteLine(Enum.GetName(typeof(days), num));
            }
            else if (num == 7)
            {
                Console.WriteLine(Enum.GetName(typeof(days), num));
            }
            else
            {
                Console.WriteLine("Invalid");
            }



        }
    }
}

