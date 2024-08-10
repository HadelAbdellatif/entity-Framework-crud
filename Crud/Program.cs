using Crud.Models;
using System.Net.Sockets;
using System.Net;
using Crud.Data;

namespace Crud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            // Add data into order table
            Order order_1 = new Order() {
                Address = "Jerusalem",
                CreatedAt = DateTime.Now
            };

            context.orders.Add(order_1);
            context.SaveChanges();

            Order order_2 = new Order()
            {
                Address = "Ramallah",
                CreatedAt = DateTime.Now
            };

            context.orders.Add(order_2);
            context.SaveChanges();

            Order order_3 = new Order()
            {
                Address = "Jenin",
                CreatedAt = DateTime.Now
            };

            context.orders.Add(order_3);
            context.SaveChanges();

            // Add data into product table

            Product product_1 = new Product()
            {
                Name = "iPhone",
                Price = 4999.99
            };

            Product product_2 = new Product()
            {
                Name = "iPad",
                Price = 3499.99
            };
            Product product_3 = new Product()
            {
                Name = "Laptop",
                Price = 6999.99
            };
            context.products.Add(product_1);
            context.products.Add(product_2);
            context.products.Add(product_3);
            context.SaveChanges();


            // Get all Orders
            var allOrders = context.orders.ToList();
            Console.WriteLine("---- ORDERS ----");
            foreach (var order in allOrders)
            {
                Console.WriteLine($"    - {order.Id}: {order.Address}, {order.CreatedAt}");
            }

            // Get all Products
            var allProducts = context.products.ToList();
            Console.WriteLine("---- PRODUCTS ----");
            foreach (var product in allProducts)
            {
                Console.WriteLine($"    - {product.Id}: {product.Name}, {product.Price}");
            }

            // Updata product name
            Product updatedProduct = context.products.Where(prod => prod.Id == 1).First();
            updatedProduct.Name = "New Name";
            context.SaveChanges();

            // Updata order created date
            Order updatedOrder = context.orders.Where(ord => ord.Id == 1).First();
            updatedOrder.CreatedAt = DateTime.Now;
            context.SaveChanges();

            // remove product with id 2
            Product deletedProduct = context.products.Where(prod => prod.Id == 2).First();
            context.products.Remove(deletedProduct);
            context.SaveChanges();

            // remove order with id 3
            Order deletedOrder = context.orders.Where(ord => ord.Id == 3).First();
            context.orders.Remove(deletedOrder);
            context.SaveChanges();
        }
    }
}
