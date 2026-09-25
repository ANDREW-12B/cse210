using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Salt Lake City",
            "Utah",
            "USA");

        Customer customer1 = new Customer("John Smith", address1);

        Product product1 = new Product("Laptop", "P100", 800.00, 1);
        Product product2 = new Product("Mouse", "P101", 25.00, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);


        Address address2 = new Address(
            "15 Kampala Road",
            "Kampala",
            "Central",
            "Uganda");

        Customer customer2 = new Customer("Mary Nakato", address2);

        Product product3 = new Product("Keyboard", "P200", 50.00, 1);
        Product product4 = new Product("Headphones", "P201", 75.00, 2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);


        Console.WriteLine("ORDER 1");
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        Console.WriteLine();

        Console.WriteLine("ORDER 2");
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
    }
}