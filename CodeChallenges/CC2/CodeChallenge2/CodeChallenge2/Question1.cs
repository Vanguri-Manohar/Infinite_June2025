using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public Student(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, double grade)
        : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade)
        : base(name, studentId, grade) { }

        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter student type (Undergraduate/Graduate): ");
            string type = Console.ReadLine();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter grade: ");
            double grade = double.Parse(Console.ReadLine());

            Student student;

            if (type.ToLower() == "undergraduate")
            {
                student = new Undergraduate(name, id, grade);
            }
            else if (type.ToLower() == "graduate")
            {
                student = new Graduate(name, id, grade);
            }
            else
            {
                Console.WriteLine("Invalid student type.");
                return;
            }

            Console.WriteLine($"{student.Name} Passed: {student.IsPassed(student.Grade)}");

            Console.ReadLine();
        }
    }

}





