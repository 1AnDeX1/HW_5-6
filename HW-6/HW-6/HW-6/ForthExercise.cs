using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    internal class ForthExercise
    {
        public static void DoForthExercise()
        {
            using (var context = new Hw3Context())
            {
                Order order = new Order
                {
                    OrdDatetime = DateTime.Now,
                    OrdAn = 5,
                };

                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
