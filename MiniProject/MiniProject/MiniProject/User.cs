using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiniProj
{
    public class User
    {
        static string connectionString = "Data Source=ICS-LT-D72BJ84\\SQLEXPRESS;Initial Catalog=Assignment1;user id=sa;password=Manohar@2004; ";
        static int currentUserId = -1;
        internal void UserLogin()
        {
            Console.Write("Enter user username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var result = AuthenticateUser(username, password);
            if (result.role == "user")
            {
                currentUserId = result.userId;
                Console.WriteLine($"Login successful. Welcome, {username} ({result.role}) ({result.userId})");
                UserMenu();
            }
            else Console.WriteLine("Invalid user credentials.");
        }
        public static (string role, int userId) AuthenticateUser(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT role, userid FROM Users WHERE username = @username AND password = @password", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string role = reader["role"].ToString();
                    int userId = (int)reader["userid"];
                    return (role, userId);
                }
                return (null, -1);
            }
        }

        internal void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu");
                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Tickets");
                Console.WriteLine("4.Logout");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: ViewTrains(); break;
                    case 2: BookTickets(); break;
                    case 3: CancelTickets(); break;
                    case 4: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        internal void AddUser()
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

        internal void ViewTrains()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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

        internal void BookTickets()
        {
            Console.Write("Enter your User ID: ");
            int userid = Convert.ToInt32(Console.ReadLine());


            if (userid != currentUserId)
            {
                Console.WriteLine("You are not authorized to book tickets with this User ID.");
                return;
            }

            Console.WriteLine("Enter The Name of the Person");
            string Name = Console.ReadLine();
            Console.Write("Enter Train Number: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of seats to book (max 3): ");
            int seatsToBook = Convert.ToInt32(Console.ReadLine());
            EnterData:
            Console.Write("Enter Journey date (yyyy-MM-dd): ");
            DateTime bookingDate;
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), out bookingDate);

            if (!isValidDate)
            {
                Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
                goto EnterData;
            }

            if (bookingDate.Date < DateTime.Today)
            {
                Console.WriteLine("Journey date cannot be in the past. Please enter a valid future date.");
                goto EnterData;
            }



            if (seatsToBook > 3)
            {
                Console.WriteLine("Cannot book more than 3 seats at a time.");
                return;
            }


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();


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
                    bookCmd.Parameters.AddWithValue("@booking_date", bookingDate);
                    bookCmd.Parameters.AddWithValue("@Name", Name);

                    int booking_id = Convert.ToInt32(bookCmd.ExecuteScalar());



                    SqlCommand updateCmd = new SqlCommand("UPDATE Trains SET seats_available = seats_available - @seats_booked WHERE tno = @tno", con);
                    updateCmd.Parameters.AddWithValue("@seats_booked", seatsToBook);
                    updateCmd.Parameters.AddWithValue("@tno", trainNumber);
                    bookCmd.Parameters.AddWithValue("@booking_date", bookingDate);
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
                    Console.WriteLine($"Price per Seat : Rs{pricePerSeat}");
                    Console.WriteLine($"Total Fare     : Rs{totalFare}");
                    Console.WriteLine($"Date For Journey  : {bookingDate}");

                }

                else Console.WriteLine("Train or user not found or Train inactive.");
            }
        }

        internal void CancelTickets()
        {
            Console.Write("Enter Booking ID: ");
            int bookingId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of seats to cancel: ");
            int seatsToCancel = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT userid, tno, seats_booked, booking_date FROM Bookings WHERE booking_id = @booking_id", con);
                checkCmd.Parameters.AddWithValue("@booking_id", bookingId);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.Read())
                {
                    int userId = (int)reader["userid"];
                    int trainNumber = (int)reader["tno"];
                    int seatsBooked = (int)reader["seats_booked"];
                    DateTime bookingDate = (DateTime)reader["booking_date"];
                    reader.Close();

                    if (userId != currentUserId)
                    {
                        Console.WriteLine("You are not authorized to cancel this booking.");
                        return;
                    }

                    if (seatsToCancel > seatsBooked)
                    {
                        Console.WriteLine("Cannot cancel more seats than booked.");
                        return;
                    }

                    TimeSpan timeBeforeTravel = bookingDate - DateTime.Now;
                    decimal refundRate = 0;
                    if (timeBeforeTravel.TotalDays > 90) refundRate = 0.50m;
                    else if (timeBeforeTravel.TotalDays < 30) refundRate = 0.25m;
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
