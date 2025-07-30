using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ADOCC1
{
    class Question2
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main()
        {
            Insert_into_proc();
            ShowAll();
            Console.ReadLine();

        }
        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-D72BJ84\\SQLEXPRESS;Initial Catalog=CodeChallenge;" +
                "user id=sa;password=Manohar@2004; ");
            con.Open();
            return con;
        }

        static void Insert_into_proc()
        {
            try
            {
                con = getConnection();

                Console.WriteLine("Enter empid");
                int empid = int.Parse(Console.ReadLine());

                cmd = new SqlCommand("update_salary_by_100", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empid", empid);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("Rows updated successfully");
                }
                else
                {
                    Console.WriteLine("No rows updated");
                }

            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }



        }

        static void ShowAll()
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
                            Console.Write(dr[i] + "  ");
                        }

                        Console.WriteLine();
                    }

                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        

    }
}
