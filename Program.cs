using System;
public class Product {
    private double price;
    private string ProductCode;
    public string Name;
    public int Stock;
    public double Price
    {
        get { return price; }
        set
        {
            if (value > 0)
                price = value;
            else
            {
                Console.WriteLine("invalid price: " + value);
                price = 1.0;
            }
        }
    }
    public Product(string productCode, string name, double price, int stock)
    {
        ProductCode = productCode;
        Name = name;
        Price = price;
        Stock = stock;
    }
    public void restock(int amount)
    {
        Stock += amount;
    }
    public void Info()
    {
        Console.WriteLine("ProductCode: " + ProductCode + ", Name: " + Name +
                          ", Price: $" + Price.ToString("F2") + ", Stock: " + Stock);
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Product[] products = new Product[4];
        products[0] = new Product("[P101]", "Wireless Mouse", 25.50, 15);
        products[1] = new Product("[P102]", "Mechanical Keyboard", 85.00, 10);
        products[2] = new Product("[P103]", "USB-C Cable", 1.00, 50);
        products[3] = new Product("[P104]", "Gaming Monitor", 220.00, 50);
        Console.WriteLine("Products:");
        for (int i = 0; i < products.Length; i++)
        {
            products[i].Info();
        }
        products[0].restock(5);
        products[1].restock(8);
        Console.WriteLine("\nAfter restocking:");
        products[0].Info();
        products[1].Info();
        double min = products[0].Price;
        double max = products[0].Price;
        double total = 0;
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].Price < min) min = products[i].Price;
            if (products[i].Price > max) max = products[i].Price;
            total += products[i].Price;
        }
        double avg = total / products.Length;

        Console.WriteLine("\nMinimum Price: " + min.ToString("F2"));
        Console.WriteLine("Maximum Price: " + max.ToString("F2"));
        Console.WriteLine("Average Price: " + avg.ToString("F2"));
        Console.WriteLine("\nProducts >= $50:");
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].Price >= 50)
                products[i].Info();
        }
        double[] prices = new double[products.Length];
        for (int i = 0; i < products.Length; i++)
        {
            prices[i] = products[i].Price;
        }
        for (int i = 0; i < prices.Length - 1; i++)
        {
            for (int j = 0; j < prices.Length - 1 - i; j++)
            {
                if (prices[j] > prices[j + 1])
                {
                    double temp = prices[j];
                    prices[j] = prices[j + 1];
                    prices[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("\n Sorted Prices:");
        int index = -1;
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].Price == 85)
            {
                index = i;
                break;
            }
        }
        Console.WriteLine("\nSearch:");
        if (index != -1)
        {
            Console.WriteLine("Found: 85 at index " + index);
        }
        else
            Console.WriteLine("Not found");
    }
}