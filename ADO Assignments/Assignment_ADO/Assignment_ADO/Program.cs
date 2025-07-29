using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_ADO
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
            this.DOJ = DOJ;
            this.City = City;
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
        static void DisplayEmployee(List<Employee> elist)
        {
            foreach(var x in elist)
            {
                x.Display();
            }
        }

        static List<Employee> Populate_Data()
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
            return empList;
        }
        static void Main(string[] args)
        {
            // To Display All the Details
            List<Employee> IterEmpList = Populate_Data();
            //DisplayEmployee(IterEmpList);


            //1. Display a list of all the employee who have joined before 1/1/2015

            var DOJEmp = IterEmpList.Where(emp => emp.DOJ < new DateTime(2015, 1, 1));
            DisplayEmployee(DOJEmp.ToList());

            Console.WriteLine("***************************************************************************************");
            // 2.Display a list of all the employee whose date of birth is after 1 / 1 / 1990

            var DOBEmp = IterEmpList.Where(emp => emp.DOB > new DateTime(1990, 1, 1)).ToList();
            DisplayEmployee(DOBEmp);

            Console.WriteLine("*****************************************************************************************");

            //3. Display a list of all the employee whose designation is Consultant and Associate
            var Desig = IterEmpList.Where(emp => emp.Title == "Consultant" || emp.Title=="Associate").ToList();
            DisplayEmployee(Desig);

            Console.WriteLine("*****************************************************************************************");

            //4. Display total number of employees

            int tot = IterEmpList.Count();
            Console.WriteLine("The total no of employees are {0}",tot);

            Console.WriteLine("*****************************************************************************************");

            //5. Display total number of employees belonging to “Chennai”

            var chennai = IterEmpList.FindAll(emp => emp.City == "Chennai").ToList();
            DisplayEmployee(chennai);
            Console.WriteLine($"The Count of Chennai Employees are {chennai.Count()}");

            Console.WriteLine("*****************************************************************************************");

            //6.Display highest employee id from the list

            int highestid = IterEmpList.Max(emp => emp.EmployeeID);
            Console.WriteLine($"The Highest Employee id is {highestid}");

            Console.WriteLine("*****************************************************************************************");

            //7. Display total number of employee who have joined after 1/1/2015

            var dojemp = IterEmpList.Count(emp => emp.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"The total employees are {dojemp}");
            Console.WriteLine("*****************************************************************************************");
            //8. Display total number of employee whose designation is not “Associate”
            int NotAssociate = IterEmpList.Count(emp => emp.Title != "Associate");
            Console.WriteLine($"The employees who are not associate are {NotAssociate}");
            //9. Display total number of employee based on City
            var totalCity = IterEmpList.GroupBy(emp => emp.City).Select(g => new { city = g.Key, Count = g.Count() });
            foreach(var x in totalCity)
            {
                Console.WriteLine($"The city is {x.city} and the count is {x.Count}");
            }

            Console.WriteLine("*****************************************************************************************");
            //10.Display total number of employee based on city and title


            var TotalEmp = IterEmpList
                .GroupBy(emp => new { emp.City, emp.Title })
                .Select(g => new { city = g.Key.City, title = g.Key.Title, Count = g.Count() });


            foreach (var x in TotalEmp)
            {
                Console.WriteLine($"The city is {x.city}, the title is {x.title}, the count is {x.Count}");
            }
            Console.WriteLine("*****************************************************************************************");

            //11. Display total number of employee who is youngest in the list

            var Yongest = IterEmpList.Max(emp => emp.DOB);
            var Yemp = IterEmpList.FindAll(emp => emp.DOB == Yongest);
            DisplayEmployee(Yemp);

            Console.ReadLine();

        }
    }
}
