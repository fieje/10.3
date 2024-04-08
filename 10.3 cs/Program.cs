using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    static void Main()
    {
        string filePath = "products.txt";
        List<Product> productList = new List<Product>();

        ReadProductsFromFile(filePath, productList);

        Console.WriteLine("Available products:");
        DisplayProducts(productList);

        Console.WriteLine("Enter the product name for searching:");
        string productName = Console.ReadLine();

        Product foundProduct = FindProductByName(productList, productName);

        if (foundProduct != null)
        {
            Console.WriteLine($"Information about the product '{productName}':");
            Console.WriteLine(foundProduct);
        }
        else
        {
            Console.WriteLine($"Product with the name '{productName}' not found.");
        }

        Console.ReadLine(); 
    }

    public class Product
    {
        public string Name { get; set; }
        public string Store { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Store: {Store}, Price: {Price} UAH";
        }
    }

    public static void ReadProductsFromFile(string filePath, List<Product> productList)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                Console.WriteLine(line); 
                                         
            }


            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 3)
                {
                    string name = parts[0].Trim();
                    string store = parts[1].Trim();
                    double price = double.Parse(parts[2].Trim());
                    productList.Add(new Product { Name = name, Store = store, Price = price });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public static void DisplayProducts(List<Product> productList)
    {
        foreach (Product product in productList)
        {
            Console.WriteLine(product);
        }
    }

    public static Product FindProductByName(List<Product> productList, string productName)
    {
        foreach (Product product in productList)
        {
            if (product.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
            {
                return product;
            }
        }
        return null;
    }
}
