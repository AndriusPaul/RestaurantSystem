using RestaurantSystem.Classes;
using RestaurantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Entity
{
    public class Order
    {
        private static int orderIdCounter = 1;
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order(int tableId)
        {
            TableId = tableId;

        }
        public Order(int tableId, List<OrderItem> items)
        {
            OrderId = orderIdCounter;
            orderIdCounter++;
            TableId = tableId;
            OrderDate = DateTime.Now;
            Items = items;

        }
        public decimal GetTotalCost()
        {
            decimal totalCost = 0;
            foreach (var item in Items)
            {
                totalCost += item.Price;

            }
            return totalCost;
        }

    }
}
