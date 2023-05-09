using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    internal class FirstExercise
    {
        public static void ForDataReader() 
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string queryString = "SELECT * FROM Orders WHERE ord_datetime >= @LastYear";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@LastYear", DateTime.Now.AddYears(-1));
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    Console.WriteLine("{0} \t {1}\t\t {2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t {1}\t {2}", reader["ord_id"], reader["ord_datetime"], reader["ord_an"]);
                    }
                }

            }
        }
        
    }
}
