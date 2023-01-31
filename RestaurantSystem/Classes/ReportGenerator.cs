using RestaurantSystem.Entity;
using RestaurantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Classes
{
    public class ReportGenerator
    {
        public OrderRepository _orderRepository;

        public ReportGenerator(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void SendReceipt(int orderId)
        {
            Order order = _orderRepository.Orders.Find(x => x.OrderId == orderId);
            if (order != null)
            {
                Console.WriteLine("Are you want to send Receipt to email ? 1 - yes, 2 - no");

               int choise = int.Parse(Console.ReadLine());

                if (choise == 1)
                {
                    MailAddress to = new MailAddress("from@example.com");
                    MailAddress from = new MailAddress("to@example.com");
                    MailMessage message = new MailMessage(from, to);
                    message.Subject = "Receipt for Order #" + order.OrderId;
                    message.Body = "        Receipt" + "\n" + "Table: " + order.TableId + "\n" + "Date: " + order.OrderDate + "\n" + "\n\nItems:\n";
                    foreach (OrderItem item in order.Items)
                    {
                        message.Body += item.Name + " @ " + item.Price + "Eur" + "\n" + "-------------" + "\n";
                    }
                    message.Body += "\nTotal: $" + order.GetTotalCost() + "\n" + "---------------------------" + "\n\nThank you for your visit!";

                    SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
                    {
                        Credentials = new NetworkCredential("7e71012932f43c", "2da6940405fbed"),
                        EnableSsl = true
                    };
                    try
                    {
                        client.Send(message);
                    }
                    catch (SmtpException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    Console.WriteLine("Email sent to " + to);
     
                }
                               
            }
           
        }
    }
    }
