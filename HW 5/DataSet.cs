using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HW_5
{
    internal class SecondExercise
    {
        public static void ForDataSet()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string queryString = "SELECT * FROM Orders WHERE ord_datetime >= @LastYear";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@LastYear", DateTime.Now.AddYears(-1));

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Orders");

                foreach (DataTable dt in dataSet.Tables)
                {
                    foreach (DataColumn column in dt.Columns)
                        Console.Write($"{column.ColumnName}  \t");
                    Console.WriteLine();
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        
                        var cells = row.ItemArray;
                        foreach (object cell in cells)
                            Console.Write($"{cell}\t");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
