
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSystem.Classes;

namespace RestaurantSystem.Entity
{
    public class Food : OrderItem
    {
        public int Id { get; set; }
        public Food(string name, decimal price) : base(name, price)
        {

        }

    }
}
