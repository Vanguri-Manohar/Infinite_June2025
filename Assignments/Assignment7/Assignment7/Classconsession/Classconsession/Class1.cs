using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classconsession
{
    public class Class1
    {
        public void CalculateConcession(int constant, string Name, int age)
        {
            if (age <= 5)
            {
                Console.WriteLine("Little Champs - Free Ticket");
            }

            else if (age > 60)
            {
                float consession = 0.3f * constant;
                Console.WriteLine($"Senior citizen: {500 - consession} Name:{Name}");
            }
            else
            {
                Console.WriteLine("Print Ticket Booked{0}", constant);
            }

        }
    }
}
