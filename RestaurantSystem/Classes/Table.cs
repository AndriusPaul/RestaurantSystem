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
        public bool IsFree { get; set; }

        public Table(int id, string name, bool isFree)
        {
            Id= id;
            Name= name;
            IsFree= isFree;
        }
    }
}
