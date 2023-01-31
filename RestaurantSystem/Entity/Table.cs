using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Entity
{

    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFree { get; set; }
        public int Seats { get; set; }

        public Table()
        {

        }
        public Table(int id, int seats)
        {
            Id = id;
            IsFree = true;
            Seats = seats;
        }
    }
}
