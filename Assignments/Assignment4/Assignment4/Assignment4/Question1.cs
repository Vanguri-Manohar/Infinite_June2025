﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Scenario: Employee Management System (Console-Based)
-----------------------------------------------------
You are tasked with developing a simple console-based Employee Management System using C# that allows users to manage a list of employees. Use a menu-driven approach to perform CRUD operations on a List<Employee>.

Each Employee has the following properties:

int Id

string Name

string Department

double Salary
 Functional Requirements
Design a menu that repeatedly prompts the user to choose one of the following actions:


===== Employee Management Menu =====
1. Add New Employee
2. View All Employees
3. Search Employee by ID
4. Update Employee Details
5. Delete Employee
6. Exit
====================================
Enter your choice:

 Task:
Write a C# program using:

A class Employee with the above properties.

A List<Employee> to hold all employee records.

A menu-based loop to allow the user to perform the following:

✅ Expected Functionalities (CRUD)

1.Prompt the user to enter details for a new employee and add it to the list.


2.Display all employees 

3.Allow searching an employee by Id and display their details.

4.Search for an employee by Id, and if found, allow the user to update name, department, or salary.

5.Search for an employee by Id and remove the employee from the list.

6.Cleanly exit the program.

Use Exception handling Mechanism
*/
namespace Assignment4
{
    class Employeee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public double Salary { get; set; }

        List<Employeee> emplist = new List<Employeee>();

        internal void Add_New_Employee(Employeee emp)
        {
            emplist.Add(emp);
        }

        internal void View_All_Employees()
        {
            foreach (var i in emplist)
            {
                Console.WriteLine("Employee List");
                Console.WriteLine(i.Id + " " + i.Name + " " + i.Salary + " " + i.Department);
            }
        }

        internal void Search_Employee_by_ID(int a)
        {
            foreach (var i in emplist)
            {
                if (i.Id == a)
                {
                    Console.WriteLine(i.Id + " " + i.Name + " " + i.Salary + " " + i.Department);
                }
            }
        }

        internal void Update(Employeee emp1, Employeee emp)
        {
            foreach (var i in emplist)
            {
                if (i == emp1)
                {
                    emp1.Department = emp.Department;
                    emp1.Id = emp.Id;
                    emp1.Name = emp.Name;
                    emp1.Salary = emp.Salary;
                    break;
                }
            }
        }

        internal void Delete(Employeee emp)
        {
            emplist.Remove(emp);
        }

        internal Employeee GetEmployeeById(int id)
        {
            return emplist.FirstOrDefault(e => e.Id == id);
        }
    }

    class Task
    {
        public static void Main()
        {
            Employeee employeee = new Employeee();
        yrr: Console.WriteLine();
            Console.WriteLine("===== Employee Management Menu =====\n" +
                "1. Add New Employee\n" +
                "2. View All Employees\n" +
                "3. Search Employee by ID\n" +
                "4. Update Employee Details\n" +
                "5. Delete Employee\n" +
                "6. Exit\n" +
                "-------------------------\n" +
                "Enter your choice:");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Employeee o = new Employeee();
                    Console.WriteLine("Enter Name");
                    o.Name = Console.ReadLine();
                    Console.WriteLine("Enter Id");
                    o.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter department");
                    o.Department = Console.ReadLine();
                    Console.WriteLine("Enter Salary");
                    o.Salary = Convert.ToDouble(Console.ReadLine());
                    employeee.Add_New_Employee(o);
                    goto yrr;
                    break;

                case 2:
                    employeee.View_All_Employees();
                    goto yrr;
                    break;

                case 3:
                    Console.WriteLine("Enter Id:");
                    int w = Convert.ToInt32(Console.ReadLine());
                    employeee.Search_Employee_by_ID(w);
                    goto yrr;
                    break;

                case 4:
                    Console.WriteLine("Enter the ID of the employee to update:");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Employeee existingEmp = employeee.GetEmployeeById(updateId);
                    if (existingEmp != null)
                    {
                        Employeee updatedEmp = new Employeee();
                        Console.WriteLine("Enter new Name:");
                        updatedEmp.Name = Console.ReadLine();
                        Console.WriteLine("Enter new Id:");
                        updatedEmp.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new Department:");
                        updatedEmp.Department = Console.ReadLine();
                        Console.WriteLine("Enter new Salary:");
                        updatedEmp.Salary = Convert.ToDouble(Console.ReadLine());
                        employeee.Update(existingEmp, updatedEmp);
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }
                    goto yrr;
                    break;

                case 5:
                    Console.WriteLine("Enter the employee Id to be removed from List");
                    int e = Convert.ToInt32(Console.ReadLine());
                    Employeee empToDelete = employeee.GetEmployeeById(e);
                    if (empToDelete != null)
                    {
                        employeee.Delete(empToDelete);
                        Console.WriteLine("Employee deleted .");
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }
                    goto yrr;
                    break;

                case 6:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    goto yrr;
                    break;
            }
            Console.Read();
        }
    }
}
