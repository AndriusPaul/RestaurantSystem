using RestaurantSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Repositories
{
    public class OrderRepository
    {
        List<Order> orders { get; set; }
        public OrderRepository()
        {
            orders = new List<Order>();
        }
    }
}
