using System.Data;
using System.Data.SqlClient;


namespace HW_5
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1)");
            FirstExercise.ForDataReader();
            Console.WriteLine("2)");
            SecondExercise.ForDataSet();
            
        }
    }
}