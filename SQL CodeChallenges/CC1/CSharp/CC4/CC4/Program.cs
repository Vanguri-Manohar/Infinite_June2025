using System;
using System.Collections.Generic;
using System.Linq;

namespace CC4
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public Employee(int EmployeeID, string FirstName, string LastName, string Title, DateTime DOB, DateTime DOJ, string City)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.DOB = DOB;
            this.City=City;
        }

        public void Display()
        {
            Console.WriteLine($"EmployeeID: {EmployeeID}");
            Console.WriteLine($"FirstName: {FirstName}");
            Console.WriteLine($"LastName: {LastName}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"DOB: {DOB.ToShortDateString()}");
            Console.WriteLine($"DOJ: {DOJ.ToShortDateString()}");
            Console.WriteLine($"City: {City}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void DisplayList(List<Employee> employeeList)
        {
            foreach (var emp in employeeList)
            {
                emp.Display();
            }
        }

        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee(1001, "Malcolm", "Daruwalla", "Manager", Convert.ToDateTime("16-11-1984"), Convert.ToDateTime("08-06-2011"), "Mumbai"),
                new Employee(1002, "Asdin", "Dhalla", "AsstManager", Convert.ToDateTime("20-08-1994"), Convert.ToDateTime("07-07-2012"), "Mumbai"),
                new Employee(1003, "Madhavi", "Oza", "Consultant", Convert.ToDateTime("14-11-1987"), Convert.ToDateTime("12-04-2015"), "Pune"),
                new Employee(1004, "Saba", "Shaikh", "SE", Convert.ToDateTime("03-06-1990"), Convert.ToDateTime("02-02-2016"), "Pune"),
                new Employee(1005, "Nazia", "Shaikh", "SE", Convert.ToDateTime("08-03-1991"), Convert.ToDateTime("02-02-2016"), "Mumbai"),
                new Employee(1006, "Amit", "Pathak", "Consultant", Convert.ToDateTime("07-11-1989"), Convert.ToDateTime("08-08-2014"), "Chennai"),
                new Employee(1007, "Vijay", "Natrajan", "Consultant", Convert.ToDateTime("02-12-1989"), Convert.ToDateTime("01-06-2015"), "Mumbai"),
                new Employee(1008, "Rahul", "Dubey", "Associate", Convert.ToDateTime("11-11-1993"), Convert.ToDateTime("06-11-2014"), "Chennai"),
                new Employee(1009, "Suresh", "Mistry", "Associate", Convert.ToDateTime("12-08-1992"), Convert.ToDateTime("03-12-2014"), "Chennai"),
                new Employee(1010, "Sumit", "Shah", "Manager", Convert.ToDateTime("12-04-1991"), Convert.ToDateTime("02-01-2016"), "Pune")
            };

            // a. Display detail of all the employee
            Console.WriteLine("a. Display detail of all the employee");
            DisplayList(empList);

            Console.WriteLine("-------------------------------------------------------------");

            // b. Display details of all the employee whose location is not Mumbai
            Console.WriteLine("b. Display details of all the employee whose location is not Mumbai");
            var nonMumbai = empList.Where(emp => emp.City != "Mumbai").ToList();
            DisplayList(nonMumbai);

            Console.WriteLine("-------------------------------------------------------------");

            // c. Display details of all the employee whose title is AsstManager
            Console.WriteLine("c. Display details of all the employee whose title is AsstManager");
            var asstManagerList = empList.Where(e => e.Title == "AsstManager").ToList();
            DisplayList(asstManagerList);

            Console.WriteLine("-------------------------------------------------------------");

            // d. Display details of all the employee whose Last Name start with S
            Console.WriteLine("d. Display details of all the employee whose Last Name start with S");
            var lastNameList = empList.Where(e => e.LastName.StartsWith("S")).ToList();
            DisplayList(lastNameList);

            Console.ReadLine();
        }
    }
}
