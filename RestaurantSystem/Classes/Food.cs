
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Classes
{
     public class Food : OrderItem
    {
        public int Id { get; set; }
        public Food( string name, decimal price) : base(name,price)
        {
          
        }

    }
}
