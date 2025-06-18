using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_dotnetproj
{
    class Program
    {
        static void Main(string[] args)

        {
            // ConversionFunction();
            //Program prog = new Program();
            //prog.Sample();
            //Trytestparse.tryparse_Function();
            Trytestparse.nullableExample();
            Console.Read();
        }
        public static void ConversionFunction()   //static member or class member
        {
            Console.WriteLine("Min int value={0}",int.MaxValue);
            Console.WriteLine("Max value of int={0}",int.MinValue );

            int i = 100;
            float f = i;// implicit conversion 
            float f2 = 123.45f;
            i = (int)f2;
            Console.WriteLine(i);
            i = Convert.ToInt32(f2);
            Console.WriteLine(i);


            Console.WriteLine("enter the num");
            int num = int.Parse(Console.ReadLine());
           // int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter the marks");
            float marks = float.Parse(Console.ReadLine());
            //float marks = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("num={0},marks={1}",num,marks);
        }
        public void Sample()
        {
            Console.WriteLine("enter the number");
            int number = int.Parse(Console.ReadLine());
            bool b;
            if (number == 10)
            {
                b = true;
            }
            else
            {
                b = false;
            }
           // b = number == 10 ? true : false;
            Console.WriteLine("number =10 {0}",b);
        }

        class Trytestparse
        {
            public static void tryparse_Function()
            {
                float data = 3434567825674.77f;
                int x = (int)data;
                Console.WriteLine(x);

                string str = "100mg";
                //x = int.Parse(str);

                int result;
                bool status;
                status = int.TryParse(str, out result);
                if (status)
                {
                    Console.WriteLine($"status is {status} and result is {result}");
                }
                else
                {
                    Console.WriteLine("Invalid code.....");
                }
            }
            public static void Box_unBox()
            {
                int i = 10;
                object obj = i; //boxing 

                i = (int)obj;//unboxing

            }
            public static void Implicit_types()
            {
                int x;
                x = 8;

                var v = 10;
                dynamic d = 10;
                Console.WriteLine(d);
            }
            public static void nullableExample()
            {
                int ? ticketsonsale=Convert.ToInt32(Console.ReadLine());
                int availabletickets;
                //enabling a value type to have null values
                
                if (ticketsonsale == null)
                {
                    availabletickets = 0;
                }
                else
                {
                    availabletickets = ticketsonsale.Value;// or
                    //total=number.Value
                    //total = number ?? 0; number is assaigned to total if it is not null

                    
                }
                Console.WriteLine(availabletickets);
                Console.Read();
            }
        }
    }
}
