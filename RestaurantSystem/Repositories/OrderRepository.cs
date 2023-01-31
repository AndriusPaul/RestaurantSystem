using RestaurantSystem.Classes;
using RestaurantSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Repositories
{
    public class OrderRepository
    {
        public static int NextOrderId = 1;
        public List<Order> Orders;
        public OrderRepository()
        {
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public List<Order> GetOrders()
        {
            return Orders;
        }
        public void CheckoutOrder(int order)
        {

            var orderIndex = Orders.FindIndex(o => o.OrderId == order);
            if (orderIndex != -1)
            {

                Console.WriteLine("Do you need recipet? 1 - yes, 2 - no");
                int choise = int.Parse(Console.ReadLine());
                if (choise == 1)
                {
                    var test = GetByOrderId(order);
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Thank you for comming");
                    Console.WriteLine("        Receipt");
                    Console.WriteLine($"Date: {test.OrderDate}");
                    Console.WriteLine("Items:");
                    foreach (var item in test.Items)
                    {
                        Console.WriteLine($"{item.Name} - {item.Price}");
                    }
                    Console.WriteLine("-------------");
                    Console.WriteLine($"Total: {test.GetTotalCost()}");
                    Console.WriteLine("---------------------------");

                    Orders.RemoveAt(orderIndex);
                    Console.WriteLine("Succesfully checkout.");
                }
                else
                {
                    Orders.RemoveAt(orderIndex);
                    Console.WriteLine("Succesfully checkout.");
                }
            }
            else
            {
                Console.WriteLine("Order not found");
            }
            Console.WriteLine("To continue press 'Enter'");
            Console.ReadKey();
        }
        public int GetNextOrderId()
        {
            int NextOrderId = 1;
            if (Orders.Count > 0)
            {
                NextOrderId = Orders.Max(o => o.OrderId) + 1;
            }
            return NextOrderId;
        }

        public void ShowAllOrders()
        {
            if (Orders.Count() == 0)
            {
                Console.WriteLine("Orders are empty.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("List of all orders:");
                foreach (Order order in Orders)
                {
                    Console.WriteLine("Order ID: " + order.OrderId);
                    Console.WriteLine("Table ID: " + order.TableId);
                    Console.WriteLine("Date: " + order.OrderDate);
                    Console.WriteLine("Order Items:");

                    foreach (OrderItem item in order.Items)
                    {

                        Console.WriteLine($"{item.Name} - {item.Price}");

                    }
                    Console.WriteLine("Total Price: " + order.GetTotalCost());
                    Console.WriteLine("---------------------------");
                }
            }
        }

        public Order GetByOrderId(int orderId)
        {

            return Orders.FirstOrDefault(x => x.OrderId == orderId);

        }
        public int GetTableIdByOrderId(int orderId)
        {
            var order = Orders.FirstOrDefault(x => x.OrderId == orderId);
            if(order != null)
            {
                return order.TableId;
            }
            return 0;
        }

    }
}

