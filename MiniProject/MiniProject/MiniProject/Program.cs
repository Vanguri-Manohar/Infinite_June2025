using System;

namespace MiniProj
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Railway Reservation System");
                Console.WriteLine("1. Login as Admin");
                Console.WriteLine("2. Login as User");
                Console.WriteLine("3.Register User");
                Console.WriteLine("4. Register Admin");
                Console.WriteLine("5.Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                Admin admin = new Admin();
                User user = new User();

                if (choice == 1) admin.AdminLogin();
                else if (choice == 2) user.UserLogin();
                else if (choice == 3) user.AddUser();
                else if (choice == 4) admin.AddAdmin();
                else if (choice == 5) break;
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
                }
            }
        }   

    }
}

