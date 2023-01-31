using RestaurantSystem.Entity;
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
            ReportGenerator reportGenerator = new ReportGenerator(orderRepository);


            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("Welcome to Restaurant System");
                Console.WriteLine("1. Check tables status");
                Console.WriteLine("2. Change table status (Free/Not Free)");
                Console.WriteLine("3. Make Order");
                Console.WriteLine("4. Print all orders");
                Console.WriteLine("5. Checkout");
                Console.WriteLine("0. Finish");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {


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
                            tableRepository.Read();

                            if (tableRepository.GetTableStatus() == false)
                            {
                                Console.WriteLine("No free tables at the moment");
                                break;
                            }
                            else
                            {

                                Console.WriteLine("Laisvi staliukai");
                                tableRepository.GetFreeTables();
                                Console.Write("Enter table number: ");

                                int tableNumber;
                                if (int.TryParse(Console.ReadLine(), out tableNumber))
                                {
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
                                        int itemType;
                                        if (int.TryParse(Console.ReadLine(), out itemType))
                                        {
                                            if (itemType == 1)
                                            {

                                                Console.WriteLine("Food items:");
                                                foodRepository.ReadJSON();
                                                Console.WriteLine("Enter the number of the food item to add to the order:");
                                                int foodChoice;
                                                if (int.TryParse(Console.ReadLine(), out foodChoice))
                                                {
                                                    Food selectedFood = foodRepository.RetrieveById(foodChoice);
                                                    if (selectedFood != null)
                                                    {
                                                        currentOrder.Add(selectedFood);
                                                        Console.WriteLine("Added " + selectedFood.Name + " to the order.");


                                                        Console.Clear();

                                                        currentOrder.ShowCurrentOrder();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Food not found.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input, Food ID must be a number.");
                                                }

                                            }
                                            else if (itemType == 2)
                                            {
                                                Console.WriteLine("Drink items: ");
                                                drinkRepository.ReadJSON();
                                                Console.WriteLine("Enter the number of the drink item to add to the order:");
                                                int drinkChoice;
                                                if (int.TryParse(Console.ReadLine(), out drinkChoice))
                                                {
                                                    Drink selectedDrink = drinkRepository.RetrieveById(drinkChoice);
                                                    if (selectedDrink != null)
                                                    {
                                                        currentOrder.Add(selectedDrink);
                                                        Console.WriteLine("Added " + selectedDrink.Name + " to the order.");

                                                        Console.Clear();

                                                        currentOrder.ShowCurrentOrder();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Drink not found.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input, Drink ID must be a number.");
                                                }
                                            }
                                            else if (itemType == 3)
                                            {
                                                Order order = new Order(currentOrder.SelectedTableId, currentOrder.Order.Items);
                                                orderRepository.AddOrder(order);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Select number from list");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input");
                                        }
                                    }
                                }
                            }
                            break;

                        case 4:
                            orderRepository.ShowAllOrders();
                            break;

                        case 5:
                            if (orderRepository.GetOrders().Count() != 0)
                            {

                                foreach (var item in orderRepository.GetOrders())
                                {
                                    Console.WriteLine($"Order ID: {item.OrderId}, Table ID: {item.TableId} - Date: {item.OrderDate} Total: {item.GetTotalCost()}");

                                }


                                int orderId;
                                Console.WriteLine("Select Order ID to Checkout");


                                if (int.TryParse(Console.ReadLine(), out orderId))
                                {
                                    Order order = orderRepository.GetByOrderId(orderId);
                                    if (order != null)
                                    {


                                        reportGenerator.SendReceipt(orderId);
                                        var tableId = orderRepository.GetTableIdByOrderId(orderId);
                                        var retrievedTableId = tableRepository.Retrieve(tableId);
                                        retrievedTableId.IsFree = true;
                                        tableRepository.CreateJSON();
                                        orderRepository.CheckoutOrder(orderId);


                                    }
                                    else
                                    {
                                        Console.WriteLine("Order ID not found.");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, order ID must be a number.");
                                }


                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("There are no active orders");
                                break;
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
                else
                {
                    Console.WriteLine("Wrong input. Select from menu.");
                }

                void ChangeTableStatus()
                {
                    TableSelect tableSelect = new TableSelect();
                    tableSelect.Selection();
                    Console.Clear();
                }
            }
        }
    }
}
