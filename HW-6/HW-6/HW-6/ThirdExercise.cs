using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    internal class ThirdExercise
    {
        public static void DoThirdExercise()
        {
            using (var context = new Hw3Context())
            {
                var lastYearDate = DateTime.Now.AddYears(-1);

                var orders = context.Orders
                .Where(o => o.OrdDatetime >= lastYearDate)
                .ToList();

                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.OrdId}, Order Date: {order.OrdDatetime}, Analysis ID: {order.OrdAn}");
                }
            }
        }
        
    }
}
