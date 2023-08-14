using Restaurante.Entities;
using Restaurante.Enums;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Client Data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY)");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Enter Order Data: ");
            Console.Write("Status: ");
            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            Console.WriteLine("-------------------------------------");
            Console.Write("How many items to this order?");
            int n = int.Parse(Console.ReadLine());


            Client client = new Client(name,email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter #{n} item data:");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine());

                Product product = new Product(prodName, price);


                Console.Write("Quantity: ");
                int qtdProd = int.Parse(Console.ReadLine());

                
                OrderItem item = new OrderItem(qtdProd, product);

                order.addItem(item);
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
        }
    }
}