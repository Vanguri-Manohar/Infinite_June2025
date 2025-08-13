using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiniProj
{
    public class Admin
    {
        static string connectionString = "Data Source=ICS-LT-D72BJ84\\SQLEXPRESS;Initial Catalog=Assignment1;user id=sa;password=Manohar@2004; ";


        internal void AdminLogin()
        {
            Console.Write("Enter admin username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string role = AuthenticateAdmin(username, password);
            if (role == "admin")
            {
                Console.WriteLine($"Login successful. Welcome, {username} ({role})");
                AdminMenu();
            }
            else Console.WriteLine("Invalid admin credentials.");
        }

        public static string AuthenticateAdmin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT role FROM Admins WHERE username = @username AND password = @password", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.Read() ? reader["role"].ToString() : null;
            }
        }
        internal void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu");
                Console.WriteLine("1. View Bookings");
                Console.WriteLine("2. View Cancellations");
                Console.WriteLine("3. Add Train");
                Console.WriteLine("4. Update Train");
                Console.WriteLine("5. Delete Train");

                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: ViewBookings(); break;
                    case 2: ViewCancellations(); break;
                    case 3: AddTrain(); break;
                    case 4: UpdateTrain(); break;
                    case 5: DeleteTrain(); break;
                    case 6: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }
        internal void AddAdmin()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                Console.WriteLine("Enter Admin Name");
                string uname = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string pw = Console.ReadLine();
                SqlCommand cmd = new SqlCommand("Insert into admins(username,pasword,roles) values(@uname,@pw,'admin')", con);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pw", pw);
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    Console.WriteLine("Successfully inserted Admin");
                }
                else
                {
                    Console.WriteLine("Not Inserted");
                }

            }
        }
        internal void ViewBookings()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings WHERE status = 'active'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Booking ID: {reader["booking_id"]}, Train No: {reader["tno"]}, User ID: {reader["userid"]}, Seats: {reader["seats_booked"]}, Date: {reader["booking_date"]},Name: {reader["Name"]}");
                }
            }
        }

        internal void ViewCancellations()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cancellations WHERE status= 'active'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Cancellation ID: {reader["cancellation_id"]}, Booking ID: {reader["booking_id"]}, Seats Cancelled: {reader["seats_cancelled"]}, Date: {reader["cancellation_date"]}");
                }
            }
        }

        internal void AddTrain()
        {
            Console.Write("Enter Train Number: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter From Station: ");
            string from = Console.ReadLine();
            Console.Write("Enter Destination Station: ");
            string dest = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Class of Travel: ");
            string classOfTravel = Console.ReadLine();
            Console.Write("Enter Train Status (active/inactive): ");
            string trainStatus = Console.ReadLine();
            Console.Write("Enter Number of Seats Available: ");
            int seatsAvailable = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Trains (tno, tname, [from], dest, price, class_of_travel, train_status, seats_available) VALUES (@tno, @tname, @from, @dest, @price, @class_of_travel, @train_status, @seats_available)", con);
                cmd.Parameters.AddWithValue("@tno", trainNumber);
                cmd.Parameters.AddWithValue("@tname", trainName);
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@dest", dest);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@class_of_travel", classOfTravel);
                cmd.Parameters.AddWithValue("@train_status", trainStatus);
                cmd.Parameters.AddWithValue("@seats_available", seatsAvailable);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Train added successfully.");
            }
        }

        internal void UpdateTrain()
        {
            Console.Write("Enter Train Number to update: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Train Name");
            Console.WriteLine("2. From Station");
            Console.WriteLine("3. Destination Station");
            Console.WriteLine("4. Price");
            Console.WriteLine("5. Class of Travel");
            Console.WriteLine("6. Train Status(active/inactive)");
            Console.WriteLine("7. Seats Available");
           
            Console.Write("Enter your choice (1-7): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            string column = "";
            object newValue;
        

            switch (choice)
            {
                case 1:
                    column = "tname";
                    Console.Write("Enter new Train Name: ");
                    newValue = Console.ReadLine();
                    break;
                case 2:
                    column = "[from]";
                    Console.Write("Enter new From Station: ");
                    newValue = Console.ReadLine();
                    break;
                case 3:
                    column = "dest";
                    Console.Write("Enter new Destination Station: ");
                    newValue = Console.ReadLine();
                    break;
                case 4:
                    column = "price";
                    Console.Write("Enter new Price: ");
                    newValue = decimal.Parse(Console.ReadLine());
                    break;
                case 5:
                    column = "class_of_travel";
                    Console.Write("Enter new Class of Travel: ");
                    newValue = Console.ReadLine();
                    break;
                case 6:
                    column = "train_status";
                    Console.Write("Enter new status of Travel(active/inactive): ");
                    newValue = Console.ReadLine().ToLower();
                    break;
                case 7:
                    column = "seats_available";
                    Console.Write("Enter new Number of Seats Available: ");
                    newValue = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"UPDATE Trains SET {column} = @newValue WHERE tno = @tno";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@newValue", newValue);
                cmd.Parameters.AddWithValue("@tno", trainNumber);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine(rowsAffected > 0 ? "Train updated successfully." : "Train update failed.");
            }
        }

        internal void DeleteTrain()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                Console.WriteLine("Enter Train Number to Delete");
                int trainno = int.Parse(Console.ReadLine());
                SqlCommand cmd = new SqlCommand("Update Trains set train_status='inactive' where tno=@trainno", con);
                cmd.Parameters.AddWithValue("@trainno", trainno);
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    Console.WriteLine($"Successfully Deleted The train {trainno}");
                }
                else
                {
                    Console.WriteLine("Train Not Found");
                }

            }
        }
    }
}
