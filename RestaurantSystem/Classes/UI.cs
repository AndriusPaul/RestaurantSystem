using RestaurantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Classes
{
    public class UI
    {
        public void Start()
        {
            FoodRepository foodRepository = new FoodRepository();
            DrinkRepository drinkRepository = new DrinkRepository();
            TableRepository tableRepository = new TableRepository();
            OrderRepository orderRepository = new OrderRepository();



            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("Welcome to Restaurant System");
                Console.WriteLine("1. Patikrinti staliuku uzimtuma");
                Console.WriteLine("2. Pakeisti staliuko statusa (Uzimta/Neuzimta)");
                Console.WriteLine("3. Pradeti uzsakyma");
                Console.WriteLine("4. Perziureti visus uzsakymus");
                Console.WriteLine("5. Checkout by Order ID");
                Console.WriteLine("0. Baigti programa.");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Staliuku uzimtumas");
                        tableRepository.ReadJSON();
                        break;
                    case 2:
                        ChangeTableStatus();
                        break;
                    case 3:
                        Console.WriteLine("Laisvi staliukai");
                        tableRepository.GetFreeTables();

                        Console.Write("Enter table number: ");

                        int tableNumber = int.Parse(Console.ReadLine());
                        var selectedTable = tableRepository.Retrieve(tableNumber);
                        Console.WriteLine(selectedTable.Id);

                        var retrievedTable = tableRepository.Retrieve(tableNumber);
                         retrievedTable.IsFree = false;
                         tableRepository.CreateJSON();

                        var currentOrder = new CurrentOrder(tableNumber);
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("1. Food");
                            Console.WriteLine("2. Drink");
                            Console.WriteLine("3. Done");
                            Console.WriteLine("Enter number:");
                            int itemType = int.Parse(Console.ReadLine());
                            if (itemType == 1)
                            {

                                Console.WriteLine("Food items:");
                                foodRepository.ReadJSON();
                                Console.WriteLine("Enter the number of the food item to add to the order:");
                                int foodChoice = int.Parse(Console.ReadLine());
                                Food selectedFood = foodRepository.GetFoods()[foodChoice - 1];
                                currentOrder.Add(selectedFood);
                                Console.WriteLine("Added " + selectedFood.Name + " to the order.");


                                Console.Clear();

                                currentOrder.ShowCurrentOrder();



                            }
                            else if (itemType == 2)
                            {
                                Console.WriteLine("Drink items: ");
                                drinkRepository.ReadJSON();
                                Console.WriteLine("Enter the number of the drink item to add to the order:");
                                int drinkChoice = int.Parse(Console.ReadLine());
                                Drink selectedDrink = drinkRepository.GetDrinks()[drinkChoice - 1];
                                currentOrder.Add(selectedDrink);
                                Console.WriteLine("Added " + selectedDrink.Name + " to the order.");

                                Console.Clear();

                                currentOrder.ShowCurrentOrder();

                            }
                            else if (itemType == 3)
                            {
                                Order order = new Order(currentOrder.SelectedTableId, currentOrder.Order.Items);
                                orderRepository.AddOrder(order);
                                break;
                            };
                        }

                        break;

                    case 4:
                        orderRepository.ShowAllOrders();
                        break;

                    case 5:
                        if(orderRepository.GetOrders().Count() != 0) { 
                        foreach (var item in orderRepository.GetOrders())
                        {
                            Console.WriteLine($"Order ID: {item.OrderId}, Table ID: {item.TableId} - Date: {item.OrderDate}");
                        }
                        Console.WriteLine("Select Order ID to Checkout");
                        int choiseToCheckout = int.Parse(Console.ReadLine());
                        orderRepository.CheckoutOrder(choiseToCheckout);
                         
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("There are no active orders");
                            Console.WriteLine("To continue please press 'Enter'");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Pasirinkite is duoto meniu!");
                        break;
                }
            }

            void ChangeTableStatus()
            {
                TableSelect tableSelect = new TableSelect();
                tableSelect.Selection();
                Console.Clear();
            }

            void DisplayOrders(List<Order> orders)
            {
                Console.WriteLine("List of all orders");
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.OrderId} - Date: {order.OrderDate} - Table ID: {order.TableId} - Total Cost: {order.GetTotalCost()}");
                    Console.WriteLine("Items: ");
                    foreach (var item in order.Items)
                    {
                        Console.WriteLine($"- {item.Name}, {item.Price}");
                    }

                    Console.WriteLine();
                }
            }

        }
    }
}
