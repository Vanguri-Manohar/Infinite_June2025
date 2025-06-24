using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_Work
{
    class Question2
    {
        int RollNo;
        string Name;
        string Class;
        int semester;
        string branch;
        int[] Marks = new int[5];

        public Question2(int RollNo,string Name,string Class,int semester,string branch)
        {
            this.RollNo = RollNo;
            this.Name = Name;
            this.Class = Class;
            this.semester = semester;
            this.branch = branch;
        }

        public void GetMarks()
        {
            Console.WriteLine("Enter the Marks");
            for(int i = 0; i < Marks.Length; i++)
            {
                Console.WriteLine("Enter the Marks {0}",i+1);
                Marks[i] = int.Parse(Console.ReadLine());
            }
        }

        public void DisplayResults()
        {
            int total = 0;
            float avg;
            int check = 0;
            foreach(int i in Marks)
            {
                if (i < 35)
                {
                    check = 1;
                }
                total += i;
            }

            avg = total / Marks.Length;

            Console.WriteLine("Average of all the 5 subs is {0}",avg);
            Console.WriteLine("Results___________________");
            if (check == 1)
            {
                Console.WriteLine("Failed");
            }
            else if (check == 0 && avg<50)
            {
                Console.WriteLine("Result failed");
            }
            else
            {
                Console.WriteLine("Result Passed");
            }
        }

        public void DisplayData()
        {
            Console.WriteLine("-----------The Student Details----------");
            Console.WriteLine("Student Roll No:{0}", RollNo);
            Console.WriteLine("Student Name:{0}", Name);
            Console.WriteLine("Class:{0}", Class);
            Console.WriteLine("Semester:{0}", semester);
            Console.WriteLine("Branch:{0}",branch);
            Console.WriteLine("-----The 5 Subject Marks are:-----");
            foreach (int i in Marks)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            DisplayResults();
        }




        static void Main()
        {
            int rollno;
            string name;
            string Class;
            int semester;
            string branch;
            Console.WriteLine("Enter Student Roll No: ");
            rollno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Student Class: ");
            Class = Console.ReadLine();
            Console.WriteLine("Enter Semester: ");
            semester = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Branch: ");
            branch = Console.ReadLine();
            Question2 stu = new Question2(rollno, name, Class, semester, branch);
            stu.GetMarks();
            stu.DisplayData();
            Console.Read();

        }
    }
}
