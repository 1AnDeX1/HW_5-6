using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    internal class FifthExercise
    {
        public static void DoFifthExercise()
        {
            using (var context = new Hw3Context())
            {
                
                var orderToUpdate = context.Orders.FirstOrDefault(o => o.OrdId == 1);

                if (orderToUpdate != null)
                {
                    
                    orderToUpdate.OrdDatetime = DateTime.Now;
                    orderToUpdate.OrdAn = 2;

                    context.SaveChanges();
                }
            }
        }
    }
}
