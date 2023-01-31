
using RestaurantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Classes
{
    public class CurrentOrder 
    {

        public Order Order { get; set; }
        public int SelectedTableId { get; set; }

 
        public CurrentOrder(int tableId)
        {
            this.SelectedTableId = tableId;
            this.Order = new Order(tableId);
        }
        public void Add(OrderItem item)
        {
           
            this.Order.Items.Add(item);
        }

        public void ShowCurrentOrder()
        {
            Console.WriteLine("Current Order:");
            Console.WriteLine("Table ID: " + SelectedTableId);
            Console.WriteLine("Items: ");
            foreach (var item in Order.Items)
            {
                
                Console.WriteLine("\t" + item.Name + " (x" + item.Price + ")");
            }
            Console.WriteLine("Total: " + Order.GetTotalCost());
        }
    }
}
