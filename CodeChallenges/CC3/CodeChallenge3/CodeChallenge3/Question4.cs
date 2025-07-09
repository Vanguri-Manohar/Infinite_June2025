using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    class Question4
    {
        public delegate int Calculator(int x, int y);

        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Subtract(int x, int y)
        {
            return x - y;
        }
        public static int Multiply(int x, int y)
        {
            return x * y;
        }
        static void Main()
        {
            Calculator add = new Calculator(Add);
            Calculator subtract = new Calculator(Subtract);
            Calculator multiply = new Calculator(Multiply);

            Console.Write("Enter First Number:");
            int n1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Number:");
            int n2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Addition: {add(n1, n2)}");
            Console.WriteLine($"Subtraction: {subtract(n1, n2)}");
            Console.WriteLine($"Multiplication: {multiply(n1, n2)}");
            Console.Read();

        }
     
    }
}
