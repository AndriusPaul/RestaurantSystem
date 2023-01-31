using RestaurantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Classes
{
    public class TableSelect
    {
        public void Selection()
        {
            var tables = new TableRepository();
            tables.ReadJSON();



            Console.WriteLine("Pakeisti staliuko statusa:");
            Console.WriteLine("Noredami grizti atgal paspauskite mygtuka - 0 ");
            Console.WriteLine("Select table:");
            var select = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    SelectTablesbyId();
                    break;
                case 2:
                    SelectTablesbyId();
                    break;
                case 3:
                    SelectTablesbyId();
                    break;
                case 4:
                    SelectTablesbyId();
                    break;
                    case 0:
                    break;
                default:
                    Console.WriteLine($"There are only {tables} tables");
                    break;
            }

            void SelectTablesbyId()
            {
                Console.WriteLine($"You selected: {tables.Retrieve(select).Id}. {tables.Retrieve(select).Name}, status: {tables.Retrieve(select).IsFree}");
                Console.WriteLine("Do you want to change status ? Press 1 to change status");
                int select2 = int.Parse(Console.ReadLine());
                if (select2 == 1)
                {
                    if (tables.Retrieve(select).IsFree == true)
                    {
                        tables.Retrieve(select).IsFree = false;
                    }
                    else
                    {
                        tables.Retrieve(select).IsFree = true;
                    }

                    tables.CreateJSON();
                    Console.WriteLine($"Table status changed to {tables.Retrieve(select).IsFree}");

                }
            }
        }
    }
}
