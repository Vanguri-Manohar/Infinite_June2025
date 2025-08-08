using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiniProj
{
    class Program
    {

        static string connectionString = "Data Source=ICS-LT-D72BJ84\\SQLEXPRESS;Initial Catalog=Assignment1;user id=sa;password=Manohar@2004; ";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Railway Reservation System");
                Console.WriteLine("1. Login as Admin");
                Console.WriteLine("2. Login as User");
                Console.WriteLine("3.Add New User");
                Console.WriteLine("4. Add New Admin");
                Console.WriteLine("5.Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1) AdminLogin();
                else if (choice == 2) UserLogin();
                else if (choice == 3) AddUser();
                else if (choice == 4) AddAdmin();
                else if (choice == 5) break;
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
                }
            }
        }

        static void AdminLogin()
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

        static string AuthenticateAdmin(string username, string password)
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

        static void UserLogin()
        {
            Console.Write("Enter user username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string role = AuthenticateUser(username, password);
            if (role == "user")
            {
                Console.WriteLine($"Login successful. Welcome, {username} ({role})");
                UserMenu();
            }
            else Console.WriteLine("Invalid user credentials.");
        }

        static string AuthenticateUser(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT role FROM Users WHERE username = @username AND password = @password", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.Read() ? reader["role"].ToString() : null;
            }
        }



        static void AdminMenu()
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
                    case 5:DeleteTrain(); break;
                    case 6: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu");
                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Trains");            
                Console.WriteLine("4.Logout");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: ViewTrains();break;
                    case 2: BookTickets(); break;
                    case 3: CancelTickets(); break;
                    case 4:return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void AddUser()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                Console.WriteLine("Enter User Name");
                string uname = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string pw = Console.ReadLine();
                SqlCommand cmd = new SqlCommand("Insert into Users(username,pasword,roles) values(@uname,@pw,'user')", con);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pw", pw);
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    Console.WriteLine("Successfully inserted user");
                }
                else
                {
                    Console.WriteLine("Not Inserted");
                }

            }
        }

        static void AddAdmin()
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

       
        static void ViewTrains()
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Trains where train_status='active'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Train No:{reader["tno"]}, Train Name:{reader["tname"]}, From:{reader["from"]}, To:{reader["dest"]}" +
                        $"Price:{reader["price"]}, Class_To_Travel :{reader["class_of_travel"]}, Train_status: {reader["train_status"]}," +
                        $"Seats_Available:{reader["seats_available"]}");
                }


            }
        }
     
        static void ViewBookings()
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

        static void ViewCancellations()
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

        static void AddTrain()
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

        static void UpdateTrain()
        {
            Console.Write("Enter Train Number to update: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Train Name");
            Console.WriteLine("2. From Station");
            Console.WriteLine("3. Destination Station");
            Console.WriteLine("4. Price");
            Console.WriteLine("5. Class of Travel");
            Console.WriteLine("6. Train Status");
            Console.WriteLine("7. Seats Available");
            Console.Write("Enter your choice (1-7): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            string column = "";
            object newValue;
            if (choice == 6)
            {
                DeleteTrain();
                return;
            }

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

        static void DeleteTrain()
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


        static void BookTickets()
        {
            Console.Write("Enter your User ID: ");
            int userid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter The Name of the Person");
            string Name = Console.ReadLine();
            Console.Write("Enter Train Number: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of seats to book (max 3): ");
            int seatsToBook = Convert.ToInt32(Console.ReadLine());

            if (seatsToBook > 3)
            {
                Console.WriteLine("Cannot book more than 3 seats at a time.");
                return;
            }


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand userCheckCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE userid = @userid", con);
                userCheckCmd.Parameters.AddWithValue("@userid", userid);
                int userExists = (int)userCheckCmd.ExecuteScalar();

                if (userExists == 0)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                SqlCommand checkCmd = new SqlCommand("SELECT * FROM Trains WHERE tno = @tno AND train_status = 'active'", con);
                checkCmd.Parameters.AddWithValue("@tno", trainNumber);
                SqlDataReader reader = checkCmd.ExecuteReader();

                
                    if (reader.Read())
                    {
                        int seatsAvailable = (int)reader["seats_available"];
                        string class_of_travel = reader["class_of_travel"].ToString();
                        decimal pricePerSeat = (decimal)reader["price"];
                        string TrainName = reader["tname"].ToString();
                        reader.Close();

                        if (seatsAvailable < seatsToBook)
                        {
                            Console.WriteLine("Not enough seats available.");
                            return;
                        }


                     SqlCommand bookCmd = new SqlCommand(
                        "INSERT INTO Bookings (tno, userid, seats_booked, booking_date, Name) " +
                        "VALUES (@tno, @userid, @seats_booked, @booking_date, @Name); " +
                        "SELECT SCOPE_IDENTITY();", con);

                        bookCmd.Parameters.AddWithValue("@tno", trainNumber);
                        bookCmd.Parameters.AddWithValue("@userid", userid);
                        bookCmd.Parameters.AddWithValue("@seats_booked", seatsToBook);
                        bookCmd.Parameters.AddWithValue("@booking_date", DateTime.Now);
                        bookCmd.Parameters.AddWithValue("@Name", Name);
                     
                        int booking_id = Convert.ToInt32(bookCmd.ExecuteScalar());
                    
                        

                        SqlCommand updateCmd = new SqlCommand("UPDATE Trains SET seats_available = seats_available - @seats_booked WHERE tno = @tno", con);
                        updateCmd.Parameters.AddWithValue("@seats_booked", seatsToBook);
                        updateCmd.Parameters.AddWithValue("@tno", trainNumber);
                        updateCmd.ExecuteNonQuery();

                   

                        Console.WriteLine("Booking successful.");

                        Console.WriteLine($"*************** The Bill of {Name}********************");



                        decimal totalFare = pricePerSeat * seatsToBook;
                        Console.WriteLine("\n===== Booking Bill  =====");

                        Console.WriteLine($"Booking_id   :  {booking_id}");
                        Console.WriteLine($"Train Number   : {trainNumber}");
                        Console.WriteLine($"Train Name     : {TrainName}");
                        Console.WriteLine($"Class          : {class_of_travel }");
                        Console.WriteLine($"Seats Booked   : {seatsToBook}");
                        Console.WriteLine($"Price per Seat : ₹{pricePerSeat}");
                        Console.WriteLine($"Total Fare     : ₹{totalFare}");
                        Console.WriteLine($"Booking Date   : {DateTime.Now}");



                    }
                
                else Console.WriteLine("Train or user not found or Train inactive.");
            }
        }

        static void CancelTickets()
        {
            Console.Write("Enter Booking ID: ");
            int bookingId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of seats to cancel: ");
            int seatsToCancel = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT tno, seats_booked, booking_date FROM Bookings WHERE booking_id = @booking_id", con);
                checkCmd.Parameters.AddWithValue("@booking_id", bookingId);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.Read())
                {
                    int trainNumber = (int)reader["tno"];
                    int seatsBooked = (int)reader["seats_booked"];
                    DateTime bookingDate = (DateTime)reader["booking_date"];
                    reader.Close();

                    if (seatsToCancel > seatsBooked)
                    {
                        Console.WriteLine("Cannot cancel more seats than booked.");
                        return;
                    }

                    TimeSpan timeBeforeTravel = bookingDate - DateTime.Now;
                    decimal refundRate = 0;
                    if (timeBeforeTravel.TotalDays > 90) refundRate = 0.50m;
                    else if (timeBeforeTravel.TotalDays > 30) refundRate = 0.25m;
                    else refundRate = 0.00m;

                    decimal refundAmount = seatsToCancel * refundRate * 100;

                    SqlCommand cancelCmd = new SqlCommand("INSERT INTO Cancellations (booking_id, seats_cancelled, cancellation_date) VALUES (@booking_id, @seats_cancelled, @cancellation_date)", con);
                    cancelCmd.Parameters.AddWithValue("@booking_id", bookingId);
                    cancelCmd.Parameters.AddWithValue("@seats_cancelled", seatsToCancel);
                    cancelCmd.Parameters.AddWithValue("@cancellation_date", DateTime.Now);
                    cancelCmd.ExecuteNonQuery();

                    SqlCommand updateTrainCmd = new SqlCommand("UPDATE Trains SET seats_available = seats_available + @seats_cancelled WHERE tno = @tno", con);
                    updateTrainCmd.Parameters.AddWithValue("@seats_cancelled", seatsToCancel);
                    updateTrainCmd.Parameters.AddWithValue("@tno", trainNumber);
                    updateTrainCmd.ExecuteNonQuery();

                    SqlCommand updateBookingCmd = new SqlCommand("UPDATE Bookings SET seats_booked = seats_booked - @seats_cancelled WHERE booking_id = @booking_id", con);
                    updateBookingCmd.Parameters.AddWithValue("@seats_cancelled", seatsToCancel);
                    updateBookingCmd.Parameters.AddWithValue("@booking_id", bookingId);
                    updateBookingCmd.ExecuteNonQuery();

                    Console.WriteLine($"Cancellation successful. Refund Amount: ₹{refundAmount}");
                }
                else Console.WriteLine("Booking not found.");
            }
        }
    }
}

