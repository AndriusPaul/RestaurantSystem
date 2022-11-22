using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Classes
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public Table(int id, string name, bool status)
        {
            Id= id;
            Name= name;
            Status= status;
        }
    }
}
