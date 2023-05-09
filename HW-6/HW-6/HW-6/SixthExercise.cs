using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    internal class SixthExercise
    {
        public static void DoSixthExercise()
        {
            using (var context = new Hw3Context())
            {
                
                var orderToDelete = context.Orders.FirstOrDefault(o => o.OrdId == 25);

                if (orderToDelete != null)
                {
                    
                    context.Orders.Remove(orderToDelete);

                    
                    context.SaveChanges();
                }
            }

        }
    }
}
