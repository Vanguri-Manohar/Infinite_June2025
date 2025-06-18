using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_dotnetproj
{
    class Controlstatements
    {
        #region
        static void Main()
        {
            //CheckGrade();
            //Checkgrades_with_switch();
            Iterationstatements iterationstatements = new Iterationstatements();
            iterationstatements.Whileloop();
            Console.WriteLine("............................");
            iterationstatements.DoWhileLoop();
            Console.WriteLine("............................");
            iterationstatements.ForLoop();
            Console.WriteLine(".......................");
            iterationstatements.ForeachLoop();

            Console.Read();
        }
        #endregion

        public static void CheckGrade()
        {
            char grade;
            Console.WriteLine("Enter the grade");
            //grade = Convert.ToChar(Console.ReadLine());
            grade = char.Parse(Console.ReadLine());
            if(grade=='O' || grade=='o')
                Console.WriteLine("outstanding");
            else if(grade=='A' || grade=='a')
                Console.WriteLine("Excellent");
            else if(grade=='B' || grade=='b')
                Console.WriteLine("Very Good");
            else if(grade=='C' || grade=='c')
                Console.WriteLine("Fair");
            else
                Console.WriteLine("invalid character");

        }

        public static void Checkgrades_with_switch()
        {
            char grade;
            Console.WriteLine("Enter the grade");
            grade = char.Parse(Console.ReadLine());
            switch (grade)
            {
                case 'O':
                case 'o':
                    Console.WriteLine("outstanding");
                    break;
                case 'A':
                case 'a':
                    Console.WriteLine("Excellent");
                    break;
                case 'B':
                case 'b':
                    Console.WriteLine("Very Good");
                    break;
                case 'C':
                case 'c':
                    Console.WriteLine("Fair");
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;

                    //multiple switch cases

                    //int intval = 0;
                    //string strval = "Hi";
                    //bool boolval = true;

                    //switch((intval, strval, boolval))
                    //{
                    //    case(0, "Hi", true):
                    //        Console.WriteLine("all met");
                    //        break;
                    //}

            }

    }
    }

    class Iterationstatements
    {
        public void Whileloop()
        {
            int i = 1;
            while (i < 5)
            {
                Console.WriteLine(i);
                i++;
            }
        }
        public void DoWhileLoop()
        {
            int i = 1;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 5);
        }

        public void ForLoop()
        {
            int tot = 0;
            for(int i = 0; i <= 5; i++)
            {
                if (i == 3)
                    //break;
                    continue;
                tot += i;
            }

            Console.WriteLine("The total sum is {0}",tot);
        }

        public void ForeachLoop()
        {
            int[] data = new int[] { 74, 4, 12, 0, 3 };
            Console.WriteLine(data.Length);
            Console.WriteLine("before sorting.............");
            foreach(int x in data)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("AFter Sorting......");
            Array.Sort(data);
            foreach(var x in data)
            {
                Console.WriteLine(x);
            }
        }
    }
}
