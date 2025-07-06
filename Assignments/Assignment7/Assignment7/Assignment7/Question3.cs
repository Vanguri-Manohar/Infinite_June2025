using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{

    class Employee
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string EmpCity { get; set; }

        public double EmpSalary { get; set; }

        public Employee(int Empid, string name, string Empcity, double Empsalary)
        {
            EmpID = Empid;
            Name = name;
            EmpCity = Empcity;
            EmpSalary = Empsalary;
        }

        public void DisplayData()
        {
            Console.WriteLine($"The id is {EmpID} and Name is {Name} and City is {EmpCity} and Salary is {EmpSalary}");
        }


    }
    class Q3
    {
        static void Main()
        {
            List<Employee> emp = new List<Employee>()
            {

            new Employee(1, "Alice", "Bangalore", 50000),
            new Employee(2, "Bob", "Hyderabad", 40000),
            new Employee(3, "Charlie", "Bangalore", 60000),
            new Employee(4, "David", "Chennai", 30000),
            new Employee(5, "Eve", "Mumbai", 70000)

            };
            Console.WriteLine("a.To display all employees data");
            foreach (var x in emp)
            {
                x.DisplayData();
            }


            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("b.To display all employees data whose salary is greater than 45000");
            var highSalaryEmployees = from e in emp
                                      where e.EmpSalary > 45000
                                      select e;


            foreach (var x in highSalaryEmployees)
            {
                x.DisplayData();
            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("c.To display all employees data who belong to Bangalore Region");



            var bangaloreEmployees = from e in emp
                                     where e.EmpCity.ToLower() == "bangalore"
                                     select e;
            foreach (var x in bangaloreEmployees)
            {
                x.DisplayData();
            }

            Console.WriteLine("------------------------------------");

            Console.WriteLine("d.To display all employees data by their names is Ascending order");

            var sortedEmployees = from e in emp
                                  orderby e.Name
                                  select e;
            foreach (var x in sortedEmployees)
            {
                x.DisplayData();
            }

            Console.ReadLine();
        }
    }
}
