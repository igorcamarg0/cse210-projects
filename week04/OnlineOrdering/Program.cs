using System;
using System.Collections.Generic;

namespace ProductOrderingSystem
{
    // Address class
    public class Address
    {
        private string streetAddress;
        private string city;
        private string state;
        private string country;

        public Address(string streetAddress, string city, string state, string country)
        {
            this.streetAddress = streetAddress;
            this.city = city;
            this.state = state;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return country.ToLower() == "usa";
        }

        public string GetFullAddress()
        {
            return $"{streetAddress}\n{city}, {state}\n{country}";
        }
    }

    // Customer class
    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }

        public bool LivesInUSA()
        {
            return address.IsInUSA();
        }
    }

    // Product class
    public class Product
    {
        private string name;
        private string productId;
        private decimal price;
        private int quantity;

        public Product(string name, string productId, decimal price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public string GetName()
        {
            return name;
        }

        public string GetProductId()
        {
            return productId;
        }

        public decimal GetTotalCost()
        {
            return price * quantity;
        }
    }

    // Order class
    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;

            foreach (var product in products)
            {
                totalCost += product.GetTotalCost();
            }

            // Add shipping cost
            totalCost += customer.LivesInUSA() ? 5 : 35;

            return totalCost;
        }

        public string GetPackingLabel()
        {
            string packingLabel = "Packing Label:\n";
            foreach (var product in products)
            {
                packingLabel += $"{product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return packingLabel;
        }

        public string GetShippingLabel()
        {
            string shippingLabel = "Shipping Label:\n";
            shippingLabel += $"{customer.GetName()}\n";
            shippingLabel += customer.GetAddress().GetFullAddress();
            return shippingLabel;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address address1 = new Address("123 Apple St", "New York", "NY", "USA");
            Address address2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);

            // Create products
            Product product1 = new Product("Laptop", "P001", 999.99m, 1);
            Product product2 = new Product("Mouse", "P002", 25.99m, 2);
            Product product3 = new Product("Keyboard", "P003", 49.99m, 1);
            Product product4 = new Product("Monitor", "P004", 199.99m, 1);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            // Display order details
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}\n");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}");
        }
    }
}