using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    internal class OrderItem
    {
        public int quantity { get; set; }
        public double price { get; set; }

        Product product { get; set; }

        public OrderItem() { }

        public OrderItem(int quantity, Product product)
        {
            this.quantity = quantity;
            
            this.product = product;

            this.price = product.price;
        }

        public double subTotal()
        {
            
            return quantity * price;
        }


        public override string ToString()
        {
            return product.name
            + ", $"
                + price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantity: "
                + quantity
                + ", Subtotal: $"
                + subTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
