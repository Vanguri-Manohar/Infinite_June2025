using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADOCC1
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {

            insert_to_Proc();
            Console.WriteLine("************************");
            Show_Emp();
            Console.ReadLine();
        }

        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-D72BJ84\\SQLEXPRESS;Initial Catalog=CodeChallenge;" +
                "user id=sa;password=Manohar@2004; ");
            con.Open();
            return con;
        }

        static void insert_to_Proc()
        {
            try
            {
                con = getConnection();

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Salary: ");
                int salary = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Gender: ");
                string gender = Console.ReadLine();

                cmd = new SqlCommand("insert_employee", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@gender", gender);

                dr = cmd.ExecuteReader();

                Console.WriteLine("Employee Added Successfully");
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1]);
                      
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void Show_Emp()
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("select * from Employee_Details", con);

                dr = cmd.ExecuteReader();

                Console.WriteLine("Empid   Name    Salary     Cal_Salary   Gender");

                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.Write(dr[i]+ "  ");
                    }

                    Console.WriteLine();
                }

            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
