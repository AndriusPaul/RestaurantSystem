using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime CreatedOrderTime { get; set; }

        public Order(int tableId)
        {
            TableId = tableId;
            CreatedOrderTime = DateTime.Now;
        }
    }
}
