using System.Collections.Generic;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:";

        foreach (Product product in _products)
        {
            label += $"\n{product.GetName()} - {product.GetProductId()}";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:";
        label += $"\n{_customer.GetName()}";
        label += $"\n{_customer.GetAddress().GetAddress()}";

        return label;
    }
}