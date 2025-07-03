using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
    class NegativeValueException : Exception
    {
        public NegativeValueException()
        {
            Console.WriteLine("Negative Value Cannot be Passed");
        }
    }
    class Question3
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter the number");
                int number=int.Parse(Console.ReadLine());
                if (number > 0)
                {
                    Console.WriteLine($"{number} The number is Positive");
                }
                else
                {
                    throw new NegativeValueException();
                }
            }

            catch(NegativeValueException Nv)
            {
                Console.WriteLine("Error: "+Nv.Message);
            }
            Console.ReadLine();
        }

       
    }
}
