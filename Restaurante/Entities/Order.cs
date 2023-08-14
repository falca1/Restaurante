using Restaurante.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace Restaurante.Entities
{
    internal class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus status { get; set; }
        Client client { get; set; }
        List<OrderItem> orderItems { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime date, OrderStatus status, Client client)
        {
            Date = date;
            this.status = status;
            this.client = client;
        }

        public void addItem (OrderItem item)
        {
            orderItems.Add(item);
        }
        public void removeItem (OrderItem item)
        {
            orderItems.Remove(item);
        }

        public double total()
        {
            double sum = 0;
            foreach (OrderItem item in orderItems)
            {
                sum += item.subTotal();
            }
            return sum;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Date.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + status);
            sb.AppendLine("Client: " + client.name);
            sb.AppendLine("Order items:");
            foreach (OrderItem item in orderItems)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: $" + total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
